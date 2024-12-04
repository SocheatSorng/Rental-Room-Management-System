USE rrmsdb;
GO


-- Resident CRUD

CREATE PROCEDURE SP_GetAllResidents
AS
BEGIN
    SELECT ResidentID, Type, FirstName, LastName, Sex, BD, PrevHouseNo, PrevStNo, PrevCommune, PrevDistrict,
           PrevProvince, PerNum, ConNum, CheckIn, CheckOut
    FROM tblResident;
END
GO

-- Get resident by ID
CREATE PROCEDURE SP_GetResidentByID
    @ResidentID INT
AS
BEGIN
    SELECT *  FROM tblResident  WHERE ResidentID = @ResidentID;
END
GO

-- Insert a new resident
CREATE PROCEDURE SP_InsertResident
    @ResType NVARCHAR(20), 
    @ResFirstName NVARCHAR(50),
    @ResLastName NVARCHAR(50),
    @ResSex NVARCHAR(6),
    @ResBD DATETIME,
    @ResPrevHouseNo NVARCHAR(30),
    @ResPrevStNo NVARCHAR(30),
    @ResPrevCommune NVARCHAR(30),
    @ResPrevDistrict NVARCHAR(30),
    @ResPrevProvince NVARCHAR(30),
    @ResPerNum NVARCHAR(20),
    @ResConNum NVARCHAR(20),
    @ResCheckIn DATETIME,  
    @ResCheckOut DATETIME
AS
BEGIN
    INSERT INTO tblResident (Type, FirstName, LastName, Sex, BD, PrevHouseNo, PrevStNo, PrevCommune,
     PrevDistrict, PrevProvince, PerNum, ConNum, CheckIn, CheckOut)
    VALUES (@ResType, @ResFirstName, @ResLastName, @ResSex, @ResBD, @ResPrevHouseNo, @ResPrevStNo,
     @ResPrevCommune, @ResPrevDistrict, @ResPrevProvince, @ResPerNum, @ResConNum, @ResCheckIn, @ResCheckOut);
END
GO

-- Update an existing resident
CREATE PROCEDURE SP_UpdateResident
    @ResidentID INT,
    @ResType NVARCHAR(20),  
    @ResFirstName NVARCHAR(50),
    @ResLastName NVARCHAR(50), 
    @ResSex NVARCHAR(6),
    @ResBD DATETIME, 
    @ResPrevHouseNo NVARCHAR(30),
    @ResPrevStNo NVARCHAR(30),
    @ResPrevCommune NVARCHAR(30),
    @ResPrevDistrict NVARCHAR(30),
    @ResPrevProvince NVARCHAR(30),
    @ResPerNum NVARCHAR(20),
    @ResConNum NVARCHAR(20),
    @ResCheckIn DATETIME, 
    @ResCheckOut DATETIME   
AS
BEGIN
    UPDATE tblResident
    SET Type = @ResType,
        FirstName = @ResFirstName,
        LastName = @ResLastName, 
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
    DELETE FROM tblResident WHERE ResidentID = @ResidentID;
END
GO
GO

-- Get resident name by ID
CREATE PROCEDURE SP_GetResidentNameByID
    @ResidentID INT
AS
BEGIN
    SELECT FirstName, LastName FROM tblResident WHERE ResidentID = @ResidentID;
END
GO

-- Load resident IDs
CREATE PROCEDURE SP_LoadResidentIDs
AS
BEGIN
    SELECT FirstName, LastName, ResidentID FROM tblResident;
END 
GO  
--End of Resident CRUD

--Staff CRUD
CREATE PROCEDURE SP_LoadStaffIDs
AS
BEGIN
    SELECT 
        FirstName + ' ' + LastName AS StaffName,
        StaffID
    FROM tblStaff;
END
GO

CREATE PROCEDURE SP_GetAllStaffs
AS
BEGIN
    SELECT 
        StaffID, FirstName, LastName, Sex, BirthDate, Position, HouseNo, StreetNo, Commune, District, Province,
        PersonalNumber, Salary, StartDate, StoppedDate
    FROM tblStaff;
END
GO

CREATE PROCEDURE SP_GetStaffByID
    @StaffID INT
AS
BEGIN
    SELECT StaffID, FirstName, LastName, Sex, BirthDate, Position, HouseNo, StreetNo, Commune, District,
        Province, PersonalNumber, Salary, StartDate, StoppedDate
    FROM tblStaff WHERE StaffID = @StaffID;
END
GO

