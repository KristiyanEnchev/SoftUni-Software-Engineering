--- Problem - 12

SELECT 
c.[CigarName],
CONCAT('$',c.[PriceForSingleCigar]) AS [Price],
t.[TasteType],
b.[BrandName],
CONCAT(s.[Length], ' ', 'cm') AS [CigarLength],
CONCAT(s.[RingRange], ' ', 'cm') AS [CigarRingRange]
FROM [Cigars] AS c
JOIN [Brands] AS b
ON c.[BrandId] = b.[Id]
JOIN [Tastes] AS t 
ON t.[Id] = c.[TastId]
JOIN [Sizes] AS s
ON c.[SizeId] = s.[Id]
WHERE t.[TasteType] = 'Woody'
ORDER BY [CigarLength], [CigarRingRange] DESC

DROP PROCEDURE usp_SearchByTaste

CREATE PROCEDURE usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN 
SELECT 
c.[CigarName],
CONCAT('$',c.[PriceForSingleCigar]) AS [Price],
t.[TasteType],
b.[BrandName],
CONCAT(s.[Length], ' ', 'cm') AS [CigarLength],
CONCAT(s.[RingRange], ' ', 'cm') AS [CigarRingRange]
FROM [Cigars] AS c
JOIN [Brands] AS b
ON c.[BrandId] = b.[Id]
JOIN [Tastes] AS t 
ON t.[Id] = c.[TastId]
JOIN [Sizes] AS s
ON c.[SizeId] = s.[Id]
WHERE t.[TasteType] = @taste
ORDER BY [CigarLength], [CigarRingRange] DESC
END


EXEC usp_SearchByTaste 'Woody'
