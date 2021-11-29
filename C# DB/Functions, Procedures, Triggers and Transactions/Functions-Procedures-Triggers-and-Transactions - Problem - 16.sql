--- Problem - 16

DROP PROCEDURE usp_DepositMoney

CREATE PROCEDURE usp_DepositMoney (@AccountId INT, @MoneyAmount MONEY)
AS
 BEGIN TRANSACTION
	UPDATE [Accounts]
	SET [Balance] += @MoneyAmount
	WHERE [Id] = @AccountId
COMMIT
BEGIN
	SELECT 
	a.[Id] AS [AccountId],
	a.[AccountHolderId],
	CAST(a.[Balance] AS DECIMAL(10,4)) AS [Balance]
	FROM [Accounts] AS a
	JOIN [AccountHolders] AS ah
	ON a.[AccountHolderId] = ah.[Id]
	WHERE @AccountId = a.[Id]
END

EXECUTE usp_DepositMoney 1,10