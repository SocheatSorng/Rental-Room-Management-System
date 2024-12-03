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



-- Feedback CRUD
CREATE PROCEDURE SP_GetAllFeedbacks
AS
BEGIN
    Select * FROM tblFeedback;
END
GO

CREATE PROCEDURE SP_GetFeedbackByID
    @FeedID INT
AS
BEGIN
    SELECT * FROM tblFeedback WHERE FeedbackID = @FeedID;
END
GO

CREATE PROCEDURE SP_InsertFeedback
	@FeedDate DATETIME,
    @FeedCon NVARCHAR(50),
    @FeedCom NVARCHAR(50),
    @ResID INT,
    @ResName VARCHAR(50)
AS
BEGIN
    Insert INTO tblFeedback(
        Date, Content, Comment, ResidentID, ResName
    )
    VALUES(
        @FeedDate, @FeedCon, @FeedCom, @ResID, @ResName
    );
END
GO

CREATE PROCEDURE SP_UpdateFeedback
    @FeedID INT,
	@Date DATETIME,
    @Content NVARCHAR(50),
    @Comment NVARCHAR(50),
    @ResID INT,
    @ResName NVARCHAR(50)
AS
BEGIN
    Update tblFeedback
    SET
		DATE = @FeedDate,
        Content = @Content,
        Comment = @Comment,
        ResidentID = @ResID,
        ResName = @ResName
    WHERE FeedbackID = @FeedID;
END
GO

CREATE PROCEDURE SP_DeleteFeedback
    @FeedID INT
AS 
BEGIN
    DELETE FROM tblFeedback WHERE FeedbackID = @FeedID;
END
GO

--End of Store Procedure LeaseAgreement

-- LeaseAgreement CRUD
Create Procedure SP_GetAllLeaseAgreements
as
Begin
    Select * from tblLeaseAgreement
end
GO

Create Procedure SP_GetLeaseAgreementByID
    @LeaseAgreementID INT
AS
BEGIN
    Select * from tblLeaseAgreement
    Where LeaseAgreementID = @LeaseID
end
Go

CREATE PROCEDURE SP_InsertLeaseAgreement
    @StartDate DATETIME2,
    @EndDate DATETIME2,
    @TermsAndConditions NVARCHAR(MAX),
    @ResidentID INT
AS
BEGIN
    INSERT INTO tblLeaseAgreement (StartDate, EndDate, TermsAndConditions, ResidentID)
    VALUES (@StartDate, @EndDate, @TermsAndConditions, @ResidentID)
END
GO

CREATE PROCEDURE SP_UpdateLeaseAgreement
    @LeaseAgreementID INT,
    @StartDate DATETIME2,
    @EndDate DATETIME2,
    @TermsAndConditions NVARCHAR(MAX),
    @ResidentID INT
AS
BEGIN
    UPDATE tblLeaseAgreement
    SET StartDate = @StartDate,
        EndDate = @EndDate,
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
Create Procedure SP_LoadUtilityIDs
As
Begin
	Select Type,
			UtilityID
	From tblUtility
END 
GO

CREATE PROCEDURE SP_GetAllUtilitys
AS
BEGIN
    select * from tblUtility
END
GO

CREATE PROCEDURE SP_GetUtilityByID
	@UtilityID INT
AS
BEGIN
    SELECT * FROM tblUtility WHERE UtilityID = @UtilityID;
END
GO
    

CREATE PROCEDURE SP_InsertUtility
    @Type NVARCHAR(50),
    @Cost float,
    @UsageDate DATETIME2,
    @RoomID INT
AS
BEGIN
    INSERT INTO tblUtility (Type, Cost, UsageDate, RoomID)
    VALUES (@Type, @Cost, @UsageDate, @RoomID)
END
GO


CREATE PROCEDURE SP_UpdateUtility
    @UtilityID INT,
    @Type NVARCHAR(50),
    @Cost DECIMAL(10,2),
    @UsageDate DATE,
    @RoomID INT
AS
BEGIN
    UPDATE tblUtility
    SET Type = @Type,
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
CREATE PROCEDURE SP_GetAllAmenitys
AS
BEGIN
	SELECT AmenityID,
		   Name,
		   Availability,
		   Location,
		   BoughtPrice,
		   CPR,
		   MainDate,
		   Description
	FROM tblAmenity;
END
GO

CREATE PROCEDURE SP_GetAmenityByID
	@AmeID INT
AS
BEGIN
	SELECT TOP 1 AmenityID,
				 Name,
				 Availability,
				 Location,
				 BoughtPrice,
				 CPR,
				 MainDate,
				 Description
	FROM tblAmenity
	WHERE AmenityID = @AmeID;
