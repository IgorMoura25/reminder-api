USE Reminder_Dev
GO

CREATE OR ALTER PROCEDURE [dbo].[ISP_RMD_ADD_IdentityUser]
(
	@UserName VARCHAR(50),
	@NormalizedUserName VARCHAR(50),
	@Email VARCHAR(100),
	@NormalizedEmail VARCHAR(100),
	@PasswordHash VARCHAR(MAX),
	@IsActive BIT,
	@EmailConfirmed BIT,
	@CreatedAt DATETIME,
	@LockoutEnabled BIT,
	@AccessFailedCount INT,
	@LockoutEnd DATETIME = NULL,
	@UserId BIGINT
)
AS
BEGIN
	INSERT INTO
		Users
	(
		UserName,
		NormalizedUserName,
		Email,
		NormalizedEmail,
		PasswordHash,
		IsActive,
		EmailConfirmed,
		CreatedAt,
		LockoutEnabled,
		AccessFailedCount,
		LockoutEnd
	)
	VALUES
	(
		@UserName,
		@NormalizedUserName,
		@Email,
		@NormalizedEmail,
		@PasswordHash,
		@IsActive,
		@EmailConfirmed,
		@CreatedAt,
		@LockoutEnabled,
		@AccessFailedCount,
		@LockoutEnd
	)

	SELECT CONVERT(BIGINT, SCOPE_IDENTITY())
END