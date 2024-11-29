USE rrmsdb;
GO


CREATE PROCEDURE SP_GetResidentName
    @ResidentID INT
AS
BEGIN
    SELECT ResidentName 
    FROM tblResident 
    WHERE ResidentID = @ResidentID
END
GO

CREATE PROCEDURE SP_CheckRoomID
    @RoomID INT
AS
BEGIN
    SELECT COUNT(*)
    FROM tblRoom 
    WHERE RoomID = @RoomID
END
GO


-- Policy CRUD
CREATE PROCEDURE SP_InsertPolicy
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

CREATE PROCEDURE SP_ReadPolicy
    @PolicyID INT = NULL
AS
BEGIN
    IF @PolicyID IS NULL
        SELECT * FROM tblPolicy
    ELSE
        SELECT * FROM tblPolicy WHERE PolicyID = @PolicyID
END
GO

CREATE PROCEDURE SP_UpdatePolicy
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

CREATE PROCEDURE SP_DeletePolicy
    @PolicyID INT
AS
BEGIN
    DELETE FROM tblPolicy WHERE PolicyID = @PolicyID
END
GO
--End of Store Procedure Policy

-- Feedback CRUD
CREATE PROCEDURE SP_CreateFeedback
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

CREATE PROCEDURE SP_ReadFeedback
    @FeedbackID INT = NULL
AS
BEGIN
    IF @FeedbackID IS NULL
        SELECT * FROM tblFeedback
    ELSE
        SELECT * FROM tblFeedback WHERE FeedbackID = @FeedbackID
END
GO

CREATE PROCEDURE SP_UpdateFeedback
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

CREATE PROCEDURE SP_DeleteFeedback
    @FeedbackID INT
AS
BEGIN
    DELETE FROM tblFeedback WHERE FeedbackID = @FeedbackID
END
GO
--End of Store Procedure LeaseAgreement

-- LeaseAgreement CRUD
CREATE PROCEDURE SP_InsertLeaseAgreement
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

CREATE PROCEDURE SP_ReadLeaseAgreement
    @LeaseAgreementID INT = NULL
AS
BEGIN
    IF @LeaseAgreementID IS NULL
        SELECT * FROM tblLeaseAgreement
    ELSE
        SELECT * FROM tblLeaseAgreement WHERE LeaseAgreementID = @LeaseAgreementID
END
GO

CREATE PROCEDURE SP_UpdateLeaseAgreement
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

CREATE PROCEDURE SP_DeleteLeaseAgreement
    @LeaseAgreementID INT
AS
BEGIN
    DELETE FROM tblLeaseAgreement WHERE LeaseAgreementID = @LeaseAgreementID
END
GO
--End of Store Procedure LeaseAgreement

-- Utility CRUD
CREATE PROCEDURE SP_InsertUtility
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

CREATE PROCEDURE SP_ReadUtility
    @UtilityID INT = NULL
AS
BEGIN
    IF @UtilityID IS NULL
        SELECT * FROM tblUtility
    ELSE
        SELECT * FROM tblUtility WHERE UtilityID = @UtilityID
END
GO

CREATE PROCEDURE SP_UpdateUtility
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

CREATE PROCEDURE SP_DeleteUtility
    @UtilityID INT
AS
BEGIN
    DELETE FROM tblUtility WHERE UtilityID = @UtilityID
END
GO 
--End of Store Procedure Utility

-- Amenity CRUD
CREATE PROCEDURE SP_GetAllAmenities
AS
BEGIN
	SELECT AmenityID,
		   Name,
		   Avail,
		   Location,
		   BouPri,
		   CPR,
		   MainDate,
		   Desc
	FROM tblAmenity;
END
GO

CREATE PROCEDURE SP_GetAmenityById
	@AmenityID INT
AS
BEGIN
	SELECT TOP 1 AmenityID,
				 Name,
				 Avail,
				 Location,
				 BouPri,
				 CPR,
				 MainDate,
				 Desc
	FROM tblAmenity
	WHERE AmenityID = @AmenityID;
END
GO

CREATE PROCEDURE SP_InsertAmenity
	@AmenityName NVARCHAR(30),
	@AmenityAvail BIT,
	@AmenityLocation NVARCHAR(30),
	@AmenityBouPri FLOAT,
	@AmenityCPR FLOAT,
	@AmenityMainDate DATETIME,
	@AmenityDesc NVARCHAR(100)
AS
BEGIN
	INSERT INTO tblAmenity
	(	Name,
		Avail,
		Location,
		BouPri,
		CPR,
		MainDate,
		Desc
	)
	VALUES
	(
		@AmenityName,
		@AmenityAvail,
		@AmenityLocation,
		@AmenityBouPri,
		@AmenityCPR,
		@AmenityMainDate,
		@AmenityDesc
	)
END
GO

