--- Problem - 5

CREATE FUNCTION ufn_GetSalaryLevel (@salary DECIMAL (18,4))
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(7)

	IF @salary < 30000
	BEGIN 
		SET @salaryLevel = 'Low'
	END
	ELSE IF @salary BETWEEN 30000 AND 50000
	BEGIN
		SET @salaryLevel = 'Average'
	END
	ELSE 
	BEGIN 
		SET @salaryLevel = 'High'
	END
    RETURN @salaryLevel
END

SELECT [Salary], dbo.ufn_GetSalaryLevel([Salary]) AS [SalaryLevel] FROM [Employees]