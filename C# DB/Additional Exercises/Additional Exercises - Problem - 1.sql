--- Problem - 1

USE [Diablo]

SELECT SUBSTRING([Email], CHARINDEX('@',[Email])+1,LEN([Email])) AS [Email Provider],
	   COUNT(*) AS [Number of Users]
FROM [Users]
GROUP BY SUBSTRING([Email], CHARINDEX('@',[Email])+1,LEN([Email]))
ORDER BY [Number of Users] DESC, [Email Provider]