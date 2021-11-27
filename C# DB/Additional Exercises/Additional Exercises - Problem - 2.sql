--- Problem - 2

SELECT
	g.[Name] AS [Game],
	gt.[Name] AS [Game Type],
	u.[Username],
	ug.[Level],
	ug.[Cash],
	c.[Name]
FROM [UsersGames] AS ug
LEFT JOIN [Users] AS u ON ug.[UserId] = u.[Id]
LEFT JOIN [Games] AS g ON ug.[GameId] = g.[Id]
LEFT JOIN [GameTypes] AS gt ON g.[GameTypeId] = gt.[Id]
LEFT JOIN [Characters] AS c ON ug.[CharacterId] = c.[Id]
ORDER BY ug.[Level] DESC,u.[Username],g.[Name]