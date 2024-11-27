CREATE DATABASE rrmsdb;
GO
USE rrmsdb;
GO

-- Table RESIDENT
CREATE TABLE tblResident (
    ResidentID INT PRIMARY KEY IDENTITY(1,1),
    ResidentType NVARCHAR(10),
	ResidentName NVARCHAR(50),
	ResidentSex NVARCHAR(6),
	ResidentBOD DATETIME,
	ResidentPrevHouseNo NVARCHAR(30),
	ResidentPrevStNo NVARCHAR(30),
	ResidentPrevCommune NVARCHAR(30),
	ResidentPrevDistrict NVARCHAR(30),
	ResidentPerNum NVARCHAR(20),
	ResidentConNum NVARCHAR(20),
	ResidentCheckIn DATETIME,
	ResidentCheckOut DATETIME
);

-- Table VENDOR
Create Table tblVendor (
	VendorID int primary key identity(1,1),
	VendorName nvarchar(50),
	VendorContact nvarchar(20),
	VendorHNo nvarchar(30),
	VendorSNo nvarchar(30),
	VendorCommune nvarchar(30),
	VendorDistrict nvarchar(30),
	VendorProvince nvarchar(30),
	VendorConStart Datetime,
	VendorConEnd Datetime,
	VendorStatus bit,
	VendorDesc nvarchar(100)
);

-- Table STAFF
Create Table tblStaff (
	StaffID int primary key identity(1,1),
	StaffFName nvarchar(50),
	StaffLName nvarchar(50),
	StaffSex nvarchar(10),
	StaffBOD Datetime,
	StaffPosition nvarchar(10),
	StaffHNo nvarchar(30),
	StaffSNo nvarchar(30),
	StaffCommune nvarchar(30),
	StaffDistrict nvarchar(30),
	StaffProvince nvarchar(30),
	StaffPerNum nvarchar(20),
	StaffSalary float,
	StaffHiredDate Datetime,
	StaffStopped bit
);

-- Table Amenity
Create table tblAmenity(
	AmenityID int primary key identity(1,1),
	AmenityName nvarchar(30),
	AmenityAvail bit,
	AmenityLocation nvarchar(30),
	AmenityBouPri float,
	AmenityCPR float,
	AmenityMainDate Datetime,
	AmenityDesc nvarchar(100)
);

-- Table User
Create Table tblUser(
	UserID int primary key identity(1,1),
	UserName nvarchar(30),
	UserPass nvarchar(30),
	StaffID int,
	Constraint FKStaffID Foreign Key(StaffID) References tblStaff(StaffID) on Delete Cascade on Update Cascade
);

-- POLICY table
CREATE TABLE tblPolicy (
    PolicyID INT PRIMARY KEY IDENTITY(1,1),
    PolicyName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    CreatedDate DATETIME2 DEFAULT GETDATE(),
    UpdatedDate DATETIME2,
    ResidentID INT,
    FOREIGN KEY (ResidentID) REFERENCES tblResident(ResidentID)
);

-- FEEDBACK table
CREATE TABLE tblFeedback (
    FeedbackID INT PRIMARY KEY IDENTITY(1,1),
    FeedbackDate DATETIME2 DEFAULT GETDATE(),
    Comments NVARCHAR(MAX),
    Rating INT CHECK (Rating >= 1 AND Rating <= 5), 
    ResidentID INT,
    FOREIGN KEY (ResidentID) REFERENCES tblResident(ResidentID)
);

-- LEASEAGREEMENT table
CREATE TABLE tblLeaseAgreement (
    LeaseAgreementID INT PRIMARY KEY IDENTITY(1,1),
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    MonthlyRent DECIMAL(10,2) NOT NULL,
    TermsAndConditions NVARCHAR(MAX),
    ResidentID INT,
    CONSTRAINT CHK_DateRange CHECK (EndDate >= StartDate),
    FOREIGN KEY (ResidentID) REFERENCES tblResident(ResidentID)
);

-- UTILITY table
CREATE TABLE tblUtility (
    UtilityID INT PRIMARY KEY IDENTITY(1,1),
    UtilityType NVARCHAR(50) NOT NULL,
    Cost DECIMAL(10,2) NOT NULL,
    UsageDate DATE NOT NULL,
    RoomID INT,
    FOREIGN KEY (RoomID) REFERENCES tblRoom(RoomID)
);

