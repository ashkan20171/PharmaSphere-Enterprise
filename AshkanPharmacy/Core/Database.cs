using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AshkanPharmacy.Core
{
    public static class Database
    {
        public static string ConnectionString
        {
            get
            {
                var cs = ConfigurationManager.ConnectionStrings["AshkanPharmacyDb"];
                return cs == null ? @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AshkanPharmacyDb;Integrated Security=True;Connect Timeout=5" : cs.ConnectionString;
            }
        }

        public static bool IsAvailable { get; private set; }
        public static string LastError { get; private set; }

        public static void Initialize()
        {
            try
            {
                var builder = new SqlConnectionStringBuilder(ConnectionString);
                string db = builder.InitialCatalog;
                builder.InitialCatalog = "master";
                using (var cn = new SqlConnection(builder.ConnectionString))
                using (var cmd = cn.CreateCommand())
                {
                    cn.Open();
                    cmd.CommandText = "IF DB_ID(@db) IS NULL EXEC('CREATE DATABASE [" + db.Replace("]", "]]") + "]')";
                    cmd.Parameters.AddWithValue("@db", db);
                    cmd.ExecuteNonQuery();
                }
                using (var cn = new SqlConnection(ConnectionString))
                using (var cmd = cn.CreateCommand())
                {
                    cn.Open();
                    cmd.CommandText = SchemaSql;
                    cmd.ExecuteNonQuery();
                }
                IsAvailable = true;
                LastError = null;
            }
            catch (Exception ex)
            {
                IsAvailable = false;
                LastError = ex.Message;
            }
        }

        public static SqlConnection Open()
        {
            var cn = new SqlConnection(ConnectionString);
            cn.Open();
            return cn;
        }

        public static int Execute(string sql, params SqlParameter[] parameters)
        {
            using (var cn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, cn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static DataTable Query(string sql, params SqlParameter[] parameters)
        {
            using (var cn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(sql, cn))
            using (var da = new SqlDataAdapter(cmd))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                var table = new DataTable();
                da.Fill(table);
                return table;
            }
        }

        private const string SchemaSql = @"
IF OBJECT_ID('dbo.Medicines','U') IS NULL
CREATE TABLE dbo.Medicines(
 Id INT IDENTITY(1,1) PRIMARY KEY, NameFa NVARCHAR(160) NOT NULL, NameEn NVARCHAR(160) NOT NULL,
 Barcode NVARCHAR(80) NOT NULL UNIQUE, Category NVARCHAR(100) NULL, Stock INT NOT NULL DEFAULT 0,
 MinStock INT NOT NULL DEFAULT 0, BuyPrice DECIMAL(18,2) NOT NULL DEFAULT 0, SellPrice DECIMAL(18,2) NOT NULL DEFAULT 0,
 Expiry DATE NULL, Batch NVARCHAR(80) NULL, Manufacturer NVARCHAR(120) NULL);
IF OBJECT_ID('dbo.Sales','U') IS NULL
CREATE TABLE dbo.Sales(Id INT IDENTITY(1,1) PRIMARY KEY, CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(), Total DECIMAL(18,2) NOT NULL, Customer NVARCHAR(160) NULL, Status NVARCHAR(40) NOT NULL);
IF OBJECT_ID('dbo.SaleItems','U') IS NULL
CREATE TABLE dbo.SaleItems(Id INT IDENTITY(1,1) PRIMARY KEY, SaleId INT NOT NULL, MedicineId INT NOT NULL, Quantity INT NOT NULL, UnitPrice DECIMAL(18,2) NOT NULL, CONSTRAINT FK_SaleItems_Sales FOREIGN KEY(SaleId) REFERENCES dbo.Sales(Id), CONSTRAINT FK_SaleItems_Medicines FOREIGN KEY(MedicineId) REFERENCES dbo.Medicines(Id));
IF OBJECT_ID('dbo.AuditLogs','U') IS NULL
CREATE TABLE dbo.AuditLogs(Id BIGINT IDENTITY(1,1) PRIMARY KEY, CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME(), Username NVARCHAR(80) NULL, ActionName NVARCHAR(120) NOT NULL, EntityName NVARCHAR(80) NULL, Details NVARCHAR(1000) NULL);";
    }
}
