USE master
GO

--drop database if it exists
IF DB_ID('PotholeTracker') IS NOT NULL
BEGIN
	ALTER DATABASE PotholeTracker SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE PotholeTracker;
END

CREATE DATABASE PotholeTracker
GO

USE PotholeTracker
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

--Pothole Table
CREATE TABLE [Pothole]
(
 [Id]          int IDENTITY (1, 1) NOT NULL ,
 [Location]    nvarchar(100) NOT NULL ,
 [DateAdded]   datetime NOT NULL ,
 [Description] nvarchar(200) NOT NULL ,


 CONSTRAINT [PK_pothole] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- [PotholeStatus]

CREATE TABLE [PotholeStatus]
(
 [Reported]   bit NOT NULL ,
 [InProgress] bit NOT NULL ,
 [Repaired]   bit NOT NULL ,
 [Id]         int NOT NULL ,


 CONSTRAINT [FK_30] FOREIGN KEY ([Id])  REFERENCES [Pothole]([Id])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_30] ON [PotholeStatus] 
 (
  [Id] ASC
 )

GO


--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO