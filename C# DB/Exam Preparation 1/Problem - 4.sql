--- Probelem - 4

DELETE FROM [Tickets]
WHERE [FlightId] IN 
(
	SELECT [Id] 
	FROM [Flights]
	WHERE [Destination] = 'Ayn Halagim'
)

DELETE FROM [Flights]
WHERE [Destination] = 'Ayn Halagim';