using System;using System.Collections.Generic;
namespace AshkanPharmacy.Models {
 public class PatientProfile { public int Id{get;set;} public string FullName{get;set;} public string NationalCode{get;set;} public DateTime? BirthDate{get;set;} public string Phone{get;set;} public string Insurance{get;set;} public string InsuranceNo{get;set;} public string Allergies{get;set;} public string ChronicConditions{get;set;} public string Notes{get;set;} }
 public class PrescriptionItem { public int MedicineId{get;set;} public string MedicineName{get;set;} public string Dosage{get;set;} public int Quantity{get;set;} public string Instructions{get;set;} }
}