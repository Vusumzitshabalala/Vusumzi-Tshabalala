USE [HospitalManagementSystem]
GO

DECLARE @applicationId UNIQUEIDENTIFIER = (SELECT ApplicationId FROM Applications WHERE ApplicationName = 'HospitalManagementSystem')

IF NOT EXISTS(SELECT RoleId FROM Roles WHERE RoleName = 'SuperAdministrator' AND ApplicationId = @applicationId )
	BEGIN
		INSERT INTO Roles (RoleId,ApplicationId, RoleName, [Description]) VALUES(NEWID(),@applicationId,'SuperAdministrator','Super Administrator')
	END

IF NOT EXISTS(SELECT RoleId FROM Roles WHERE RoleName = 'Administrator' AND ApplicationId = @applicationId )
	BEGIN
		INSERT INTO Roles (RoleId, ApplicationId, RoleName, [Description]) VALUES(NEWID(), @applicationId,'Administrator','Administrator')
	END

IF NOT EXISTS(SELECT RoleId FROM Roles WHERE RoleName = 'Patient' AND ApplicationId = @applicationId )
	BEGIN
		INSERT INTO Roles (RoleId,ApplicationId, RoleName, [Description]) VALUES(NEWID(),@applicationId,'Patient','Patient')
	END

IF NOT EXISTS(SELECT RoleId FROM Roles WHERE RoleName = 'Doctor' AND ApplicationId = @applicationId )
	BEGIN
		INSERT INTO Roles (RoleId,ApplicationId, RoleName, [Description]) VALUES(NEWID(),@applicationId,'Doctor','Doctor')
	END

IF NOT EXISTS(SELECT RoleId FROM Roles WHERE RoleName = 'Nurse' AND ApplicationId = @applicationId )
	BEGIN
		INSERT INTO Roles (RoleId,ApplicationId, RoleName, [Description]) VALUES(NEWID(),@applicationId,'Nurse','Nurse')
	END

IF NOT EXISTS(SELECT RoleId FROM Roles WHERE RoleName = 'Porter' AND ApplicationId = @applicationId )
	BEGIN
		INSERT INTO Roles (RoleId,ApplicationId, RoleName, [Description]) VALUES(NEWID(),@applicationId,'Porter','Porter')
	END

DECLARE @thabisomId UNIQUEIDENTIFIER = (SELECT UserId FROM Users WHERE UserName = '0837811648')
DECLARE @vusiId UNIQUEIDENTIFIER = (SELECT UserId FROM Users WHERE UserName = '0730342074')

DECLARE @adminId UNIQUEIDENTIFIER = (SELECT TOP 1 RoleId FROM Roles WHERE RoleName = 'SuperAdministrator')
DECLARE @roleId UNIQUEIDENTIFIER = (SELECT TOP 1 RoleId FROM Roles WHERE RoleName = 'Administrator')

IF NOT EXISTS(SELECT * FROM UsersInRoles WHERE UserId = @thabisomId AND RoleId = @adminId  ) AND @thabisomId IS NOT NULL
	BEGIN
		INSERT INTO UsersInRoles(UserId,RoleId) VALUES(@thabisomId,@adminId)
	END
    
IF NOT EXISTS(SELECT * FROM UsersInRoles WHERE UserId = @thabisomId AND RoleId = @roleId  ) AND @thabisomId IS NOT NULL
	BEGIN
		INSERT INTO UsersInRoles(UserId,RoleId) VALUES(@thabisomId,@roleId)
	END

IF NOT EXISTS(SELECT * FROM UsersInRoles WHERE UserId = @vusiId AND RoleId = @roleId  ) AND @vusiId IS NOT NULL
	BEGIN
		INSERT INTO UsersInRoles(UserId,RoleId) VALUES(@vusiId,@roleId)
	END