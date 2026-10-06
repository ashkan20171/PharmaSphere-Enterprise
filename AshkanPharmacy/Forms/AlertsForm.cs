using System.Drawing; using System.Windows.Forms; using AshkanPharmacy.Core;
namespace AshkanPharmacy.Forms { public class AlertsForm:Form {
 public AlertsForm(){Text=Localization.IsFa?"هشدارهای هوشمند":"Smart Alerts";BackColor=Color.FromArgb(255,247,237);Dock=DockStyle.Fill;FormBorderStyle=FormBorderStyle.None;
 var title=new Label{Text=Text,Font=new Font("Segoe UI",18,FontStyle.Bold),AutoSize=true,Location=new Point(28,24),ForeColor=Theme.Navy};Controls.Add(title);
 var list=new ListView{Location=new Point(28,75),Size=new Size(850,430),Anchor=AnchorStyles.Top|AnchorStyles.Bottom|AnchorStyles.Left|AnchorStyles.Right,View=View.Details,FullRowSelect=true,BackColor=Color.FromArgb(255,252,247)};list.Columns.Add("Severity",120);list.Columns.Add("Alert",680);
 foreach(var a in AlertService.Load())list.Items.Add(new ListViewItem(new[]{a.Severity,a.Message}));Controls.Add(list); } } }