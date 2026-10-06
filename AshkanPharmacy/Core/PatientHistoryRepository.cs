using System;using System.Data;using System.Data.SqlClient;
namespace AshkanPharmacy.Core { public static class PatientHistoryRepository {
 public static DataTable Load(int patientId){var t=new DataTable();if(!Database.IsAvailable)return t;using(var c=Database.Open())using(var q=new SqlCommand("SELECT TOP 100 Id,CreatedAt,Total,Status FROM dbo.Sales WHERE PatientId=@p ORDER BY CreatedAt DESC",c)){q.Parameters.AddWithValue("@p",patientId);using(var a=new SqlDataAdapter(q))a.Fill(t);}return t;}
 } }