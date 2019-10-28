USE [Multiplex.Tea]
GO

DECLARE @applicationId UNIQUEIDENTIFIER = (SELECT ApplicationId FROM Applications WHERE ApplicationName = 'Tea')

IF NOT EXISTS(SELECT RoleId FROM Roles WHERE RoleName = 'Administrator' AND ApplicationId = @applicationId )
	BEGIN
		INSERT INTO Roles (RoleId, ApplicationId, RoleName, [Description]) VALUES(NEWID(), @applicationId,'Administrator','Administrator')
	END

IF NOT EXISTS(SELECT RoleId FROM Roles WHERE RoleName = 'Client' AND ApplicationId = @applicationId )
	BEGIN
		INSERT INTO Roles (RoleId,ApplicationId, RoleName, [Description]) VALUES(NEWID(),@applicationId,'Client','Client')
	END

IF NOT EXISTS(SELECT RoleId FROM Roles WHERE RoleName = 'SuperAdministrator' AND ApplicationId = @applicationId )
	BEGIN
		INSERT INTO Roles (RoleId,ApplicationId, RoleName, [Description]) VALUES(NEWID(),@applicationId,'SuperAdministrator','Super Administrator')
	END

DECLARE @thabisomId UNIQUEIDENTIFIER = (SELECT UserId FROM Users WHERE UserName = '0837811648')
DECLARE @roleId UNIQUEIDENTIFIER = (SELECT TOP 1 RoleId FROM Roles WHERE RoleName = 'Administrator')
DECLARE @adminId UNIQUEIDENTIFIER = (SELECT TOP 1 RoleId FROM Roles WHERE RoleName = 'SuperAdministrator')

IF NOT EXISTS(SELECT * FROM UsersInRoles WHERE UserId = @thabisomId AND RoleId = @roleId  ) AND @thabisomId IS NOT NULL
	BEGIN
		INSERT INTO UsersInRoles(UserId,RoleId) VALUES(@thabisomId,@roleId)
	END