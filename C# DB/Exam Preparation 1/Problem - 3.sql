--- Probelm - 3

UPDATE [Tickets]
SET [Price] = [Price] * 1.13
WHERE [FlightId] IN (
	SELECT [Id] 
	FROM [Flights]
	WHERE [Destination] = 'Carlsbad'
)
