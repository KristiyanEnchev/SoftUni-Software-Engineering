--- Problem - 12

USE [Geography]

SELECT c.[CountryCode], m.[MountainRange], p.[PeakName], p.[Elevation]
FROM [Peaks] AS p
LEFT JOIN [Mountains] AS m
ON p.[MountainId] = m.[Id]
LEFT JOIN [MountainsCountries] AS mc
ON m.[Id] = mc.[MountainId]
LEFT JOIN [Countries] AS c
ON mc.[CountryCode] = c.[CountryCode]
WHERE c.[CountryCode] = 'BG' AND p.[Elevation] > 2835
ORDER BY p.[Elevation] DESC