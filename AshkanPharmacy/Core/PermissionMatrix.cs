using System;using System.Collections.Generic;
namespace AshkanPharmacy.Core {
 public static class PermissionMatrix {
  static readonly Dictionary<string,string[]> Map=new Dictionary<string,string[]>(StringComparer.OrdinalIgnoreCase){
   {"Admin",new[]{"POS","Medicines","Inventory","Patients","Prescriptions","Suppliers","Reports","Settings","Returns","Insurance","Audit"}},
   {"Pharmacist",new[]{"POS","Medicines","Inventory","Patients","Prescriptions","Returns","Insurance"}},
   {"Cashier",new[]{"POS","Patients","Returns"}},{"Inventory",new[]{"Medicines","Inventory","Suppliers","Reports"}}
  };
  public static bool Can(string role,string permission){if(string.IsNullOrWhiteSpace(role))return false;string[] a;if(!Map.TryGetValue(role,out a))return false;return Array.Exists(a,x=>string.Equals(x,permission,StringComparison.OrdinalIgnoreCase));}
 }
}