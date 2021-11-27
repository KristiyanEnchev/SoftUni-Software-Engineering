--- Problem - 3

SELECT u.[Username],
		g.[Name] AS [Game],
		COUNT(ugi.[ItemId]) AS [Items Count],
		SUM(i.[Price]) AS [Items Price]
FROM [UsersGames] AS ug
JOIN [Users] AS u ON ug.[UserId] = u.[Id]
JOIN [Games] AS g ON ug.[GameId] = g.[Id]
JOIN [UserGameItems] AS ugi ON ug.[Id] = ugi.[UserGameId]
JOIN [Items] AS i ON ugi.[ItemId] = i.[Id]
GROUP BY g.[Name], u.[Username]
HAVING COUNT(ugi.ItemId) >= 10
ORDER BY [Items Count] DESC,[Items Price] DESC, u.[Username]