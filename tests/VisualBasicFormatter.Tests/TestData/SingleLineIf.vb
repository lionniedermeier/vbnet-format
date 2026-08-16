Module Guards

    Public Sub Check(ByVal candidate As Contract)
        If candidate Is Nothing Then Throw New ArgumentNullException(NameOf(candidate))
        If candidate.IsActive AndAlso candidate.HasValidSignature AndAlso candidate.RemainingTerm > 0 Then Report(candidate)
    End Sub

End Module
