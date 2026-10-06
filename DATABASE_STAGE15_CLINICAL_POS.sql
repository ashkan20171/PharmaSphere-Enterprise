USE AshkanPharmacyDb;
IF COL_LENGTH('dbo.Sales','PatientId') IS NULL ALTER TABLE dbo.Sales ADD PatientId INT NULL;
IF COL_LENGTH('dbo.Sales','PrescriptionId') IS NULL ALTER TABLE dbo.Sales ADD PrescriptionId INT NULL;
IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE name='IX_Payments_SaleId') CREATE INDEX IX_Payments_SaleId ON dbo.Payments(SaleId);
IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE name='IX_Returns_SaleId') CREATE INDEX IX_Returns_SaleId ON dbo.Returns(SaleId);
