Imports System.Xml.Linq

Module Reports

    Public Function Build(departments As IEnumerable(Of Department)) As XElement
        Dim xml = _
            <departments>
                <%= From department In departments
                    Select <department id=<%= department.Id %> name=<%= department.Name %>>
                    <employees>
                        <%= From employee In department.Employees Select
                            <employee id=<%= employee.Id %>
                                      name=<%= employee.Name %>
                                      age=<%= employee.Age %>
                                      tags=<%= String.Join(",", employee.Tags) %>/> %>
                    </employees>
                </department> %>
            </departments>

        Return xml
    End Function

End Module
