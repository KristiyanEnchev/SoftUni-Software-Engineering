--- Problem - 17.2

SELECT TOP (5)
c.[CountryName],
MAX(p.[Elevation]) AS [HighestPeakElevation],
MAX(r.[Length]) AS [LongestRiverLength]
FROM [Countries] AS c
LEFT JOIN [CountriesRivers] AS cr
ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r
ON cr.[RiverId] = r.[Id]
LEFT JOIN [MountainsCountries] AS mc
ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN [Peaks] AS p
ON mc.[MountainId] = p.[MountainId]
GROUP BY [CountryName]
ORDER BY [HighestPeakElevation] DESC,
[LongestRiverLength] DESC,
c.[CountryName]