END
GO

CREATE PROCEDURE SP_InsertAmenity
	@AmeName NVARCHAR(30),
	@AmeAvail BIT,
	@AmeLoc NVARCHAR(30),
	@AmeBP FLOAT,
	@AmeCPR FLOAT,
	@AmeMD DATETIME,
	@AmeDesc NVARCHAR(100)
AS
BEGIN
	INSERT INTO tblAmenity
	(	Name,
		Availability,
		Location,
		BoughtPrice,
		CPR,
		MainDate,
		Description
	)
	VALUES
	(
		@AmeName,
		@AmeAvail,
		@AmeLoc,
		@AmeBP,
		@AmeCPR,
		@AmeMD,
		@AmeDesc
	)
END
GO

CREATE PROCEDURE SP_UpdateAmenity
	@AmeID INT,
	@AmeName NVARCHAR(30),
	@AmeAvail BIT,
	@AmeLoc NVARCHAR(30),
	@AmeBP FLOAT,
	@AmeCPR FLOAT,
	@AmeMD DATETIME,
	@AmeDesc NVARCHAR(100)
AS
BEGIN
	UPDATE tblAmenity
	SET Name = @AmeName,
		Availability = @AmeAvail,
		Location = @AmeLoc,
		BoughtPrice = @AmeBP,
		CPR = @AmeCPR,
		MainDate = @AmeMD,
		Description = @AmeDesc
	WHERE AmenityID = @AmeID
END
GO

CREATE PROCEDURE SP_DeleteAmenity
	@AmeID INT
AS
BEGIN
	DELETE FROM tblAmenity
	WHERE AmenityID = @AmeID;
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
-- Resident CRUD

-- Get all residents
CREATE PROCEDURE SP_GetAllResidents
AS
BEGIN
    SELECT ResidentID,
           Type,
           FirstName,  -- Changed from Name to FirstName
           LastName,   -- Added LastName for completeness
           Sex,
           BD AS BOD,  -- Assuming BD is the birth date
           PrevHouseNo,
           PrevStNo,
           PrevCommune,
           PrevDistrict,
           PrevProvince,
           PerNum,
           ConNum,
           CheckIn,
           CheckOut
    FROM tblResident;
END
GO

-- Get resident by ID
CREATE PROCEDURE SP_GetResidentByID
    @ResidentID INT
AS
BEGIN
    SELECT * 
    FROM tblResident 
    WHERE ResidentID = @ResidentID;
END
GO

-- Insert a new resident
CREATE PROCEDURE SP_InsertResident
    @ResType NVARCHAR(20),  -- Increased length for Type
    @ResFirstName NVARCHAR(50),
    @ResLastName NVARCHAR(50),  -- Added LastName
    @ResSex NVARCHAR(6),
    @ResBD DATETIME2,  -- Changed to DATETIME2 for consistency
    @ResPrevHouseNo NVARCHAR(30),
    @ResPrevStNo NVARCHAR(30),
    @ResPrevCommune NVARCHAR(30),
    @ResPrevDistrict NVARCHAR(30),
    @ResPrevProvince NVARCHAR(30),
    @ResPerNum NVARCHAR(20),
    @ResConNum NVARCHAR(20),
    @ResCheckIn DATETIME2,  -- Changed to DATETIME2 for consistency
    @ResCheckOut DATETIME2   -- Changed to DATETIME2 for consistency
AS
BEGIN
    INSERT INTO tblResident
    (Type,
     FirstName,
     LastName,  -- Added LastName
     Sex,
     BD,
     PrevHouseNo,
     PrevStNo,
     PrevCommune,
     PrevDistrict,
     PrevProvince,
     PerNum,
     ConNum,
     CheckIn,
     CheckOut)
    VALUES
    (@ResType,
     @ResFirstName,
     @ResLastName,  -- Added LastName
     @ResSex,
     @ResBD,
     @ResPrevHouseNo,
     @ResPrevStNo,
     @ResPrevCommune,
     @ResPrevDistrict,
     @ResPrevProvince,
     @ResPerNum,
     @ResConNum,
     @ResCheckIn,
     @ResCheckOut);
END
GO

