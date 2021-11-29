--- Problem - 10

SELECT 
pl.[Name],
pl.[Seats],
COUNT(t.[Id]) AS [Passengers Count]
FROM [Planes] AS pl
LEFT JOIN [Flights] AS f
ON pl.[Id] = f.[PlaneId]
LEFT JOIN [Tickets] AS t
ON f.[Id] = t.[FlightId]
GROUP BY pl.[Id], pl.[Name], pl.[Seats]
ORDER BY [Passengers Count] DESC, [Name], [Seats]
