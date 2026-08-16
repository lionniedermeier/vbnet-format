Module Stubborn

    ' Neither line offers an implicit continuation point: no comma, no operator, no invoked member.
    Public Sub Emit()
        Dim value = configuration.Diagnostics.Tracing.Verbose.Payload.Timing.Breakdown.Stages.FirstStage.SecondStage.ThirdStage
        Dim text As String = "a very long string literal that cannot sensibly be split without changing the content it carries"
    End Sub

End Module
