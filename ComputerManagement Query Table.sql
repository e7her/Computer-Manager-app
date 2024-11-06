USE NewComputerManagementDB;

CREATE TABLE dbo.Accounts (
    StudentID INT PRIMARY KEY,
    StudentPassword NVARCHAR(255),
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    Program NVARCHAR(100),
    Email NVARCHAR(100),
    isLocked BIT
);

-- Create dbo.LockedAccounts table
CREATE TABLE dbo.LockedAccounts (
    StudentID INT PRIMARY KEY,
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    Program NVARCHAR(100),
    Email NVARCHAR(100),
    FOREIGN KEY (StudentID) REFERENCES dbo.Accounts(StudentID)
);

-- Create dbo.ClientSessions1 table
CREATE TABLE dbo.ClientSessions1 (
    SessionID INT PRIMARY KEY IDENTITY,
    StudentID INT,
    ClientPCID INT,
    LoginTime DATETIME,
    LogoutTime DATETIME,
    SessionDuration INT,
    FOREIGN KEY (StudentID) REFERENCES dbo.Accounts(StudentID)
);

-- Create dbo.ClientSessions2 table
CREATE TABLE dbo.ClientSessions2 (
    SessionID INT PRIMARY KEY IDENTITY,
    StudentID INT,
    ClientPCID INT,
    LoginTime DATETIME,
    LogoutTime DATETIME,
    SessionDuration INT,
    FOREIGN KEY (StudentID) REFERENCES dbo.Accounts(StudentID)
);

INSERT INTO dbo.Accounts (StudentID, StudentPassword, FirstName, LastName, Program, Email, isLocked)
VALUES ('2023130888', 'password123', 'Test', 'User', 'Computer Science', 'test.user@mcm.edu.ph', 0);


USE master;
GO

USE NewComputerManagementDB;
GO

-- Create a user for the login in the database
CREATE USER admin1 FOR LOGIN admin1;
GO

ALTER ROLE db_owner ADD MEMBER admin1;
GO

-- Check users and their roles in the database
SELECT dp.name AS DatabaseUserName, dp.type_desc AS UserType, 
       dp.create_date AS UserCreationDate, 
       dr.name AS RoleName
FROM sys.database_principals AS dp
JOIN sys.database_role_members AS drm ON dp.principal_id = drm.member_principal_id
JOIN sys.database_principals AS dr ON drm.role_principal_id = dr.principal_id
WHERE dp.type IN ('S', 'U') -- User types: S = SQL user, U = Windows user
ORDER BY dp.name;


USE NewComputerManagementDB;
GO

ALTER TABLE dbo.ClientSessions1
DROP COLUMN ClientPCID;

ALTER TABLE dbo.ClientSessions2
DROP COLUMN ClientPCID;

ALTER TABLE dbo.ClientSessions1
ADD FirstName NVARCHAR(50), -- Adjust size as needed
    LastName NVARCHAR(50),
    Program NVARCHAR(50);

ALTER TABLE dbo.ClientSessions2
ADD FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Program NVARCHAR(50);


-- time format for ClientSessions1

USE NewComputerManagementDB;
GO

ALTER TABLE dbo.ClientSessions1
DROP COLUMN SessionDuration;

ALTER TABLE dbo.ClientSessions2
DROP COLUMN SessionDuration;

