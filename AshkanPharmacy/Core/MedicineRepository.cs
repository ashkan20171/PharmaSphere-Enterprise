using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AshkanPharmacy.Models;

namespace AshkanPharmacy.Core
{
    public static class MedicineRepository
    {
        public static List<Medicine> GetAll()
        {
            var result = new List<Medicine>();
            var t = Database.Query("SELECT Id,NameFa,NameEn,Barcode,Category,Stock,MinStock,BuyPrice,SellPrice,Expiry,Batch,Manufacturer FROM dbo.Medicines ORDER BY Id");
            foreach (System.Data.DataRow r in t.Rows)
                result.Add(new Medicine { Id=Convert.ToInt32(r["Id"]), NameFa=Convert.ToString(r["NameFa"]), NameEn=Convert.ToString(r["NameEn"]), Barcode=Convert.ToString(r["Barcode"]), Category=Convert.ToString(r["Category"]), Stock=Convert.ToInt32(r["Stock"]), MinStock=Convert.ToInt32(r["MinStock"]), BuyPrice=Convert.ToDecimal(r["BuyPrice"]), SellPrice=Convert.ToDecimal(r["SellPrice"]), Expiry=r["Expiry"]==DBNull.Value?DateTime.Today:Convert.ToDateTime(r["Expiry"]), Batch=Convert.ToString(r["Batch"]), Manufacturer=Convert.ToString(r["Manufacturer"]) });
            return result;
        }
        public static int Insert(Medicine m)
        {
            var t=Database.Query(@"INSERT dbo.Medicines(NameFa,NameEn,Barcode,Category,Stock,MinStock,BuyPrice,SellPrice,Expiry,Batch,Manufacturer) OUTPUT INSERTED.Id VALUES(@fa,@en,@bc,@cat,@stock,@min,@buy,@sell,@exp,@batch,@man)", P("@fa",m.NameFa),P("@en",m.NameEn),P("@bc",m.Barcode),P("@cat",m.Category),P("@stock",m.Stock),P("@min",m.MinStock),P("@buy",m.BuyPrice),P("@sell",m.SellPrice),P("@exp",m.Expiry),P("@batch",m.Batch),P("@man",m.Manufacturer));
            return Convert.ToInt32(t.Rows[0][0]);
        }
        public static void Update(Medicine m) { Database.Execute(@"UPDATE dbo.Medicines SET NameFa=@fa,NameEn=@en,Barcode=@bc,Category=@cat,Stock=@stock,MinStock=@min,BuyPrice=@buy,SellPrice=@sell,Expiry=@exp,Batch=@batch,Manufacturer=@man WHERE Id=@id",P("@fa",m.NameFa),P("@en",m.NameEn),P("@bc",m.Barcode),P("@cat",m.Category),P("@stock",m.Stock),P("@min",m.MinStock),P("@buy",m.BuyPrice),P("@sell",m.SellPrice),P("@exp",m.Expiry),P("@batch",m.Batch),P("@man",m.Manufacturer),P("@id",m.Id)); }
        public static void Delete(int id) { Database.Execute("DELETE dbo.Medicines WHERE Id=@id",P("@id",id)); }
        public static void SetStock(int id,int stock) { Database.Execute("UPDATE dbo.Medicines SET Stock=@stock WHERE Id=@id",P("@stock",stock),P("@id",id)); }
        static SqlParameter P(string n,object v){return new SqlParameter(n,v??(object)DBNull.Value);}
    }
}
