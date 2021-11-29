--- Problem- 15

SELECT *
INTO [EmployeesWithSalaryHigherThan30000]
FROM [Employees]
WHERE [Salary] > 30000

DELETE FROM [EmployeesWithSalaryHigherThan30000]
WHERE [ManagerID] = 42

UPDATE [EmployeesWithSalaryHigherThan30000]
SET [Salary] += 5000
WHERE [DepartmentID] = 1

SELECT [DepartmentID],AVG([Salary]) AS [AvarageSalary]
FROM [EmployeesWithSalaryHigherThan30000]
GROUP BY [DepartmentID]