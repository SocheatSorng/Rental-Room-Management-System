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
    SELECT 
        f.FeedbackID,
        f.FeedbackDate,
        f.Content,
        f.Comment,
        f.ResidentID,
        r.FirstName + ' ' + r.LastName AS ResidentName
    FROM tblFeedback f
    LEFT JOIN tblResident r ON f.ResidentID = r.ResidentID
END
GO

CREATE PROCEDURE SP_GetFeedbackByID
    @FeedbackID INT
AS
BEGIN
    SELECT f.FeedbackID, f.FeedbackDate, f.Content, f.Comment, f.ResidentID,
			r.FirstName + ' ' + r.LastName AS ResidentName
    FROM tblFeedback f
    LEFT JOIN tblResident r ON f.ResidentID = r.ResidentID
    WHERE FeedbackID = @FeedbackID
END
GO

CREATE PROCEDURE SP_InsertFeedback
    @FeedbackDate DATETIME,
    @Content NVARCHAR(100),
    @Comment NVARCHAR(MAX),
    @ResidentID INT
AS
BEGIN
    INSERT INTO tblFeedback (FeedbackDate, Content, Comment, ResidentID)
    VALUES (@FeedbackDate, @Content, @Comment, @ResidentID );
    SELECT SCOPE_IDENTITY() AS FeedbackID;
END
GO

CREATE PROCEDURE SP_UpdateFeedback
    @FeedbackID INT,
    @FeedbackDate DATETIME,
    @Content NVARCHAR(100),
    @Comment NVARCHAR(MAX),
    @ResidentID INT
AS
BEGIN
    UPDATE tblFeedback
    SET 
        FeedbackDate = @FeedbackDate,
        Content = @Content,
        Comment = @Comment,
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
--End of Feedback CRUD

-- Utility CRUD

Create Procedure SP_LoadUtilityIDs
As
Begin
	Select UtilityType,
			UtilityID
	From tblUtility
END 
GO

CREATE PROCEDURE SP_GetAllUtilitys
AS
BEGIN
    SELECT u.UtilityID, u.UtilityType, u.Cost, u.UsageDate, u.RoomID, r.RoomNumber
    FROM tblUtility u LEFT JOIN tblRoom r ON u.RoomID = r.RoomID
END
GO

CREATE PROCEDURE SP_GetUtilityByID
    @UtilityID INT
AS
BEGIN
    SELECT u.UtilityID, u.UtilityType, u.Cost, u.UsageDate, u.RoomID, r.RoomNumber
    FROM tblUtility u LEFT JOIN tblRoom r ON u.RoomID = r.RoomID WHERE u.UtilityID = @UtilityID
END
GO
    

CREATE PROCEDURE SP_InsertUtility
    @UtilityType NVARCHAR(50),
    @Cost FLOAT,
    @UsageDate DATETIME2,
    @RoomID INT
AS
BEGIN
    INSERT INTO tblUtility ( UtilityType, Cost, UsageDate, RoomID)
    VALUES (@UtilityType, @Cost, @UsageDate, @RoomID);
    SELECT SCOPE_IDENTITY() AS UtilityID;
END
GO


CREATE PROCEDURE SP_UpdateUtility
    @UtilityID INT,
    @UtilityType NVARCHAR(50),
    @Cost FLOAT,
    @UsageDate DATETIME2,
    @RoomID INT
AS
BEGIN
    UPDATE tblUtility
    SET 
        UtilityType = @UtilityType,
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
    SELECT a.AmenityID, a.Name, a.BoughtPrice, a.CostPerRent, a.MaintenanceDate, a.Description, a.RoomID, r.RoomNumber
    FROM tblAmenity a LEFT JOIN tblRoom r ON a.RoomID = r.RoomID;
END
GO

CREATE PROCEDURE SP_GetAmenityByID
    @AmenityID INT
