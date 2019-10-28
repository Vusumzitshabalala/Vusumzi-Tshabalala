--USE [Multiplex.Tea]
--USE [TeaTesting]
USE [TeaLive]
GO

ALTER TABLE Categories ADD [Pictogram] [VARBINARY](MAX) NULL
ALTER TABLE Categories ADD [PictogramFileName] [VARCHAR](256) NULL