USE master
GO

IF EXISTS (SELECT * FROM sysdatabases WHERE name='NHSPatientServices')
DROP DATABASE NHSPatientServices
GO

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE NHSPatientServices
  ON PRIMARY (NAME = N''NHSPatientServices'', FILENAME = N''' + @device_directory + N'NHSPatientServices.mdf'')
  LOG ON (NAME = N''NHSPatientServices_log'',  FILENAME = N''' + @device_directory + N'NHSPatientServices.ldf'')')
GO
----------------------------------------------------------------------------------------------------
--------DROP TABLES----------
----------------------------------------------------------------------------------------------------
IF OBJECT_ID('dbo.Organisation_Type', 'U') IS NOT NULL
  
  DROP TABLE dbo.Addresses
  DROP TABLE dbo.Email
  DROP TABLE dbo.Fax
  DROP TABLE dbo.Location
  DROP TABLE dbo.ParentOrganisation
  DROP TABLE dbo.ServicesOrganisation
  DROP TABLE dbo.Parent
  DROP TABLE dbo.Telephone
  DROP TABLE dbo.Website
  DROP TABLE dbo.GP_Services
  DROP TABLE dbo.Organisation_Details 
  DROP TABLE dbo.Organisation_Type
    
--------------------------------------------------------------------------------------------------------
--------CREATE TABLES----------
--------------------------------------------------------------------------------------------------------
CREATE TABLE Organisation_Type (
Organisation_Type_ID INTEGER IDENTITY (1,1),
Organisation_Type CHAR(25) NOT NULL,
PRIMARY KEY (Organisation_Type_ID)
)

CREATE TABLE Organisation_Details (
ID INTEGER IDENTITY (1,1),
OrganisationNum INTEGER UNIQUE NOT NULL,
Organisation_Name VARCHAR(max) NOT NULL,
Ref_Organisation_Type_ID INTEGER NOT NULL,
EPS_Enabled VARCHAR(max) NOT NULL,
FOREIGN KEY (Ref_Organisation_Type_ID) REFERENCES Organisation_Type (Organisation_Type_ID),
PRIMARY KEY (ID)
)


CREATE TABLE GP_Services (
Service_ID INTEGER NOT NULL UNIQUE IDENTITY (1,1),
GP_Service_Name CHAR(255), 
PRIMARY KEY (Service_ID)
)


CREATE TABLE ServicesOrganisation (
Services_Organisation_ID INTEGER IDENTITY (1,1),
Ref_Organisation_Details_ID INTEGER NOT NULL,
Ref_Service_ID INTEGER NOT NULL,
FOREIGN KEY (Ref_Service_ID) REFERENCES GP_Services(Service_ID),
FOREIGN KEY (Ref_Organisation_Details_ID) REFERENCES Organisation_Details(ID),
PRIMARY KEY (Services_Organisation_ID)
)


CREATE TABLE Parent(
Parent_ID INTEGER IDENTITY (1,1),
ODSCode VARCHAR(max),
Parent_Name VARCHAR(max),
PRIMARY KEY (Parent_ID) 
)

CREATE TABLE ParentOrganisation(
Parent_Organisation_ID INTEGER IDENTITY (1,1),
Ref_Organisation_Details_ID INTEGER,
Ref_Parent_ID INTEGER,
PRIMARY KEY(Parent_Organisation_ID),
FOREIGN KEY (Ref_Parent_ID) REFERENCES Parent(Parent_ID),
FOREIGN KEY (Ref_Organisation_Details_ID) REFERENCES Organisation_Details(ID)
)

CREATE TABLE Location(
Ref_Organisation_Details_ID INTEGER UNIQUE NOT NULL,
Longtitude float NOT NULL,
Latitude float NOT NULL,
PRIMARY KEY (Ref_Organisation_Details_ID, Latitude, Longtitude), 
FOREIGN KEY (Ref_Organisation_Details_ID) REFERENCES Organisation_Details (ID)
)

CREATE TABLE Fax(
Ref_Organisation_Details_ID INTEGER UNIQUE NOT NULL,
Fax_Number CHAR(255) NOT NULL,
PRIMARY KEY (Ref_Organisation_Details_ID, Fax_Number), 
FOREIGN KEY (Ref_Organisation_Details_ID) REFERENCES Organisation_Details (ID)
)

CREATE TABLE Telephone(
Ref_Organisation_Details_ID INTEGER UNIQUE NOT NULL,
Telephone_Number CHAR(255) NOT NULL,
PRIMARY KEY (Ref_Organisation_Details_ID, Telephone_Number), 
FOREIGN KEY (Ref_Organisation_Details_ID) REFERENCES Organisation_Details (ID)
)

CREATE TABLE Email(
Ref_Organisation_Details_ID INTEGER UNIQUE NOT NULL,
Email CHAR(255) NOT NULL,
PRIMARY KEY (Ref_Organisation_Details_ID, Email), 
FOREIGN KEY (Ref_Organisation_Details_ID) REFERENCES Organisation_Details (ID)
)

CREATE TABLE Website(
Ref_Organisation_Details_ID INTEGER UNIQUE NOT NULL,
Website CHAR(255) NOT NULL,
PRIMARY KEY (Ref_Organisation_Details_ID, Website), 
FOREIGN KEY (Ref_Organisation_Details_ID) REFERENCES Organisation_Details (ID)
)

