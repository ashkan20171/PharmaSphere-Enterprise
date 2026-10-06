using System; using System.Drawing; using System.Drawing.Printing;
namespace AshkanPharmacy.Core {
 public sealed class InvoiceService {
  readonly string text; public InvoiceService(string invoiceText){text=invoiceText??"";}
  public void Print(){var d=new PrintDocument();d.PrintPage+=(s,e)=>e.Graphics.DrawString(text,new Font("Segoe UI",10),Brushes.Black,new RectangleF(40,40,e.MarginBounds.Width,e.MarginBounds.Height));d.Print();}
 }
}