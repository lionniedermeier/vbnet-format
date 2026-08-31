Module Setup

    ' The leading dot of a With block is not a legal break point and has to stay put.
    Public Sub Configure(ByVal configuration As Options)
        With configuration
            .Diagnostics.
                EnableVerboseTracing(True).
                EnablePayloadCapture(False).
                EnableTimingBreakdownForEveryStage(True).
                Apply()
        End With
    End Sub

End Module
