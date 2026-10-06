using System.Drawing; using System.Windows.Forms;
namespace AshkanPharmacy.Core { public static class Theme {
 public static readonly Color Navy=Color.FromArgb(15,35,55), Teal=Color.FromArgb(20,154,136), Mint=Color.FromArgb(218,244,239),
 Bg=Color.FromArgb(224,236,242), Card=Color.FromArgb(244,249,250), Text=Color.FromArgb(24,45,58), Muted=Color.FromArgb(91,111,122),
 Danger=Color.FromArgb(210,70,78), Warning=Color.FromArgb(226,145,42), Sidebar=Color.FromArgb(19,48,62), Topbar=Color.FromArgb(232,242,246),
 Surface=Color.FromArgb(235,244,246), Aqua=Color.FromArgb(35,176,166), Indigo=Color.FromArgb(77,92,181);
 public static Font Font(float s=10,FontStyle st=FontStyle.Regular){return new Font("Segoe UI",s,st);}
 public static void StyleGrid(DataGridView g){g.BorderStyle=BorderStyle.None;g.BackgroundColor=Card;g.RowHeadersVisible=false;g.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;g.EnableHeadersVisualStyles=false;g.ColumnHeadersDefaultCellStyle.BackColor=Navy;g.ColumnHeadersDefaultCellStyle.ForeColor=Color.White;g.ColumnHeadersDefaultCellStyle.Font=Font(10,FontStyle.Bold);g.DefaultCellStyle.BackColor=Card;g.DefaultCellStyle.ForeColor=Text;g.DefaultCellStyle.SelectionBackColor=Mint;g.DefaultCellStyle.SelectionForeColor=Text;g.RowTemplate.Height=38;}
} }