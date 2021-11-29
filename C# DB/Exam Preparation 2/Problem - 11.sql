--- Problem - 11

DROP FUNCTION udf_ExamGradesToUpdate

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15,2))
RETURNS NVARCHAR(MAX)
AS
BEGIN
DECLARE @studentExist INT = (SELECT TOP(1) StudentId FROM StudentsExams WHERE StudentId = @studentId);
IF @studentExist IS NULL
RETURN ('The student with provided id does not exist in the school!')
IF @grade > 6.00
RETURN ('Grade cannot be above 6.00!')
DECLARE @studentFirstName NVARCHAR(20) = (SELECT 1 [FirstName] FROM [Students] WHERE [Id] = @studentId)
DECLARE @biggestGrade DECIMAL(15,2) = @grade + 0.50;
DECLARE @count INT = (SELECT COUNT([Grade])FROM [StudentsSubjects]
WHERE [StudentId] = @studentId AND [Grade] >= @grade AND [Grade] <= @biggestGrade)
IF @count > 0
RETURN ('You have to update '+ CAST(@count AS nvarchar(10)) +'grades for the student' + @studentFirstName)
END

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15,2))
RETURNS NVARCHAR(MAX)
AS
BEGIN
		DECLARE @studentExist INT = (SELECT TOP(1) StudentId FROM StudentsExams WHERE StudentId = @studentId);
		IF @studentExist IS NULL
		RETURN ('The student with provided id does not exist in the school!')

		IF @grade > 6.00
		RETURN ('Grade cannot be above 6.00!')

		DECLARE @studentFirstName NVARCHAR(20) = (SELECT TOP(1) FirstName FROM Students WHERE Id = @studentId);
		DECLARE @biggestGrade DECIMAL(15,2) = @grade + 0.50;
		DECLARE @count INT = (SELECT Count(Grade) FROM StudentsExams
		WHERE StudentId = @studentId AND Grade >= @grade AND Grade <= @biggestGrade)
		RETURN ('You have to update ' + CAST(@count AS nvarchar(10)) + ' grades for the student ' + @studentFirstName)
END