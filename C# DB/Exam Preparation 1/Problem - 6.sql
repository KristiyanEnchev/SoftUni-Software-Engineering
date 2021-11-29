--- Problem - 6

SELECT [FlightId], SUM([Price]) AS [TotallPrice]  
FROM [Tickets]
GROUP BY [FlightId]
ORDER BY [TotallPrice] DESC, [FlightId]