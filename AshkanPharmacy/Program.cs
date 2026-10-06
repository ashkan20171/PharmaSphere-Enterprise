using System;
using System.Windows.Forms;
using AshkanPharmacy.Core;
using AshkanPharmacy.Forms;
namespace AshkanPharmacy
{
 static class Program
 {
  [STAThread] static void Main()
  {
   Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false);
   Database.Initialize();try{MigrationRunner.EnsurePlatformTables();}catch{}
   AppStore.InitializePersistence();
   using(var login=new LoginForm()){ if(login.ShowDialog()!=DialogResult.OK) return; }
   Application.Run(new MainForm());
  }
 }
}
