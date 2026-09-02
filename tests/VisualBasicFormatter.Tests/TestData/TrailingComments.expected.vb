Module Annotated

    Public Sub Emit() ' entry point
        Dim line As String = String.Format(
            "{0} {1} {2} {3} {4}",
            currentCustomerName,
            currentOrderNumber,
            currentInvoiceTotal,
            currentDueDate,
            currentStatus
        ) ' the long one
        Dim short1 = 1 ' short
        Dim upper = elements.GetLength(0) - 1 ' the last index
        For index = 0 To elements.GetLength(0) - 1 ' walk every row
            values(index) = elements(index, 1)
        Next
        Dim both = first AndAlso second ' both of them
        Dim total = Add(
            alpha, ' the first term
            beta
        )
    End Sub

End Module