AS
BEGIN
    SELECT a.AmenityID, a.Name, a.BoughtPrice, a.CostPerRent, a.MaintenanceDate, a.Description, a.RoomID, r.RoomNumber
    FROM tblAmenity a LEFT JOIN tblRoom r ON a.RoomID = r.RoomID WHERE a.AmenityID = @AmenityID;
END
GO

CREATE PROCEDURE SP_InsertAmenity
    @Name NVARCHAR(30),
    @BoughtPrice FLOAT,
    @CostPerRent FLOAT,
    @MaintenanceDate DATETIME,
    @Description NVARCHAR(100),
    @RoomID INT
AS
BEGIN
    IF @RoomID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM tblRoom WHERE RoomID = @RoomID)
    BEGIN
        THROW 50001, 'Invalid RoomID specified', 1;
        RETURN;
    END

    INSERT INTO tblAmenity (Name, BoughtPrice, CostPerRent, MaintenanceDate, Description, RoomID)
    VALUES (@Name, @BoughtPrice, @CostPerRent, @MaintenanceDate, @Description, @RoomID);
    
    SELECT SCOPE_IDENTITY() AS AmenityID;
END
GO

CREATE PROCEDURE SP_UpdateAmenity
    @AmenityID INT,
    @Name NVARCHAR(30),
    @BoughtPrice FLOAT,
    @CostPerRent FLOAT,
    @MaintenanceDate DATETIME,
    @Description NVARCHAR(100),
    @RoomID INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM tblAmenity WHERE AmenityID = @AmenityID)
    BEGIN
        THROW 50002, 'Amenity not found', 1;
        RETURN;
    END

    IF @RoomID IS NOT NULL AND NOT EXISTS (SELECT 1 FROM tblRoom WHERE RoomID = @RoomID)
    BEGIN
        THROW 50001, 'Invalid RoomID specified', 1;
        RETURN;
    END

    UPDATE tblAmenity
    SET 
        Name = @Name,
        BoughtPrice = @BoughtPrice,
        CostPerRent = @CostPerRent,
        MaintenanceDate = @MaintenanceDate,
        Description = @Description,
        RoomID = @RoomID
    WHERE AmenityID = @AmenityID;
END
GO

CREATE PROCEDURE SP_DeleteAmenity
	@AmenityID INTgoo
AS
BEGIN
	DELETE FROM tblAmenity
	WHERE AmenityID = @AmenityID;
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
        r.Amount,
        r.RoomID,
        rm.RoomNumber
    FROM tblRent r
    LEFT JOIN tblRoom rm ON r.RoomID = rm.RoomID
END
GO

CREATE PROCEDURE SP_GetRentByID
    @RentID INT
AS
BEGIN
    SELECT 
        r.RentID,
        r.StartDate, 
        r.EndDate,
        r.Amount,
        r.RoomID,
        rm.RoomNumber
    FROM tblRent r
    LEFT JOIN tblRoom rm ON r.RoomID = rm.RoomID
    WHERE RentID = @RentID
END
GO

CREATE PROCEDURE SP_InsertRent
    @StartDate DATE,
    @EndDate DATE,
    @Amount float,
    @RoomID INT
AS
BEGIN
    INSERT INTO tblRent (StartDate, EndDate, Amount, RoomID)
    VALUES (@StartDate, @EndDate, @Amount, @RoomID);
    SELECT SCOPE_IDENTITY() AS RentID;
END
GO

CREATE PROCEDURE SP_UpdateRent
    @RentID INT,
    @StartDate DATE,
    @EndDate DATE,
    @Amount float,
    @RoomID INT
AS
BEGIN
    UPDATE tblRent
    SET
        StartDate = @StartDate,
        EndDate = @EndDate,
        Amount = @Amount,
        RoomID = @RoomID
    WHERE RentID = @RentID
END
GO

CREATE PROCEDURE SP_DeleteRent
    @RentID INT
