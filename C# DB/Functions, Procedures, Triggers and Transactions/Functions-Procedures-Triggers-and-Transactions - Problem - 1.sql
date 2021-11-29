--- Problem - 1

USE [SoftUni]

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT [firstName], [LastName] 
	FROM [Employees]
	WHERE [Salary] > 35000
END

EXEC usp_GetEmployeesSalaryAbove35000