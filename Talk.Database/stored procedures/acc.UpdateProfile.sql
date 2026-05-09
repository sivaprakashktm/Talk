CREATE PROCEDURE acc.UpdateProfile
(
	@ProfileId INT,
	@FirstName NVARCHAR(20),
	@LastName NVARCHAR(20),
	@Email NVARCHAR(20),
	@Bio NVARCHAR(MAX),
	@UserId INT,
	@PictureId INT,
	@ModifiedDate DATETIME,
	@IsActive BIT
)
AS
BEGIN
	UPDATE pro
	SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Bio = @Bio, UserId = @UserId, PictureId = @PictureId, ModifiedDate = @ModifiedDate, IsActive = @IsActive
	FROM [acc].[Profile] pro
	WHERE pro.Id = @PictureId
END