CREATE PROCEDURE SP_InsertStaff
    @StaFirstName NVARCHAR(50),
    @StaLastName NVARCHAR(50),
    @StaSex NVARCHAR(10),
    @StaBD DATETIME,
    @StaPosition NVARCHAR(50),
    @StaHouseNo NVARCHAR(30),
    @StaStreetNo NVARCHAR(30),
    @StaCommune NVARCHAR(30),
    @StaDistrict NVARCHAR(30),
    @StaProvince NVARCHAR(30),
    @StaPerNum NVARCHAR(30),
    @StaSalary FLOAT,
    @StaHiredDate DATETIME,
    @StaStopped DATETIME = NULL
AS
BEGIN
    INSERT INTO tblStaff (FirstName, LastName, Sex, BirthDate, Position, HouseNo, StreetNo, Commune, District,
        Province, PersonalNumber, Salary, StartDate, StoppedDate)
    VALUES (@StaFirstName, @StaLastName, @StaSex, @StaBD, @StaPosition, @StaHouseNo, @StaStreetNo, @StaCommune,
		@StaDistrict, @StaProvince, @StaPerNum, @StaSalary, @StaHiredDate, @StaStopped);
    SELECT SCOPE_IDENTITY() AS StaffID;
END
GO

CREATE PROCEDURE SP_UpdateStaff
	@StaID INT,
    @StaFirstName NVARCHAR(50),
    @StaLastName NVARCHAR(50),
    @StaSex NVARCHAR(10),
    @StaBD DATETIME,
    @StaPosition NVARCHAR(50),
    @StaHouseNo NVARCHAR(30),
    @StaStreetNo NVARCHAR(30),
    @StaCommune NVARCHAR(30),
    @StaDistrict NVARCHAR(30),
    @StaProvince NVARCHAR(30),
    @StaPerNum NVARCHAR(30),
    @StaSalary FLOAT,
    @StaHiredDate DATETIME,
    @StaStopped DATETIME = NULL
AS
BEGIN
    UPDATE tblStaff
    SET 
        FirstName = @StaFirstName,
        LastName = @StaLastName,
        Sex = @StaSex,
        BirthDate = @StaBD,
        Position = @StaPosition,
        HouseNo = @StaHouseNo,
        StreetNo = @StaStreetNo,
        Commune = @StaCommune,
        District = @StaDistrict,
        Province = @StaProvince,
        PersonalNumber = @StaPerNum,
        Salary = @StaSalary,
        StartDate = @StaHiredDate,
        StoppedDate = @StaStopped
    WHERE StaffID = @StaID;
END
GO

CREATE PROCEDURE SP_DeleteStaff
    @StaffID INT
AS
BEGIN
    DELETE FROM tblStaff WHERE StaffID = @StaffID;
END
GO
--End of Staff CRUD

-- Vendor CRUD

CREATE PROCEDURE SP_LoadVendorIDs
AS
BEGIN
    SELECT Name, VendorID FROM tblVendor
END
GO

CREATE PROCEDURE SP_GetAllVendors
AS
BEGIN
    SELECT VendorID, Name, Contact, HouseNo, StreetNo, Commune, District, Province, ContractStart, ContractEnd,
           Status, Description
    FROM tblVendor;
END
GO

CREATE PROCEDURE SP_GetVendorByID
    @VendorID INT
AS
BEGIN
    SELECT TOP 1 VendorID, Name, Contact, HouseNo, StreetNo, Commune, District, Province, ContractStart,
           ContractEnd, Status, Description
    FROM tblVendor WHERE VendorID = @VendorID;
END
GO

CREATE PROCEDURE SP_InsertVendor
    @VenName NVARCHAR(50),
    @VenContact NVARCHAR(20),
    @VenHouseNo NVARCHAR(30),
    @VenStreetNo NVARCHAR(30),
    @VenCommune NVARCHAR(30),
    @VenDistrict NVARCHAR(30),
    @VenProvince NVARCHAR(30),
    @VenConStart DATETIME,
    @VenConEnd DATETIME,
    @VenStatus BIT,
    @VenDesc NVARCHAR(100)
AS
BEGIN
    INSERT INTO tblVendor (Name, Contact, HouseNo, StreetNo, Commune, District, Province, ContractStart,
        ContractEnd, Status, Description)
    VALUES (@VenName, @VenContact, @VenHouseNo, @VenStreetNo, @VenCommune, @VenDistrict, @VenProvince,
        @VenConStart, @VenConEnd, @VenStatus, @VenDesc);
    SELECT SCOPE_IDENTITY() AS VendorID;
