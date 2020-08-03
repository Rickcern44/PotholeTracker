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
 [Id]          int IDENTITY (1, 1) NOT NULL,
 [Location]    nvarchar(100) NOT NULL,
 [DateAdded]   datetime NOT NULL,
 [Description] nvarchar(200) NOT NULL,
 Status int NOT NULL DEFAULT 1


 CONSTRAINT [PK_pothole] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO









--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');


--Add a couple potholes
INSERT INTO Pothole ([Location], DateAdded, [Description])
	VALUES ('123 Main Street, Cleveland, OH, 44107', '08/03/2020', 'Bad Pothole')
INSERT INTO Pothole ([Location], DateAdded, [Description])
	VALUES ('980 Athens Street, Cleveland, OH, 44107', '08/03/2020', 'Badderest Pothole')
INSERT INTO Pothole ([Location], DateAdded, [Description])
	VALUES ('564 Clark Street, Cleveland, OH, 44107', '08/03/2020', 'Badder Pothole')
