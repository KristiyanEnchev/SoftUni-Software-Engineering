--- Problem - 9
CREATE PROCEDURE usp_GetHoldersFullName AS
	SELECT CONCAT(acc.[FirstName], ' ', acc.[LastName]) AS [Full Name]
	FROM [AccountHolders] AS acc


EXEC usp_GetHoldersFullName