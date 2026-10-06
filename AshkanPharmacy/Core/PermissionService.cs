using System;
namespace AshkanPharmacy.Core {
 public enum AppPermission { Sell,ManageMedicines,ReceiveStock,ManagePatients,ViewReports,ManageUsers,ViewAudit,Backup }
 public static class PermissionService {
  public static bool Can(string role,AppPermission permission) {
   role=(role??"").Trim().ToLowerInvariant();
   if(role=="admin") return true;
   if(role=="pharmacist") return permission!=AppPermission.ManageUsers;
   if(role=="cashier") return permission==AppPermission.Sell || permission==AppPermission.ManagePatients;
   return false;
  }
 }
}