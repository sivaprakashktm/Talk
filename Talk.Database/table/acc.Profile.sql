CREATE TABLE [acc].[Profile](
	Id					INT				IDENTITY(1, 1),
	FirstName			NVARCHAR(20)	NOT NULL,
	LastName			NVARCHAR(20)	NOT NULL,
	Email				NVARCHAR(MAX)	NOT NULL,
	Bio					NVARCHAR(MAX)	NOT NULL,
	UserId				INT				NULL,
	PictureId			INT				NULL,
	IsActive			BIT				NOT NULL,
	CreatedDate			DATETIME		NOT NULL,
	ModifiedDate		DATETIME		NULL,
	CONSTRAINT Pk_Profile_Id PRIMARY KEY (Id),
	CONSTRAINT Fk_Profile_User_UserId FOREIGN KEY (UserId) REFERENCES [acc].[User](Id),
	CONSTRAINT Fk_Prfile_Picture_PictureId FOREIGN KEY (PictureId) REFERENCES [acc].[Picture](Id)
)