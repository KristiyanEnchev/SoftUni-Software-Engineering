--- Problem - 12

DROP PROCEDURE usp_ExcludeFromSchool

CREATE PROCEDURE usp_ExcludeFromSchool (@StudentId INT)
AS
BEGIN
    DECLARE @studentExist INT = (SELECT Id FROM Students WHERE Id = @StudentId)
	IF @studentExist IS NULL 
	BEGIN
		RAISERROR('This school has no student with the provided id!', 16, 1)
		RETURN
	END

	DELETE FROM StudentsExams
	WHERE StudentId = @StudentId

	DELETE FROM StudentsSubjects
	WHERE StudentId = @StudentId

	DELETE FROM StudentsTeachers
	WHERE StudentId = @StudentId

	DELETE FROM Students
	WHERE Id = @StudentId
END

EXEC usp_ExcludeFromSchool 301

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students
