--- Problem - 11

SELECT MIN ([AVG].[DepartmentAVGSalary]) AS [MinAverageSalary]
FROM
(
	SELECT AVG([Salary]) AS [DepartmentAVGSalary]
	FROM [Employees]
	GROUP BY [DepartmentID]
) 
AS [AVG] 