END
GO

CREATE PROCEDURE SP_UpdateVendor
    @VendorID INT,
    @VenName NVARCHAR(50),
    @VenContact NVARCHAR(20),
    @VenHouseNo NVARCHAR(30),
    @VenStreetNo NVARCHAR(30),
    @VenCommune NVARCHAR(30),
    @VenDistrict NVARCHAR(30),
    @VenProvince NVARCHAR(30),
    @VenConStart DATETIME,
    @VenConEnd DATETIME,
    @VenStatus BIT,
    @VenDesc NVARCHAR(100)
AS
BEGIN
    UPDATE tblVendor
    SET Name = @VenName,
        Contact = @VenContact,
        HouseNo = @VenHouseNo,
        StreetNo = @VenStreetNo,
        Commune = @VenCommune,
        District = @VenDistrict,
        Province = @VenProvince,
        ContractStart = @VenConStart,
        ContractEnd = @VenConEnd,
        Status = @VenStatus,
        Description = @VenDesc
    WHERE VendorID = @VendorID;
END
GO

CREATE PROCEDURE SP_DeleteVendor
    @VendorID INT
AS
BEGIN
    DELETE FROM tblVendor WHERE VendorID = @VendorID;
END
GO
--End of Vendor CRUD

--RoomType CRUD

Create Procedure SP_GetAllRoomTypes
as
Begin
    Select RoomTypeID, TypeName, Description, BasePrice, Capacity
    From tblRoomType
END
Go

Create Procedure SP_GetRoomTypeByID
    @RoomTypeID INT
AS
BEGIN
    Select TypeName, Description, BasePrice, Capacity
    From tblRoomType Where RoomTypeID = @RoomTypeID
End
GO

Create Procedure SP_InsertRoomType
    @TypeName NVARCHAR(50),
    @Description NVARCHAR(100),
    @BasePrice float,
    @Capacity INT
as
Begin
    Insert into tblRoomType (TypeName, Description, BasePrice, Capacity)
    Values (@TypeName, @Description, @BasePrice, @Capacity);
end
GO

Create Procedure SP_UpdateRoomType
    @RoomTypeID INT,
    @TypeName NVARCHAR(50),
    @Description NVARCHAR(100),
    @BasePrice float,
    @Capacity INT
AS
BEGIN
    Update tblRoomType
    SET TypeName = @TypeName,
        Description = @Description,
        BasePrice = @BasePrice,
        Capacity = @Capacity
    Where RoomTypeID = @RoomTypeID;
END
GO

Create Procedure SP_DeleteRoomType
    @RoomTypeID INT
As
Begin
    Delete From tblRoomType Where RoomTypeId = @RoomTypeID
END
GO
--End of RoomType CRUD

-- LeaseAgreement CRUD
CREATE PROCEDURE SP_GetAllLeaseAgreements
AS
BEGIN
    SELECT 
        l.LeaseAgreementID,
        l.StartDate,
        l.EndDate,
        l.TermsAndConditions,
        l.ResidentID,
        r.FirstName + ' ' + r.LastName AS ResName
    FROM tblLeaseAgreement l
    LEFT JOIN tblResident r ON l.ResidentID = r.ResidentID;
END
GO

CREATE PROCEDURE SP_GetLeaseAgreementByID
    @LeaseAgreementID INT
AS
BEGIN
    SELECT 
        l.LeaseAgreementID, l.StartDate, l.EndDate, l.TermsAndConditions, l.ResidentID,
        r.FirstName + ' ' + r.LastName AS ResName
    FROM tblLeaseAgreement l
    LEFT JOIN tblResident r ON l.ResidentID = r.ResidentID
    WHERE LeaseAgreementID = @LeaseAgreementID;
END
GO

CREATE PROCEDURE SP_InsertLeaseAgreement
    @StartDate DATETIME,
    @EndDate DATETIME,
    @TermsAndConditions NVARCHAR(MAX),
    @ResidentID INT
AS
BEGIN
    INSERT INTO tblLeaseAgreement (StartDate, EndDate, TermsAndConditions, ResidentID)
    VALUES (@StartDate, @EndDate, @TermsAndConditions, @ResidentID);
    SELECT SCOPE_IDENTITY() AS LeaseAgreementID;
END
GO

CREATE PROCEDURE SP_UpdateLeaseAgreement
    @LeaseAgreementID INT,
    @StartDate DATETIME,
    @EndDate DATETIME, 
    @TermsAndConditions NVARCHAR(MAX),
    @ResidentID INT
