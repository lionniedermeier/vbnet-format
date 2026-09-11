Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Contoso.Generated

    Public Class Widget0
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget1
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget2
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget3
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget4
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget5
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget6
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget7
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget8
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget9
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget10
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget11
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget12
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget13
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget14
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget15
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget16
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget17
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget18
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget19
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget20
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget21
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget22
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

    Public Class Widget23
        Inherits WidgetBase

        Private ReadOnly _items As New List(Of String)()
        Private _count As Integer

        Public Function Compute0(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 1 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 0 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute1(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 2 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 1 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute2(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 3 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 2 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute3(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 4 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 3 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute4(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 5 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 4 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute5(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 6 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 5 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute6(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 7 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 6 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

        Public Function Compute7(ByVal seed As Integer, ByVal label As String) As Integer
            Dim total = seed * 8 + _count
            For index = 0 To seed
                If index Mod 2 = 0 AndAlso index > 7 Then
                    total += _items.Where(Function(x) x.Length > index).Select(Function(x) x.Length).Sum()
                ElseIf index Mod 3 = 0 Then
                    total -= CInt(Math.Floor(index / 2.0))
                Else
                    total += index
                End If
            Next

            Return total + label.Length
        End Function

    End Class

End Namespace
