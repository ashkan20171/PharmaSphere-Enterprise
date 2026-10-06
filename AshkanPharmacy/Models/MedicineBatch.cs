using System; namespace AshkanPharmacy.Models {
 public class MedicineBatch { public int Id{get;set;} public int MedicineId{get;set;} public string BatchNo{get;set;} public DateTime ExpiryDate{get;set;} public int Quantity{get;set;} public decimal PurchasePrice{get;set;} }
}