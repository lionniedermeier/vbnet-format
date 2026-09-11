using System.Buffers;
using System.Collections.Immutable;
using System.Runtime.InteropServices;

namespace VisualBasicFormatter.Printing;

internal ref struct DocListBuilder
{
    private Doc[] _items;
    private int _count;

    public DocListBuilder(int capacity)
    {
        _items = capacity > 0 ? ArrayPool<Doc>.Shared.Rent(capacity) : [];
        _count = 0;
    }

    public int Count => _count;

    public Doc this[int index] => _items[index];

    public void Add(Doc doc)
    {
        if (doc is DocNothing)
        {
            return;
        }

        if (_count == _items.Length)
        {
            Grow();
        }

        _items[_count++] = doc;
    }

    public ImmutableArray<Doc> ToImmutable()
    {
        var result = new Doc[_count];
        Array.Copy(_items, result, _count);
        return ImmutableCollectionsMarshal.AsImmutableArray(result);
    }

    public Doc ToDoc() =>
        _count switch
        {
            0 => Doc.Nothing,
            1 => _items[0],
            _ => new DocConcat(ToImmutable()),
        };

    public void Dispose()
    {
        if (_items.Length > 0)
        {
            ArrayPool<Doc>.Shared.Return(_items, clearArray: true);
        }

        _items = [];
        _count = 0;
    }

    private void Grow()
    {
        var next = ArrayPool<Doc>.Shared.Rent(_count == 0 ? 4 : _count * 2);
        Array.Copy(_items, next, _count);
        ArrayPool<Doc>.Shared.Return(_items, clearArray: true);
        _items = next;
    }
}
