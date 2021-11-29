--- Problem - 7

SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander Family'
GROUP BY [DepositGroup]
HAVING SUM ([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC