CREATE PROCEDURE AddStaff
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
        StaffFName, StaffLName, StaffSex, StaffBOD, StaffPosition,
        StaffHNo, StaffSNo, StaffCommune, StaffDistrict, StaffProvince,
        StaffPerNum, StaffSalary, StaffHiredDate, StaffStopped
    )
    VALUES (
        @StaffFName, @StaffLName, @StaffSex, @StaffBOD, @StaffPosition,
        @StaffHNo, @StaffSNo, @StaffCommune, @StaffDistrict, @StaffProvince,
        @StaffPerNum, @StaffSalary, @StaffHiredDate, @StaffStopped
    );
END
GO

CREATE PROCEDURE GetAllStaff
AS
BEGIN
    SELECT * FROM tblStaff;
END
GO

CREATE PROCEDURE GetStaffById
    @StaffId INT
AS
BEGIN
    SELECT * FROM tblStaff WHERE StaffId = @StaffId;
END
GO

CREATE PROCEDURE UpdateStaff
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
        StaffFName = @StaffFName,
        StaffLName = @StaffLName,
        StaffSex = @StaffSex,
        StaffBOD = @StaffBOD,
        StaffPosition = @StaffPosition,
        StaffHNo = @StaffHNo,
        StaffSNo = @StaffSNo,
        StaffCommune = @StaffCommune,
        StaffDistrict = @StaffDistrict,
        StaffProvince = @StaffProvince,
        StaffPerNum = @StaffPerNum,
        StaffSalary = @StaffSalary,
        StaffHiredDate = @StaffHiredDate,
        StaffPhoto = @StaffPhoto,
        StaffStopped = @StaffStopped
    WHERE StaffId = @StaffId;
END
GO

CREATE PROCEDURE DeleteStaff 
	@StaffId INT 
AS BEGIN DELETE FROM tblStaff WHERE StaffId = @StaffId; 
END
GO



CREATE PROCEDURE ValidateStaffID
    @StaffID INT
AS
BEGIN
    SELECT COUNT(*) FROM tblStaff WHERE StaffId = @StaffID;
END
GO