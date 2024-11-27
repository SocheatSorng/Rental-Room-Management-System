-- Get All Vendors
Create Procedure GetAllVendors
As
Begin
	Select VendorID,
		   VendorName,
		   VendorContact,
		   VendorHNo,
		   VendorSNo,
		   VendorCommune,
		   VendorDistrict,
		   VendorProvince,
		   VendorConStart,
		   VendorConEnd,
		   VendorStatus,
		   VendorDesc
	From tblVendor;
End
Go

-- Get Vendor By ID
Create Procedure GetVendorById
	@VendorID INT
As
Begin
	Select Top 1 VendorID,
				 VendorName,
				 VendorContact,
				 VendorHNo,
				 VendorSNo,
				 VendorCommune,
				 VendorDistrict,
				 VendorProvince,
				 VendorConStart,
				 VendorConEnd,
				 VendorStatus,
				 VendorDesc
	From tblVendor
	Where VendorID = @VendorID;
End
Go

-- Add New Vendor
Create Procedure AddVendor
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
	(	VendorName,
		VendorContact,
		VendorHNo,
		VendorSNo,
		VendorCommune,
		VendorDistrict,
		VendorProvince,
		VendorConStart,
		VendorConEnd,
		VendorStatus,
		VendorDesc
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

	-- Return the newly inserted VendorID
	SELECT SCOPE_IDENTITY() AS NewVendorID;
End
Go

-- Update Existing Vendor
Create Procedure UpdateVendor
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
	Set VendorName = @VendorName,
		VendorContact = @VendorContact,
		VendorHNo = @VendorHNo,
		VendorSNo = @VendorSNo,
		VendorCommune = @VendorCommune,
		VendorDistrict = @VendorDistrict,
		VendorProvince = @VendorProvince,
		VendorConStart = @VendorConStart,
		VendorConEnd = @VendorConEnd,
		VendorStatus = @VendorStatus,
		VendorDesc = @VendorDesc
	Where VendorID = @VendorID
End
Go

-- Delete Vendor
Create Procedure DeleteVendor
	@VendorID INT
As
Begin
	Delete from tblVendor
	Where VendorID = @VendorID;
End
Go

-- Validate Vendor ID
Create Procedure ValidateVendorID
	@VendorID INT
As
Begin
	Select Count(*) 
	from tblVendor 
	Where VendorID = @VendorID
End
Go