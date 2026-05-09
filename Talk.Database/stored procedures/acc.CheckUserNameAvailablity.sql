CREATE PROCEDURE acc.CheckUserNameAvailablity
(
	@UserName NVARCHAR(20) NULL,
	@IsActive BIT NULL
)
AS
BEGIN
	SELECT COUNT(*) FROM [acc].[User]
	WHERE UserName = @UserName AND IsActive = ISNULL(@IsActive, IsActive)
END