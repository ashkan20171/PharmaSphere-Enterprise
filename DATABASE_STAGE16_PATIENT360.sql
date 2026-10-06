USE AshkanPharmacyDb;
IF OBJECT_ID('dbo.PatientProfiles') IS NULL CREATE TABLE dbo.PatientProfiles(Id INT IDENTITY PRIMARY KEY,FullName NVARCHAR(160) NOT NULL,NationalCode NVARCHAR(30),BirthDate DATE NULL,Phone NVARCHAR(40),Insurance NVARCHAR(100),InsuranceNo NVARCHAR(80),Allergies NVARCHAR(500),ChronicConditions NVARCHAR(500),Notes NVARCHAR(MAX));
IF OBJECT_ID('dbo.PrescriptionItems') IS NULL CREATE TABLE dbo.PrescriptionItems(Id BIGINT IDENTITY PRIMARY KEY,PrescriptionId INT NOT NULL,MedicineId INT NOT NULL,Dosage NVARCHAR(120),Quantity INT NOT NULL,Instructions NVARCHAR(500));
IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE name='IX_PatientProfiles_NationalCode') CREATE INDEX IX_PatientProfiles_NationalCode ON dbo.PatientProfiles(NationalCode);
