--- Problem - 5

CREATE DATABASE [OnlineStore]

USE [OnlineStore]

CREATE TABLE [Cities](
	[CityID] INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Customers](
	[CustomerID] INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[Birthdate] DATE NOT NULL,
	[CityID] INT FOREIGN KEY([CityID]) REFERENCES [Cities]([CityID])
)

CREATE TABLE [Orders](
	[OrderID] INT PRIMARY KEY NOT NULL,
	[CustomerID] INT FOREIGN KEY([CustomerID]) REFERENCES [Customers]([CustomerID])
)

CREATE TABLE [ItemTypes](
	[ItemTypeID] INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Items](
	[ItemID] INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[ItemTypeID] INT FOREIGN KEY([ItemTypeID]) REFERENCES [ItemTypes]([ItemTypeID])
)

CREATE TABLE [OrderItems](
	[OrderID] INT FOREIGN KEY([OrderID]) REFERENCES [Orders]([OrderID]),
	[ItemID] INT FOREIGN KEY([ItemID]) REFERENCES [Items]([ItemID]),	
	CONSTRAINT Composite_PK_OrderID_ItemID PRIMARY KEY([OrderID],[ItemID])
)