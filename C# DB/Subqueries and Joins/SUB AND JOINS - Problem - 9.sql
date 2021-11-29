--- Problem - 9

SELECT ep.[EmployeeID], ep.[FirstName], ep.[ManagerID], e.[FirstName] AS [ManagerName] 
FROM [Employees] AS e
JOIN [Employees] AS ep
ON e.[EmployeeID] = ep.[ManagerID]
WHERE ep.[ManagerID] IN (3, 7)
ORDER BY ep.[EmployeeID]