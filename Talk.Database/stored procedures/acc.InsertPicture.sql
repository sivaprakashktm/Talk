CREATE PROCEDURE [acc].[InsertPicture]
(
	@Image VARBINARY(MAX),
	@CreatedUserId INT,
	@CreatedDate DATETIME
)
AS
BEGIN
	INSERT INTO [acc].[picture]([Image], CreatedUserId, CreatedDate, IsActive)
	VALUES (@Image, @CreatedUserId, @CreatedDate, 1)

	SELECT CAST(SCOPE_IDENTITY() AS INT);
END