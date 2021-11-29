--- Problem - 12

CREATE PROCEDURE usp_CancelFlights
AS
BEGIN
	UPDATE [Flights] SET
	[DepartureTime] = NULL,
	[ArrivalTime] = NULL
	WHERE [ArrivalTime] > [DepartureTime]
END

EXEC usp_CancelFlights