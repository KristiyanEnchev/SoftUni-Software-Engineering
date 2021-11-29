--- Problem - 18

USE [SoftUni]

SELECT DISTINCT [DepartmentID],[Salary] AS [ThurdHighestSalary]
FROM
(
	SELECT e.[DepartmentID],
	e.[Salary],
	DENSE_RANK () OVER(PARTITION BY e.[DepartmentId] ORDER BY e.[Salary] DESC) AS [SalaryRank]
	FROM [Employees] AS e
) 
AS [SalaryRAnkerQuery]
WHERE [SalaryRank] = 3