CREATE TABLE Room (
    RoomID INT PRIMARY KEY IDENTITY(1,1),
    RoomNumber NVARCHAR(20)
);
GO

CREATE TABLE Resident (
    ResidentID INT PRIMARY KEY IDENTITY(1,1),
    ResidentName NVARCHAR(100)
);
GO

CREATE TABLE Service (
    ServiceID INT PRIMARY KEY IDENTITY(1,1),
    ServiceName NVARCHAR(100),
    ServiceDescription NVARCHAR(MAX),
    Cost DECIMAL(10,2)
);
GO

-- Table Reservation
CREATE TABLE Reservation (
    ReservationID INT PRIMARY KEY IDENTITY(1,1),
    ReservationDate DATE,
    StartDate DATE,
    EndDate DATE,
    Status NVARCHAR(50),
    ResidentID INT,
    RoomID INT,
    ResidentName NVARCHAR(100),
    RoomNumber NVARCHAR(20),
    FOREIGN KEY (ResidentID) REFERENCES Resident(ResidentID),
    FOREIGN KEY (RoomID) REFERENCES Room(RoomID)
);
GO

-- Table Request
CREATE TABLE Request (
    RequestID INT PRIMARY KEY IDENTITY(1,1),
    RequestDate DATE,
    Description NVARCHAR(MAX),
    Status NVARCHAR(50),
    ResidentID INT,
    ServiceID INT,
    ResidentName NVARCHAR(100),
    ServiceName NVARCHAR(100),
    FOREIGN KEY (ResidentID) REFERENCES Resident(ResidentID),
    FOREIGN KEY (ServiceID) REFERENCES Service(ServiceID)
);
GO

-- Table Rent
CREATE TABLE Rent (
    RentID INT PRIMARY KEY IDENTITY(1,1),
    StartDate DATE,
    EndDate DATE,
    RentAmount DECIMAL(10,2),
    ResidentID INT,
    RoomID INT,
    ResidentName NVARCHAR(100),
    RoomNumber NVARCHAR(20),
    FOREIGN KEY (ResidentID) REFERENCES Resident(ResidentID),
    FOREIGN KEY (RoomID) REFERENCES Room(RoomID)
);
GO

-- Create triggers (each in its own batch)
CREATE TRIGGER trg_UpdateReservationDenormalizedData
ON Reservation
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE r
    SET 
        r.ResidentName = res.ResidentName,
        r.RoomNumber = rm.RoomNumber
    FROM Reservation r
    JOIN Resident res ON r.ResidentID = res.ResidentID
    JOIN Room rm ON r.RoomID = rm.RoomID
    WHERE r.ReservationID IN (SELECT ReservationID FROM inserted);
END;
GO

CREATE TRIGGER trg_UpdateRequestDenormalizedData
ON Request
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE r
    SET 
        r.ResidentName = res.ResidentName,
        r.ServiceName = s.ServiceName
    FROM Request r
    JOIN Resident res ON r.ResidentID = res.ResidentID
    JOIN Service s ON r.ServiceID = s.ServiceID
    WHERE r.RequestID IN (SELECT RequestID FROM inserted);
END;
GO

CREATE TRIGGER trg_UpdateRentDenormalizedData
ON Rent
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE r
    SET 
        r.ResidentName = res.ResidentName,
        r.RoomNumber = rm.RoomNumber
    FROM Rent r
    JOIN Resident res ON r.ResidentID = res.ResidentID
    JOIN Room rm ON r.RoomID = rm.RoomID
    WHERE r.RentID IN (SELECT RentID FROM inserted);
END;
GO

-- Create indexes
CREATE INDEX IX_Reservation_Dates ON Reservation(ReservationDate, StartDate, EndDate);
CREATE INDEX IX_Request_Date ON Request(RequestDate);
CREATE INDEX IX_Rent_Dates ON Rent(StartDate, EndDate);
CREATE INDEX IX_Resident_Name ON Resident(ResidentName);
CREATE INDEX IX_Room_Number ON Room(RoomNumber);
CREATE INDEX IX_Service_Name ON Service(ServiceName);
