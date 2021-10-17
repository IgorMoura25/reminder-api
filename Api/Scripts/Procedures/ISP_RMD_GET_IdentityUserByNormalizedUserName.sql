﻿USE Reminder_Dev
GO

CREATE OR ALTER PROCEDURE [dbo].[ISP_RMD_GET_IdentityUserByNormalizedUserName]
(
	@NormalizedUserName VARCHAR(50)
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
		Users.NormalizedUserName = @NormalizedUserName
END