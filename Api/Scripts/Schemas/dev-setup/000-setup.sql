CREATE DATABASE Reminder_Dev;
GO

USE Reminder_Dev;
GO

CREATE TABLE [dbo].[Users]
(
	[UserId] uniqueidentifier NOT NULL CONSTRAINT PK_Users PRIMARY KEY NONCLUSTERED,
	[UserName] VARCHAR(50) NOT NULL,
	[NormalizedUserName] VARCHAR(50) NOT NULL,
	[Email] VARCHAR(100) NOT NULL,
	[NormalizedEmail] VARCHAR(100) NOT NULL,
	[PasswordHash] VARCHAR(MAX) NOT NULL,
	[EmailConfirmed] BIT NOT NULL,
	[IsActive] BIT NOT NULL,
	[CreatedAt] DATETIME NOT NULL,
	[CreatedByName] VARCHAR(50) NOT NULL
)
GO

CREATE TABLE [dbo].[ReminderStatus]
(
	[ReminderStatusId] SMALLINT NOT NULL CONSTRAINT PK_ReminderStatus PRIMARY KEY NONCLUSTERED,
	[Name] VARCHAR(50) NOT NULL,
)
GO

CREATE TABLE [dbo].[Reminders]
(
	[ReminderId] uniqueidentifier NOT NULL CONSTRAINT PK_Reminders PRIMARY KEY NONCLUSTERED,
	[ReminderStatusId] SMALLINT NOT NULL CONSTRAINT FK_Reminders_ReminderStatus REFERENCES ReminderStatus(ReminderStatusId),
	[Deadline] DATETIME NOT NULL,
	[IsActive] BIT NOT NULL,
	[CreatedAt] DATETIME NOT NULL,
	[CreatedBy] uniqueidentifier NOT NULL CONSTRAINT FK_Reminders_Users REFERENCES Users(UserId),
)
GO