AS
BEGIN
    UPDATE tblLeaseAgreement
    SET
        StartDate = @StartDate,
        EndDate = @EndDate,
        TermsAndConditions = @TermsAndConditions,
        ResidentID = @ResidentID
    WHERE LeaseAgreementID = @LeaseAgreementID;
END
GO

CREATE PROCEDURE SP_DeleteLeaseAgreement
    @LeaseAgreementID INT
AS
BEGIN
    DELETE FROM tblLeaseAgreement 
    WHERE LeaseAgreementID = @LeaseAgreementID;
END
GO
--End of LeaseAgreement CRUD

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

-- Policy CRUD

CREATE PROCEDURE SP_LoadPolicyIDs
AS
BEGIN
    SELECT PolicyID, Name FROM tblPolicy;
END
GO

CREATE PROCEDURE SP_GetAllPolicies
AS
BEGIN
    SELECT p.*, 
           r.FirstName + ' ' + r.LastName AS ResidentName,
           s.FirstName + ' ' + s.LastName AS StaffName
    FROM tblPolicy p
    LEFT JOIN tblResident r ON p.ResidentID = r.ResidentID
    LEFT JOIN tblStaff s ON p.StaffID = s.StaffID
    ORDER BY p.PolicyID;
END
GO


CREATE PROCEDURE SP_GetPolicyByID
    @PolicyID INT
AS
BEGIN
    SELECT p.*, 
           r.FirstName + ' ' + r.LastName AS ResidentName,
           s.FirstName + ' ' + s.LastName AS StaffName
    FROM tblPolicy p
    LEFT JOIN tblResident r ON p.ResidentID = r.ResidentID
    LEFT JOIN tblStaff s ON p.StaffID = s.StaffID
    WHERE p.PolicyID = @PolicyID;
END
GO


CREATE PROCEDURE SP_InsertPolicy
    @Name NVARCHAR(100),
    @PolicyDescription NVARCHAR(MAX),
    @CreatedDate DATETIME,
    @UpdatedDate DATETIME,
    @ResidentID INT,
    @StaffID INT
AS
BEGIN
    INSERT INTO tblPolicy (Name, PolicyDescription, CreatedDate, UpdatedDate, ResidentID, StaffID)
    VALUES (@Name, @PolicyDescription, @CreatedDate, @UpdatedDate, @ResidentID, @StaffID);
    
    SELECT SCOPE_IDENTITY() AS PolicyID;
END
GO


CREATE PROCEDURE SP_UpdatePolicy
    @PolicyID INT,
    @Name NVARCHAR(100),
    @PolicyDescription NVARCHAR(MAX),
    @CreatedDate DATETIME,
    @UpdatedDate DATETIME,
    @ResidentID INT,
    @StaffID INT
AS
BEGIN
    UPDATE tblPolicy
    SET Name = @Name,
        PolicyDescription = @PolicyDescription,
        CreatedDate = @CreatedDate,
        UpdatedDate = @UpdatedDate,
        ResidentID = @ResidentID,
        StaffID = @StaffID
    WHERE PolicyID = @PolicyID;
END
GO


CREATE PROCEDURE SP_DeletePolicy
    @PolicyID INT
AS
BEGIN
    DELETE FROM tblPolicy WHERE PolicyID = @PolicyID;
END
GO
--End of Policy CRUD


-- Validate Policy ID
CREATE PROCEDURE SP_ValidatePolicyID
    @PolicyID INT
AS
BEGIN
    SELECT COUNT(*) 
    FROM tblPolicy 
    WHERE PolicyID = @PolicyID;
END
GO

--End of Store Procedure Policy





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

CREATE PROCEDURE SP_LoadServiceIDs
AS
BEGIN
    SELECT ServiceID,
           ServiceName,
           CAST(ServiceCost as FLOAT) as ServiceCost,
           ServiceDescription
    FROM tblService
    ORDER BY ServiceName;
END
GO


CREATE PROCEDURE SP_GetAllServices
AS
BEGIN
    SELECT s.ServiceID, 
           s.ServiceName, 
           s.ServiceDescription, 
           CAST(s.ServiceCost as FLOAT) as ServiceCost,
           s.VendorID,
           s.RoomID,
           r.RoomNumber,
           v.Name as VendorName
    FROM tblService s
    LEFT JOIN tblVendor v ON s.VendorID = v.VendorID
    LEFT JOIN tblRoom r ON s.RoomID = r.RoomID;
END
GO

CREATE PROCEDURE SP_GetServiceByID
    @ServiceID INT
