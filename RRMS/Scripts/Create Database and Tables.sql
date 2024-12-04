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
    ResidentID INT PRIMARY KEY IDENTITY(1,1),
    Type NVARCHAR(20) NOT NULL,  -- Increased length for future types
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Sex NVARCHAR(10) NOT NULL,    -- Adjusted length for more options
    BD DATETIME2 NOT NULL,        -- Assuming birth date is required
    PrevHouseNo NVARCHAR(30),
    PrevStNo NVARCHAR(30),
    PrevCommune NVARCHAR(30),
    PrevDistrict NVARCHAR(30),
    PrevProvince NVARCHAR(30),
    PerNum NVARCHAR(20) NOT NULL, -- Assuming personal number is required
    ConNum NVARCHAR(20) NOT NULL, -- Assuming contact number is required
    CheckIn DATETIME2 NOT NULL,    -- Assuming check-in is required
    CheckOut DATETIME2 NULL        -- Allow NULL for residents who haven't checked out
);

-- Table VENDOR
Create Table tblVendor (
	VendorID int primary key identity(1,1),
	Name nvarchar(50) NOT NULL,
	Contact nvarchar(20) NOT NULL,
	HouseNo nvarchar(30) NOT NULL,
	StreetNo nvarchar(30) NOT NULL,
	Commune nvarchar(30) NOT NULL,
	District nvarchar(30) NOT NULL,
	Province nvarchar(30) NOT NULL,
	ContractStart Datetime NOT NULL,
	ContractEnd Datetime NOT NULL,
	Status bit,
	Description nvarchar(100)
);

-- Table STAFF
CREATE TABLE tblStaff (
    StaffID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Sex NVARCHAR(10) NOT NULL,
    BirthDate DATETIME NOT NULL,
    Position NVARCHAR(20) NOT NULL,
    HouseNo NVARCHAR(30),
    StreetNo NVARCHAR(30),
    Commune NVARCHAR(30),
    District NVARCHAR(30),
    Province NVARCHAR(30),
    PersonalNumber NVARCHAR(20) NOT NULL,
    Salary Float NOT NULL,
    StartDate DATETIME NOT NULL,
    StoppedDate DATETIME NULL
);
GO

-- Table RoomType
CREATE TABLE tblRoomType(
    RoomTypeID INT PRIMARY KEY identity(1,1),
    TypeName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(100),
    BasePrice FLOAT NOT NULL,
    Capacity INT NOT NULL,
    
);
GO

-- LEASEAGREEMENT table
CREATE TABLE tblLeaseAgreement (
    LeaseAgreementID INT PRIMARY KEY IDENTITY(1,1),
    StartDate DATETIME,
    EndDate DATETIME,
    TermsAndConditions NVARCHAR(MAX),
    ResidentID INT,
    Constraint FKResidentID Foreign Key(ResidentID) References tblResident(ResidentID) on Delete Cascade on Update Cascade
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



-- Table Reservation
CREATE TABLE tblReservation (
    ReservationID INT PRIMARY KEY IDENTITY(1,1),
    ReserDate DATETIME2,
    StartDate DATETIME2,
    EndDate DATETIME2,
    ReserStatus NVARCHAR(50),
    ResidentID INT,
    RoomID INT,
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

-- Table Payment
CREATE TABLE tblPayment (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    PaymentDate DATETIME NOT NULL,
    ReservationID INT NULL,
    StaffID INT NOT NULL,
    UtilityID INT NULL,
    PaidAmount DECIMAL(10,2) NOT NULL,
    RemainingAmount DECIMAL(10,2) NOT NULL,
    IsSecondPaymentDone BIT DEFAULT 0,
    IsUtilityOnly BIT DEFAULT 0,
    FOREIGN KEY (ReservationID) REFERENCES tblReservation(ReservationID),
    FOREIGN KEY (StaffID) REFERENCES tblStaff(StaffID),
    FOREIGN KEY (UtilityID) REFERENCES tblUtility(UtilityID)
)
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
