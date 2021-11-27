--- Problem - 11

SELECT
	curr.[CurrencyCode],
	curr.[Description] AS [Currency],
	COUNT(c.[CountryName]) AS [NumberOfCountries]
FROM [Currencies] AS curr
LEFT JOIN [Countries] AS c ON curr.[CurrencyCode] = c.[CurrencyCode]
GROUP BY curr.[CurrencyCode],curr.[Description]
ORDER BY [NumberOfCountries] DESC,[Currency]