Module Conditions

    Public Function Describe(ByVal candidate As Contract) As String
        If candidate.IsActive AndAlso
            candidate.HasValidSignature AndAlso
            candidate.RemainingTerm > 0 AndAlso
            Not candidate.IsSuspended Then
            Return "aktiv: " &
                candidate.Number &
                " / " &
                candidate.HolderName &
                " / " &
                candidate.ProductName &
                " / " &
                candidate.BranchName
        End If

        Return String.Empty
    End Function

End Module
