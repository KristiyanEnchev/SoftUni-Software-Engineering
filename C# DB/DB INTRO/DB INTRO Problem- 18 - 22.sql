---- Problem - 18

USE [SoftUni]

INSERT INTO [Towns]([Name]) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO [Departments]([Name]) VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assuranc')

--INSERT INTO [Employees]([FirstName],[MiddleName],[LastName],[JobTitle],[DepartmentId],[HireDate],[Salary]) VALUES
--('Joro', 'Jorgio', 'Jorev', 'Developer', 4, '2010-01-02', 2000.00),
--('Minka', 'Mineva', 'Minkova', 'Sales Manager', 2, '2011-03-01', 3100.00),
--('Gosho', 'Georgiev', 'Goshev', 'QA', 5, '2014-07-02', 7000.00),
--('Pesho', 'Paskov', 'Peshev', 'Architect', 1, '2009-01-01', 5050.42),
--('Grisho', 'Grigorov', 'Grishev', 'Comercial Analityst', 3, '2015-12-04', 3000.00)

INSERT INTO [Employees]([FirstName],[MiddleName],[LastName],[JobTitle],[DepartmentId],[HireDate],[Salary]) VALUES
('Ivan','Ivanov','Ivanov','.NET Developer',4,'2013-01-02',3500.00),
('Petar','Petrov','Petrov','Senior Engineer',1,'2004-03-02',4000.00),
('Maria','Petrova','Ivanova','Intern',5,'2016-08-28',525.25),
('Georgi','Terziev','Ivanov','CEO',2,'2007-12-09',3000.00),
('Peter','Pan','Pan','Inter',3,'2016-08-28',3500.00)

--- Problem 19

SELECT * FROM [Towns]

SELECT * FROM [Departments]

SELECT * FROM [Employees]

--- Problem 20

SELECT * FROM [Towns]
ORDER BY [Name] ASC

SELECT * FROM [Departments]
ORDER BY [Name] ASC

SELECT * FROM [Employees]
ORDER BY [Salary] DESC

--- Problem - 21

SELECT [Name] FROM [Towns]
ORDER BY [Name] ASC

SELECT [Name] FROM [Departments]
ORDER BY [Name] ASC

SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM [Employees]
ORDER BY [Salary] DESC

--- Problem - 22

UPDATE [Employees]
	SET [Salary] += [Salary] * 0.10

SELECT [Salary] FROM [Employees]