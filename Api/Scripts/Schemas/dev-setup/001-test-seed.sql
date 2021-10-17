USE Reminder_Dev;
GO

INSERT INTO ReminderStatus(ReminderStatusId, Name)VALUES(1, 'Aberto')

INSERT INTO Users(UserName, NormalizedUserName, Email, NormalizedEmail, PasswordHash, EmailConfirmed, IsActive, CreatedAt)VALUES('root', 'ROOT', 'reminder.applications@gmail.com', 'REMINDER.APPLICATIONS@GMAIL.COM', 'AQAAAAEAAC7gAAAAEFs94HfKMcES7xiq8t/aVtLbe+HRfP156iFUHXQAaJfZkL6aDtMuE3vwKiJOjX4WlQ==',	1,	1, GETDATE())

INSERT INTO Reminders(ReminderStatusId, Deadline, IsActive, CreatedAt, CreatedBy)VALUES(1, GETDATE(), 1, GETDATE(), 1)