-- Update an existing resident
CREATE PROCEDURE SP_UpdateResident
    @ResidentID INT,
    @ResType NVARCHAR(20),  -- Increased length for Type
    @ResFirstName NVARCHAR(50),
    @ResLastName NVARCHAR(50),  -- Added LastName
    @ResSex NVARCHAR(6),
    @ResBD DATETIME2,  -- Changed to DATETIME2 for consistency
    @ResPrevHouseNo NVARCHAR(30),
    @ResPrevStNo NVARCHAR(30),
    @ResPrevCommune NVARCHAR(30),
    @ResPrevDistrict NVARCHAR(30),
    @ResPrevProvince NVARCHAR(30),
    @ResPerNum NVARCHAR(20),
    @ResConNum NVARCHAR(20),
    @ResCheckIn DATETIME2,  -- Changed to DATETIME2 for consistency
    @ResCheckOut DATETIME2   -- Changed to DATETIME2 for consistency
AS
BEGIN
    UPDATE tblResident
    SET Type = @ResType,
        FirstName = @ResFirstName,
        LastName = @ResLastName,  -- Added LastName
        Sex = @ResSex,
        BD = @ResBD,
        PrevHouseNo = @ResPrevHouseNo,
        PrevStNo = @ResPrevStNo,
        PrevCommune = @ResPrevCommune,
        PrevDistrict = @ResPrevDistrict,
        PrevProvince = @ResPrevProvince,
        PerNum = @ResPerNum,
        ConNum = @ResConNum,
        CheckIn = @ResCheckIn,
        CheckOut = @ResCheckOut
    WHERE ResidentID = @ResidentID;
END
GO

-- Delete a resident
CREATE PROCEDURE SP_DeleteResident
    @ResidentID INT
AS
BEGIN
    DELETE FROM tblResident
    WHERE ResidentID = @ResidentID;
END
GO

-- Validate resident ID
CREATE PROCEDURE SP_ValidateResidentID
    @ResidentID INT
AS
BEGIN
    SELECT COUNT(*) 
    FROM tblResident 
    WHERE ResidentID = @ResidentID;
END
GO

-- Get resident name by ID
CREATE PROCEDURE SP_GetResidentNameByID
    @ResidentID INT
AS
BEGIN
    SELECT FirstName, LastName  -- Changed to include LastName
    FROM tblResident
    WHERE ResidentID = @ResidentID;
END
GO

-- Load resident IDs
CREATE PROCEDURE SP_LoadResidentIDs
AS
BEGIN
    SELECT FirstName, LastName, ResidentID  -- Changed to include LastName
    FROM tblResident;
END 
GO

    
--End of Store Procedure Resident

-- Policy CRUD

CREATE PROCEDURE SP_GetAllPolicys
AS
BEGIN
    SELECT * FROM tblPolicy;
END
GO

CREATE PROCEDURE SP_InsertPolicy
    @Name NVARCHAR(100),
    @Description NVARCHAR(MAX),
    @CreatedDate DATETIME,
    @UpdatedDate DATETIME,
    @ResidentID INT
AS
BEGIN
    INSERT INTO tblPolicy (Name, Description, CreatedDate, UpdatedDate, ResidentID)
    VALUES (@Name, @Description, @CreatedDate, @UpdatedDate, @ResidentID)
END
GO

CREATE PROCEDURE SP_UpdatePolicy
    @PolicyID INT,
    @Name NVARCHAR(100),
    @CreatedDate DATETIME,
    @UpdatedDate DATETIME,
    @Description NVARCHAR(MAX),
    @ResidentID INT
AS
BEGIN
    UPDATE tblPolicy
    SET Name = @Name, Description = @Description, CreatedDate = @CreatedDate, UpdatedDate = @UpdatedDate,
				ResidentID = @ResidentID
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

-- Staff CRUD

Create Procedure SP_LoadStaffIDs
As
Begin
	Select FName + '' + LName,
			StaffID
	From tblStaff
END 
GO

CREATE PROCEDURE SP_GetAllStaffs
AS
BEGIN
    SELECT * FROM tblStaff;
END
GO


CREATE PROCEDURE SP_GetStaffByID
    @StaID INT
AS
BEGIN
    SELECT * FROM tblStaff WHERE StaffID = @StaID;
END
GO 

CREATE PROCEDURE SP_InsertStaff
    @StaFName NVARCHAR(50),
    @StaLName NVARCHAR(50),
    @StaSex NVARCHAR(10),
    @StaBD DATETIME,
    @StaPosition NVARCHAR(50),
    @StaHNo NVARCHAR(30),
    @StaSNo NVARCHAR(30),
    @StaCommune NVARCHAR(30),
    @StaDistrict NVARCHAR(30),
    @StaProvince NVARCHAR(30),
    @StaPerNum NVARCHAR(30),
    @StaSalary FLOAT,
    @StaHiredDate DATETIME,
    @StaStopped DATETIME,
