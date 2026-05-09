CREATE TABLE [acc].[Group] (
	Id INT IDENTITY(1, 1),
	Name NVARCHAR(50) NOT NULL,
	Description NVARCHAR(MAX) NULL,
	GroupTypeId INT NOT NULL,
	PictureId INT NULL,
	CreatedUserId INT NOT NULL,
	CreatedDate DATETIME NOT NULL,
	ModifiedUserId INT NULL,
	ModifiedDate DATETIME NULL,
	CONSTRAINT Pk_Group_Id PRIMARY KEY (Id),
	CONSTRAINT Fk_Group_GroupType_GroupTypeId FOREIGN KEY (GroupTypeId) REFERENCES acc.GroupType(Id),
	CONSTRAINT Fk_Group_Picture_PictureId FOREIGN KEY (PictureId) REFERENCES acc.Picture(Id),
	CONSTRAINT Fk_Group_User_CreatedUserId FOREIGN KEY (CreatedUserId) REFERENCES [acc].[User](Id),
	CONSTRAINT Fk_Group_User_ModifieUserId FOREIGN KEY (ModifiedUserId) REFERENCES [acc].[User](Id)
)