Module CaseClauses

    Public Function Describe(ByVal feature As Feature) As Boolean
        Select Case feature
            Case Feature.AutoProperties,
                Feature.LineContinuation,
                Feature.StatementLambdas,
                Feature.CoContraVariance,
                Feature.CollectionInitializers,
                Feature.SubLambdas,
                Feature.ArrayLiterals
                Return True
            Case Feature.AutoProperties, Feature.LineContinuation
                Return True
            Case Else
                Return False
        End Select
    End Function

End Module