AS
BEGIN
    DELETE FROM tblRent 
    WHERE RentID = @RentID
END
GO
--End of Store Precedure Rent

-- Request CRUD
CREATE PROCEDURE SP_LoadRequestIDs
AS
BEGIN
    SELECT r.RequestDescription,
           r.RequestID,
           res.FirstName + ' ' + res.LastName AS ResidentName,
           s.ServiceName
    FROM tblRequest r
    INNER JOIN tblResident res ON r.ResidentID = res.ResidentID
    INNER JOIN tblService s ON r.ServiceID = s.ServiceID
    ORDER BY r.RequestID DESC;
END
GO

CREATE PROCEDURE SP_GetAllRequests
AS
BEGIN
    SELECT r.*, 
           res.FirstName + ' ' + res.LastName AS ResidentName,
           s.ServiceName
    FROM tblRequest r
    INNER JOIN tblResident res ON r.ResidentID = res.ResidentID
    INNER JOIN tblService s ON r.ServiceID = s.ServiceID
    ORDER BY r.RequestID DESC;
END
GO

CREATE PROCEDURE SP_GetRequestById
    @RequestID INT
AS
BEGIN
    SELECT r.*,
           res.FirstName + ' ' + res.LastName AS ResidentName,
           s.ServiceName
    FROM tblRequest r
    INNER JOIN tblResident res ON r.ResidentID = res.ResidentID
    INNER JOIN tblService s ON r.ServiceID = s.ServiceID
    WHERE r.RequestID = @RequestID;
END
GO

CREATE PROCEDURE SP_InsertRequest
    @RequestDate DATETIME,
    @RequestDescription NVARCHAR(MAX),
    @RequestStatus NVARCHAR(50),
    @ResidentID INT,
    @ServiceID INT
AS
BEGIN
    INSERT INTO tblRequest (
        RequestDate,
        RequestDescription,
        RequestStatus,
        ResidentID,
        ServiceID
    )
    VALUES (
        @RequestDate,
        @RequestDescription,
        @RequestStatus,
        @ResidentID,
        @ServiceID
    );
END
GO

CREATE PROCEDURE SP_UpdateRequest
    @RequestID INT,
    @RequestDate DATETIME,
    @RequestDescription NVARCHAR(MAX),
    @RequestStatus NVARCHAR(50),
    @ResidentID INT,
    @ServiceID INT
AS
BEGIN
    UPDATE tblRequest
    SET 
        RequestDate = @RequestDate,
        RequestDescription = @RequestDescription,
        RequestStatus = @RequestStatus,
        ResidentID = @ResidentID,
        ServiceID = @ServiceID
    WHERE RequestID = @RequestID;
END
GO

CREATE PROCEDURE SP_DeleteRequest
    @RequestID INT
AS
BEGIN
    DELETE FROM tblRequest 
    WHERE RequestID = @RequestID;
END
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
       r.PaidAmount,
       r.RemainingAmount,
       res.FirstName + ' ' + res.LastName AS ResidentName,
       rm.RoomNumber,
       rt.BasePrice as RoomAmount
   FROM tblReservation r
   LEFT JOIN tblResident res ON r.ResidentID = res.ResidentID
   LEFT JOIN tblRoom rm ON r.RoomID = rm.RoomID
   LEFT JOIN tblRoomType rt ON rm.RoomTypeID = rt.RoomTypeID;
END
GO

-- Get reservation by ID
CREATE PROCEDURE SP_GetReservationByID
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
       r.PaidAmount,
       r.RemainingAmount,
       res.FirstName + ' ' + res.LastName AS ResidentName,
       rm.RoomNumber,
       rt.BasePrice as RoomAmount
   FROM tblReservation r
   LEFT JOIN tblResident res ON r.ResidentID = res.ResidentID
   LEFT JOIN tblRoom rm ON r.RoomID = rm.RoomID
   LEFT JOIN tblRoomType rt ON rm.RoomTypeID = rt.RoomTypeID
   WHERE r.ReservationID = @ReservationID;