CREATE PROCEDURE SP_UpdateAmenity
	@AmenityID INT,
	@AmenityName NVARCHAR(30),
	@AmenityAvail BIT,
	@AmenityLocation NVARCHAR(30),
	@AmenityBouPri FLOAT,
	@AmenityCPR FLOAT,
	@AmenityMainDate DATETIME,
	@AmenityDesc NVARCHAR(100)
AS
BEGIN
	UPDATE tblAmenity
	SET Name = @AmenityName,
		Avail = @AmenityAvail,
		Location = @AmenityLocation,
		BouPri = @AmenityBouPri,
		CPR = @AmenityCPR,
		MainDate = @AmenityMainDate,
		Desc = @AmenityDesc
	WHERE AmenityID = @AmenityID
END
GO

CREATE PROCEDURE DeleteAmenity
	@AmenityID INT
AS
BEGIN
	DELETE FROM tblAmenity
	WHERE AmenityID = @AmenityID;
END
GO

CREATE PROCEDURE SP_ValidateAmenityID
	@AmenityID INT
AS
BEGIN
	SELECT COUNT(*) 
	FROM tblAmenity 
	WHERE AmenityID = @AmenityID
END
GO
--End of Store Procedure Amenity

-- Resident CRUD
Create Procedure SP_GetAllResidents
As
Begin
	Select ID,
		   Type,
		   Name,
		   Sex,
		   BOD,
		   PrevHouseNo,
		   PrevStNo,
		   PrevCommune,
		   PrevDistrict,
           PrevProvince,
		   PerNum,
		   ConNum,
		   CheckIn,
		   CheckOut
	From tblResident;
End
Go

Create Procedure SP_GetResidentById
	@ResID INT
As
Begin
	Select Top 1 ID,
				 Type,
				 Name,
				 Sex,
				 BOD,
				 PrevHouseNo,
				 PrevStNo,
				 PrevCommune,
				 PrevDistrict,
                 PrevProvince,
				 PerNum,
				 ConNum,
				 CheckIn,
				 CheckOut
	From tblResident
	Where ID = @ResID;
End
Go

Create Procedure SP_AddResident
	@ResType NVARCHAR(10),
	@ResName NVARCHAR(50),
	@ResSex NVARCHAR(6),
	@ResBOD DATETIME,
	@ResPrevHouseNo NVARCHAR(30),
	@ResPrevStNo NVARCHAR(30),
	@ResPrevCommune NVARCHAR(30),
	@ResPrevDistrict NVARCHAR(30),
    @ResPrevProvince NVARCHAR(30),
	@ResPerNum NVARCHAR(20),
	@ResConNum NVARCHAR(20),
	@ResCheckIn DATETIME,
	@ResCheckOut DATETIME
As
Begin
	Insert into tblResident
	(	Type,
		Name,
		Sex,
		BOD,
		PrevHouseNo,
		PrevStNo,
		PrevCommune,
		PrevDistrict,
        PrevProvince,
		PerNum,
		ConNum,
		CheckIn,
		CheckOut
	)
	Values
	(
		@ResType,
		@ResName,
		@ResSex,
		@ResBOD,
		@ResPrevHouseNo,
		@ResPrevStNo,
		@ResPrevCommune,
		@ResPrevDistrict,
		@ResPerNum,
		@ResConNum,
		@ResCheckIn,
		@ResCheckOut
	)
End
Go

Create Procedure SP_UpdateResident
	@ResID INT,
	@ResType NVARCHAR(10),
	@ResName NVARCHAR(50),
	@ResSex NVARCHAR(6),
	@ResBOD DATETIME,
	@ResPrevHouseNo NVARCHAR(30),
	@ResPrevStNo NVARCHAR(30),
	@ResPrevCommune NVARCHAR(30),
	@ResPrevDistrict NVARCHAR(30),
    @ResPrevProvince NVARCHAR(30),
	@ResPerNum NVARCHAR(20),
	@ResConNum NVARCHAR(20),
	@ResCheckIn DATETIME,
	@ResCheckOut DATETIME
As
Begin
	Update tblResident
	Set Type = @ResType,
		Name = @ResName,
		Sex = @ResSex,
		BOD = @ResBOD,
		PrevHouseNo = @ResPrevHouseNo,
		PrevStNo = @ResPrevStNo,
		PrevCommune = @ResPrevCommune,
		PrevDistrict = @ResPrevDistrict,
        PrevProvince = @ResPrevProvince,
		PerNum = @ResPerNum,
		ConNum = @ResConNum,
		CheckIn = @ResCheckIn,
		CheckOut = @ResCheckOut
	Where ID = @ResID
End
Go

Create Procedure SP_DeleteResident
	@ResID INT
As
Begin
	Delete from tblResident
	Where ID = @ResID;
End
Go

Create Procedure SP_ValidateResidentID
	@ResidentID INT
As
Begin
	Select Count(*) 
	from tblResident 
	Where ResidentID = @ResidentID
