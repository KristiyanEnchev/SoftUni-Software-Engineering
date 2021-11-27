--- Problem - 16

SELECT [UserName],[IpAddress] AS [IP Address]
FROM [Users]
WHERE [IpAddress] LIKE '___.1_%._%.___'
ORDER BY [Username]