AS
BEGIN
    SELECT s.ServiceID, 
           s.ServiceName, 
           s.ServiceDescription, 
           CAST(s.ServiceCost as FLOAT) as ServiceCost,
           s.VendorID,
           s.RoomID,
           r.RoomNumber,
           v.Name as VendorName
    FROM tblService s
    LEFT JOIN tblVendor v ON s.VendorID = v.VendorID
    LEFT JOIN tblRoom r ON s.RoomID = r.RoomID
    WHERE s.ServiceID = @ServiceID;
END
GO

CREATE PROCEDURE SP_InsertService
    @ServiceName NVARCHAR(100),
    @ServiceDescription NVARCHAR(MAX),
    @ServiceCost FLOAT,
    @VendorID INT = NULL,
    @RoomID INT = NULL
AS
BEGIN
    INSERT INTO tblService (
        ServiceName, 
        ServiceDescription, 
        ServiceCost, 
        VendorID,
        RoomID
    )
    VALUES (
        @ServiceName, 
        @ServiceDescription, 
        @ServiceCost, 
        @VendorID,
        @RoomID
    );
    
    SELECT SCOPE_IDENTITY() AS ServiceID;
END
GO

CREATE PROCEDURE SP_UpdateService
    @ServiceID INT,
    @ServiceName NVARCHAR(100),
    @ServiceDescription NVARCHAR(MAX),
    @ServiceCost FLOAT,
    @VendorID INT = NULL,
    @RoomID INT = NULL
AS
BEGIN
    UPDATE tblService
    SET ServiceName = @ServiceName,
        ServiceDescription = @ServiceDescription,
        ServiceCost = @ServiceCost,
        VendorID = @VendorID,
        RoomID = @RoomID
    WHERE ServiceID = @ServiceID;
END
GO

CREATE PROCEDURE SP_DeleteService
    @ServiceID INT
AS
BEGIN
    DELETE FROM tblService 
    WHERE ServiceID = @ServiceID;
END
GO

--End of Store Precedure Request

--Start of Room CRUD
CREATE PROCEDURE SP_LoadRoomIDs
AS
BEGIN
   SELECT 
       RoomNumber,
       RoomID,
       rt.TypeName
   FROM tblRoom r
   LEFT JOIN tblRoomType rt ON r.RoomTypeID = rt.RoomTypeID;
END 
GO

CREATE PROCEDURE SP_GetAllRooms
AS
BEGIN
   SELECT 
       r.RoomID,
       r.RoomNumber,
       r.ResidentID,
       r.RoomTypeID,
       res.FirstName + ' ' + res.LastName AS ResidentName,
       rt.TypeName
   FROM tblRoom r
   LEFT JOIN tblResident res ON r.ResidentID = res.ResidentID
   LEFT JOIN tblRoomType rt ON r.RoomTypeID = rt.RoomTypeID;
END
GO

CREATE PROCEDURE SP_GetRoomByID
   @RoomID INT
AS
BEGIN
   SELECT 
       r.RoomID,
       r.RoomNumber, 
       r.ResidentID,
       r.RoomTypeID,
       res.FirstName + ' ' + res.LastName AS ResidentName,
       rt.TypeName
   FROM tblRoom r
   LEFT JOIN tblResident res ON r.ResidentID = res.ResidentID
   LEFT JOIN tblRoomType rt ON r.RoomTypeID = rt.RoomTypeID
   WHERE r.RoomID = @RoomID;
END
GO

CREATE PROCEDURE SP_InsertRoom
   @RoomNumber NVARCHAR(20),
   @ResidentID INT = NULL,
   @RoomTypeID INT = NULL
AS
BEGIN
   INSERT INTO tblRoom (RoomNumber, ResidentID, RoomTypeID)
   VALUES (@RoomNumber, @ResidentID, @RoomTypeID);
   SELECT SCOPE_IDENTITY() AS RoomID;
END
GO

CREATE PROCEDURE SP_UpdateRoom
   @RoomID INT,
   @RoomNumber NVARCHAR(20),
   @ResidentID INT = NULL,
   @RoomTypeID INT = NULL
AS
BEGIN
   UPDATE tblRoom
   SET 
       RoomNumber = @RoomNumber,
       ResidentID = @ResidentID,
       RoomTypeID = @RoomTypeID
   WHERE RoomID = @RoomID;
END
GO

CREATE PROCEDURE SP_DeleteRoom
   @RoomID INT
AS
BEGIN
   DELETE FROM tblRoom WHERE RoomID = @RoomID;
END
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