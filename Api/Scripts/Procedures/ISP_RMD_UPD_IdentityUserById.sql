USE Reminder_Dev
GO

CREATE OR ALTER PROCEDURE [dbo].[ISP_RMD_UPD_IdentityUserById]
(
	@OperationUserId UNIQUEIDENTIFIER,
	@UserName VARCHAR(50),
	@NormalizedUserName VARCHAR(50),
	@Email VARCHAR(100),
	@NormalizedEmail VARCHAR(100),
	@PasswordHash VARCHAR(MAX),
	@EmailConfirmed BIT,
	@UserId UNIQUEIDENTIFIER
)
AS
BEGIN
	UPDATE
		Users
	SET
		UserId = @OperationUserId,
		UserName = @UserName,
		NormalizedUserName = @NormalizedUserName,
		Email = @Email,
		NormalizedEmail = @NormalizedEmail,
		PasswordHash = @PasswordHash,
		EmailConfirmed = @EmailConfirmed
	WHERE
		Users.UserId = @OperationUserId
END