CREATE PROCEDURE [acc].[GetUserNameByEmail]
(
	@Email NVARCHAR(20) NULL,
	@IsActive BIT NULL
)
AS
BEGIN
	SELECT usr.UserName FROM [acc].[Profile] pro
	INNER JOIN [acc].[User] usr ON pro.UserId = usr.Id AND usr.IsActive = ISNULL(@IsActive, usr.IsActive)
	WHERE pro.Email = @Email AND pro.IsActive = ISNULL(@IsActive, pro.IsActive)
END