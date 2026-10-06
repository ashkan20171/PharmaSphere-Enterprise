USE AshkanPharmacyDb;
IF OBJECT_ID('dbo.AuditLogs') IS NULL CREATE TABLE dbo.AuditLogs(Id BIGINT IDENTITY PRIMARY KEY,UserName NVARCHAR(100),ActionName NVARCHAR(120) NOT NULL,EntityName NVARCHAR(120) NOT NULL,Details NVARCHAR(MAX),CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME());
IF OBJECT_ID('dbo.NotificationRules') IS NULL CREATE TABLE dbo.NotificationRules(Id INT IDENTITY PRIMARY KEY,RuleType NVARCHAR(80) NOT NULL,ThresholdValue INT NULL,Enabled BIT NOT NULL DEFAULT 1);
IF NOT EXISTS(SELECT 1 FROM dbo.NotificationRules WHERE RuleType='ExpiryDays') INSERT dbo.NotificationRules(RuleType,ThresholdValue) VALUES('ExpiryDays',60);
IF NOT EXISTS(SELECT 1 FROM sys.indexes WHERE name='IX_AuditLogs_CreatedAt') CREATE INDEX IX_AuditLogs_CreatedAt ON dbo.AuditLogs(CreatedAt DESC);
