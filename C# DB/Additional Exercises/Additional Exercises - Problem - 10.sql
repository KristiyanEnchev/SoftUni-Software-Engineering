--- Problem - 10

SELECT
	c.[CountryName],
	con.[ContinentName],
	COUNT(r.[Id]) AS [RiversCount],
	ISNULL(SUM(r.[Length]),0) AS [TotalLength]
FROM [Countries] AS c
LEFT JOIN [Continents] AS con ON c.[ContinentCode] = con.[ContinentCode]
LEFT JOIN [CountriesRivers] AS cr ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r ON cr.[RiverId] = r.[Id]
GROUP BY c.[CountryName],con.[ContinentName]
ORDER BY [RiversCount] DESC, [TotalLength] DESC, c.[CountryName]