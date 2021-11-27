--- Problem - 13

SELECT [PeakName],[RiverName]
FROM [Peaks],[Rivers]
WHERE RIGHT([PeakName],1) = LEFT([RiverName],1)

SELECT [PeakName],[RiverName], CONCAT(LOWER([PeakName]),LOWER(SUBSTRING([RiverName],2,LEN([RiverName])))) AS [Mix] 
FROM [Peaks],[Rivers]
WHERE RIGHT([PeakName],1) = LEFT([RiverName],1)
ORDER BY [Mix]