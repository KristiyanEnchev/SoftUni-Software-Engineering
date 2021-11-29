--- Problem - 19 

SELECT TOP (10)
e.[FirstName],
e.[LastName],
e.[DepartmentID] 
FROM [Employees] AS e
WHERE [Salary] > 
(
	SELECT AVG([Salary]) AS [DepartmentAvarageSalary]
	FROM [Employees]
	WHERE [DepartmentID] = e.[DepartmentId]
	GROUP BY [DepartmentID]
)
ORDER BY e.[DepartmentID]