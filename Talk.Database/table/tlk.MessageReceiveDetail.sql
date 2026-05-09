CREATE TABLE tlk.MessageReceiveDetail(
	Id					INT			IDENTITY(1, 1),
	ReceivedUserId		INT			NOT NULL,
	ReceivedDate		DATETIME	NOT NULL,
	IsSeen				BIT			NOT NULL,
	SeenDate			DATETIME	NOT NULL,
	IsDeletedForMe		BIT			NOT NULL,
	DeletedForMeDate	DATETIME	NULL,
	CONSTRAINT Pk_MessageReceiveDetail_Id PRIMARY KEY (Id),
	CONSTRAINT Fk_MessageReceiveDetail_User_Id FOREIGN KEY (ReceivedUserId) REFERENCES [acc].[User](Id)
)