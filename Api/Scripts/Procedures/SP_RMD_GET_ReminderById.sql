USE Reminder_Dev
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_RMD_GET_ReminderById]
(
	@ReminderId VARCHAR(68),
	@UserId VARCHAR(68)
)
AS
BEGIN
	SELECT
		Reminders.ReminderId,
		Reminders.ReminderStatusId,
        Reminders.Deadline,
        Reminders.IsActive,
        Reminders.CreatedAt,
        Reminders.CreatedBy
	FROM
		Reminders
	WHERE
		Reminders.ReminderId = @ReminderId
END