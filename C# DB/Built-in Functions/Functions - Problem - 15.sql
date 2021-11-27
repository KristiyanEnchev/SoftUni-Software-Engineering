--- Problem - 15

SELECT [UserName],SUBSTRING([Email],CHARINDEX('@',[Email]) + 1,LEN([Email])) AS [Email Provider] 
FROM [Users]
ORDER BY [Email Provider], [Username]
