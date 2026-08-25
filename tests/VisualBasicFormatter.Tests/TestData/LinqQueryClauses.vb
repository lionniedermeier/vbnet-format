Imports System.Linq

Public Class QueryClauses

    Public Sub Run(employees As List(Of Employee), departments As List(Of Department))
        ' Join and Group Join are clause heads like any other, so they align under From too.
        Dim staffing = From employee In employees Join department In departments On employee.DepartmentId Equals department.Id Select employee.Name, Department = department.Name

        Dim rosters = From department In departments Group Join employee In employees On department.Id Equals employee.DepartmentId Into Members = Group Select department.Name, Members

        ' A join too long for the column its clauses align at breaks in front of On, and its
        ' condition indents one level below the head. Nothing else inside the clause is on offer, so
        ' the Into of a group join stays where it is.
        Dim overlyLongExtremelyDetailedVariableName = From employee In employees Join reportingManager In employees On employee.ReportingManagerIdentifier Equals CType(reportingManager.UniqueIdentifier, Integer?) Group Join colleague In employees On employee.Department Equals colleague.Department Into ColleagueGroup = Group Select employee.Name

        ' Let, Order By, the paging operators and Distinct.
        Dim page = From employee In employees Let bonus = employee.Salary * 0.1D Where bonus > 1000D Order By employee.Department, employee.Salary Descending Skip 10 Take 25 Select employee.Name, bonus

        Dim titles = From employee In employees Where employee.Title IsNot Nothing Select employee.Title Distinct

        Dim window = From employee In employees Skip While employee.Salary < 50000D Take While employee.Salary < 200000D Select employee.Name

        ' Aggregate is a clause head as well. Its own Into operators belong to the clause rather
        ' than to the query, so they stay on the line with it.
        Dim summary = From department In departments Aggregate employee In employees Into Headcount = Count() Select department.Name, Headcount
    End Sub

End Class
