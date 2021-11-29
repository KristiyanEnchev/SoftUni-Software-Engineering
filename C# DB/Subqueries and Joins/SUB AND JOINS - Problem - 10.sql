-- Problem - 10

SELECT TOP (50)
ep.[EmployeeID],
CONCAT(ep.[FirstName], ' ', ep.[LastName]) AS [EmployeeName],
CONCAT(e.[FirstName], ' ', e.[LastName]) AS [ManagerName],
d.[Name] AS [DepartmentName]
FROM [Employees] AS e
JOIN [Employees] AS ep
ON e.[EmployeeID] = ep.[ManagerID]
JOIN [Departments] AS d
ON ep.[DepartmentID] = d.[DepartmentID]
ORDER BY ep.[EmployeeID]