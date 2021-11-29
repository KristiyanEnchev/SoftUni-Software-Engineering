--- Problem - 9

SELECT
CONCAT(c.[FirstName], ' ', c.[LastName]) AS [FullName],
a.[Country],
a.[ZIP],
CONCAT('$',ci.[PriceForSingleCigar]) AS [CigarPrice]
FROM [Clients] AS c
JOIN [Addresses] AS a
ON c.[AddressId] = a.[Id]
JOIN [ClientsCigars] AS cc
ON c.[Id] = cc.[ClientId]
JOIN [Cigars] AS ci
ON cc.[CigarId] = ci.[Id]
WHERE [ZIP] NOT LIKE '%[^0-9]%'
GROUP BY c.[FirstName], c.[LastName], MAX(ci.[PriceForSingleCigar])
ORDER BY [FullName]


SELECT 
CONCAT(c.[FirstName], ' ', c.[LastName]) AS [FullName],
a.[Country],
a.[ZIP],
CONCAT('$',MAX(ci.PriceForSingleCigar)) AS [CigarPrice]
FROM [Clients] AS c
JOIN [Addresses] AS a
ON c.[AddressId] = a.[Id]
JOIN [ClientsCigars] AS cc
ON c.[Id] = cc.[ClientId]
JOIN [Cigars] AS ci
ON cc.[CigarId] = ci.[Id]
WHERE [ZIP] NOT LIKE '%[^0-9]%'
GROUP BY CONCAT(c.[FirstName], ' ', c.[LastName]), a.[Country], a.[ZIP]