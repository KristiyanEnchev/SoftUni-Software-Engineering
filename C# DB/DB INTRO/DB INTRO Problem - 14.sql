---- PROBLEM -14
CREATE DATABASE [CarRental]

USE [CarRental]

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY NOT NULL,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[DailyRate] DECIMAL(5,2) NOT NULL,
	[WeeklyRate] DECIMAL(5,2) NOT NULL,
	[MonthlyRate] DECIMAL(5,2) NOT NULL,
	[WeekendRate] DECIMAL(5,2) NOT NULL
)

CREATE TABLE [Cars](
	[Id] INT PRIMARY KEY  NOT NULL,
	[PlateNumber] NVARCHAR(10) NOT NULL,
	[Manufacturer] NVARCHAR(20) NOT NULL,
	[Model] NVARCHAR(20) NOT NULL,
	[CarYear] DATE NOT NULL,
	[CategoryId]INT FOREIGN KEY([CategoryId]) REFERENCES [Categories](Id),
	[Doors] INT NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK ([Picture] <= 2000000),
	[Condition] NVARCHAR(10) NOT NULL,
	CHECK ([Condition] = 'NEW' OR [Condition] = 'USED'),
	[Available] BIT NOT NULL,
)

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY  NOT NULL,
	[FirstName] NVARCHAR(20) NOT NULL,
	[LastName] NVARCHAR(20) NOT NULL,
	[Title] NVARCHAR(20) NOT NULL,
	[Notes] NVARCHAR(255),
)

CREATE TABLE [Customers](
	[Id] INT PRIMARY KEY  NOT NULL,
	[DriverLicenceNumber] NVARCHAR(20) UNIQUE NOT NULL,
	[FullName] NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(100) NOT NULL,
	[City] NVARCHAR(20) NOT NULL,
	[ZIPCode] INT NOT NULL,
	[Notes] NVARCHAR(255),
)

CREATE TABLE [RentalOrders](
	[Id] INT PRIMARY KEY  NOT NULL,
	[EmployeeId] INT FOREIGN KEY ([EmployeeId]) REFERENCES [Employees](Id) NOT NULL,
	[CustomerId] INT FOREIGN KEY ([CustomerId]) REFERENCES [Customers](Id) NOT NULL,
	[CarId] INT FOREIGN KEY ([CarId]) REFERENCES [Cars](Id)NOT NULL,
	[TankLevel] DECIMAL (5,2) NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] INT NOT NULL,
	[StartDate] DATE NOT NULL,
	[EndDate] DATE NOT NULL,
	[TotalDays] INT NOT NULL,
	[RateApplied] DECIMAL(5,2) NOT NULL,
	[TaxRate] DECIMAL (5,2) NOT NULL,
	[OrderStatus] NVARCHAR(12)NOT NULL,
	CHECK ([OrderStatus] = 'COMPLATE' OR [OrderStatus] = 'NOT COMPLATE'),
	[Notes] NVARCHAR(255),
)

INSERT INTO [Categories]([Id],[CategoryName],[DailyRate],[WeeklyRate],[MonthlyRate],[WeekendRate]) VALUES
(1,'Category1',1.20,2.20,3.20,4.20),
(2,'Category2',5.20,6.20,7.20,8.20),
(3,'Category3',7.20,8.20,9.20,10.20)

INSERT INTO [Cars]([Id],[PlateNumber],[Manufacturer],[Model],[CarYear],[CategoryId],[Doors],[Picture],[Condition],[Available]) VALUES
(2, 'SS5555AA','BMW','E63','2020-01-01',2,5,NULL,'USED',0),
(1, 'SS3333AA','Tesla','Model Y','2021-01-01',1,5,NULL,'USED',1),
(3, 'SS7777AA','Mercedes','C300','2019-01-01',3,5,NULL,'NEW',1)

INSERT INTO [Employees]([Id],[FirstName],[LastName],[Title],[Notes]) VALUES
(1,'Stanimir','Stamatov', 'Director', NULL),
(2,'Gosho','Petrov', 'Manager', 'note2'),
(3,'Joro','Jorev', 'Sales', 'note3')

INSERT INTO [Customers]([Id],[DriverLicenceNumber],[FullName],[Address],[City],[ZIPCode],[Notes]) VALUES
(1, 11111,'Stanimir Stamatov','ALABIN','SOFIA', 1000, NULL),
(2, 222222,'Gosho Petrov','CHERVEN PLOSHTAD','VARNA', 9000, NULL),
(3, 333333,'Joro Jorev','OPYLCHENIE','SILISTRA', 7500, 'note3')

INSERT INTO [RentalOrders]
([Id],[EmployeeId],[CustomerId],[CarId],[TankLevel],[KilometrageStart],[KilometrageEnd],[TotalKilometrage],[StartDate],[EndDate],[TotalDays],[RateApplied],[TaxRate],[OrderStatus],[Notes])
VALUES
(1,3,2,1,15.31,7234,7265,33,'2010-01-01','2010-01-10',10,1.4,1.1,'COMPLATE',NULL),
(2,2,1,3,22.54,1555,1566,33,'2011-02-02','2011-02-11',10,2.2,2.1,'COMPLATE',NULL),
(3,1,3,2,68.55,85667,85679,33,'2012-03-03','2012-03-11',10,3.4,3,'NOT COMPLATE',NULL)