Imports System.Linq

Public Class QueryDemo

    Public Sub Run(employees As List(Of Employee))
        ' A query breaks in front of the keyword that opens the next clause -- the one place VB
        ' continues implicitly before a token rather than after it.
        Dim highEarners = From employee In employees
            Where employee.Salary > 100000 AndAlso employee.Department = "Engineering"
            Order By employee.Salary Descending
            Select employee.Name, employee.Salary

        Dim byDepartment = From employee In employees
            Group employee By Key = employee.Department Into Group, Count()
            Select Department = Key, Headcount = Count

        ' Short enough to stay on one line.
        Dim names = From employee In employees Select employee.Name
    End Sub

End Class
