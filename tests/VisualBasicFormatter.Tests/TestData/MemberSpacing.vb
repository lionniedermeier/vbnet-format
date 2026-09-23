Namespace Tracker.Core
    Public Class FlowConductor
        Inherits SimpleConductor
        Implements IConductor
        Private _count As Integer
        Private _current As Diagnostic
        Private _position As Integer

        ''' <summary>
        ''' An xml doccomment
        ''' </summary>
        Public Property Some As String

        ''' <summary>
        ''' An xml doccomment
        ''' </summary>
        Public Property Other As String
        Public Sub New()
        End Sub

        ''' <summary>
        ''' An xml doccomment
        ''' </summary>
        Public Function DoSomething() As String
        End Function
    End Class
End Namespace

Namespace Tracker.Single
    Public Class OnlyMember
        Public Sub Run()
        End Sub
    End Class
End Namespace

Namespace Tracker.Empty
End Namespace

Public Class NoBase
    Private _value As Integer
End Class

Public Class OnlyInherits
    Inherits SimpleConductor
End Class

Public Interface IWorker
    Sub Run()
    Function Compute() As Integer
    Property Total As Integer
    Event Done As EventHandler
End Interface

Public MustInherit Class WorkerBase
    Public MustOverride Sub Run()
    Public MustOverride Function Compute() As Integer
End Class

Public Class WithNested
    Public Enum Status
        Active
        Inactive
    End Enum

    Public Class Nested
        Public Sub Run()
        End Sub
    End Class
End Class

Public Class WithRegion
    Private _a As Integer

    #Region "Helpers"
    Private _b As Integer
    #End Region

    ' A plain comment above a method.
    Public Sub Run()
    End Sub
End Class

Public Class First
    Private _a As Integer
End Class

Public Class Second
    Private _b As Integer
End Class
