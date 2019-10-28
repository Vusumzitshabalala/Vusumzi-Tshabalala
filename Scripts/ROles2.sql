/****** Script for SelectTopNRows command from SSMS  ******/
SELECT * FROM [Tea].[dbo].UsersInRoles WHERE UserId = '678A3E54-51EE-4D38-918E-6CDEF162DA8E'
SELECT TOP 1000 
		R.[ApplicationId]
      ,R.[RoleId]
      ,[RoleName]
      ,[Description]
	  ,U.Username
	  ,UI.FirstName
	  ,UI.Surname
	  ,U.UserId
  FROM [Tea].[dbo].[Roles] R
  INNER JOIN [Tea].[dbo].UsersInRoles UR ON UR.RoleId = R.RoleId
  INNER JOIN [Tea].[dbo].Users U ON U.UserId = UR.UserId
  INNER JOIN Tea.dbo.UserInformations UI ON UI.UserId = U.UserId
  WHERE
	U.Username = '0837811648'
	--R.RoleName = 'Client'
	--R.RoleName = 'SuperAdministrator'
	--R.RoleName = 'Administrator'
	SELECT * FROM [Tea].[dbo].ROles
UPDATE Tea.dbo.Roles SET RoleName = 'SuperAdministrator', [Description] = 'Super Administrator' WHERE RoleName = 'Administrator'
UPDATE Tea.dbo.Roles SET RoleName = 'Administrator', [Description] = 'Administrator' WHERE RoleName = 'User'

UPDATE Users SET Username = '+27713922427' WHERE Username = '+27713922427'
INSERT INTO [Tea].[dbo].UsersInRoles ( UserId, RoleId ) VALUES  ('678A3E54-51EE-4D38-918E-6CDEF162DA8E','0BD9E087-AABF-40B1-8A4B-BF7261F30436')
INSERT INTO [Tea].[dbo].UsersInRoles ( UserId, RoleId ) VALUES  ('678A3E54-51EE-4D38-918E-6CDEF162DA8E','E0A9B40C-28FB-4121-9544-AD0B0EDEE561')

		  --DELETE FROM Tea.dbo.UsersInRoles WHERE UserId = '678A3E54-51EE-4D38-918E-6CDEF162DA8E' AND RoleId = '0BD9E087-AABF-40B1-8A4B-BF7261F30436'