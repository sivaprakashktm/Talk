CREATE PROCEDURE acc.CheckEmailAvailablity
(
	@Email NVARCHAR(20)
)
AS
BEGIN
	SELECT COUNT(*) FROM [acc].[Profile] pro
	WHERE pro.Email = @Email
END