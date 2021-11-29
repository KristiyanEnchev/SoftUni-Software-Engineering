USE [SoftUni]

SELECT TOP (50) e.[FirstName],e.[LastName],t.[Name],a.[AddressText]
FROM [Employees] AS e
LEFT JOIN [Addresses] AS a
ON e.[AddressID] = a.[AddressID]
LEFT JOIN [Towns] AS t
ON a.[TownID] = t.[TownID]
ORDER BY [FirstName],[LastName]