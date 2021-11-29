--- Problem - 15

CREATE TABLE [NotificationEmails](
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Recipient] INT NOT NULL,
	[Subject] VARCHAR(MAX) NOT NULL,
	[Body] VARCHAR(MAX) NOT NULL
)

CREATE TRIGGER tr_EmailUpdate
ON [Logs] FOR INSERT
AS
	INSERT INTO [NotificationEmails]([Recipient],[Subject],[Body])
	SELECT i.[AccountId], 
	CONCAT('Balance change for account: ',i.[AccountId]),
	CONCAT('On ',GETDATE(),' your balance was changed from ',i.[NewSum],' to ',i.[OldSum])
  FROM [inserted] AS i