END
GO

-- Get room amount and calculate remaining
CREATE PROCEDURE SP_GetRoomAmount
   @RoomID INT,
   @PaidAmount DECIMAL(10,2),
   @RemainingAmount DECIMAL(10,2) OUTPUT
AS
BEGIN
   DECLARE @BasePrice DECIMAL(10,2)

   SELECT @BasePrice = rt.BasePrice
   FROM tblRoom r
   JOIN tblRoomType rt ON r.RoomTypeID = rt.RoomTypeID
   WHERE r.RoomID = @RoomID;

   SET @RemainingAmount = @BasePrice - @PaidAmount;

   SELECT @BasePrice AS BasePrice, @RemainingAmount AS RemainingAmount;
END
GO

-- Insert reservation
CREATE PROCEDURE SP_InsertReservation
    @ReservationDate DATETIME,
    @StartDate DATETIME,
    @EndDate DATETIME,
    @Status NVARCHAR(50),
    @ResidentID INT,
    @RoomID INT,
    @PaidAmount DECIMAL(10,2),
    @RemainingAmount DECIMAL(10,2)
AS
BEGIN
    INSERT INTO tblReservation (
        ReservationDate,
        StartDate,
        EndDate,
        Status,
        ResidentID,
        RoomID,
        PaidAmount,
        RemainingAmount
    )
    VALUES (
        @ReservationDate,
        @StartDate,
        @EndDate,
        @Status,
        @ResidentID,
        @RoomID,
        @PaidAmount,
        @RemainingAmount
    );
    
    SELECT SCOPE_IDENTITY() as ReservationID;
END

CREATE PROCEDURE SP_UpdateReservation
    @ReservationID INT,
    @ReservationDate DATETIME,
    @StartDate DATETIME,
    @EndDate DATETIME, 
    @Status NVARCHAR(50),
    @ResidentID INT,
    @RoomID INT,
    @PaidAmount DECIMAL(10,2),
    @RemainingAmount DECIMAL(10,2)
