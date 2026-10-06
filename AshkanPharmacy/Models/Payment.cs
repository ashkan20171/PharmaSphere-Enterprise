using System;
namespace AshkanPharmacy.Models {
 public enum PaymentMethod { Cash, Card, Insurance, Mixed }
 public class PaymentSummary { public decimal Subtotal{get;set;} public decimal Discount{get;set;} public decimal Tax{get;set;} public decimal Payable{get;set;} public PaymentMethod Method{get;set;} public string Reference{get;set;} public DateTime PaidAt{get;set;}=DateTime.Now; }
}