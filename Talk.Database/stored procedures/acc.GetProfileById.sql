CREATE PROCEDURE acc.GetProfileById
(
	@ProfileId INT
)
AS
BEGIN
	SELECT	pro.Id, pro.FirstName, pro.LastName, pro.Email, pro.Bio, pro.UserId, pro.UserId, usr.UserName, pro.PictureId,
	pro.CreatedDate, pro.ModifiedDate
	FROM [acc].[Profile] pro
	INNER JOIN [acc].[User] usr ON pro.UserId = usr.Id AND usr.IsActive = 1
	LEFT JOIN [acc].[Picture] ptr ON pro.PictureId = ptr.Id AND ptr.IsActive = 1
	WHERE pro.Id = @ProfileId AND pro.IsActive = 1
END