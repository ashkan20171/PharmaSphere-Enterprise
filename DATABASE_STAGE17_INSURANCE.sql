USE AshkanPharmacyDb;
IF OBJECT_ID('dbo.InsuranceClaims') IS NULL CREATE TABLE dbo.InsuranceClaims(Id BIGINT IDENTITY PRIMARY KEY,SaleId INT NOT NULL,PatientId INT NOT NULL,Provider NVARCHAR(120),PolicyNo NVARCHAR(100),GrossAmount DECIMAL(18,2) NOT NULL,CoveredAmount DECIMAL(18,2) NOT NULL,PatientShare DECIMAL(18,2) NOT NULL,Status NVARCHAR(30) NOT NULL,CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),SubmittedAt DATETIME2 NULL,SettledAt DATETIME2 NULL);
IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE name='IX_InsuranceClaims_Status') CREATE INDEX IX_InsuranceClaims_Status ON dbo.InsuranceClaims(Status,CreatedAt DESC);
IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE name='IX_Sales_PatientId') CREATE INDEX IX_Sales_PatientId ON dbo.Sales(PatientId,CreatedAt DESC);
