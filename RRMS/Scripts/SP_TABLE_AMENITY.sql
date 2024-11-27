-- Get All Amenities
CREATE PROCEDURE GetAllAmenities
AS
BEGIN
	SELECT AmenityID,
		   AmenityName,
		   AmenityAvail,
		   AmenityLocation,
		   AmenityBouPri,
		   AmenityCPR,
		   AmenityMainDate,
		   AmenityDesc
	FROM tblAmenity;
END
GO

-- Get Amenity By ID
CREATE PROCEDURE GetAmenityById
	@AmenityID INT
AS
BEGIN
	SELECT TOP 1 AmenityID,
				 AmenityName,
				 AmenityAvail,
				 AmenityLocation,
				 AmenityBouPri,
				 AmenityCPR,
				 AmenityMainDate,
				 AmenityDesc
	FROM tblAmenity
	WHERE AmenityID = @AmenityID;
END
GO

-- Add New Amenity
CREATE PROCEDURE AddAmenity
	@AmenityName NVARCHAR(30),
	@AmenityAvail BIT,
	@AmenityLocation NVARCHAR(30),
	@AmenityBouPri FLOAT,
	@AmenityCPR FLOAT,
	@AmenityMainDate DATETIME,
	@AmenityDesc NVARCHAR(100)
AS
BEGIN
	INSERT INTO tblAmenity
	(	AmenityName,
		AmenityAvail,
		AmenityLocation,
		AmenityBouPri,
		AmenityCPR,
		AmenityMainDate,
		AmenityDesc
	)
	VALUES
	(
		@AmenityName,
		@AmenityAvail,
		@AmenityLocation,
		@AmenityBouPri,
		@AmenityCPR,
		@AmenityMainDate,
		@AmenityDesc
	)

	-- Return the newly inserted AmenityID
	SELECT SCOPE_IDENTITY() AS NewAmenityID;
END
GO

-- Update Existing Amenity
CREATE PROCEDURE UpdateAmenity
	@AmenityID INT,
	@AmenityName NVARCHAR(30),
	@AmenityAvail BIT,
	@AmenityLocation NVARCHAR(30),
	@AmenityBouPri FLOAT,
	@AmenityCPR FLOAT,
	@AmenityMainDate DATETIME,
	@AmenityDesc NVARCHAR(100)
AS
BEGIN
	UPDATE tblAmenity
	SET AmenityName = @AmenityName,
		AmenityAvail = @AmenityAvail,
		AmenityLocation = @AmenityLocation,
		AmenityBouPri = @AmenityBouPri,
		AmenityCPR = @AmenityCPR,
		AmenityMainDate = @AmenityMainDate,
		AmenityDesc = @AmenityDesc
	WHERE AmenityID = @AmenityID
END
GO

-- Delete Amenity
CREATE PROCEDURE DeleteAmenity
	@AmenityID INT
AS
BEGIN
	DELETE FROM tblAmenity
	WHERE AmenityID = @AmenityID;
END
GO

-- Validate Amenity ID
CREATE PROCEDURE ValidateAmenityID
	@AmenityID INT
AS
BEGIN
	SELECT COUNT(*) 
	FROM tblAmenity 
	WHERE AmenityID = @AmenityID
END
GO