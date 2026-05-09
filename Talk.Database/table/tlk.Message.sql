CREATE TABLE tlk.Message(
	Id		INT				IDENTITY(1, 1),
	Content NVARCHAR(MAX)	NOT NULL,
	CreatedUserId	INT NOT NULL,
	ReceivedGroupId INT NULL,
	ReplyMessageId INT NULL,
	CreatedDate DATETIME NOT NULL,
	ModifiedUserId INT NULL,
	ModifiedDate DATETIME NULL,
	IsDeletedForMe BIT NOT NULL,
	DeletedForMeDate	DATETIME	NULL,
	DeletedForEveryoneUserId INT NULL,
	DeletedForEveryoneDate INT NULL,
	CONSTRAINT Pk_Message_Id PRIMARY KEY (Id),
	CONSTRAINT Fk_Message_User_CreatedUserId FOREIGN KEY (CreatedUserId) REFERENCES [acc].[User](Id),
	CONSTRAINT Fk_Message_User_ModifiedUserId FOREIGN KEY (ModifiedUserId) REFERENCES [acc].[User](Id),
	CONSTRAINT Fk_Message_Group_ReceivedGroupId FOREIGN KEY (ReceivedGroupId) REFERENCES [acc].[Group](Id),
	CONSTRAINT Fk_Message_Message_ReplyMessageId FOREIGN KEY (ReplyMessageId) REFERENCES [tlk].[Message](Id)
)