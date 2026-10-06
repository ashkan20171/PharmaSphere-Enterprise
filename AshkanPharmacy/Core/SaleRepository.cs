using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AshkanPharmacy.Models;
namespace AshkanPharmacy.Core
{
 public static class SaleRepository
 {
  public static int Create(List<SaleLine> lines,string customer)
  {
   using(var cn=new SqlConnection(Database.ConnectionString)){cn.Open();using(var tx=cn.BeginTransaction())try{
    int saleId;decimal total=0;foreach(var x in lines) total+=x.Total;
    using(var cmd=new SqlCommand("INSERT dbo.Sales(Total,Customer,Status) OUTPUT INSERTED.Id VALUES(@t,@c,'Completed')",cn,tx)){cmd.Parameters.AddWithValue("@t",total);cmd.Parameters.AddWithValue("@c",customer??"");saleId=Convert.ToInt32(cmd.ExecuteScalar());}
    foreach(var x in lines){using(var cmd=new SqlCommand("INSERT dbo.SaleItems(SaleId,MedicineId,Quantity,UnitPrice) VALUES(@s,@m,@q,@p); UPDATE dbo.Medicines SET Stock=Stock-@q WHERE Id=@m AND Stock>=@q; IF @@ROWCOUNT=0 THROW 50001, 'Insufficient stock', 1;",cn,tx)){cmd.Parameters.AddWithValue("@s",saleId);cmd.Parameters.AddWithValue("@m",x.Medicine.Id);cmd.Parameters.AddWithValue("@q",x.Quantity);cmd.Parameters.AddWithValue("@p",x.Medicine.SellPrice);cmd.ExecuteNonQuery();}}
    tx.Commit();return saleId;
   }catch{tx.Rollback();throw;}}
  }
 }
 public static class AuditRepository
 {
  public static void Log(string action,string entity,string details){if(!Database.IsAvailable)return;try{Database.Execute("INSERT dbo.AuditLogs(Username,ActionName,EntityName,Details) VALUES(@u,@a,@e,@d)",new SqlParameter("@u",Session.CurrentUser==null?"system":Session.CurrentUser.Username),new SqlParameter("@a",action),new SqlParameter("@e",entity??""),new SqlParameter("@d",details??""));}catch{}}
 }
}
