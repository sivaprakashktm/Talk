CREATE PROCEDURE acc.IsPasswordMatchedByUserName
(
	@UserName NVARCHAR(20),
	@Password NVARCHAR(20)
)
AS
BEGIN
	SELECT COUNT(*) FROM [acc].[User]
	WHERE UserName = @UserName AND [Password] = @Password AND IsActive = 1
END