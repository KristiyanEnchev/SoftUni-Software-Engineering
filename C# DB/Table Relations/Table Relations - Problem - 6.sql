--- PRoblem - 6

CREATE DATABASE [University]

USE [University]

CREATE TABLE [Subjects](
	[SubjectID] INT PRIMARY KEY NOT NULL,
	[SubjectName] VARCHAR(50) NOT NULL
)

CREATE TABLE [Majors](
	[MajorID] INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY NOT NULL,
	[StudentNumber] INT NOT NULL,
	[StudentName] VARCHAR(50) NOT NULL,
	[MajorID] INT FOREIGN KEY([MajorID]) REFERENCES [Majors]([MajorID])
)

CREATE TABLE [Payments](
	[PaymentID] INT PRIMARY KEY NOT NULL,
	[PaymentDate] DATE NOT NULL,
	[PaymentAmount] DECIMAL(5,2),
	[StudentID] INT FOREIGN KEY([StudentID]) REFERENCES [Students]([StudentID])
)

CREATE TABLE [Agenda](
	[StudentID] INT FOREIGN KEY([StudentID]) REFERENCES [Students]([StudentID]),
	[SubjectID] INT FOREIGN KEY([SubjectID]) REFERENCES [Subjects]([SubjectID]),
	CONSTRAINT Composite_PK_StudentID_SubjectID PRIMARY KEY([StudentID],[SubjectID])
)