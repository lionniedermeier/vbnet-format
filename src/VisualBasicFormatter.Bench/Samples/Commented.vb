Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Contoso.Generated

    ''' <summary>
    ''' Widget number 0 in the generated sample set.
    ''' </summary>
    Public Class Widget0
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 1 in the generated sample set.
    ''' </summary>
    Public Class Widget1
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 2 in the generated sample set.
    ''' </summary>
    Public Class Widget2
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 3 in the generated sample set.
    ''' </summary>
    Public Class Widget3
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 4 in the generated sample set.
    ''' </summary>
    Public Class Widget4
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 5 in the generated sample set.
    ''' </summary>
    Public Class Widget5
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 6 in the generated sample set.
    ''' </summary>
    Public Class Widget6
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 7 in the generated sample set.
    ''' </summary>
    Public Class Widget7
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 8 in the generated sample set.
    ''' </summary>
    Public Class Widget8
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 9 in the generated sample set.
    ''' </summary>
    Public Class Widget9
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 10 in the generated sample set.
    ''' </summary>
    Public Class Widget10
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 11 in the generated sample set.
    ''' </summary>
    Public Class Widget11
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 12 in the generated sample set.
    ''' </summary>
    Public Class Widget12
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 13 in the generated sample set.
    ''' </summary>
    Public Class Widget13
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 14 in the generated sample set.
    ''' </summary>
    Public Class Widget14
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 15 in the generated sample set.
    ''' </summary>
    Public Class Widget15
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 16 in the generated sample set.
    ''' </summary>
    Public Class Widget16
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 17 in the generated sample set.
    ''' </summary>
    Public Class Widget17
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 18 in the generated sample set.
    ''' </summary>
    Public Class Widget18
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 19 in the generated sample set.
    ''' </summary>
    Public Class Widget19
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 20 in the generated sample set.
    ''' </summary>
    Public Class Widget20
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 21 in the generated sample set.
    ''' </summary>
    Public Class Widget21
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 22 in the generated sample set.
    ''' </summary>
    Public Class Widget22
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

    ''' <summary>
    ''' Widget number 23 in the generated sample set.
    ''' </summary>
    Public Class Widget23
        Inherits WidgetBase

        ' Backing store for the items this widget tracks.
        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer ' running total seed

        ''' <summary>
        ''' Computes derived total 0 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 1 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 2 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 3 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 4 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 5 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 6 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

        ''' <summary>
        ''' Computes derived total 7 for this widget.
        ''' </summary>
        ''' <param name="seed">The seed value.</param>
        ''' <param name="label">A label whose length contributes to the result.</param>
        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count ' start from the seed
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    ' Even indices past the threshold accumulate matching lengths.
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0)) ' back off every third index
                Else
                    total += index
                End If
            Next

            Return total + label.Length ' fold the label length in
        End Function

    End Class

End Namespace
