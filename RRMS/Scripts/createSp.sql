CREATE PROCEDURE sp_GetResidentName
    @ResidentID INT
AS
BEGIN
    SELECT ResidentName 
    FROM tblResident 
    WHERE ResidentID = @ResidentID
END

CREATE PROCEDURE sp_CheckRoomID
    @RoomID INT
AS
BEGIN
    SELECT COUNT(*)
    FROM tblRoom 
    WHERE RoomID = @RoomID
END
GO


-- Policy CRUD
CREATE PROCEDURE sp_CreatePolicy
    @PolicyName NVARCHAR(100),
    @Description NVARCHAR(MAX),
    @ResidentID INT
AS
BEGIN
    INSERT INTO tblPolicy (PolicyName, Description, ResidentID)
    VALUES (@PolicyName, @Description, @ResidentID)
    SELECT SCOPE_IDENTITY() as PolicyID
END
GO

CREATE PROCEDURE sp_ReadPolicy
    @PolicyID INT = NULL
AS
BEGIN
    IF @PolicyID IS NULL
        SELECT * FROM tblPolicy
    ELSE
        SELECT * FROM tblPolicy WHERE PolicyID = @PolicyID
END
GO

CREATE PROCEDURE sp_UpdatePolicy
    @PolicyID INT,
    @PolicyName NVARCHAR(100),
    @Description NVARCHAR(MAX),
    @ResidentID INT
AS
BEGIN
    UPDATE tblPolicy
    SET PolicyName = @PolicyName,
        Description = @Description,
        ResidentID = @ResidentID,
        UpdatedDate = GETDATE()
    WHERE PolicyID = @PolicyID
END
GO

CREATE PROCEDURE sp_DeletePolicy
    @PolicyID INT
AS
BEGIN
    DELETE FROM tblPolicy WHERE PolicyID = @PolicyID
END
GO

-- Feedback CRUD
CREATE PROCEDURE sp_CreateFeedback
    @Comments NVARCHAR(MAX),
    @Rating INT,
    @ResidentID INT
AS
BEGIN
    INSERT INTO tblFeedback (Comments, Rating, ResidentID)
    VALUES (@Comments, @Rating, @ResidentID)
    SELECT SCOPE_IDENTITY() as FeedbackID
END
GO

CREATE PROCEDURE sp_ReadFeedback
    @FeedbackID INT = NULL
AS
BEGIN
    IF @FeedbackID IS NULL
        SELECT * FROM tblFeedback
    ELSE
        SELECT * FROM tblFeedback WHERE FeedbackID = @FeedbackID
END
GO

CREATE PROCEDURE sp_UpdateFeedback
    @FeedbackID INT,
    @Comments NVARCHAR(MAX),
    @Rating INT,
    @ResidentID INT
AS
BEGIN
    UPDATE tblFeedback
    SET Comments = @Comments,
        Rating = @Rating,
        ResidentID = @ResidentID
    WHERE FeedbackID = @FeedbackID
END
GO

CREATE PROCEDURE sp_DeleteFeedback
    @FeedbackID INT
AS
BEGIN
    DELETE FROM tblFeedback WHERE FeedbackID = @FeedbackID
END
GO

-- LeaseAgreement CRUD
CREATE PROCEDURE sp_CreateLeaseAgreement
    @StartDate DATE,
    @EndDate DATE,
    @MonthlyRent DECIMAL(10,2),
    @TermsAndConditions NVARCHAR(MAX),
    @ResidentID INT
AS
BEGIN
    INSERT INTO tblLeaseAgreement (StartDate, EndDate, MonthlyRent, TermsAndConditions, ResidentID)
    VALUES (@StartDate, @EndDate, @MonthlyRent, @TermsAndConditions, @ResidentID)
    SELECT SCOPE_IDENTITY() as LeaseAgreementID
END
GO

CREATE PROCEDURE sp_ReadLeaseAgreement
    @LeaseAgreementID INT = NULL
AS
BEGIN
    IF @LeaseAgreementID IS NULL
        SELECT * FROM tblLeaseAgreement
    ELSE
        SELECT * FROM tblLeaseAgreement WHERE LeaseAgreementID = @LeaseAgreementID
END
GO

CREATE PROCEDURE sp_UpdateLeaseAgreement
    @LeaseAgreementID INT,
    @StartDate DATE,
    @EndDate DATE,
    @MonthlyRent DECIMAL(10,2),
    @TermsAndConditions NVARCHAR(MAX),
    @ResidentID INT
AS
BEGIN
    UPDATE tblLeaseAgreement
    SET StartDate = @StartDate,
        EndDate = @EndDate,
        MonthlyRent = @MonthlyRent,
        TermsAndConditions = @TermsAndConditions,
        ResidentID = @ResidentID
    WHERE LeaseAgreementID = @LeaseAgreementID
END
GO

CREATE PROCEDURE sp_DeleteLeaseAgreement
    @LeaseAgreementID INT
AS
BEGIN
    DELETE FROM tblLeaseAgreement WHERE LeaseAgreementID = @LeaseAgreementID
END
GO

-- Utility CRUD
CREATE PROCEDURE sp_CreateUtility
    @UtilityType NVARCHAR(50),
    @Cost DECIMAL(10,2),
    @UsageDate DATE,
    @RoomID INT
AS
BEGIN
    INSERT INTO tblUtility (UtilityType, Cost, UsageDate, RoomID)
    VALUES (@UtilityType, @Cost, @UsageDate, @RoomID)
    SELECT SCOPE_IDENTITY() as UtilityID
END
GO

CREATE PROCEDURE sp_ReadUtility
    @UtilityID INT = NULL
AS
BEGIN
    IF @UtilityID IS NULL
        SELECT * FROM tblUtility
    ELSE
        SELECT * FROM tblUtility WHERE UtilityID = @UtilityID
END
GO

CREATE PROCEDURE sp_UpdateUtility
    @UtilityID INT,
    @UtilityType NVARCHAR(50),
    @Cost DECIMAL(10,2),
    @UsageDate DATE,
    @RoomID INT
AS
BEGIN
    UPDATE tblUtility
    SET UtilityType = @UtilityType,
        Cost = @Cost,
        UsageDate = @UsageDate,
        RoomID = @RoomID
    WHERE UtilityID = @UtilityID
END
GO

CREATE PROCEDURE sp_DeleteUtility
    @UtilityID INT
AS
BEGIN
    DELETE FROM tblUtility WHERE UtilityID = @UtilityID
END
GO 