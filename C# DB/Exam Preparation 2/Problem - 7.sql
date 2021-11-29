--- Problem - 7

SELECT  
CONCAT(s.[FirstName], ' ', s.[LastName]) AS [Full Name]
FROM [Students] AS s
LEFT JOIN [StudentsExams] AS se
ON s.[Id] = se.[StudentId]
LEFT JOIN [Exams] AS e
ON se.[ExamId] = e.[Id]
WHERE e.[Id] IS NULL
ORDER BY [Full Name]