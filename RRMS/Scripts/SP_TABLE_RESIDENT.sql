-- Get All Residents
Create Procedure GetAllResidents
As
Begin
	Select ResidentID,
		   ResidentType,
		   ResidentName,
		   ResidentSex,
		   ResidentBOD,
		   ResidentPrevHouseNo,
		   ResidentPrevStNo,
		   ResidentPrevCommune,
		   ResidentPrevDistrict,
		   ResidentPerNum,
		   ResidentConNum,
		   ResidentCheckIn,
		   ResidentCheckOut
	From tblResident;
End
Go

-- Get Resident By ID
Create Procedure GetResidentById
	@ResidentID INT
As
Begin
	Select Top 1 ResidentID,
				 ResidentType,
				 ResidentName,
				 ResidentSex,
				 ResidentBOD,
				 ResidentPrevHouseNo,
				 ResidentPrevStNo,
				 ResidentPrevCommune,
				 ResidentPrevDistrict,
				 ResidentPerNum,
				 ResidentConNum,
				 ResidentCheckIn,
				 ResidentCheckOut
	From tblResident
	Where ResidentID = @ResidentID;
End
Go

-- Add New Resident
Create Procedure AddResident
	@ResidentType NVARCHAR(10),
	@ResidentName NVARCHAR(50),
	@ResidentSex NVARCHAR(6),
	@ResidentBOD DATETIME,
	@ResidentPrevHouseNo NVARCHAR(30),
	@ResidentPrevStNo NVARCHAR(30),
	@ResidentPrevCommune NVARCHAR(30),
	@ResidentPrevDistrict NVARCHAR(30),
	@ResidentPerNum NVARCHAR(20),
	@ResidentConNum NVARCHAR(20),
	@ResidentCheckIn DATETIME,
	@ResidentCheckOut DATETIME
As
Begin
	Insert into tblResident
	(	ResidentType,
		ResidentName,
		ResidentSex,
		ResidentBOD,
		ResidentPrevHouseNo,
		ResidentPrevStNo,
		ResidentPrevCommune,
		ResidentPrevDistrict,
		ResidentPerNum,
		ResidentConNum,
		ResidentCheckIn,
		ResidentCheckOut
	)
	Values
	(
		@ResidentType,
		@ResidentName,
		@ResidentSex,
		@ResidentBOD,
		@ResidentPrevHouseNo,
		@ResidentPrevStNo,
		@ResidentPrevCommune,
		@ResidentPrevDistrict,
		@ResidentPerNum,
		@ResidentConNum,
		@ResidentCheckIn,
		@ResidentCheckOut
	)

	-- Return the newly inserted ResidentID
	SELECT SCOPE_IDENTITY() AS NewResidentID;
End
Go

-- Update Existing Resident
Create Procedure UpdateResident
	@ResidentID INT,
	@ResidentType NVARCHAR(10),
	@ResidentName NVARCHAR(50),
	@ResidentSex NVARCHAR(6),
	@ResidentBOD DATETIME,
	@ResidentPrevHouseNo NVARCHAR(30),
	@ResidentPrevStNo NVARCHAR(30),
	@ResidentPrevCommune NVARCHAR(30),
	@ResidentPrevDistrict NVARCHAR(30),
	@ResidentPerNum NVARCHAR(20),
	@ResidentConNum NVARCHAR(20),
	@ResidentCheckIn DATETIME,
	@ResidentCheckOut DATETIME
As
Begin
	Update tblResident
	Set ResidentType = @ResidentType,
		ResidentName = @ResidentName,
		ResidentSex = @ResidentSex,
		ResidentBOD = @ResidentBOD,
		ResidentPrevHouseNo = @ResidentPrevHouseNo,
		ResidentPrevStNo = @ResidentPrevStNo,
		ResidentPrevCommune = @ResidentPrevCommune,
		ResidentPrevDistrict = @ResidentPrevDistrict,
		ResidentPerNum = @ResidentPerNum,
		ResidentConNum = @ResidentConNum,
		ResidentCheckIn = @ResidentCheckIn,
		ResidentCheckOut = @ResidentCheckOut
	Where ResidentID = @ResidentID
End
Go

-- Delete Resident
Create Procedure DeleteResident
	@ResidentID INT
As
Begin
	Delete from tblResident
	Where ResidentID = @ResidentID;
End
Go

-- Validate Resident ID
Create Procedure ValidateResidentID
	@ResidentID INT
As
Begin
	Select Count(*) 
	from tblResident 
	Where ResidentID = @ResidentID
End
Go