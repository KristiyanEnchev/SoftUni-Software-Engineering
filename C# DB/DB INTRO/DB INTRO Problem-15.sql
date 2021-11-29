----Problem - 15

CREATE DATABASE [Hotel]

USE [Hotel]

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[FirstName] NVARCHAR(20) NOT NULL,
	[LastName] NVARCHAR(20) NOT NULL,
	[Title] NVARCHAR(20) NOT NULL,
	[Notes] NVARCHAR(255),
)

INSERT INTO [Employees] VALUES
('Gosho', 'Goshev', 'Receptionist1', NULL),
('Ivan', 'Ivanov', 'Receptionist2', NULL),
('Pesho', 'Peshev', 'HouseKeeper', NULL)

CREATE TABLE [Customers](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[AccountNumber] BIGINT UNIQUE,
	[FirstName] NVARCHAR(20) NOT NULL,
	[LastName] NVARCHAR(20) NOT NULL,
	[PhoneNumber] NVARCHAR(20) NOT NULL,
	[EmergencyName] NVARCHAR(20) NOT NULL,
	[EmergencyNumber] NVARCHAR(20) NOT NULL,
	[Notes] NVARCHAR(255),
)

INSERT INTO [Customers] VALUES
(111111, 'Gosho', 'Goshev', '359888888888', 'EMName1', '359888888888', NULL),
(22222, 'Ivan', 'Ivanov', '359999999999', 'EMName2', '359999999999', NULL),
(333333, 'Pesho', 'Peshev', '359333333333', 'EMName3', '359333333333', NULL)


CREATE TABLE [RoomStatus](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[RoomStatus] BIT,
	[Notes] NVARCHAR(255)
)

INSERT INTO [RoomStatus]([RoomStatus], [Notes]) VALUES
(1,NULL),
(2,'Check the Room'),
(3,NULL)

CREATE TABLE [RoomTypes](
	[RoomType] VARCHAR(50) PRIMARY KEY,
	[Notes] NVARCHAR(255)
)
 
INSERT INTO RoomTypes (RoomType, Notes) VALUES
('BIG', NULL),
('SMALL', NULL),
('APARTMENT', 'OPTION FOR KIDS BEDS')

CREATE TABLE [BedTypes](
	[BedType] VARCHAR(50) PRIMARY KEY,
	[Notes] NVARCHAR(255)
)
 
INSERT INTO BedTypes VALUES
('ONE PERSON', NULL),
('TWO PERSON', NULL),
('FEW PERSON', 'One child')

CREATE TABLE [Rooms] (
	[RoomNumber] INT PRIMARY KEY IDENTITY NOT NULL,
	[RoomType] VARCHAR(50) FOREIGN KEY REFERENCES [RoomTypes]([RoomType]),
	[BedType] VARCHAR(50) FOREIGN KEY REFERENCES [BedTypes]([BedType]),
	[Rate] DECIMAL(5,2),
	[RoomStatus] NVARCHAR(50),
	[Notes] NVARCHAR(255)
)
 
INSERT INTO [Rooms] ([Rate], [Notes]) VALUES
(6,'FREE'),
(4, NULL),
(5, 'CLEANING IN PROGRESS')


CREATE TABLE [Payments](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
	[PaymentDate] DATE,
	[AccountNumber] BIGINT,
	[FirstDateOccupied] DATE,
	[LastDateOccupied] DATE,
	[TotalDays] AS DATEDIFF(DAY, [FirstDateOccupied], [LastDateOccupied]),
	[AmountCharged] DECIMAL(14,2),
	[TaxRate] DECIMAL(8, 2),
	[TaxAmount] DECIMAL(8, 2),
	[PaymentTotal] DECIMAL(15, 2),
	[Notes] NVARCHAR(255)
)
 
INSERT INTO [Payments] ([EmployeeId], [PaymentDate], [AmountCharged]) VALUES
(1, '1-11-2021', 2008),
(2, '2-11-2021', 1000.55),
(3, '3-11-2021', 800.30)
 
CREATE TABLE [Occupancies](
	[Id]  INT PRIMARY KEY IDENTITY NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
	[DateOccupied] DATE,
	[AccountNumber] BIGINT,
	[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms]([RoomNumber]),
	[RateApplied] DECIMAL(6,2),
	[PhoneCharge] DECIMAL(6,2),
	[Notes] NVARCHAR(255)
)
 
INSERT INTO [Occupancies] ([EmployeeId], [RateApplied], [Notes]) VALUES
(1, 55.55, NULL),
(2, 33.33, NULL),
(3, 77.77, NULL)