End
Go
--End of Store Precedure Resident

-- Staff CRUD
CREATE PROCEDURE SP_InsertStaff
    @StaffFName NVARCHAR(50),
    @StaffLName NVARCHAR(50),
    @StaffSex NVARCHAR(10),
    @StaffBOD DATETIME,
    @StaffPosition NVARCHAR(50),
    @StaffHNo NVARCHAR(30),
    @StaffSNo NVARCHAR(30),
    @StaffCommune NVARCHAR(30),
    @StaffDistrict NVARCHAR(30),
    @StaffProvince NVARCHAR(30),
    @StaffPerNum NVARCHAR(30),
    @StaffSalary NVARCHAR(20),
    @StaffHiredDate DATETIME,
    @StaffStopped BIT
AS
BEGIN
    INSERT INTO tblStaff (
        FName, LName, Sex, BOD, Position,
        HNo, SNo, Commune, District, Province,
        PerNum, Salary, HiredDate, Stopped
    )
    VALUES (
        @StaffFName, @StaffLName, @StaffSex, @StaffBOD, @StaffPosition,
        @StaffHNo, @StaffSNo, @StaffCommune, @StaffDistrict, @StaffProvince,
        @StaffPerNum, @StaffSalary, @StaffHiredDate, @StaffStopped
    );
END
GO

CREATE PROCEDURE SP_GetAllStaff
AS
BEGIN
    SELECT * FROM tblStaff;
END
GO

CREATE PROCEDURE SP_GetStaffById
    @StaffId INT
AS
BEGIN
    SELECT * FROM tblStaff WHERE StaffId = @StaffId;
END
GO

CREATE PROCEDURE SP_UpdateStaff
    @StaffId INT,
    @StaffFName NVARCHAR(50),
    @StaffLName NVARCHAR(50),
    @StaffSex NVARCHAR(10),
    @StaffBOD DATETIME,
    @StaffPosition NVARCHAR(50),
    @StaffHNo NVARCHAR(30),
    @StaffSNo NVARCHAR(30),
    @StaffCommune NVARCHAR(30),
    @StaffDistrict NVARCHAR(30),
    @StaffProvince NVARCHAR(30),
    @StaffPerNum NVARCHAR(30),
    @StaffSalary NVARCHAR(20),
    @StaffHiredDate DATETIME,
    @StaffPhoto NVARCHAR(MAX),
    @StaffStopped BIT
AS
BEGIN
    UPDATE tblStaff
    SET 
        FName = @StaffFName,
        LName = @StaffLName,
        Sex = @StaffSex,
        BOD = @StaffBOD,
        Position = @StaffPosition,
        HNo = @StaffHNo,
        SNo = @StaffSNo,
        Commune = @StaffCommune,
        District = @StaffDistrict,
        Province = @StaffProvince,
        PerNum = @StaffPerNum,
        Salary = @StaffSalary,
        HiredDate = @StaffHiredDate,
        Photo = @StaffPhoto,
        Stopped = @StaffStopped
    WHERE StaffId = @StaffId;
END
GO

CREATE PROCEDURE SP_DeleteStaff 
	@StaffId INT 
AS BEGIN DELETE FROM tblStaff WHERE StaffId = @StaffId; 
END
GO

CREATE PROCEDURE SP_ValidateStaffID
    @StaffID INT
AS
BEGIN
    SELECT COUNT(*) FROM tblStaff WHERE StaffId = @StaffID;
END
GO
--End of Store Precedure Staff

-- Vendor CRUD
Create Procedure SP_GetAllVendors
As
Begin
	Select VendorID,
		   Name,
		   Contact,
		   HNo,
		   SNo,
		   Commune,
		   District,
		   Province,
		   ConStart,
		   ConEnd,
		   Status,
		   Desc
	From tblVendor;
End
Go

Create Procedure GetVendorById
	@VendorID INT
As
Begin
	Select Top 1 VendorID,
				 Name,
				 Contact,
				 HNo,
				 SNo,
				 Commune,
				 District,
				 Province,
				 ConStart,
				 ConEnd,
				 Status,
				 Desc
	From tblVendor
	Where VendorID = @VendorID;
End
Go

Create Procedure SP_InsertVendor
	@VendorName NVARCHAR(50),
	@VendorContact NVARCHAR(20),
	@VendorHNo NVARCHAR(30),
	@VendorSNo NVARCHAR(30),
	@VendorCommune NVARCHAR(30),
	@VendorDistrict NVARCHAR(30),
	@VendorProvince NVARCHAR(30),
	@VendorConStart DATETIME,
	@VendorConEnd DATETIME,
	@VendorStatus BIT,
	@VendorDesc NVARCHAR(MAX)
