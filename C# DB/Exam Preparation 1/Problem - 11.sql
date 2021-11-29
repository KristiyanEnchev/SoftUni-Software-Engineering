--- Problem - 11

CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(50) 
AS
BEGIN
	IF @peopleCount <= 0 RETURN 'Invalid people count!'
	IF (NOT EXISTS(SELECT TOP(1)* FROM [Flights] WHERE [Origin] = @origin AND [Destination] = @destination)) RETURN 'Invalid flight!'
	RETURN CONCAT('Total price ',
			(
				SELECT TOP(1) t.[Price]
				FROM [Tickets] AS t 
				JOIN [Flights] AS f
				ON f.[Id] = t.[FlightId]
				WHERE @origin = f.[Origin] AND @destination = f.[Destination]
			) * @peopleCount)

END


SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)