Use [Tea]
/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [ApplicationId]
      ,[UserId]
      ,[UserName]
      ,[IsAnonymous]
      ,[LastActivityDate]
  FROM [dbo].[Users]
  WHERE UserId NOT IN (Select UserId FROM  [dbo].UserInformations)

  DELETE FROM UsersInRoles WHERE UserId IN ('43E3C1B8-4379-4EEF-A375-9F417A9AE42D')
  DELETE FROM Memberships WHERE UserId IN ('43E3C1B8-4379-4EEF-A375-9F417A9AE42D')
  DELETE FROM Users WHERE UserId IN ('43E3C1B8-4379-4EEF-A375-9F417A9AE42D')

  SELECT * FROM UserInformations WHERE Cellphone = 0808080808--0617243266
  --DELETE FROM UserInformations WHERE Id  = 2022

  SELECT * FROm Users WHERE UserName = 0808080808--0617243266

  UPDATE USers SET Username = 0713922427 WHERE UserName = '+27713922427'
  SELECT * FROM dbo.UserInformations WHERE Cellphone = '+27713922427'
 --DELETE FROM Memberships WHERE UserId = '1191960D-9E7B-4879-A38B-C1FBCBC18012'
  --DELETE FROM Users WHERE UserId  = '1191960D-9E7B-4879-A38B-C1FBCBC18012'