As
Begin
	Insert into tblVendor
	(	Name,
		Contact,
		HNo,
		SNo,
		Commune,
		District,
		Province,
		ConStart,
		ConEnd,
		Status,
		Desc
	)
	Values
	(
		@VendorName,
		@VendorContact,
		@VendorHNo,
		@VendorSNo,
		@VendorCommune,
		@VendorDistrict,
		@VendorProvince,
		@VendorConStart,
		@VendorConEnd,
		@VendorStatus,
		@VendorDesc
	)
End
Go

Create Procedure SP_UpdateVendor
	@VendorID INT,
	@VendorName NVARCHAR(50),
	@VendorContact NVARCHAR(20),
	@VendorHNo NVARCHAR(30),
	@VendorSNo NVARCHAR(30),
	@VendorCommune NVARCHAR(30),
	@VendorDistrict NVARCHAR(30),
	@VendorProvince NVARCHAR(30),
	@VendorConStart DATETIME,
	@VendorConEnd DATETIME,
	@VendorStatus BIT,
	@VendorDesc NVARCHAR(MAX)
As
Begin
	Update tblVendor
	Set Name = @VendorName,
		Contact = @VendorContact,
		HNo = @VendorHNo,
		SNo = @VendorSNo,
		Commune = @VendorCommune,
	    District = @VendorDistrict,
		Province = @VendorProvince,
		ConStart = @VendorConStart,
		ConEnd = @VendorConEnd,
		Status = @VendorStatus,
		Desc = @VendorDesc
	Where VendorID = @VendorID
End
Go

Create Procedure SP_DeleteVendor
	@VendorID INT
As
Begin
	Delete from tblVendor
	Where VendorID = @VendorID;
End
Go

Create Procedure SP_ValidateVendorID
	@VendorID INT
As
Begin
	Select Count(*) 
	from tblVendor 
	Where VendorID = @VendorID
End
Go
--End of Store Precedure Vendor

-- Rent CRUD
CREATE PROCEDURE SP_GetAllRents
AS
BEGIN
    SELECT 
        r.RentID,
        r.StartDate,
        r.EndDate,
        r.RentAmount,
        r.ResidentID,
        r.RoomID,
        res.ResidentName,
        rm.RoomNumber
    FROM Rent r
    INNER JOIN Resident res ON r.ResidentID = res.ResidentID
    INNER JOIN Room rm ON r.RoomID = rm.RoomID
    ORDER BY r.RentID DESC;
END;
GO

CREATE PROCEDURE SP_SearchRents
    @SearchTerm NVARCHAR(100)
AS
BEGIN
    SELECT 
        r.RentID,
        r.StartDate,
        r.EndDate,
        r.RentAmount,
        r.ResidentID,
        r.RoomID,
        res.ResidentName,
        rm.RoomNumber
    FROM Rent r
    INNER JOIN Resident res ON r.ResidentID = res.ResidentID
    INNER JOIN Room rm ON r.RoomID = rm.RoomID
    WHERE res.ResidentName LIKE @SearchTerm + '%'
    ORDER BY r.RentID DESC;
END;
GO

CREATE PROCEDURE SP_GetResidentNameById
    @ResidentID INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Resident WHERE ResidentID = @ResidentID)
    BEGIN
        THROW 50001, 'Resident not found', 1;
        RETURN;
    END

    SELECT ResidentName
    FROM Resident
    WHERE ResidentID = @ResidentID;
END;
GO

CREATE PROCEDURE SP_GetRoomNumberById
    @RoomID INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Room WHERE RoomID = @RoomID)
    BEGIN
        THROW 50002, 'Room not found', 1;
        RETURN;
    END

    SELECT RoomNumber
    FROM Room
    WHERE RoomID = @RoomID;
END;
GO

CREATE PROCEDURE SP_InsertRent
    @StartDate DATE,
    @EndDate DATE,
    @RentAmount DECIMAL(10,2),
    @ResidentID INT,
    @RoomID INT
AS
BEGIN
    -- Validate resident exists
    IF NOT EXISTS (SELECT 1 FROM Resident WHERE ResidentID = @ResidentID)
    BEGIN
        THROW 50001, 'Resident not found', 1;
        RETURN;
    END

    -- Validate room exists
    IF NOT EXISTS (SELECT 1 FROM Room WHERE RoomID = @RoomID)
    BEGIN
        THROW 50002, 'Room not found', 1;
        RETURN;
    END

    -- Validate dates
    IF @EndDate < @StartDate
    BEGIN
        THROW 50003, 'End date cannot be earlier than start date', 1;
        RETURN;
    END

    -- Validate rent amount
    IF @RentAmount <= 0
    BEGIN
        THROW 50004, 'Rent amount must be greater than zero', 1;
        RETURN;
    END

    -- Check for overlapping rent periods
    IF EXISTS (
        SELECT 1 
        FROM Rent 
        WHERE RoomID = @RoomID 
        AND (
            (@StartDate BETWEEN StartDate AND EndDate)
            OR (@EndDate BETWEEN StartDate AND EndDate)
            OR (StartDate BETWEEN @StartDate AND @EndDate)
        )
    )
    BEGIN
        THROW 50005, 'Room is already rented during this period', 1;
        RETURN;
    END

    -- Insert the rent record
    INSERT INTO Rent (
        StartDate,
        EndDate,
        RentAmount,
        ResidentID,
        RoomID
    )
    VALUES (
        @StartDate,
        @EndDate,
        @RentAmount,
        @ResidentID,
        @RoomID
    );

    SELECT SCOPE_IDENTITY() AS RentID;
