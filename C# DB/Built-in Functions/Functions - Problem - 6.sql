---- Problem - 6

SELECT * 
FROM [Towns]
WHERE LEFT ([Name],1) IN ('M','K','B','E')
ORDER BY [Name]