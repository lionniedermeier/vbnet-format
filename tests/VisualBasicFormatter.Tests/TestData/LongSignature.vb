Module Calculations

    Public Function CalculateWeightedAverage(ByVal firstMeasurement As Double, ByVal secondMeasurement As Double, ByVal firstWeight As Double, ByVal secondWeight As Double) As Double
        Return (firstMeasurement * firstWeight + secondMeasurement * secondWeight) / (firstWeight + secondWeight)
    End Function

End Module
