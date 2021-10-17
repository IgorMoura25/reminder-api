USE Reminder_Dev
GO

CREATE OR ALTER PROCEDURE [dbo].[ISP_RMD_DEL_UserById]
(
	@OperationUserId BIGINT,
	@UserId BIGINT
)
AS
BEGIN
	
	DELETE FROM
		Users
	WHERE
		Users.UserId = @OperationUserId

END
GO