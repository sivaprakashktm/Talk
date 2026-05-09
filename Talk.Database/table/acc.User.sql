CREATE TABLE [acc].[User](
	Id			INT				IDENTITY(1, 1),
	UserName	NVARCHAR(20)	NOT NULL,
	UserRoleId  INT				NULL,
	[Password]	NVARCHAR(20)	NOT NULL,
	IsActive	BIT				NOT NULL,
	CONSTRAINT Pk_User_Id PRIMARY KEY (Id),
	CONSTRAINT Fk_User_UserRole_UserRoleId FOREIGN KEY (UserRoleId) REFERENCES acc.UserRole(Id)
)