CREATE DATABASE rrmsdb;
GO
USE rrmsdb;
GO

-- Table Room
CREATE TABLE tblRoom (
    RoomID INT PRIMARY KEY IDENTITY(1,1),
    RoomType NVARCHAR(50),
    RoomNumber NVARCHAR(20),
    Status Bit default 0,
    ResidentID INT,
    RoomTypeID INT
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
	BoughtPrice float,
	CostPerRent float,
	MaintenanceDate Datetime,
	Description nvarchar(100),
    RoomID int
    Constraint FKAmenityRoomID Foreign Key(RoomID) References tblRoom(RoomID) on delete cascade on update cascade
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
    PolicyDescription NVARCHAR(MAX),
    CreatedDate DATETIME,
    UpdatedDate DATETIME,
    ResidentID INT,
    StaffID INT,
    CONSTRAINT FK_Policy_Resident FOREIGN KEY (ResidentID) 
        REFERENCES tblResident(ResidentID) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_Policy_Staff FOREIGN KEY (StaffID)
        REFERENCES tblStaff(StaffID) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

-- FEEDBACK table
CREATE TABLE tblFeedback (
    FeedbackID INT PRIMARY KEY IDENTITY(1,1),
	FeedbackDate DATETIME,
	Content NVARCHAR(100),
    Comment NVARCHAR(MAX),
    ResidentID INT,
    Constraint FKFeedbackResident FOREIGN KEY(ResidentID) REFERENCES tblResident(ResidentID)
);

-- UTILITY table
CREATE TABLE tblUtility (
    UtilityID INT PRIMARY KEY IDENTITY(1,1),
    Type NVARCHAR(50),
    Cost float,
    UsageDate DATETIME2,
    RoomID INT,
    Constraint FKUtilityRoom FOREIGN KEY (RoomID) REFERENCES tblRoom(RoomID)
);

CREATE TABLE tblRoom (
    RoomID INT PRIMARY KEY IDENTITY(1,1),
    RoomType NVARCHAR(50),
    RoomNumber NVARCHAR(20),
    ResidentID INT,
    RoomTypeID INT,
	Constraint FKRoomResidentID Foreign Key(ResidentID) References tblResident(ResidentID),
	Constraint FKRoomRoomTypeID Foreign Key(RoomTypeID) References tblRoomType(RoomTypeID)
);
GO

CREATE TABLE tblResident (
    ResidentID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100)
);
GO

-- Table Service
CREATE TABLE tblService (
    ServiceID INT PRIMARY KEY IDENTITY(1,1),
    ServiceName NVARCHAR(100) NOT NULL,
    ServiceDescription NVARCHAR(MAX),
    ServiceCost DECIMAL(10,2) NOT NULL,
    VendorID INT,
    RoomID INT,
    CONSTRAINT FK_Service_Vendor FOREIGN KEY (VendorID) REFERENCES tblVendor(VendorID) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_Service_Room FOREIGN KEY (RoomID) REFERENCES tblRoom(RoomID) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

-- Table Reservation
CREATE TABLE tblReservation (
    ReservationID INT PRIMARY KEY IDENTITY(1,1),
    ReservationDate DATETIME NOT NULL,
    StartDate DATETIME NULL,
    EndDate DATETIME NULL,
    Status NVARCHAR(50),
    ResidentID INT,
    RoomID INT,
    PaidAmount DECIMAL(10,2),
    RemainingAmount DECIMAL(10,2),
    CONSTRAINT FK_Reservation_Resident FOREIGN KEY (ResidentID) REFERENCES tblResident(ResidentID),
    CONSTRAINT FK_Reservation_Room FOREIGN KEY (RoomID) REFERENCES tblRoom(RoomID)
);
GO

-- Table Request
CREATE TABLE tblRequest (
    RequestID INT PRIMARY KEY IDENTITY(1,1),
    RequestDate DATETIME NOT NULL,
    RequestDescription NVARCHAR(MAX),
    RequestStatus NVARCHAR(50),
    ResidentID INT,
    ServiceID INT,
    CONSTRAINT FK_Request_Resident FOREIGN KEY (ResidentID) REFERENCES tblResident(ResidentID),
    CONSTRAINT FK_Request_Service FOREIGN KEY (ServiceID) REFERENCES tblService(ServiceID)
);

-- Table Rent
CREATE TABLE tblRent (
    RentID INT PRIMARY KEY IDENTITY(1,1),
    StartDate DATE,
    EndDate DATE,
    Amount float,
    RoomID INT,
    RoomNumber NVARCHAR(20),
    Constraint FKRentRoom FOREIGN KEY (RoomID) REFERENCES tblRoom(RoomID)
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

CREATE TABLE tblPayment (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    PaymentDate DATETIME NOT NULL,
    ReservationID INT NULL,
    StaffID INT NOT NULL,
    UtilityID INT NULL,
    ServiceID INT NULL,  -- Added for service payments
    PaidAmount DECIMAL(10,2) NOT NULL,
    RemainingAmount DECIMAL(10,2) NOT NULL,
    IsSecondPaymentDone BIT DEFAULT 0,
    IsUtilityOnly BIT DEFAULT 0,
    IsServiceOnly BIT DEFAULT 0,  -- Added for service payments
    Description NVARCHAR(MAX) NULL,  -- Added for payment notes/description
    Status BIT DEFAULT 1,  -- Added for payment status tracking
    CONSTRAINT FK_Payment_Reservation FOREIGN KEY (ReservationID) 
        REFERENCES tblReservation(ReservationID) ON DELETE NO ACTION,
    CONSTRAINT FK_Payment_Staff FOREIGN KEY (StaffID) 
        REFERENCES tblStaff(StaffID) ON DELETE NO ACTION,
    CONSTRAINT FK_Payment_Utility FOREIGN KEY (UtilityID) 
        REFERENCES tblUtility(UtilityID) ON DELETE NO ACTION,
    CONSTRAINT FK_Payment_Service FOREIGN KEY (ServiceID)
        REFERENCES tblService(ServiceID) ON DELETE NO ACTION,
    CONSTRAINT CK_Payment_Type CHECK (
        (IsUtilityOnly = 1 AND IsServiceOnly = 0 AND ReservationID IS NULL AND UtilityID IS NOT NULL) OR
        (IsServiceOnly = 1 AND IsUtilityOnly = 0 AND ReservationID IS NULL AND ServiceID IS NOT NULL) OR
        (IsUtilityOnly = 0 AND IsServiceOnly = 0 AND ReservationID IS NOT NULL AND UtilityID IS NULL AND ServiceID IS NULL)
    )
)
GO


CREATE TABLE tblInvoice (
    InvoiceID INT PRIMARY KEY IDENTITY(1,1),
    InvoiceNo NVARCHAR(50) NOT NULL,
    InvoiceDate DATETIME NOT NULL,
    PaymentID INT NOT NULL,
    Status BIT DEFAULT 1,
    FOREIGN KEY (PaymentID) REFERENCES tblPayment(PaymentID)
);
GO