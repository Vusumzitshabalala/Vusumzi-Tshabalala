USE [Multiplex.Tea]
GO

--DECLARE @userId UNIQUEIDENTIFIER = (SELECT UserId FROM Users WHERE UserName = '0837811648')


IF NOT EXISTS(SELECT Name FROM Genders WHERE Name = 'Male' )
	BEGIN
		INSERT INTO Genders(Name,DisplayName,CreatedById,DateCreated,Active) VALUES ('Male','Male',NEWID(),GETDATE(),1)
	END
IF NOT EXISTS(SELECT Name FROM Genders WHERE Name = 'Female' )
	BEGIN
		INSERT INTO Genders(Name,DisplayName,CreatedById,DateCreated,Active) VALUES ('Female','Female',NEWID(),GETDATE(),1)
	END


