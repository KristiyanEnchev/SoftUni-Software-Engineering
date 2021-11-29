---- Problem - 13
CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors](
	[Id] INT PRIMARY KEY NOT NULL,
	[DirectorName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(255)
)


CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY NOT NULL,
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(255)
)

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY NOT NULL,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(255)
)

CREATE TABLE [Movies](
	[Id] INT PRIMARY KEY NOT NULL,
	[Title] NVARCHAR(50) NOT NULL,
	[DirectorId] INT FOREIGN KEY ([DirectorId]) REFERENCES [Directors]([Id]),
	[CopyrightYear] DATE NOT NULL,
	[Length] INT NOT NULL,
	[GenreId] INT FOREIGN KEY ([GenreId]) REFERENCES [Genres]([Id]),
	[CategoryId] INT FOREIGN KEY ([CategoryId]) REFERENCES [Categories]([Id]),
	[Rating] VARCHAR(10),
	[Notes] NVARCHAR(255)
)

INSERT INTO [Directors]([Id],[DirectorName],[Notes]) VALUES
(1,'Director1','note1'),
(2,'Director2','note2'),
(3,'Director3','note3'),
(4,'Director4','note4'),
(5,'Director5','note5')


INSERT INTO [Genres]([Id],[GenreName],[Notes]) VALUES
(1,'Genre1','note1'),
(2,'Genre2','note2'),
(3,'Genre3','note3'),
(4,'Genre4','note4'),
(5,'Genre5','note5')


INSERT INTO [Categories]([Id],[CategoryName],[Notes]) VALUES
(1,'Category1','note1'),
(2,'Category2','note2'),
(3,'Category3','note3'),
(4,'Category4','note4'),
(5,'Category5','note5')


INSERT INTO [Movies]([Id],[Title],[DirectorId],[CopyrightYear],[Length],[GenreId],[CategoryId],[Rating],[Notes]) VALUES
(1,'Title1',5,'2011-01-02',10,3,2,'R','note1'),
(2,'Title2',4,'2012-01-03',11,3,3,'A','note2'),
(3,'Title3',4,'2013-01-04',12,2,4,'T','note3'),
(4,'Title4',1,'2014-01-05',13,1,4,'I','note4'),
(5,'Title5',2,'2015-01-06',14,5,5,'N','note5')