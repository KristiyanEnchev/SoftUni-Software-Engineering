--- Problem - 12

USE [Geography]

SELECT [CountryName],[IsoCode]
FROM [Countries]
WHERE [CountryName] LIKE '%a%a%a%'
ORDER BY [IsoCode]

SELECT [CountryName],[IsoCode]
FROM [Countries]
WHERE LEN([CountryName]) - LEN(REPLACE([CountryName],'a','')) >= 3
ORDER BY [IsoCode]