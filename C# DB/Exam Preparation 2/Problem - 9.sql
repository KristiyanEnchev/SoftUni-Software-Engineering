--- Problem - 9

SELECT CONCAT(s.[FirstName], ' ', ISNULL(s.[MiddleName] + ' ', ''), s.[LastName]) AS [Full Name]
FROM [Students] AS s
LEFT JOIN [StudentsSubjects] AS ss
ON s.[Id] = ss.[StudentId]
WHERE ss.[id] IS NULL
ORDER BY [Full Name]