END;
GO

CREATE PROCEDURE SP_UpdateRent
    @RentID INT,
    @StartDate DATE,
    @EndDate DATE,
    @RentAmount DECIMAL(10,2)
AS
BEGIN
    -- Validate rent exists
    IF NOT EXISTS (SELECT 1 FROM Rent WHERE RentID = @RentID)
    BEGIN
        THROW 50006, 'Rent record not found', 1;
        RETURN;
    END

    -- Validate dates
    IF @EndDate < @StartDate
    BEGIN
        THROW 50003, 'End date cannot be earlier than start date', 1;
        RETURN;
    END

    -- Validate rent amount
    IF @RentAmount <= 0
    BEGIN
        THROW 50004, 'Rent amount must be greater than zero', 1;
        RETURN;
    END

    -- Get the RoomID for the current rent record
    DECLARE @CurrentRoomID INT;
    SELECT @CurrentRoomID = RoomID FROM Rent WHERE RentID = @RentID;

    -- Check for overlapping rent periods (excluding current record)
    IF EXISTS (
        SELECT 1 
        FROM Rent 
        WHERE RoomID = @CurrentRoomID 
        AND RentID != @RentID
        AND (
            (@StartDate BETWEEN StartDate AND EndDate)
            OR (@EndDate BETWEEN StartDate AND EndDate)
            OR (StartDate BETWEEN @StartDate AND @EndDate)
        )
    )
    BEGIN
        THROW 50005, 'Room is already rented during this period', 1;
        RETURN;
    END

    -- Update the rent record
    UPDATE Rent
    SET 
        StartDate = @StartDate,
        EndDate = @EndDate,
        RentAmount = @RentAmount
    WHERE RentID = @RentID;
END;
GO

CREATE PROCEDURE SP_DeleteRent
    @RentID INT
AS
BEGIN
    -- Validate rent exists
    IF NOT EXISTS (SELECT 1 FROM Rent WHERE RentID = @RentID)
    BEGIN
        THROW 50006, 'Rent record not found', 1;
        RETURN;
    END

    -- Check if this is an active rent
    IF EXISTS (
        SELECT 1 
        FROM Rent 
        WHERE RentID = @RentID 
        AND GETDATE() BETWEEN StartDate AND EndDate
    )
    BEGIN
        THROW 50007, 'Cannot delete an active rent record', 1;
        RETURN;
    END

    -- Delete the rent record
    DELETE FROM Rent
    WHERE RentID = @RentID;
END;
GO
--End of Store Precedure Rent

-- Request CRUD
CREATE PROCEDURE SP_GetAllRequests
AS
BEGIN
    SELECT 
        r.RequestID,
        r.RequestDate,
        r.Description,
        r.Status,
        r.ResidentID,
        r.ServiceID,
        res.ResidentName,
        s.ServiceName
    FROM Request r
    INNER JOIN Resident res ON r.ResidentID = res.ResidentID
    INNER JOIN Service s ON r.ServiceID = s.ServiceID
    ORDER BY r.RequestID DESC;
END;
GO

CREATE PROCEDURE SP_GetRequestById
    @RequestID INT
AS
BEGIN
    SELECT 
        r.RequestID,
        r.RequestDate,
        r.Description,
        r.Status,
        r.ResidentID,
        r.ServiceID,
        res.ResidentName,
        s.ServiceName
    FROM Request r
    INNER JOIN Resident res ON r.ResidentID = res.ResidentID
    INNER JOIN Service s ON r.ServiceID = s.ServiceID
    WHERE r.RequestID = @RequestID;
END;
GO

CREATE PROCEDURE SP_SearchRequests
    @SearchTerm NVARCHAR(100)
AS
BEGIN
    SELECT 
        r.RequestID,
        r.RequestDate,
        r.Description,
        r.Status,
        r.ResidentID,
        r.ServiceID,
        res.ResidentName,
        s.ServiceName
    FROM Request r
    INNER JOIN Resident res ON r.ResidentID = res.ResidentID
    INNER JOIN Service s ON r.ServiceID = s.ServiceID
    WHERE res.ResidentName LIKE @SearchTerm + '%'
    OR r.Description LIKE @SearchTerm + '%'
    OR r.Status LIKE @SearchTerm + '%'
    OR s.ServiceName LIKE @SearchTerm + '%'
    ORDER BY r.RequestID DESC;
