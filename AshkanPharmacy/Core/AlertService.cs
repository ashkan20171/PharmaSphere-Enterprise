using System; using System.Collections.Generic; using System.Data.SqlClient;
namespace AshkanPharmacy.Core {
 public sealed class PharmacyAlert { public string Severity{get;set;} public string Message{get;set;} }
 public static class AlertService {
  public static List<PharmacyAlert> Load() { var a=new List<PharmacyAlert>(); if(!Database.IsAvailable)return a; try{using(var c=Database.Open())using(var q=new SqlCommand("SELECT NameEn,Stock,MinStock,ExpiryDate FROM dbo.Medicines WHERE Stock<=MinStock OR ExpiryDate<=DATEADD(day,60,GETDATE()) ORDER BY ExpiryDate",c))using(var r=q.ExecuteReader())while(r.Read()){var n=r.IsDBNull(0)?"Medicine":r.GetString(0);var stock=r.GetInt32(1);var min=r.GetInt32(2);var exp=r.GetDateTime(3);if(stock<=min)a.Add(new PharmacyAlert{Severity="Warning",Message=n+" — low stock ("+stock+")"});if(exp<=DateTime.Today.AddDays(60))a.Add(new PharmacyAlert{Severity="Critical",Message=n+" — expires "+exp.ToString("yyyy-MM-dd")});}}catch{}return a; }
 }
}