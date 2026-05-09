CREATE PROCEDURE acc.GetAllContacts
AS
BEGIN
	SELECT usr.Id UserId, pfl.Id ProfileId, usr.UserName, pfl.FirstName, pfl.LastName, pfl.Email, ptr.[Image]
	FROM [acc].[User] usr
	INNER JOIN [acc].[Profile] pfl ON usr.Id = pfl.UserId AND pfl.IsActive = 1
	LEFT JOIN [acc].[Picture] ptr ON pfl.PictureId = ptr.Id AND ptr.IsActive = 1
	WHERE usr.IsActive = 1
END