END;
GO

CREATE PROCEDURE SP_GetServiceNameById
    @ServiceID INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Service WHERE ServiceID = @ServiceID)
    BEGIN
        THROW 50002, 'Service not found', 1;
        RETURN;
    END

    SELECT ServiceName
    FROM Service
    WHERE ServiceID = @ServiceID;
END;
GO

CREATE PROCEDURE SP_InsertRequest
    @RequestDate DATE,
    @Description NVARCHAR(MAX),
    @Status NVARCHAR(50),
    @ResidentID INT,
    @ServiceID INT
AS
BEGIN
    -- Validate inputs
    IF NOT EXISTS (SELECT 1 FROM Resident WHERE ResidentID = @ResidentID)
    BEGIN
        THROW 50001, 'Resident not found', 1;
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM Service WHERE ServiceID = @ServiceID)
    BEGIN
        THROW 50002, 'Service not found', 1;
        RETURN;
    END

    IF @Status NOT IN ('Pending', 'Confirmed', 'Completed', 'Cancelled')
    BEGIN
        THROW 50003, 'Invalid status value', 1;
        RETURN;
    END

    -- Insert the request
    INSERT INTO Request (
        RequestDate,
        Description,
        Status,
        ResidentID,
        ServiceID
    )
    VALUES (
        @RequestDate,
        @Description,
        @Status,
        @ResidentID,
        @ServiceID
    );

    SELECT SCOPE_IDENTITY() AS RequestID;
END;
GO

CREATE PROCEDURE SP_UpdateRequest
    @RequestID INT,
    @RequestDate DATE,
    @Description NVARCHAR(MAX),
    @Status NVARCHAR(50),
    @ResidentID INT,
    @ServiceID INT
AS
BEGIN
    -- Validate request exists
    IF NOT EXISTS (SELECT 1 FROM Request WHERE RequestID = @RequestID)
    BEGIN
        THROW 50004, 'Request not found', 1;
        RETURN;
    END

    -- Validate inputs
    IF NOT EXISTS (SELECT 1 FROM Resident WHERE ResidentID = @ResidentID)
    BEGIN
        THROW 50001, 'Resident not found', 1;
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM Service WHERE ServiceID = @ServiceID)
    BEGIN
        THROW 50002, 'Service not found', 1;
        RETURN;
    END

    IF @Status NOT IN ('Pending', 'Confirmed', 'Completed', 'Cancelled')
    BEGIN
        THROW 50003, 'Invalid status value', 1;
        RETURN;
    END

    -- Update the request
    UPDATE Request
    SET 
        RequestDate = @RequestDate,
        Description = @Description,
        Status = @Status,
        ResidentID = @ResidentID,
        ServiceID = @ServiceID
    WHERE RequestID = @RequestID;
END;
GO

CREATE PROCEDURE SP_DeleteRequest
    @RequestID INT
