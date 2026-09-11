' Copyright (c) Contoso AG.
' Licensed under the MIT license.

Imports Microsoft.CodeAnalysis.VisualBasic.Symbols
Imports Microsoft.CodeAnalysis.Emit

#If Not DEBUG Then
Imports MethodSymbolAdapter = Microsoft.CodeAnalysis.VisualBasic.Symbols.MethodSymbol
Imports EventSymbolAdapter = Microsoft.CodeAnalysis.VisualBasic.Symbols.EventSymbol
#End If

Namespace Demo.NoPia

    Friend NotInheritable Class Embedded
    End Class

End Namespace
