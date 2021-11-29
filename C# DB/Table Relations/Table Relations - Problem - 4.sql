---- Problem - 4

CREATE DATABASE [Teachers]

USE [Teachers]

CREATE TABLE [Teachers](
	[TeacherID] INT UNIQUE NOT NULL,
	[Name] NVARCHAR (20) NOT NULL,
	[ManagerID] INT
)

INSERT INTO [Teachers]([TeacherID],[Name],[ManagerID]) VALUES
(101,'John',NULL),
(102,'Maya',106),
(103,'Silvia',106),
(104,'Ted',105),
(105,'Mark',101),
(106,'Greta',101)

ALTER TABLE [Teachers]
ADD CONSTRAINT PK_TeacherID PRIMARY KEY([TeacherID])

ALTER TABLE[Teachers]
ADD CONSTRAINT FK_ManagerID FOREIGN KEY([ManagerID]) REFERENCES [Teachers]([TeacherID])

SELECT * 
FROM [Teachers]