AS
BEGIN
    INSERT INTO tblStaff (
        FName, LName, Sex, BD, Position,
        HNo, SNo, Commune, District, Province,
        PerNum, Salary, HiredDate, Stopped
    )
    VALUES (
        @StaFName, @StaLName, @StaSex, @StaBD, @StaPosition,
        @StaHNo, @StaSNo, @StaCommune, @StaDistrict, @StaProvince,
        @StaPerNum, @StaSalary, @StaHiredDate, @StaStopped
    );
END
GO

CREATE PROCEDURE SP_UpdateStaff
    @StaID INT,
    @StaFName NVARCHAR(50),
    @StaLName NVARCHAR(50),
    @StaSex NVARCHAR(10),
    @StaBD DATETIME,
    @StaPosition NVARCHAR(50),
    @StaHNo NVARCHAR(30),
    @StaSNo NVARCHAR(30),
    @StaCommune NVARCHAR(30),
    @StaDistrict NVARCHAR(30),
    @StaProvince NVARCHAR(30),
    @StaPerNum NVARCHAR(30),
    @StaSalary NVARCHAR(20),
    @StaHiredDate DATETIME,
    @StaStopped DATETIME
AS
BEGIN
    UPDATE tblStaff
    SET 
        FName = @StaFName,
        LName = @StaLName,
        Sex = @StaSex,
        BD = @StaBD,
        Position = @StaPosition,
        HNo = @StaHNo,
        SNo = @StaSNo,
        Commune = @StaCommune,
        District = @StaDistrict,
        Province = @StaProvince,
        PerNum = @StaPerNum,
        Salary = @StaSalary,
        HiredDate = @StaHiredDate,
        Stopped = @StaStopped
    WHERE StaffId = @StaID;
END
GO

CREATE PROCEDURE SP_DeleteStaff 
	@StaID INT 
AS BEGIN DELETE FROM tblStaff WHERE StaffID = @StaID; 
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

Create Procedure SP_LoadVendorIDs
As
Begin
	Select Name,
			VendorID
	From tblVendor
END 
GO

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
		   Description
	From tblVendor;
End
Go

Create Procedure SP_GetVendorById
	@VenID INT
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
				 Description
	From tblVendor
	Where VendorID = @VenID;
End
Go

Create Procedure SP_InsertVendor
	@VenName NVARCHAR(50),
	@VenContact NVARCHAR(20),
	@VenHNo NVARCHAR(30),
	@VenSNo NVARCHAR(30),
	@VenCommune NVARCHAR(30),
	@VenDistrict NVARCHAR(30),
	@VenProvince NVARCHAR(30),
	@VenConStart DATETIME,
	@VenConEnd DATETIME,
	@VenStatus BIT,
	@VenDesc NVARCHAR(MAX)
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
		Description
	)
	Values
	(
		@VenName,
		@VenContact,
		@VenHNo,
		@VenSNo,
		@VenCommune,
		@VenDistrict,
		@VenProvince,
		@VenConStart,
		@VenConEnd,
		@VenStatus,
		@VenDesc
	)
End
Go

Create Procedure SP_UpdateVendor
	@VenID INT,
	@VenName NVARCHAR(50),
	@VenContact NVARCHAR(20),
	@VenHNo NVARCHAR(30),
	@VenSNo NVARCHAR(30),
	@VenCommune NVARCHAR(30),
	@VenDistrict NVARCHAR(30),
	@VenProvince NVARCHAR(30),
	@VenConStart DATETIME,
	@VenConEnd DATETIME,
	@VenStatus BIT,
	@VenDesc NVARCHAR(MAX)
As
Begin
	Update tblVendor
	Set Name = @VenName,
		Contact = @VenContact,
		HNo = @VenHNo,
		SNo = @VenSNo,
		Commune = @VenCommune,
	    District = @VenDistrict,
		Province = @VenProvince,
		ConStart = @VenConStart,
		ConEnd = @VenConEnd,
		Status = @VenStatus,
		Description = @VenDesc
	Where VendorID = @VenID
End
Go

Create Procedure SP_DeleteVendor
	@VenID INT
As
Begin
	Delete from tblVendor
	Where VendorID = @VenID;
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
--End of Store Procedure Vendor

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
Create Procedure SP_LoadReservationIDs
As
Begin
	Select ReserStatus,
			ReservationID
	From tblReservation
END 
GO

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

--Start of Room CRUD
Create Procedure SP_LoadRoomIDs
As
Begin
	Select RoomNumber,
			RoomID
	From tblRoom
END 
GO

Create Procedure SP_GetAllRooms
as
BEGIN
    Select * from tblRoom
end
Go

Create Procedure SP_GetRoomByID
    @RoomID INT
