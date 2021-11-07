USE Reminder_Dev
GO

CREATE OR ALTER PROCEDURE [dbo].[ISP_RMD_UPD_IdentityUserById]
(
	@OperationUserId BIGINT,
	@UserName VARCHAR(50),
	@NormalizedUserName VARCHAR(50),
	@Email VARCHAR(100),
	@NormalizedEmail VARCHAR(100),
	@PasswordHash VARCHAR(MAX),
	@EmailConfirmed BIT,
	@LockoutEnabled BIT,
	@AccessFailedCount INT,
	@LockoutEnd DATETIME = NULL,
	@UserId BIGINT
)
AS
BEGIN
	UPDATE
		Users
	SET
		UserName = @UserName,
		NormalizedUserName = @NormalizedUserName,
		Email = @Email,
		NormalizedEmail = @NormalizedEmail,
		PasswordHash = @PasswordHash,
		EmailConfirmed = @EmailConfirmed,
		LockoutEnabled = @LockoutEnabled,
		AccessFailedCount = @AccessFailedCount,
		LockoutEnd = @LockoutEnd
	WHERE
		Users.UserId = @OperationUserId
END