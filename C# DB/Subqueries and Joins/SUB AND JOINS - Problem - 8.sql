---- Problem - 8

SELECT e.[EmployeeID], e.[FirstName], CASE
WHEN YEAR (p.[StartDate]) >= 2005 THEN NULL 
ELSE p.[Name]
END AS [ProjectName]
FROM [Employees] AS e
JOIN [EmployeesProjects] AS ep
ON e.[EmployeeID] = ep.[EmployeeID]
JOIN [Projects] As p
ON ep.[ProjectID] = p.[ProjectID]
WHERE e.[EmployeeID] = 24