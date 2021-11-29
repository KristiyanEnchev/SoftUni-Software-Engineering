--- Problem - 2

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @minSalary DECIMAL(18,4)
AS
BEGIN
	SELECT [firstName], [LastName] 
	FROM [Employees]
	WHERE [Salary] >= @minSalary
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100