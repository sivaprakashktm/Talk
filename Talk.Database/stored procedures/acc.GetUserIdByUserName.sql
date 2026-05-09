CREATE PROCEDURE acc.GetUserIdByUserName
(
	@UserName NVARCHAR(20)
)
AS
BEGIN
	SELECT Id FROM [acc].[User]
	WHERE UserName = @UserName AND IsActive = 1
END