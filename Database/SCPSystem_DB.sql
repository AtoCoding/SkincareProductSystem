CREATE DATABASE SkincareProductSystem;
GO

USE SkincareProductSystem;
GO

CREATE TABLE Brand (
  BrandId     int IDENTITY NOT NULL, 
  Name        nvarchar(100) NOT NULL, 
  IsAvailable bit NOT NULL, 
  Username    varchar(50) NOT NULL, 
  PRIMARY KEY (BrandId));

CREATE TABLE Category (
  CategoryId  int IDENTITY NOT NULL, 
  Name        nvarchar(50) NOT NULL, 
  Quantity    int NOT NULL, 
  IsAvailable bit NOT NULL, 
  Username    varchar(50) NOT NULL, 
  PRIMARY KEY (CategoryId));

CREATE TABLE Role (
  RoleId int IDENTITY NOT NULL, 
  Name   varchar(30) NOT NULL, 
  PRIMARY KEY (RoleId));

CREATE TABLE SkincareProduct (
  SkincareProductId int IDENTITY NOT NULL, 
  Name              nvarchar(255) NOT NULL, 
  Description       nvarchar(255) NOT NULL, 
  Capacity          varchar(50) NOT NULL, 
  UnitPrice         decimal(9, 2) NOT NULL, 
  IsAvailable       bit NOT NULL, 
  CategoryId        int NOT NULL, 
  BrandId           int NOT NULL, 
  Username          varchar(50) NOT NULL, 
  PRIMARY KEY (SkincareProductId));

CREATE TABLE [User] (
  Username varchar(50) NOT NULL, 
  Password varchar(50) NOT NULL, 
  Fullname nvarchar(100) NOT NULL, 
  Gender   nvarchar(10) NOT NULL,
  IsActive bit NOT NULL, 
  RoleId   int NOT NULL, 
  PRIMARY KEY (Username));

ALTER TABLE SkincareProduct ADD CONSTRAINT FKSkincarePr66470 FOREIGN KEY (CategoryId) REFERENCES Category (CategoryId);
ALTER TABLE SkincareProduct ADD CONSTRAINT FKSkincarePr37782 FOREIGN KEY (BrandId) REFERENCES Brand (BrandId);
ALTER TABLE [User] ADD CONSTRAINT FKUser68428 FOREIGN KEY (RoleId) REFERENCES Role (RoleId);
ALTER TABLE Brand ADD CONSTRAINT FKBrand47697 FOREIGN KEY (Username) REFERENCES [User] (Username);
ALTER TABLE Category ADD CONSTRAINT FKCategory337703 FOREIGN KEY (Username) REFERENCES [User] (Username);
ALTER TABLE SkincareProduct ADD CONSTRAINT FKSkincarePr229752 FOREIGN KEY (Username) REFERENCES [User] (Username);
