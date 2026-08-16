Module Reporting

    Public Sub Emit()
        ' Too wide for the statement's line, but the arguments still fit on one indented line of
        ' their own -- so they take it, and the bracket closes below them.
        Dim line As String = String.Format(
            "{0} {1} {2} {3} {4}", currentCustomerName, currentOrderNumber, currentInvoiceTotal, currentDueDate, currentStatus
        )

        ' Wider still: that one indented line does not fit either, so the commas break and every
        ' argument gets a line to itself.
        Dim detailed As String = String.Format(
            "{0} {1} {2} {3} {4} {5} {6}",
            currentCustomerName,
            currentOrderNumber,
            currentInvoiceTotal,
            currentDueDate,
            currentStatus,
            currentDeliveryAddress,
            currentContactTelephone
        )

        ' A trailing call has no brace or lambda body of its own, so it is not hugged: the outer
        ' list breaks around it rather than opening BuildSummary up on the statement's line.
        Dim summary = Describe(
            currentCustomerName, currentOrderNumber, BuildSummary(currentInvoiceTotal, currentDueDate, currentStatus)
        )

        ' A trailing object creation with a `With` initializer still hugs: its brace reads as a
        ' continuation of the call it sits in.
        Dim widget = Register(currentCustomerName, currentOrderNumber, New Widget With {
                .Total = currentInvoiceTotal,
                .DueDate = currentDueDate,
                .Status = currentStatus
            })
    End Sub

End Module
