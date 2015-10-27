-------------------------------------------------------------------------------------------------------
-----INSERT DATA TO NHSPatientService Database FROM StagingArea Database
-------------------------------------------------------------------------------------------------------
--1: Organisation_Type_Table---------
INSERT INTO NHSPatientServices.dbo.Organisation_Type_Table (Organisation_Type)
SELECT DISTINCT OrganisationType FROM StagingArea.dbo.GP_Details

--2: Organisation_Details-----------
INSERT INTO NHSPatientServices.dbo.Organisation_Details (Organisation_ID, Organisation_Name, Ref_Organisation_Type_ID, EPS_Enabled)
SELECT sa.OrganisationID, sa.OrganisationName, nhs.Organisation_Type_ID, sa.isEPSEnabled
FROM StagingArea.dbo.GP_Details sa, NHSPatientServices.dbo.Organisation_Type_Table nhs
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
WHERE Website != ' ' AND  nhs.Organisation_ID = sa.OrganisationID

--5: Telephone------------------
INSERT INTO NHSPatientServices.dbo.Telephone(Ref_Organisation_Details_ID, Telephone_Number)
SELECT  nhs.ID, sa.Phone 
FROM StagingArea.dbo.GP_Details sa, 
NHSPatientServices.dbo.Organisation_Details nhs 
WHERE phone != ' ' AND  nhs.Organisation_ID = sa.OrganisationID

--6: Parent_Table----------
INSERT INTO NHSPatientServices.dbo.Parent_Table(ODSCode, Parent_Name)
SELECT DISTINCT ParentODSCode, ParentName FROM StagingArea.dbo.GP_Details

--7: LookUp_GP_services---------------
INSERT INTO NHSPatientServices.dbo.Lookup_GP_Services(Ref_Organisation_Details_ID ,Ref_Service_ID )
SELECT nhs.ID, gpnhs.Service_ID
FROM NHSPatientServices.dbo.Organisation_Details nhs, NHSPatientServices.dbo.GP_Services gpnhs, StagingArea.dbo.GP_Services gps
WHERE nhs.Organisation_ID = gps.OrganisationID AND gps.ServiceName = gpnhs.GP_Service_Name

--8: LookUp_Parent_Table---------------
INSERT INTO NHSPatientServices.dbo.LookUp_Parent_Table(Ref_Organisation_Details_ID, Ref_Parent_ID)
SELECT nhs.ID, pt.Parent_ID 
FROM StagingArea.dbo.GP_Details sa, NHSPatientServices.dbo.Organisation_Details nhs, NHSPatientServices.dbo.Parent_Table pt
WHERE nhs.Organisation_ID = sa.OrganisationID AND pt.Parent_Name = sa.ParentName

--9: Location-----------------
INSERT INTO NHSPatientServices.dbo.Location  (Ref_Organisation_Details_ID , Longtitude , Latitude)
SELECT nhs.ID sa   , Longitude , Latitude
FROM StagingArea.dbo.GP_Details sa, NHSPatientServices.dbo.Organisation_Details nhs
WHERE Longitude != ' ' AND nhs.Organisation_ID = sa.OrganisationID

--10: Fax-------------------
INSERT INTO NHSPatientServices.dbo.Fax(Ref_Organisation_Details_ID, Fax_Number)
SELECT nhs.ID, sa.Fax 
FROM StagingArea.dbo.GP_Details sa, 
NHSPatientServices.dbo.Organisation_Details nhs
WHERE Fax != ' ' AND  nhs.Organisation_ID = sa.OrganisationID

--11: Email---------------------------
INSERT INTO NHSPatientServices.dbo.Email (Ref_Organisation_Details_ID, Email)
SELECT nhs.ID, sa.Email 
FROM StagingArea.dbo.GP_Details sa,
NHSPatientServices.dbo.Organisation_Details nhs 
WHERE Email != ' ' AND  nhs.Organisation_ID = sa.OrganisationID

--12: Addresses------------------------
INSERT INTO NHSPatientServices.dbo.Addresses(Ref_Organisation_Details_ID, Address_Line_1, Address_Line_2, Address_Line_3, City, County, Postcode)
SELECT nhs.ID, sa.Address1, sa.Address2, sa.Address3, sa.City, sa.County, sa.Postcode 
FROM StagingArea.dbo.GP_Details sa,
NHSPatientServices.dbo.Organisation_Details nhs
WHERE nhs.Organisation_ID = sa.OrganisationID
