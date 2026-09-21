Module Setup

    Public Sub Configure(ByVal collectionType As CollectionType)
        With collectionType
            If .Prop Then
                Return Nothing
            End If

            Select Case .Prop

            End Select

            For Each item In .Items
                Call .Handle(item)
            Next

            Dim flag = Not .Flag
            Dim value = .Prop
            Dim entry = .Lookup!Name

            With .Inner
                .Reset()
            End With
        End With
    End Sub

End Module
