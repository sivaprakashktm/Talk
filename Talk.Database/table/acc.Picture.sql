CREATE TABLE acc.Picture(
	Id				INT			IDENTITY(1, 1),
	Image			BINARY		NULL,
	CreatedUserId	INT			NOT NULL,
	CreatedDate		DATETIME	NOT NULL,
	IsActive		BIT			NOT NULL,
	CONSTRAINT Pk_Picture_Id PRIMARY KEY (Id),
	CONSTRAINT Fk_Picture_User_CreatedUserId FOREIGN KEY (CreatedUserId) REFERENCES [acc].[User](Id)
)