AS
Begin
    Select * from tblRoom Where RoomID = @RoomID
END
Go

Create Procedure SP_InsertRoom
    @RoomType NVARCHAR(30),
    @RoomNumber NVARCHAR(10),
    @ResidentID INT
as
BEGIN
    Insert into tblRoom (RoomType, RoomNumber, ResidentID)
    values (@RoomType, @RoomNumber, @ResidentID)
End
Go

Create Procedure SP_UpdateRoom
    @RoomID INT,
    @RoomType NVARCHAR(30),
    @RoomNumber NVARCHAR(10),
    @ResidentID INT
As
Begin
    Update tblRoom 
    SET
        RoomType = @RoomType,
        RoomNumber = @RoomNumber,
        ResidentID = @ResidentID
    WHERE RoomID = @RoomID;
end
GO

Create Procedure SP_DeleteRoom
    @RoomID INT
As
Begin
    Delete from tblRoom
    Where RoomID = @RoomID
end
GO
-- End of Room CRUD

-- Start of Payment CRUD
CREATE PROCEDURE SP_GetAllPayments
AS
BEGIN
    SELECT 
        p.*,
        u.Type,
        s.FName + ' ' + s.LName AS StaffName,
        r.ResidentID
    FROM tblPayment p
    LEFT JOIN tblUtility u ON p.UtilityID = u.UtilityID 
    LEFT JOIN tblStaff s ON p.StaffID = s.StaffID
    LEFT JOIN tblReservation r ON p.ReservationID = r.ReservationID
END
GO

CREATE PROCEDURE SP_GetPaymentByID
    @PaymentID INT
AS
BEGIN
    SELECT 
        p.*,
        u.Type,
        s.FName + ' ' + s.LName AS StaffName,
        r.ResidentID
    FROM tblPayment p
    LEFT JOIN tblUtility u ON p.UtilityID = u.UtilityID
    LEFT JOIN tblStaff s ON p.StaffID = s.StaffID
    LEFT JOIN tblReservation r ON p.ReservationID = r.ReservationID
    WHERE p.PaymentID = @PaymentID
END
GO

CREATE PROCEDURE SP_InsertPayment
    @PaymentDate DATETIME,
    @ReservationID INT = NULL,
    @StaffID INT,
    @UtilityID INT = NULL,
    @PaidAmount DECIMAL(10,2),
    @RemainingAmount DECIMAL(10,2),
    @IsSecondPaymentDone BIT = 0,
    @IsUtilityOnly BIT = 0
AS
BEGIN
    INSERT INTO tblPayment (
        PaymentDate, ReservationID, StaffID, UtilityID,
        PaidAmount, RemainingAmount, IsSecondPaymentDone, IsUtilityOnly
    )
    VALUES (
        @PaymentDate, @ReservationID, @StaffID, @UtilityID,
        @PaidAmount, @RemainingAmount, @IsSecondPaymentDone, @IsUtilityOnly
    );
    SELECT SCOPE_IDENTITY() AS PaymentID;
END
GO

CREATE PROCEDURE SP_UpdatePayment
    @PaymentID INT,
    @PaymentDate DATETIME,
    @ReservationID INT = NULL,
    @StaffID INT,
    @UtilityID INT = NULL,
    @PaidAmount DECIMAL(10,2),
    @RemainingAmount DECIMAL(10,2),
    @IsSecondPaymentDone BIT,
    @IsUtilityOnly BIT
AS
BEGIN
    UPDATE tblPayment
    SET
        PaymentDate = @PaymentDate,
        ReservationID = @ReservationID,
        StaffID = @StaffID,
        UtilityID = @UtilityID,
        PaidAmount = @PaidAmount,
        RemainingAmount = @RemainingAmount,
        IsSecondPaymentDone = @IsSecondPaymentDone,
        IsUtilityOnly = @IsUtilityOnly
    WHERE PaymentID = @PaymentID
END
GO

CREATE PROCEDURE SP_GetUtilityPayments
    @UtilityID INT = NULL
AS
BEGIN
    SELECT 
        p.*,
        u.Type,
        s.FName + ' ' + s.LName AS StaffName
    FROM tblPayment p
    LEFT JOIN tblUtility u ON p.UtilityID = u.UtilityID
    LEFT JOIN tblStaff s ON p.StaffID = s.StaffID
    WHERE p.IsUtilityOnly = 1
    AND (@UtilityID IS NULL OR p.UtilityID = @UtilityID)
END
GO

Create Procedure SP_DeletePayment
    @PaymentID
AS
BEGIN
    Delete from tblPayment where PaymentID = @PaymentID
End
GO