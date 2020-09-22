CREATE TABLE [dbo].[Award] (
    [ID]    UNIQUEIDENTIFIER NULL,
    [Title] NVARCHAR (50)    NULL
);

CREATE TABLE [dbo].[User] (
    [ID]          UNIQUEIDENTIFIER NULL,
    [UserName]    NVARCHAR (50)    NULL,
    [Age]         INT              NULL,
    [DateOfBirth] DATETIME         NULL
);

CREATE TABLE [dbo].[BindingUserAward] (
    [UserID]  UNIQUEIDENTIFIER NULL,
    [AwardID] UNIQUEIDENTIFIER NULL
);

CREATE TABLE [dbo].[Registrator] (
    [ID]       UNIQUEIDENTIFIER NULL,
    [Login]    NVARCHAR (50)    NULL,
    [Password] NVARCHAR (50)    NULL,
    [Role]     NVARCHAR (50)    NULL
);

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL

CREATE PROCEDURE [dbo].[AddAward]
	@ID uniqueidentifier out,
	@Title NVARCHAR(50)
AS
BEGIN
	SET @ID = NEWID()
	INSERT INTO Award (ID, Title)
	Values(@ID, @Title)
END

CREATE PROCEDURE [dbo].[AddUser] 
	@ID uniqueidentifier out,
	@UserName NVARCHAR(50),
	@Age INT,
	@DateOfBirth DATETIME
AS
BEGIN
	SET @ID = NEWID()
	INSERT INTO [dbo].[User] (ID, UserName, Age, DateOfBirth)
	Values(@ID, @UserName, @Age, @DateOfBirth)
END

CREATE PROCEDURE [dbo].[AddBindingUserAward] 
	@UserID uniqueidentifier,
	@AwardID uniqueidentifier
AS
BEGIN
	INSERT INTO BindingUserAward (UserID, AwardID)
	Values(@UserID, @AwardID)
END

CREATE PROCEDURE [dbo].[AddRegistrator] 
	@ID uniqueidentifier out,
	@Login NVARCHAR(50),
	@Password NVARCHAR(50),
	@Role NVARCHAR(50)
AS
BEGIN
	SET @ID = NEWID()
	INSERT INTO Registrator (ID, Login, Password, Role)
	--OUTPUT inserted.ID
	Values(@ID, @Login, @Password, @Role)
END