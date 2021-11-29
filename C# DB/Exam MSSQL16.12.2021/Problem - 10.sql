--- Problem - 10

SELECT 
cl.[LastName],
AVG(s.[Length]) AS [CiagrLength],
CEILING(AVG(s.[RingRange])) AS [CiagrRingRange]
FROM [Clients] AS cl
JOIN [ClientsCigars] AS cc
ON cl.[Id] = cc.[ClientId]
JOIN [Cigars] AS c
ON cc.[CigarId] = c.[Id]
JOIN [Sizes] AS s
ON c.[SizeId] = s.[Id]
GROUP BY cl.[LastName]
ORDER BY [CiagrLength] DESC