AS
BEGIN
    -- Validate request exists
    IF NOT EXISTS (SELECT 1 FROM Request WHERE RequestID = @RequestID)
    BEGIN
        THROW 50004, 'Request not found', 1;
        RETURN;
    END

    -- Check if request can be deleted (example: don't delete completed requests)
    IF EXISTS (SELECT 1 FROM Request WHERE RequestID = @RequestID AND Status = 'Completed')
    BEGIN
        THROW 50005, 'Cannot delete completed requests', 1;
        RETURN;
    END

    -- Delete the request
    DELETE FROM Request
    WHERE RequestID = @RequestID;
END;
GO
--End of Store Precedure Request

-- Reservation CRUD
CREATE PROCEDURE SP_GetAllReservations
AS
BEGIN
    SELECT 
        r.ReservationID,
        r.ReservationDate,
        r.StartDate,
        r.EndDate,
        r.Status,
        r.ResidentID,
        r.RoomID,
        res.ResidentName,
        rm.RoomNumber
    FROM Reservation r
    LEFT JOIN Resident res ON r.ResidentID = res.ResidentID
    LEFT JOIN Room rm ON r.RoomID = rm.RoomID
    ORDER BY r.ReservationID DESC;
END;
GO

CREATE PROCEDURE SP_GetReservationById
    @ReservationID INT
AS
BEGIN
    SELECT 
        r.ReservationID,
        r.ReservationDate,
        r.StartDate,
        r.EndDate,
        r.Status,
        r.ResidentID,
        r.RoomID,
        res.ResidentName,
        rm.RoomNumber
    FROM Reservation r
    LEFT JOIN Resident res ON r.ResidentID = res.ResidentID
    LEFT JOIN Room rm ON r.RoomID = rm.RoomID
    WHERE r.ReservationID = @ReservationID;
END;
GO

CREATE PROCEDURE SP_InsertReservation
    @ReservationDate DATE,
    @StartDate DATE,
    @EndDate DATE,
    @Status NVARCHAR(50),
    @ResidentID INT,
    @RoomID INT
AS
BEGIN
    -- Validate resident exists
    IF NOT EXISTS (SELECT 1 FROM Resident WHERE ResidentID = @ResidentID)
    BEGIN
        THROW 50001, 'Resident not found', 1;
        RETURN;
    END

    -- Validate room exists
    IF NOT EXISTS (SELECT 1 FROM Room WHERE RoomID = @RoomID)
    BEGIN
        THROW 50002, 'Room not found', 1;
        RETURN;
    END

    -- Validate dates
    IF @StartDate > @EndDate
    BEGIN
        THROW 50003, 'Start date cannot be after end date', 1;
        RETURN;
    END

    -- Check for overlapping reservations
    IF EXISTS (
        SELECT 1 
        FROM Reservation 
        WHERE RoomID = @RoomID 
        AND Status != 'Cancelled'
        AND (
            (@StartDate BETWEEN StartDate AND EndDate)
            OR (@EndDate BETWEEN StartDate AND EndDate)
            OR (StartDate BETWEEN @StartDate AND @EndDate)
        )
    )
    BEGIN
        THROW 50004, 'Room is already reserved for this period', 1;
        RETURN;
    END

    -- Insert the reservation
    INSERT INTO Reservation (
        ReservationDate,
        StartDate,
        EndDate,
        Status,
        ResidentID,
        RoomID
    )
    VALUES (
        @ReservationDate,
        @StartDate,
        @EndDate,
        @Status,
        @ResidentID,
        @RoomID
    );
    
    -- Return the inserted ID
    SELECT SCOPE_IDENTITY() AS ReservationID;
END;
GO

CREATE PROCEDURE SP_UpdateReservation
    @ReservationID INT,
    @ReservationDate DATE,
    @StartDate DATE,
    @EndDate DATE,
    @Status NVARCHAR(50),
    @ResidentID INT,
    @RoomID INT
AS
BEGIN
    -- Check if reservation exists
    IF NOT EXISTS (SELECT 1 FROM Reservation WHERE ReservationID = @ReservationID)
    BEGIN
        THROW 50005, 'Reservation not found', 1;
        RETURN;
    END

    -- Validate resident exists
    IF NOT EXISTS (SELECT 1 FROM Resident WHERE ResidentID = @ResidentID)
    BEGIN
        THROW 50001, 'Resident not found', 1;
        RETURN;
    END

    -- Validate room exists
    IF NOT EXISTS (SELECT 1 FROM Room WHERE RoomID = @RoomID)
    BEGIN
        THROW 50002, 'Room not found', 1;
        RETURN;
    END

    -- Validate dates
    IF @StartDate > @EndDate
    BEGIN
        THROW 50003, 'Start date cannot be after end date', 1;
        RETURN;
    END

    -- Check for overlapping reservations (excluding current reservation)
    IF EXISTS (
        SELECT 1 
        FROM Reservation 
        WHERE RoomID = @RoomID 
        AND ReservationID != @ReservationID
        AND Status != 'Cancelled'
        AND (
            (@StartDate BETWEEN StartDate AND EndDate)
            OR (@EndDate BETWEEN StartDate AND EndDate)
            OR (StartDate BETWEEN @StartDate AND @EndDate)
        )
    )
    BEGIN
        THROW 50004, 'Room is already reserved for this period', 1;
        RETURN;
    END

    -- Update the reservation
    UPDATE Reservation
    SET 
        ReservationDate = @ReservationDate,
        StartDate = @StartDate,
        EndDate = @EndDate,
        Status = @Status,
        ResidentID = @ResidentID,
        RoomID = @RoomID
    WHERE ReservationID = @ReservationID;
END;
GO

CREATE PROCEDURE SP_DeleteReservation
    @ReservationID INT
AS
BEGIN
    -- Check if reservation exists
    IF NOT EXISTS (SELECT 1 FROM Reservation WHERE ReservationID = @ReservationID)
    BEGIN
        THROW 50005, 'Reservation not found', 1;
        RETURN;
    END

    -- Check if the reservation can be deleted (you might want to add more business rules here)
    IF EXISTS (
        SELECT 1 
        FROM Reservation 
        WHERE ReservationID = @ReservationID 
        AND Status = 'Confirmed'
        AND StartDate <= GETDATE()
        AND EndDate >= GETDATE()
    )
    BEGIN
        THROW 50006, 'Cannot delete an active confirmed reservation', 1;
        RETURN;
    END

    -- Delete the reservation
    DELETE FROM Reservation
    WHERE ReservationID = @ReservationID;
END;
GO

CREATE PROCEDURE SP_GetResidentById
    @ResidentID INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Resident WHERE ResidentID = @ResidentID)
    BEGIN
        THROW 50001, 'Resident not found', 1;
        RETURN;
    END

    SELECT 
        r.ResidentName,
        ISNULL((
            SELECT TOP 1 RoomID 
            FROM Rent 
            WHERE ResidentID = @ResidentID 
            ORDER BY StartDate DESC
        ), '') as RoomID
    FROM Resident r
    WHERE r.ResidentID = @ResidentID;