AS
BEGIN
    -- Validate inputs
    IF NOT EXISTS (SELECT 1 FROM tblResident WHERE ResidentID = @ResidentID)
    BEGIN
        THROW 50001, 'Resident not found', 1;
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM tblRoom WHERE RoomID = @RoomID)
    BEGIN
        THROW 50002, 'Room not found', 1;
        RETURN;
    END

    IF @EndDate <= @StartDate
    BEGIN
        THROW 50003, 'End date must be after start date', 1;
        RETURN;
    END

    -- Check for overlapping reservations (excluding current reservation)
    IF EXISTS (
        SELECT 1 
        FROM tblReservation 
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
    UPDATE tblReservation
    SET 
        ReservationDate = @ReservationDate,
        StartDate = @StartDate,
        EndDate = @EndDate,
        Status = @Status,
        ResidentID = @ResidentID,
        RoomID = @RoomID,
        PaidAmount = @PaidAmount,
        RemainingAmount = @RemainingAmount
    WHERE ReservationID = @ReservationID;

    -- If no rows were updated, the reservation doesn't exist
    IF @@ROWCOUNT = 0
    BEGIN
        THROW 50005, 'Reservation not found', 1;
    END
END
GO

-- Delete reservation
CREATE PROCEDURE SP_DeleteReservation
   @ReservationID INT
AS
BEGIN
   DELETE FROM tblReservation 
   WHERE ReservationID = @ReservationID;
END
GO

-- Get room details with price
CREATE PROCEDURE SP_GetRoomDetailsWithPrice
   @RoomID INT
AS
BEGIN
   SELECT 
       r.RoomID,
       r.RoomNumber,
       rt.TypeName,
       ISNULL(rt.BasePrice, 0) as BasePrice,  -- Handle NULL values
       rt.Capacity
   FROM tblRoom r
   LEFT JOIN tblRoomType rt ON r.RoomTypeID = rt.RoomTypeID
   WHERE r.RoomID = @RoomID;
END
GO

-- Get available rooms
CREATE PROCEDURE SP_GetAvailableRooms
AS
BEGIN
   SELECT 
       r.RoomID,
       r.RoomNumber,
       rt.TypeName,
       rt.BasePrice as RoomAmount,
       rt.Capacity,
       r.Status,  -- Added room status
       r.LastModifiedDate,  -- Added modification tracking
       r.LastModifiedBy    -- Added who modified it
   FROM tblRoom r
   INNER JOIN tblRoomType rt ON r.RoomTypeID = rt.RoomTypeID
   WHERE r.ResidentID IS NULL
   AND r.Status = 'Available'  -- Only show rooms marked as available
   AND r.Status NOT IN ('UnderMaintenance', 'Renovation', 'OutOfService')  -- Exclude rooms under modification
   ORDER BY r.RoomNumber;
END
GO

-- Load reservation IDs
CREATE PROCEDURE SP_LoadReservationIDs
AS
BEGIN
   SELECT 
       ReservationID,
       Status
   FROM tblReservation;
END
GO
--End of Reservation CRUD


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
       r.RoomNumber,
       r.RoomID,
       rt.TypeName,
       rt.BasePrice
   FROM tblRoom r
   LEFT JOIN tblRoomType rt ON r.RoomTypeID = rt.RoomTypeID
   ORDER BY r.RoomID;
END 
GO

CREATE PROCEDURE SP_GetAllRooms
AS
BEGIN
    SELECT r.RoomID,
           r.RoomNumber,
           r.ResidentID,
           r.RoomTypeID,
           r.Status,
           rt.TypeName as RoomTypeName,
           CASE WHEN r.ResidentID IS NOT NULL 
                THEN res.FirstName + ' ' + res.LastName 
                ELSE NULL 
           END as ResidentName
    FROM tblRoom r
    LEFT JOIN tblRoomType rt ON r.RoomTypeID = rt.RoomTypeID
    LEFT JOIN tblResident res ON r.ResidentID = res.ResidentID;
END
GO

CREATE PROCEDURE SP_GetRoomByID
    @RoomID INT
AS
BEGIN
    SELECT r.RoomID,
           r.RoomNumber,
           r.ResidentID,
           r.RoomTypeID,
           r.Status,
           rt.TypeName as RoomTypeName,
           CASE WHEN r.ResidentID IS NOT NULL 
                THEN res.FirstName + ' ' + res.LastName 
                ELSE NULL 
           END as ResidentName
    FROM tblRoom r
    LEFT JOIN tblRoomType rt ON r.RoomTypeID = rt.RoomTypeID
    LEFT JOIN tblResident res ON r.ResidentID = res.ResidentID
    WHERE r.RoomID = @RoomID;
END
GO

CREATE PROCEDURE SP_InsertRoom
    @RoomNumber NVARCHAR(10),
    @ResidentID INT = NULL,
    @RoomTypeID INT,
    @Status BIT = 0
AS
BEGIN
    INSERT INTO tblRoom (RoomNumber, ResidentID, RoomTypeID, Status)
    VALUES (@RoomNumber, @ResidentID, @RoomTypeID, @Status);
    
    SELECT SCOPE_IDENTITY() AS RoomID;
END
GO

CREATE PROCEDURE SP_UpdateRoom
    @RoomID INT,
    @RoomNumber NVARCHAR(10),
    @ResidentID INT = NULL,
    @RoomTypeID INT,
    @Status BIT
AS
BEGIN
    UPDATE tblRoom
    SET RoomNumber = @RoomNumber,
        ResidentID = @ResidentID,
        RoomTypeID = @RoomTypeID,
        Status = @Status
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
        u.UtilityType AS UtilityType,
        sv.ServiceName,
        s.FirstName + ' ' + s.LastName AS StaffName,
        r.ResidentID,
        res.FirstName + ' ' + res.LastName AS ResidentName
    FROM tblPayment p
    LEFT JOIN tblUtility u ON p.UtilityID = u.UtilityID 
    LEFT JOIN tblService sv ON p.ServiceID = sv.ServiceID
    LEFT JOIN tblStaff s ON p.StaffID = s.StaffID
    LEFT JOIN tblReservation r ON p.ReservationID = r.ReservationID
    LEFT JOIN tblResident res ON r.ResidentID = res.ResidentID
    WHERE p.Status = 1
    ORDER BY p.PaymentDate DESC
END
GO


CREATE PROCEDURE SP_GetPaymentByID
    @PaymentID INT
AS
BEGIN
    SELECT 
        p.*,
        u.UtilityType AS UtilityType,
        sv.ServiceName,
        s.FirstName + ' ' + s.LastName AS StaffName,
        r.ResidentID,
        res.FirstName + ' ' + res.LastName AS ResidentName
    FROM tblPayment p
    LEFT JOIN tblUtility u ON p.UtilityID = u.UtilityID
    LEFT JOIN tblService sv ON p.ServiceID = sv.ServiceID
    LEFT JOIN tblStaff s ON p.StaffID = s.StaffID
    LEFT JOIN tblReservation r ON p.ReservationID = r.ReservationID
    LEFT JOIN tblResident res ON r.ResidentID = res.ResidentID
    WHERE p.PaymentID = @PaymentID AND p.Status = 1
END
GO

CREATE PROCEDURE SP_InsertPayment
    @PaymentDate DATETIME,
    @ReservationID INT = NULL,
    @StaffID INT,
    @UtilityID INT = NULL,
    @ServiceID INT = NULL,
    @PaidAmount DECIMAL(10,2),
    @RemainingAmount DECIMAL(10,2),
    @IsSecondPaymentDone BIT = 0,
    @IsUtilityOnly BIT = 0,
    @IsServiceOnly BIT = 0,
    @Description NVARCHAR(MAX) = NULL
AS
BEGIN
    INSERT INTO tblPayment (
        PaymentDate, ReservationID, StaffID, UtilityID, ServiceID,
        PaidAmount, RemainingAmount, IsSecondPaymentDone, 
        IsUtilityOnly, IsServiceOnly, Description, Status
    )
    VALUES (
        @PaymentDate, @ReservationID, @StaffID, @UtilityID, @ServiceID,
        @PaidAmount, @RemainingAmount, @IsSecondPaymentDone, 
        @IsUtilityOnly, @IsServiceOnly, @Description, 1
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
    @ServiceID INT = NULL,
    @PaidAmount DECIMAL(10,2),
    @RemainingAmount DECIMAL(10,2),
    @IsSecondPaymentDone BIT,
    @IsUtilityOnly BIT,
    @IsServiceOnly BIT,
    @Description NVARCHAR(MAX) = NULL
AS
BEGIN
    UPDATE tblPayment
    SET
        PaymentDate = @PaymentDate,
        ReservationID = @ReservationID,
        StaffID = @StaffID,
        UtilityID = @UtilityID,
        ServiceID = @ServiceID,
        PaidAmount = @PaidAmount,
        RemainingAmount = @RemainingAmount,
        IsSecondPaymentDone = @IsSecondPaymentDone,
        IsUtilityOnly = @IsUtilityOnly,
        IsServiceOnly = @IsServiceOnly,
        Description = @Description
    WHERE PaymentID = @PaymentID AND Status = 1
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

CREATE PROCEDURE SP_DeletePayment
    @PaymentID INT
AS
BEGIN
    UPDATE tblPayment 
    SET Status = 0
    WHERE PaymentID = @PaymentID
END
GO