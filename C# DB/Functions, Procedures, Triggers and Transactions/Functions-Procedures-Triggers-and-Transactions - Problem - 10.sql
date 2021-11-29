--- Problem - 10

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@number MONEY) 
AS
BEGIN
	SELECT ah.[FirstName], ah.[LastName]
	FROM [Accounts] AS a
	JOIN [AccountHolders] AS ah
	ON a.[AccountHolderId] = ah.[Id]
	GROUP BY ah.[FirstName], ah.[LastName]
	HAVING SUM(a.[Balance]) > @number
	ORDER BY ah.[FirstName], ah.[LastName]
END

EXEC usp_GetHoldersWithBalanceHigherThan 20000