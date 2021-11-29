--- Problem - 17

DROP PROCEDURE usp_WithdrawMoney

CREATE PROCEDURE usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(18,4))
AS
BEGIN TRANSACTION
	UPDATE [Accounts]
	SET [Balance] -= @moneyAmount
	WHERE [Id] = @accountId
	IF ((SELECT [Balance] FROM [Accounts] WHERE [Id] = @accountId) < 0)
		ROLLBACK
COMMIT
BEGIN
	SELECT 
	a.[Id] AS [AccountId],
	a.[AccountHolderId],
	CAST(a.[Balance] AS DECIMAL(18,4)) AS [Balance]
	FROM [Accounts] AS a
	JOIN [AccountHolders] AS ah
	ON a.[AccountHolderId] = ah.[Id]
	WHERE @accountId = a.[Id]
END

EXECUTE usp_WithdrawMoney 5,2

CREATE PROCEDURE usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(18,4))
AS
 BEGIN TRANSACTION
	UPDATE [Accounts]
	SET [Balance] -= @moneyAmount
	WHERE [Id] = @accountId
COMMIT