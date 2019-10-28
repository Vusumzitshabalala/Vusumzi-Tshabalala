--CREATE TABLE dbo.Tmp_Names
--            (
--            Id int NOT NULL IDENTITY (1, 1),
--            Name varchar(50) NULL
--            )  ON [PRIMARY]
 
--go
--SET IDENTITY_INSERT dbo.Tmp_Names ON
 
--go
--IF EXISTS(SELECT * FROM dbo.Names)
--            INSERT INTO dbo.Tmp_Names (Id, Name)
--                        SELECT Id, Name FROM dbo.Names TABLOCKX
 
--go
--SET IDENTITY_INSERT dbo.Tmp_Names OFF
 
--go
--DROP TABLE dbo.Names
 
--go
 
--Exec sp_rename 'Tmp_Names', 'Names'

USE [TeaTesting]
GO

/****** Object:  Table [dbo].[Genders_]    Script Date: 2016-04-28 11:35:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genders](
	[Id] [int] NOT NULL IDENTITY (1, 1),
	[Name] [nvarchar](100) NOT NULL,
	[DisplayName] [nvarchar](150) NOT NULL,
	[CreatedById] [uniqueidentifier] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ModifiedById] [uniqueidentifier] NULL,
	[DateModified] [datetime] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Genders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
go
SET IDENTITY_INSERT dbo.Genders ON
 
go
IF EXISTS(SELECT * FROM dbo.Genders_)
            INSERT INTO dbo.Genders (Id, Name,[DisplayName],[CreatedById],[DateCreated],[ModifiedById],[DateModified],[Active])
                        SELECT * FROM dbo.Genders_ TABLOCKX
 
go
SET IDENTITY_INSERT dbo.Genders OFF
 
go
--DROP TABLE dbo.Genders_
 
go

