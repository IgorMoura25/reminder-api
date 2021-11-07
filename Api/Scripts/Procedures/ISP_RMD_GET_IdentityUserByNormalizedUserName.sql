USE Reminder_Dev
GO

CREATE OR ALTER PROCEDURE [dbo].[ISP_RMD_GET_IdentityUserByNormalizedUserName]
(
	@NormalizedUserName VARCHAR(50),
	@UserId BIGINT
)
AS
BEGIN
	SELECT
		Users.UserId,
		Users.UserName 'UserName',
		Users.NormalizedUserName,
		Users.Email,
		Users.NormalizedEmail,
		Users.IsActive,
		Users.PasswordHash,
		Users.EmailConfirmed,
		Users.LockoutEnabled,
		Users.AccessFailedCount,
		Users.LockoutEnd
	FROM
		Users
	WHERE
		Users.NormalizedUserName = @NormalizedUserName
END