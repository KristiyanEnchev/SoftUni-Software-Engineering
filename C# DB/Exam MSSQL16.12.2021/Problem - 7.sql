--- Problem - 7

SELECT 
cl.[Id],
CONCAT(cl.[FirstName], ' ', cl.[LastName]) AS [ClientName],
cl.[Email]
FROM [Clients] AS cl
LEFT JOIN [ClientsCigars] AS cc
ON cl.[Id] = cc.[ClientId]
LEFT JOIN [Cigars] AS c
ON cc.[CigarId] = c.[Id]
WHERE c.[Id] IS NULL
ORDER BY [ClientName]
