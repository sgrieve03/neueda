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
IF OBJECT_ID('dbo.Organisation_Type_Table', 'U') IS NOT NULL
  
  DROP TABLE dbo.Addresses
  DROP TABLE dbo.Email
  DROP TABLE dbo.Fax
  DROP TABLE dbo.Location
  DROP TABLE dbo.LookUp_Parent_Table
  DROP TABLE dbo.LookUp_GP_Services
  DROP TABLE dbo.Parent_Table
  DROP TABLE dbo.Telephone
  DROP TABLE dbo.Website
  DROP TABLE dbo.GP_Services
  DROP TABLE dbo.Organisation_Details 
  DROP TABLE dbo.Organisation_Type_Table
    
--------------------------------------------------------------------------------------------------------
--------CREATE TABLES----------
--------------------------------------------------------------------------------------------------------
CREATE TABLE Organisation_Type_Table (
Organisation_Type_ID INTEGER IDENTITY (1,1),
Organisation_Type CHAR(25) NOT NULL,
PRIMARY KEY (Organisation_Type_ID)
)

CREATE TABLE Organisation_Details (
ID INTEGER IDENTITY (1,1),
Organisation_ID INTEGER UNIQUE NOT NULL,
Organisation_Name VARCHAR(max) NOT NULL,
Ref_Organisation_Type_ID INTEGER NOT NULL,
EPS_Enabled VARCHAR(max) NOT NULL,
FOREIGN KEY (Ref_Organisation_Type_ID) REFERENCES Organisation_Type_Table (Organisation_Type_ID),
PRIMARY KEY (ID)
)

CREATE TABLE GP_Services (
Service_ID INTEGER UNIQUE IDENTITY (1,1),
GP_Service_Name CHAR(255)
PRIMARY KEY (Service_ID, GP_Service_Name)
)

CREATE TABLE Lookup_GP_Services (
Ref_Organisation_Details_ID INTEGER,
Ref_Service_ID INTEGER NOT NULL,
PRIMARY KEY (Ref_Organisation_Details_ID, Ref_Service_ID),
FOREIGN KEY (Ref_Service_ID) REFERENCES GP_Services(Service_ID),
FOREIGN KEY (Ref_Organisation_Details_ID) REFERENCES Organisation_Details(ID)
)

CREATE TABLE Parent_Table(
Parent_ID INTEGER IDENTITY (1,1),
ODSCode VARCHAR(max),
Parent_Name VARCHAR(max),
PRIMARY KEY (Parent_ID) 
)

CREATE TABLE LookUp_Parent_Table(
Ref_Organisation_Details_ID INTEGER,
Ref_Parent_ID INTEGER,
PRIMARY KEY(Ref_Organisation_Details_ID, Ref_Parent_ID),
FOREIGN KEY (Ref_Parent_ID) REFERENCES Parent_Table(Parent_ID),
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