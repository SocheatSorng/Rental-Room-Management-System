CREATE DATABASE rrmsdb;
GO
USE rrmsdb;
GO

-- Table Room
CREATE TABLE tblRoom (
    RoomID INT PRIMARY KEY IDENTITY(1,1),
    RoomType NVARCHAR(50),
    RoomNumber NVARCHAR(20),
    ResidentID INT,
);
GO

-- Table RESIDENT
CREATE TABLE tblResident (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Type NVARCHAR(10),
	Name NVARCHAR(50),
	Sex NVARCHAR(6),
	BOD DATETIME,
	PrevHouseNo NVARCHAR(30),
	PrevStNo NVARCHAR(30),
	PrevCommune NVARCHAR(30),
	PrevDistrict NVARCHAR(30),
    PrevProvince NVARCHAR(30),
	PerNum NVARCHAR(20),
	ConNum NVARCHAR(20),
	CheckIn DATETIME,
	CheckOut DATETIME
);

-- Table VENDOR
Create Table tblVendor (
	VendorID int primary key identity(1,1),
	Name nvarchar(50),
	Contact nvarchar(20),
	HNo nvarchar(30),
	SNo nvarchar(30),
	Commune nvarchar(30),
	District nvarchar(30),
	Province nvarchar(30),
	ConStart Datetime,
	ConEnd Datetime,
	Status bit,
	Description nvarchar(100)
);

-- Table STAFF
Create Table tblStaff (
	StaffID int primary key identity(1,1),
	FName nvarchar(50),
	LName nvarchar(50),
	Sex nvarchar(10),
	BD Datetime,
	Position nvarchar(10),
	HNo nvarchar(30),
	SNo nvarchar(30),
	Commune nvarchar(30),
	District nvarchar(30),
	Province nvarchar(30),
	PerNum nvarchar(20),
	Salary float,
	HiredDate Datetime,
	Stopped DateTime,
);

-- Table Amenity
Create table tblAmenity(
	AmenityID int primary key identity(1,1),
	Name nvarchar(30),
	Availability bit,
	Location nvarchar(30),
	BoughtPrice float,
	CPR float,
	MainDate Datetime,
	Description nvarchar(100)
);

-- Table User
Create Table tblUser(
	UserID int primary key identity(1,1),
	Name nvarchar(30),
	Pass nvarchar(30),
	StaffID int,
	Constraint FKStaffID Foreign Key(StaffID) References tblStaff(StaffID) on Delete Cascade on Update Cascade
);

-- POLICY table
CREATE TABLE tblPolicy (
    PolicyID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    CreatedDate DATETIME,
    UpdatedDate DATETIME,
    ResidentID INT,
    FOREIGN KEY (ResidentID) REFERENCES tblResident(ID)
);

-- FEEDBACK table
CREATE TABLE tblFeedback (
    FeedbackID INT PRIMARY KEY IDENTITY(1,1),
	Date DATETIME,
	Content NVARCHAR(100),
    Comment NVARCHAR(MAX),
    ResidentID INT,
    ResName NVARCHAR(50),
    FOREIGN KEY (ResidentID) REFERENCES tblResident(ID)
);

-- LEASEAGREEMENT table
CREATE TABLE tblLeaseAgreement (
    LeaseAgreementID INT PRIMARY KEY IDENTITY(1,1),
    StartDate DATETIME2,
    EndDate DATETIME2,
    TermsAndConditions NVARCHAR(MAX),
    ResidentID INT,
    FOREIGN KEY (ResidentID) REFERENCES tblResident(ID)
);

-- UTILITY table
CREATE TABLE tblUtility (
    UtilityID INT PRIMARY KEY IDENTITY(1,1),
    Type NVARCHAR(50),
    Cost float,
    UsageDate DATETIME2,
    RoomID INT,
    FOREIGN KEY (RoomID) REFERENCES tblRoom(RoomID)
);

CREATE TABLE tblRoom (
    RoomID INT PRIMARY KEY IDENTITY(1,1),
    Number NVARCHAR(10),
    RoomTypeID INT,
    FOREIGN KEY (RoomTypeID) REFERENCES tblRoomType(RoomTypeID),
);
GO

CREATE TABLE tblResident (
    ResidentID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100)
);
GO

CREATE TABLE tblService (
    ServiceID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Description NVARCHAR(MAX),
    Cost DECIMAL(10,2)
);
GO

CREATE TABLE tblRoomType(
    RoomTypeID INT PRIMARY KEY,
    RoomTypeName NVARCHAR(100),
    Capacity INT,
    Feature NVARCHAR(100),
    PricePerNight MONEY,
    Status NVARCHAR(100),
);
GO

-- Table Reservation
CREATE TABLE tblReservation (
    ReservationID INT PRIMARY KEY IDENTITY(1,1),
    Date DATE,
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
CREATE TABLE tblRequest (
    RequestID INT PRIMARY KEY IDENTITY(1,1),
    Date DATE,
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
CREATE TABLE tblRent (
    RentID INT PRIMARY KEY IDENTITY(1,1),
    StartDate DATE,
    EndDate DATE,
    Amount DECIMAL(10,2),
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
