--- Problem - -12

SELECT SUM ([Difference]) AS [SumDifference]
FROM(
		SELECT    [FirstName] AS [HostWizzard],
				  [DepositAmount] AS [Host Wizzard Deposit],
				  LEAD([FirstName]) OVER (ORDER BY [Id]) AS [Guest Wizzard],
				  LEAD([DepositAmount]) OVER (ORDER BY [Id]) AS [Guest Wizzard Deposit],
				  [DepositAmount] - LEAD([DepositAmount]) OVER (ORDER BY [Id]) AS [Difference]
		FROM	  [WizzardDeposits]
	)
AS [SubQuery]


--- WITH JOIN 

SELECT 
SUM ([Difference]) AS [SumDifference]
FROM(
		SELECT wd1.[FirstName] AS [Host Wizzard],
		wd1.[DepositAmount] AS [Host Wizzard Deposit],
		wd2.[FirstName] AS [Guest Wizzard],
		wd2.[DepositAmount] AS [Guest Wizzard Deposite],
		wd1.[DepositAmount] - wd2.[DepositAmount] AS [Difference]
		FROM [WizzardDeposits] AS wd1
		JOIN [WizzardDeposits] AS wd2
		ON wd1.[Id] + 1 = wd2.[Id]
	) 
AS [DifferenceSubQuery]