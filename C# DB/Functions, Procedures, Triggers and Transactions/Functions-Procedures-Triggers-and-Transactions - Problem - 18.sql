--- problem - 18

DROP PROCEDURE  usp_TransferMoney

CREATE PROCEDURE usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount MONEY)
AS
CREATE TABLE #TempTable(
	[AccountId] INT NOT NULL,
	[AccountHolderId] INT NOT NULL,
	[Balance] DECIMAL(10,4)
)
BEGIN TRANSACTION
	INSERT INTO #TempTable
		EXECUTE usp_DepositMoney @ReceiverId, @Amount
	INSERT INTO #TempTable
		EXECUTE usp_WithdrawMoney @SenderId, @Amount
COMMIT
BEGIN
	SELECT 
	[AccountId],
	[AccountHolderId],
	CAST([Balance] AS DECIMAL(10,4)) AS [Balance]
	FROM #TempTable
END


EXECUTE usp_TransferMoney 5,1,5000