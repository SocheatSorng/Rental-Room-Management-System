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