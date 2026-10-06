using System;using System.Collections.Generic;using System.Linq;using AshkanPharmacy.Models;
namespace AshkanPharmacy.Core {
 public sealed class ClinicalWarning { public string Level{get;set;} public string Message{get;set;} }
 public static class ClinicalSafetyService {
  public static List<ClinicalWarning> Review(PatientProfile patient,IEnumerable<Medicine> medicines){
   var r=new List<ClinicalWarning>();if(patient==null)return r;var allergy=(patient.Allergies??"").ToLowerInvariant();
   foreach(var m in medicines??Enumerable.Empty<Medicine>()){var n=((m.NameEn??"")+" "+(m.NameFa??"")).ToLowerInvariant();if(allergy.Length>2 && n.Contains(allergy))r.Add(new ClinicalWarning{Level="Critical",Message="Potential allergy match: "+m.NameEn});if(m.Expiry.Date<DateTime.Today)r.Add(new ClinicalWarning{Level="Critical",Message="Expired medicine blocked: "+m.NameEn});}
   return r;
  }
 }
}