USE master
GO

--drop database if it exists
 --alter database [PotholeTracker] set single_user with rollback immediate

 drop database [PotholeTracker]
CREATE DATABASE PotholeTracker;
GO

USE PotholeTracker
GO

-- ************************************** [Users]
--drop table Users
CREATE TABLE [Users]
(
 [user_id]      int IDENTITY (1,1) NOT NULL ,
 [username]     nvarchar(50) NOT NULL ,
 [password_hash] nvarchar(50) NOT NULL ,
 [salt]         nvarchar(50) NOT NULL ,
 [user_role]    nvarchar(50) NOT NULL ,
 [FirstName]   nvarchar(100) NULL ,
 [LastName]    nvarchar(100) NULL ,
 [Email]       nvarchar(50) NULL ,
 [PhoneNumber] nvarchar(50) NULL ,



 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED ([user_id] ASC)
);
GO



---- ************************************** [Pothole]
--drop table Pothole
CREATE TABLE [Pothole]
(
 [Id]          int IDENTITY (1, 1) NOT NULL ,
 [Location]    nvarchar(100) NOT NULL ,
 [DateAdded]   datetime NOT NULL ,
 [Description] nvarchar(200) NOT NULL ,
 [Status]      int NOT NULL DEFAULT 1 ,
 [Severity]    int NOT NULL DEFAULT 0,
 [user_id]     int NULL ,


 CONSTRAINT [PK_pothole] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_141] FOREIGN KEY ([user_id])  REFERENCES [Users]([user_id])
);
GO


CREATE NONCLUSTERED INDEX [fkIdx_141] ON [Pothole] 
 (
  [user_id] ASC
 )

GO




--populate default data

INSERT INTO users (username, password_hash, salt, user_role, FirstName, LastName, Email, PhoneNumber) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user', 'Ricky', 'Cerny', 'rcerny@yahoo.com', '1111111111');

INSERT INTO users (username, password_hash, salt, user_role, FirstName, LastName, Email) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin',  'Dan', 'Goepfert', 'dg@yahoo.com');


-- user info 


--Add a couple potholes
INSERT INTO Pothole ([Location], DateAdded, [Description])
	VALUES ('123 Main Street, Cleveland, OH, 44107', '08/03/2020', 'Bad Pothole')
INSERT INTO Pothole ([Location], DateAdded, [Description])
	VALUES ('980 Athens Street, Cleveland, OH, 44107', '08/03/2020', 'Badderest Pothole')
INSERT INTO Pothole ([Location], DateAdded, [Description])
	VALUES ('564 Clark Street, Cleveland, OH, 44107', '08/03/2020', 'Badder Pothole')
