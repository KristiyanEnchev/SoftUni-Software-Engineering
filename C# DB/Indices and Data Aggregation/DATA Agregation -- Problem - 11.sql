--- Problem - 11

SELECT [DepositGroup],[IsDepositExpired],
AVG([DepositInterest]) AS [AvarageInterest]
FROM [WizzardDeposits]
WHERE [DepositStartDate] > '1985-01-01'
GROUP BY [DepositGroup],[IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired]