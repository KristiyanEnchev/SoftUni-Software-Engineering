--- Problem - 1

USE [SoftUni]

SELECT *
FROM [Employees] AS e
LEFT JOIN [Addresses] AS a
ON e.[AddressID] = a.[AddressID]

SELECT TOP (5) e.[EmployeeID],e.[JobTitle],e.[AddressID], a.[AddressText]
FROM [Employees] AS e
LEFT JOIN [Addresses] AS a
ON e.[AddressID] = a.[AddressID]
ORDER BY e.[AddressID]