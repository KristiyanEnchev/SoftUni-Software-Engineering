--- Problem - 10

SELECT s.[Name], AVG(ss.[Grade])  AS [AverageGrade]
FROM [Subjects] AS s
JOIN [StudentsSubjects] AS ss
ON s.[Id] = ss.[SubjectId]
GROUP BY s.[Name], ss.[SubjectId]
ORDER BY ss.[SubjectId]
