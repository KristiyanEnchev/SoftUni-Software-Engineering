--- Problem - 12

SELECT 
	con.[ContinentName],
	SUM(CAST(c.[AreaInSqKm] AS BIGINT)) AS [ContriesArea],
	SUM(CAST(c.[Population] AS BIGINT)) AS [ContriesPopulation]
FROM [Continents] AS con
LEFT JOIN [Countries] as c ON con.[ContinentCode] = c.[ContinentCode]
GROUP BY con.[ContinentName]
ORDER BY [ContriesPopulation] DESC