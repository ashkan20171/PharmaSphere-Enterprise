using System; using System.Data.SqlClient;
namespace AshkanPharmacy.Core {
 public sealed class DashboardSnapshot { public int Medicines, LowStock, Expiring; public decimal TodaySales; }
 public static class DashboardRepository {
  public static DashboardSnapshot Load() {
   var s=new DashboardSnapshot(); if(!Database.IsAvailable) return s;
   try { using(var c=Database.Open()) {
    using(var q=new SqlCommand("SELECT COUNT(*),SUM(CASE WHEN Stock<=MinStock THEN 1 ELSE 0 END),SUM(CASE WHEN ExpiryDate<=DATEADD(day,60,GETDATE()) THEN 1 ELSE 0 END) FROM dbo.Medicines",c))
    using(var r=q.ExecuteReader()) if(r.Read()){s.Medicines=r.IsDBNull(0)?0:r.GetInt32(0);s.LowStock=r.IsDBNull(1)?0:r.GetInt32(1);s.Expiring=r.IsDBNull(2)?0:r.GetInt32(2);}
    using(var q=new SqlCommand("SELECT ISNULL(SUM(Total),0) FROM dbo.Sales WHERE CAST(CreatedAt AS date)=CAST(GETDATE() AS date)",c)) s.TodaySales=Convert.ToDecimal(q.ExecuteScalar());
   }} catch {} return s;
  }
 }
}