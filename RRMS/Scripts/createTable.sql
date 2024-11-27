-- ROOM table
CREATE TABLE tblRoom (
    RoomID INT PRIMARY KEY IDENTITY(1,1),
    RoomDesc NVARCHAR(100) NOT NULL
);
CREATE TABLE tblResident (
    ResidentID INT PRIMARY KEY IDENTITY(1,1),
    ResidentName NVARCHAR(100) NOT NULL
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
