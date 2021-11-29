--- Problem - 13

USE [SoftUni]

SELECT [DepartmentID], SUM([Salary]) AS [TotalSalary]
FROM [Employees]
GROUP BY [DepartmentID]