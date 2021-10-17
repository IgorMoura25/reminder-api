USE [Reminder_Dev]
GO

CREATE OR ALTER PROCEDURE [dbo].[ISP_RMD_GET_IdentityUserById]
(
	@OperationUserId BIGINT,
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
		Users.EmailConfirmed
	FROM
		Users
	WHERE
		Users.UserId = @OperationUserId
END