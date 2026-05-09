CREATE PROCEDURE acc.InsertProfile
(
	@FirstName NVARCHAR(20),
	@LastName NVARCHAR(20),
	@Email NVARCHAR(MAX),
	@Bio NVARCHAR(MAX),
	@UserId INT,
	@PictureId INT,
	@CreatedDate DATETIME
)
AS
BEGIN
	INSERT INTO [acc].[Profile] (FirstName, LastName, Email, Bio, UserId, PictureId, IsActive, CreatedDate)
	VALUES(@FirstName, @LastName, @Email, @Bio, @UserId, @PictureId, 1, @CreatedDate)

	SELECT CAST(SCOPE_IDENTITY() AS INT)
END