USE Reminder_Dev
GO

CREATE OR ALTER PROCEDURE [dbo].[ISP_RMD_ADD_IdentityUser]
(
	@OperationUserId UNIQUEIDENTIFIER,
	@UserName VARCHAR(50),
	@NormalizedUserName VARCHAR(50),
	@Email VARCHAR(100),
	@NormalizedEmail VARCHAR(100),
	@PasswordHash VARCHAR(MAX),
	@IsActive BIT,
	@CreatedAt DATETIME,
	@UserId UNIQUEIDENTIFIER
)
AS
BEGIN
	INSERT INTO
		Users
	(
		UserId,
		UserName,
		NormalizedUserName,
		Email,
		NormalizedEmail,
		PasswordHash,
		IsActive,
		EmailConfirmed,
		CreatedAt
	)
	OUTPUT Inserted.UserId
	VALUES
	(
		@OperationUserId,
		@UserName,
		@NormalizedUserName,
		@Email,
		@NormalizedEmail,
		@PasswordHash,
		@IsActive,
		0,
		@CreatedAt
	)
END