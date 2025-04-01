CREATE DATABASE SkincareProductSystem;
GO

USE SkincareProductSystem;
GO

CREATE TABLE Brand (
  BrandId     int IDENTITY NOT NULL,
  [Name]      nvarchar(100) NOT NULL,
  IsAvailable bit NOT NULL,
  Username    varchar(50) NOT NULL,
  PRIMARY KEY (BrandId));

CREATE TABLE Category (
  CategoryId  int IDENTITY NOT NULL, 
  [Name]      nvarchar(50) NOT NULL,
  IsAvailable bit NOT NULL, 
  Username    varchar(50) NOT NULL, 
  PRIMARY KEY (CategoryId));

CREATE TABLE [Order] (
  OrderId     int IDENTITY NOT NULL, 
  DateCreated date NOT NULL, 
  Username    varchar(50) NOT NULL, 
  PRIMARY KEY (OrderId));

CREATE TABLE OrderDetails (
  OrderId           int NOT NULL, 
  SkincareProductId int NOT NULL, 
  Quantity			int NOT NULL,
  TotalPrice		decimal(9, 2) NOT NULL, 
  PRIMARY KEY (OrderId, SkincareProductId));

CREATE TABLE Question (
  QuestionId int IDENTITY NOT NULL, 
  Title      nvarchar(255) NOT NULL, 
  Answer     nvarchar(255) NOT NULL, 
  [Type]     varchar(50) NOT NULL, 
  PRIMARY KEY (QuestionId));

CREATE TABLE [Role] (
  RoleId int IDENTITY NOT NULL, 
  [Name] varchar(30) NOT NULL, 
  PRIMARY KEY (RoleId));

CREATE TABLE SkincareProduct (
  SkincareProductId int IDENTITY NOT NULL, 
  [Name]            nvarchar(150) NOT NULL, 
  [Description]     nvarchar(255) NULL, 
  Capacity          varchar(100) NULL, 
  UnitPrice         decimal(9, 2) NOT NULL, 
  Quantity			int NOT NULL,
  [Image]			varchar(255) NOT NULL,
  IsAvailable       bit NOT NULL, 
  CategoryId        int NOT NULL, 
  BrandId           int NOT NULL, 
  Username          varchar(50) NOT NULL, 
  PRIMARY KEY (SkincareProductId));

CREATE TABLE TypeOfSkin (
  TypeOfSkinId int IDENTITY NOT NULL, 
  [Name]       nvarchar(255) NOT NULL, 
  PRIMARY KEY (TypeOfSkinId));

CREATE TABLE [User] (
  Username     varchar(50) NOT NULL, 
  [Password]   varchar(50) NOT NULL, 
  Fullname     nvarchar(100) NOT NULL, 
  Gender	   nvarchar(5) NOT NULL,
  IsActive     bit NOT NULL, 
  RoleId       int NOT NULL, 
  TypeOfSkinId int NOT NULL, 
  PRIMARY KEY (Username));

ALTER TABLE SkincareProduct ADD CONSTRAINT FKSkincarePr66470 FOREIGN KEY (CategoryId) REFERENCES Category (CategoryId);
ALTER TABLE SkincareProduct ADD CONSTRAINT FKSkincarePr37782 FOREIGN KEY (BrandId) REFERENCES Brand (BrandId);
ALTER TABLE [User] ADD CONSTRAINT FKUser68428 FOREIGN KEY (RoleId) REFERENCES [Role] (RoleId);
ALTER TABLE Brand ADD CONSTRAINT FKBrand47697 FOREIGN KEY (Username) REFERENCES [User] (Username);
ALTER TABLE Category ADD CONSTRAINT FKCategory337703 FOREIGN KEY (Username) REFERENCES [User] (Username);
ALTER TABLE SkincareProduct ADD CONSTRAINT FKSkincarePr229752 FOREIGN KEY (Username) REFERENCES [User] (Username);
ALTER TABLE [Order] ADD CONSTRAINT FKOrder39294 FOREIGN KEY (Username) REFERENCES [User] (Username);
ALTER TABLE OrderDetails ADD CONSTRAINT FKOrderDetai351167 FOREIGN KEY (OrderId) REFERENCES [Order] (OrderId);
ALTER TABLE OrderDetails ADD CONSTRAINT FKOrderDetai412706 FOREIGN KEY (SkincareProductId) REFERENCES SkincareProduct (SkincareProductId);
ALTER TABLE [User] ADD CONSTRAINT FKUser447311 FOREIGN KEY (TypeOfSkinId) REFERENCES TypeOfSkin (TypeOfSkinId);