CREATE TABLE Addresses(
Ref_Organisation_Details_ID INTEGER UNIQUE NOT NULL,
Address_Line_1 VARCHAR(max) NOT NULL,
Address_Line_2 VARCHAR(max) NOT NULL,
Address_Line_3 VARCHAR(max),
City VARCHAR(max),
County VARCHAR(max),
Postcode VARCHAR(max),
PRIMARY KEY (Ref_Organisation_Details_ID), 
FOREIGN KEY (Ref_Organisation_Details_ID) REFERENCES Organisation_Details (ID)
)

-------------------------------------------------------------------------------------------------------
-----INSERT DATA TO NHSPatientService Database FROM StagingArea Database
-------------------------------------------------------------------------------------------------------
--1: Organisation_Type---------
INSERT INTO NHSPatientServices.dbo.Organisation_Type (Organisation_Type)
SELECT DISTINCT OrganisationType FROM StagingArea.dbo.GP_Details

--2: Organisation_Details-----------
INSERT INTO NHSPatientServices.dbo.Organisation_Details (OrganisationNum, Organisation_Name, Ref_Organisation_Type_ID, EPS_Enabled)
SELECT sa.OrganisationID, sa.OrganisationName, nhs.Organisation_Type_ID, sa.isEPSEnabled
FROM StagingArea.dbo.GP_Details sa, NHSPatientServices.dbo.Organisation_Type nhs
WHERE nhs.Organisation_Type = sa.OrganisationType

--3: GP_Services-------------
INSERT INTO NHSPatientServices.dbo.GP_Services(GP_Service_Name)
SELECT DISTINCT sa.ServiceName
FROM StagingArea.dbo.GP_Services sa

--4: Website---------------------
INSERT INTO NHSPatientServices.dbo.Website(Ref_Organisation_Details_ID, Website)
SELECT nhs.ID, sa.Phone 
FROM StagingArea.dbo.GP_Details sa,
NHSPatientServices.dbo.Organisation_Details nhs 
WHERE Website != ' ' AND  nhs.OrganisationNum = sa.OrganisationID

--5: Telephone------------------
INSERT INTO NHSPatientServices.dbo.Telephone(Ref_Organisation_Details_ID, Telephone_Number)
SELECT  nhs.ID, sa.Phone 
FROM StagingArea.dbo.GP_Details sa, 
NHSPatientServices.dbo.Organisation_Details nhs 
WHERE phone != ' ' AND  nhs.OrganisationNum = sa.OrganisationID

--6: Parent----------
INSERT INTO NHSPatientServices.dbo.Parent(ODSCode, Parent_Name)
SELECT DISTINCT ParentODSCode, ParentName FROM StagingArea.dbo.GP_Details

--7: ServicesOrganisation---------------
INSERT INTO NHSPatientServices.dbo.ServicesOrganisation(Ref_Organisation_Details_ID ,Ref_Service_ID )
SELECT nhs.ID, gpnhs.Service_ID
FROM NHSPatientServices.dbo.Organisation_Details nhs, NHSPatientServices.dbo.GP_Services gpnhs, StagingArea.dbo.GP_Services gps
WHERE nhs.OrganisationNum = gps.OrganisationID AND gps.ServiceName = gpnhs.GP_Service_Name

--8: ParentOrganisation---------------
INSERT INTO NHSPatientServices.dbo.ParentOrganisation(Ref_Organisation_Details_ID, Ref_Parent_ID)
SELECT nhs.ID, pt.Parent_ID 
FROM StagingArea.dbo.GP_Details sa, NHSPatientServices.dbo.Organisation_Details nhs, NHSPatientServices.dbo.Parent pt
WHERE nhs.OrganisationNum = sa.OrganisationID AND pt.Parent_Name = sa.ParentName

--9: Location-----------------
INSERT INTO NHSPatientServices.dbo.Location  (Ref_Organisation_Details_ID , Longtitude , Latitude)
SELECT nhs.ID sa   , Longitude , Latitude
FROM StagingArea.dbo.GP_Details sa, NHSPatientServices.dbo.Organisation_Details nhs
WHERE Longitude != ' ' AND nhs.OrganisationNum = sa.OrganisationID

--10: Fax-------------------
INSERT INTO NHSPatientServices.dbo.Fax(Ref_Organisation_Details_ID, Fax_Number)
SELECT nhs.ID, sa.Fax 
FROM StagingArea.dbo.GP_Details sa, 
NHSPatientServices.dbo.Organisation_Details nhs
WHERE Fax != ' ' AND  nhs.OrganisationNum = sa.OrganisationID

--11: Email---------------------------
INSERT INTO NHSPatientServices.dbo.Email (Ref_Organisation_Details_ID, Email)
SELECT nhs.ID, sa.Email 
FROM StagingArea.dbo.GP_Details sa,
NHSPatientServices.dbo.Organisation_Details nhs 
WHERE Email != ' ' AND  nhs.OrganisationNum = sa.OrganisationID

--12: Addresses------------------------
INSERT INTO NHSPatientServices.dbo.Addresses(Ref_Organisation_Details_ID, Address_Line_1, Address_Line_2, Address_Line_3, City, County, Postcode)
SELECT nhs.ID, sa.Address1, sa.Address2, sa.Address3, sa.City, sa.County, sa.Postcode 
FROM StagingArea.dbo.GP_Details sa,
NHSPatientServices.dbo.Organisation_Details nhs
WHERE nhs.OrganisationNum = sa.OrganisationID

SELECT * FROM Organisation_Type
SELECT * FROM Organisation_Details ORDER BY OrganisationNum
SELECT * FROM ServicesOrganisation