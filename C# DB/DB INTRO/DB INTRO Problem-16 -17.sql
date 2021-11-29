CREATE DATABASE [SoftUni]

USE [SoftUni]

--- Problem - 16
--- Problem - 17

CREATE TABLE [Towns](
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50)
)


CREATE TABLE [Addresses](
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[AddressText] NVARCHAR(50) NOT NULL,
	[TownId] INT FOREIGN KEY([TownId]) REFERENCES [Towns](Id),
)


CREATE TABLE [Departments](
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[FirstName] NVARCHAR(10) NOT NULL,
	[MiddleName] NVARCHAR(10) NOT NULL,
	[LastName] NVARCHAR(10) NOT NULL,
	[JobTitle] NVARCHAR(20) NOT NULL,
	[DepartmentId] INT FOREIGN KEY([DepartmentId]) REFERENCES [Departments](Id),
	[HireDate] DATE NOT NULL,
	[Salary] DECIMAL(8,3) NOT NULL,
	[AddressId] INT FOREIGN KEY([AddressId]) REFERENCES [Addresses](Id)
)