USE [Minions]

CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY (MAX),
	CHECK (DATALENGTH ([Picture]) <= 2000000),
	[Height] DECIMAL (5, 2),
	[Weight] DECIMAL (5, 2),
	[Gender] CHAR(1) NOT NULL,
	CHECK (Gender='m' OR Gender='f'),
	[Birthdate] DATE NOT NULL,
	[Biography]NVARCHAR (MAX),
)

INSERT INTO [People]([Name],[Picture],[Height],[Weight],[Gender],[Birthdate],[Biography]) VALUES
('Biserov',Null,1.76,78.20,'m','1996-07-06',Null),
('Arnaudov',Null,1.56,48.30,'f','1984-01-03',Null),
('Georgi Ivanov Georgiev',Null,1.81,98.40,'m','2000-01-13',Null),
('Pesho Peshev',Null,1.71,68.90,'m','1999-11-12',Null),
('Joro Zlatinov Peev',Null,1.72,68.20,'f','2001-08-23',Null)