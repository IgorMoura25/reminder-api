USE [Reminder_Dev]
GO

CREATE OR ALTER PROCEDURE [dbo].[ISP_RMD_GET_IdentityUserByNormalizedEmail]
(
	@NormalizedEmail VARCHAR(100),
	@UserId BIGINT
)
AS
BEGIN
	SELECT
		Users.UserId
	FROM
		Users
	WHERE
		Users.NormalizedEmail = @NormalizedEmail
END