Imports System.Xml.Linq

Module Markup

    Public Function Build(ByVal title As String) As XElement
        Return <document>
            <heading>
                <%= title %>
            </heading>
            <body>A paragraph with plenty of text, so the line exceeds the limit and still stays as is.</body>
        </document>
    End Function

End Module
