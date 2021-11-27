--- Problem - 11

SELECT *
FROM
(
	SELECT [EmployeeID],[FirstName],[LastName],[Salary],
	DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY e.[EmployeeID]) AS [Rank]
	FROM [Employees] AS e
	WHERE e.[Salary] BETWEEN 10000 AND 50000
) 
AS [RAnkingTable]
WHERE [Rank] = 2
ORDER BY [Salary] DESC