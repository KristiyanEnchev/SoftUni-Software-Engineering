--- Problem - 3

CREATE DATABASE [Students]

USE [Students]

CREATE TABLE [Students](
	[StudentID] INT NOT NULL UNIQUE,
	[Name] NVARCHAR (20) NOT NULL
)

CREATE TABLE [Exams](
	[ExamID] INT NOT NULL UNIQUE,
	[Name] NVARCHAR(20) NOT NULL
)

CREATE TABLE [StudentsExams](
	[StudentID] INT NOT NULL,
	[ExamID] INT NOT NULL
)

INSERT INTO [Students]([StudentID],[Name]) VALUES
(1,'Mila'),
(2,'Toni'),
(3,'Ron')

INSERT INTO [Exams]([ExamID],[Name]) VALUES
(101,'SpringMVC'),
(102,'Neo4j'),
(103,'Oracle 11g')

INSERT INTO [StudentsExams]([StudentID],[ExamID]) VALUES
(1,101),
(1,102),
(2,101),
(3,103),
(2,102),
(2,103)

ALTER TABLE [Students]
ADD CONSTRAINT PK_StudentID PRIMARY KEY ([StudentID])

ALTER TABLE [Exams]
ADD CONSTRAINT PK_ExamID PRIMARY KEY ([ExamID])

ALTER TABLE [StudentsExams]
ADD CONSTRAINT PK_StudentID_ExamID PRIMARY KEY ([StudentID],[ExamID])

ALTER TABLE [StudentsExams]
ADD CONSTRAINT FK_StudentID FOREIGN KEY ([StudentID]) REFERENCES [Students]([StudentID])

ALTER TABLE [StudentsExams]
ADD CONSTRAINT FK_ExamID FOREIGN KEY ([ExamID]) REFERENCES [Exams]([ExamID])

