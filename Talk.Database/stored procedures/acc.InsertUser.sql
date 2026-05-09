CREATE PROCEDURE [acc].[InsertUser]
(
	@UserName NVARCHAR(20),
	@Password NVARCHAR(20),
	@UserRoleId INT
)
AS
BEGIN
	INSERT INTO [acc].[User](UserName, [Password], UserRoleId, IsActive)
	VALUES (@UserName, @Password, @UserRoleId, 1)

	SELECT CAST(SCOPE_IDENTITY() AS INT)
END