END;
GO

CREATE PROCEDURE sp_GetRoomById
    @RoomID INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Room WHERE RoomID = @RoomID)
    BEGIN
        THROW 50002, 'Room not found', 1;
        RETURN;
    END

    SELECT RoomNumber
    FROM Room
    WHERE RoomID = @RoomID;
END;
GO
--End of Store Precedure Resident


-- Service CRUD
CREATE PROCEDURE SP_GetAllServices
AS
BEGIN
    SELECT 
        ServiceID,
        ServiceName,
        ServiceDescription,
        Cost
    FROM Service
    ORDER BY ServiceID DESC;
END;
GO

CREATE PROCEDURE SP_GetServiceById
    @ServiceID INT
AS
BEGIN
    SELECT 
        ServiceID,
        ServiceName,
        ServiceDescription,
        Cost
    FROM Service
    WHERE ServiceID = @ServiceID;
END;
GO

CREATE PROCEDURE SP_SearchServices
    @SearchTerm NVARCHAR(100)
AS
BEGIN
    SELECT 
        ServiceID,
        ServiceName,
        ServiceDescription,
        Cost
    FROM Service
    WHERE ServiceName LIKE @SearchTerm + '%'
    OR ServiceDescription LIKE @SearchTerm + '%'
    OR CAST(Cost AS NVARCHAR) LIKE @SearchTerm + '%'
    ORDER BY ServiceID DESC;
END;
GO

CREATE PROCEDURE SP_InsertService
    @ServiceName NVARCHAR(100),
    @ServiceDescription NVARCHAR(MAX),
    @Cost DECIMAL(10,2)
AS
BEGIN
    -- Validate service name is not empty
    IF LTRIM(RTRIM(@ServiceName)) = ''
    BEGIN
        THROW 50001, 'Service name cannot be empty', 1;
        RETURN;
    END

    -- Validate cost is not negative
    IF @Cost < 0
    BEGIN
        THROW 50002, 'Cost cannot be negative', 1;
        RETURN;
    END

    -- Check for duplicate service name
    IF EXISTS (SELECT 1 FROM Service WHERE ServiceName = @ServiceName)
    BEGIN
        THROW 50003, 'Service name already exists', 1;
        RETURN;
    END

    INSERT INTO Service (
        ServiceName,
        ServiceDescription,
        Cost
    )
    VALUES (
        @ServiceName,
        @ServiceDescription,
        @Cost
    );

    SELECT SCOPE_IDENTITY() AS ServiceID;
END;
GO

CREATE PROCEDURE SP_UpdateService
    @ServiceID INT,
    @ServiceName NVARCHAR(100),
    @ServiceDescription NVARCHAR(MAX),
    @Cost DECIMAL(10,2)
AS
BEGIN
    -- Validate service exists
    IF NOT EXISTS (SELECT 1 FROM Service WHERE ServiceID = @ServiceID)
    BEGIN
        THROW 50004, 'Service not found', 1;
        RETURN;
    END

    -- Validate service name is not empty
    IF LTRIM(RTRIM(@ServiceName)) = ''
    BEGIN
        THROW 50001, 'Service name cannot be empty', 1;
        RETURN;
    END

    -- Validate cost is not negative
    IF @Cost < 0
    BEGIN
        THROW 50002, 'Cost cannot be negative', 1;
        RETURN;
    END

    -- Check for duplicate service name (excluding current service)
    IF EXISTS (SELECT 1 FROM Service WHERE ServiceName = @ServiceName AND ServiceID != @ServiceID)
    BEGIN
        THROW 50003, 'Service name already exists', 1;
        RETURN;
    END

    UPDATE Service
    SET 
        ServiceName = @ServiceName,
        ServiceDescription = @ServiceDescription,
        Cost = @Cost
    WHERE ServiceID = @ServiceID;
END;
GO

CREATE PROCEDURE SP_DeleteService
    @ServiceID INT
AS
BEGIN
    -- Validate service exists
    IF NOT EXISTS (SELECT 1 FROM Service WHERE ServiceID = @ServiceID)
    BEGIN
        THROW 50004, 'Service not found', 1;
        RETURN;
    END

    -- Check for existing requests using this service
    IF EXISTS (SELECT 1 FROM Request WHERE ServiceID = @ServiceID)
    BEGIN
        THROW 50005, 'Cannot delete service because it is referenced in requests', 1;
        RETURN;
    END

    DELETE FROM Service
    WHERE ServiceID = @ServiceID;
END;
GO
--End of Store Precedure Request