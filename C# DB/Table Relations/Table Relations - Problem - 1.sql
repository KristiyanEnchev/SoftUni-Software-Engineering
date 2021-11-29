---- Problem 1 

CREATE DATABASE [People]

USE [People]

CREATE TABLE [Persons](
	[PersonID] INT NOT NULL,
	[FirstName] NVARCHAR(20),
	[Salary] DECIMAL(8,2),
	[PassportID] INT UNIQUE
)

CREATE TABLE [Passports](
	[PAssportID] INT NOT NULL UNIQUE,
	[PassportNumber] NVARCHAR(8)
)


INSERT INTO [Persons]([PersonID],[FirstName],[Salary],[PassportID]) VALUES
(1, 'Roberto', 43300.00,102),
(2,'Tom',56100.00,103),
(3,'Yana',60200.00,101)

INSERT INTO [Passports]([PassportID], [PassportNumber]) VALUES
(101,'N34FG21B'),
(102,'K65LO4R7'),
(103,'ZE657QP2')

ALTER TABLE [Persons]
ADD CONSTRAINT PK_PersonID PRIMARY KEY ([PersonID])

ALTER TABLE [Passports]
ADD CONSTRAINT PK_PassportID PRIMARY KEY ([PAssportID])

ALTER TABLE [Persons]
ADD CONSTRAINT FK_Person_PassportID FOREIGN KEY ([PassportID]) REFERENCES [Passports]([PassportID]) 