Imports System.Xml.Linq

' The three steps a literal is wrapped in, and the one shortcut past the middle of them.
Module Wrapping

    Public Sub Run()
        Dim fits = <person id="42" name="Alice"/>

        Dim hangs = <person id="42" name="Alice" role="Engineer" location="Munich" department="Eng" manager="Alice Schmidt"/>

        Dim nested = <person id="42" name="Alice"><address city="Berlin"/></person>
    End Sub

End Module
