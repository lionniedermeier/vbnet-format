Public Class SingleLineLambdas

    Public Sub BreaksAtTheCommaThenTheDot()
        AddHandler btn.Click, Sub(s, e) CollectionTypeStuff_____________________________________________________().Where(Function(a) a.hasProp)
    End Sub

    Public Sub KeepsAShortHandlerOnOneLine()
        RemoveHandler btn.Click, Sub(s, e) Work()
    End Sub

    Public Sub BreaksAtTheCommaForANonLambdaDelegateToo()
        AddHandler btn.Click, AddressOf SomeVeryLongHandlerNameThatGoesOnAndOnAndOnForeverAndEverAndEverMoreAndMoreStillXX
    End Sub

    Public Sub HugsALongSingleLineLambdaArgument()
        Register(paramAlpha, Sub(s, e) CollectionTypeStuff_________________________________________().Where(Function(a) a.hasProp))
    End Sub

    Public Sub KeepsTheDotFlatWhenTheArgumentListCanWrapInstead()
        logger.LogInformationWithContext("something happened here and the message is fairly long indeed yes", contextValue)
    End Sub

    Public Sub BreaksTheDotAsALastResort()
        Call CollectionTypeStuff_____________________________________________________________________().Where(Function(a) a.hasProp)
    End Sub

    Public Sub SuppressesANestedLastResortDot()
        a.Foo(Function(x) x.Bar______________________________________________________________________________________())
    End Sub

    Public Sub KeepsAShortLambdaAssignmentOnOneLine()
        Dim lambdaWithIfOperator____ = Function(value As Integer?) If(value.HasValue, value.Value, 0)
    End Sub

    Public Sub HangsALongLambdaAssignment()
        Dim lambdaWithIfOperator________________________ = Function(value As Integer?) If(value.HasValue, value.Value, 0)
    End Sub

    Public Sub HangsALongLambdaValueAssignmentStatement()
        someField.Property_______________________________________ = Function(value As Integer?) If(value.HasValue, value.Value, 0)
    End Sub

    Public Sub KeepsALongPlainCallAssignmentBreakingInsideItsOwnArgumentList()
        Dim plainCallAssignment_________________________________ = Compute(firstArgument, secondArgument, thirdArgument, four)
    End Sub

End Class
