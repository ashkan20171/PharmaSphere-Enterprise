using System.Collections.Generic;using System.Linq;using AshkanPharmacy.Models;
namespace AshkanPharmacy.Core { public static class HeldSaleService {
 static readonly List<HeldSale> sales=new List<HeldSale>();static int next=1;
 public static HeldSale Hold(IEnumerable<SaleLine> lines,string label){var h=new HeldSale{Id=next++,Label=label};foreach(var x in lines)h.Lines.Add(new SaleLine{Medicine=x.Medicine,Quantity=x.Quantity});sales.Add(h);return h;}
 public static List<HeldSale> All(){return sales.OrderByDescending(x=>x.HeldAt).ToList();}
 public static HeldSale Take(int id){var h=sales.FirstOrDefault(x=>x.Id==id);if(h!=null)sales.Remove(h);return h;}
 } }