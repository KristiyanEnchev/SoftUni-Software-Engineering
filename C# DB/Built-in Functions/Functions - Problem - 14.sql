--- Problem - 14

USE [Diablo]

SELECT TOP(50) [Name],FORMAT([Start],'yyyy-MM-dd','en-US') AS [Start]
FROM [Games] AS g
WHERE YEAR(g.[Start]) IN (2011, 2012)
ORDER BY [Start], [Name]