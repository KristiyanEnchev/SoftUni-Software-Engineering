--- Problem 8
USE [Minions]

CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY (MAX),
	CHECK (DATALENGTH ([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT NOT NULL
)

INSERT INTO [Users]([Username],[Password],[ProfilePicture],[LastLoginTime],[IsDeleted]) VALUES
('Biserov','kiko111',Null,'2021-09-12 01:12:04','false'),
('Arnaudov','098kiko111',Null,'2021-09-12 01:12:04','true'),
('Georgi Ivanov Georgiev','111kiko111',Null,'2021-09-12 01:12:04','false'),
('Pesho Peshev','11kiko',Null,'2021-09-12 01:12:04','true'),
('Joro Zlatinov Peev','Giko111',Null,'2021-09-12 01:12:04','false')

----- Problem 9
ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__3214EC078492EF0D]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_UsersCompositeIdUsername] PRIMARY KEY([Id], [Username])

-----Problem 10
ALTER TABLE [Users]
ADD CONSTRAINT [Least_Symbols] CHECK (DATALENGTH([Password]) >= 5)

-----Problem 11
ALTER TABLE [Users]
ADD CONSTRAINT [Default_Date] DEFAULT GETDATE() FOR [LastLoginTime]

-----Problem 12
ALTER TABLE [Users]
DROP CONSTRAINT [PK_UsersCompositeIdUsername]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_UsersId] PRIMARY KEY([Id])

ALTER TABLE [Users]
ADD CONSTRAINT [Unique_Username] UNIQUE ([Username])

ALTER TABLE [Users]
ADD CONSTRAINT [Username_Atleast_3] CHECK (DATALENGTH([Username]) >= 3)