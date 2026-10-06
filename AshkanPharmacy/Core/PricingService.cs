using System;
namespace AshkanPharmacy.Core {
 public static class PricingService {
  public static decimal Discount(decimal subtotal,decimal percent){if(percent<0||percent>100)throw new ArgumentOutOfRangeException("percent");return Math.Round(subtotal*percent/100m,0);}
  public static decimal Tax(decimal taxable,decimal percent){if(percent<0||percent>100)throw new ArgumentOutOfRangeException("percent");return Math.Round(taxable*percent/100m,0);}
  public static decimal Payable(decimal subtotal,decimal discountPercent,decimal taxPercent){var d=Discount(subtotal,discountPercent);return subtotal-d+Tax(subtotal-d,taxPercent);}
 }
}