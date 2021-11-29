--- Problem - 22

CREATE TABLE [Deleted_Employees]
(
 [EmployeeId] INT PRIMARY KEY IDENTITY,
 [FirstName] VARCHAR(50), 
 [LastName] VARCHAR(50), 
 [MiddleName] VARCHAR(50), 
 [JobTitle] VARCHAR(50), 
 [DepartmentId] INT, 
 [Salary] MONEY
)

CREATE TRIGGER tr_DeleteEmployees
ON [Employees] AFTER DELETE
AS
  BEGIN
    INSERT INTO [Deleted_Employees]
    SELECT [FirstName],[LastName],[MiddleName],[JobTitle],[DepartmentID],[Salary]
    FROM [deleted]
  END