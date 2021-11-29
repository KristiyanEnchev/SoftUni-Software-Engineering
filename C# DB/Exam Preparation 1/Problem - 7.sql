-- Probelem - 7

SELECT 
CONCAT(p.[FirstName], ' ', p.[LastName]) AS [Full Name],
f.[Origin],
f.[Destination]
FROM [Flights] AS f
JOIN [Tickets] AS t
ON f.[Id] = t.[FlightId]
JOIN [Passengers] AS p
ON t.[PassengerId] = p.[Id]
ORDER BY [Full Name], f.[Origin], f.[Destination]