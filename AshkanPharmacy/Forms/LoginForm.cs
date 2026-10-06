using System; using System.Drawing; using System.Windows.Forms; using AshkanPharmacy.Core;
namespace AshkanPharmacy.Forms
{
    public sealed class LoginForm : Form
    {
        TextBox userBox, passBox; Label title, subtitle, message; Button login, language;
        bool fa=true; readonly AuthService auth=new AuthService(); Panel brand, card;
        public LoginForm(){ InitializeUi(); ApplyLanguage(); }
        void InitializeUi(){ Text="Ashkan Pharmacy • Login"; StartPosition=FormStartPosition.CenterScreen; ClientSize=new Size(960,600); MinimumSize=new Size(850,540); BackColor=Color.FromArgb(229,245,242); Font=new Font("Segoe UI",10); FormBorderStyle=FormBorderStyle.FixedSingle; MaximizeBox=false;
            brand=new Panel{Dock=DockStyle.Left,Width=420,BackColor=Color.FromArgb(19,109,103)}; Controls.Add(brand);
            brand.Controls.Add(new Label{Text="✚",Font=new Font("Segoe UI Symbol",64,FontStyle.Bold),ForeColor=Color.White,AutoSize=true,Location=new Point(165,120)});
            brand.Controls.Add(new Label{Text="ASHKAN\nPHARMACY",Font=new Font("Segoe UI",25,FontStyle.Bold),ForeColor=Color.White,AutoSize=true,TextAlign=ContentAlignment.MiddleCenter,Location=new Point(105,235)});
            brand.Controls.Add(new Label{Text="Smart Pharmacy Management",Font=new Font("Segoe UI",11),ForeColor=Color.FromArgb(207,244,238),AutoSize=true,Location=new Point(105,325)});
            card=new Panel{BackColor=Color.FromArgb(246,251,252),Size=new Size(400,410),Location=new Point(500,85)}; Controls.Add(card);
            title=new Label{Font=new Font("Segoe UI",22,FontStyle.Bold),ForeColor=Color.FromArgb(25,50,65),AutoSize=true,Location=new Point(38,38)}; subtitle=new Label{ForeColor=Color.FromArgb(90,110,120),AutoSize=true,Location=new Point(40,86)};
            userBox=new TextBox{Font=new Font("Segoe UI",12),Size=new Size(320,34),Location=new Point(40,145)}; passBox=new TextBox{Font=new Font("Segoe UI",12),Size=new Size(320,34),Location=new Point(40,215),UseSystemPasswordChar=true};
            login=new Button{FlatStyle=FlatStyle.Flat,BackColor=Color.FromArgb(22,145,132),ForeColor=Color.White,Size=new Size(320,48),Location=new Point(40,282),Font=new Font("Segoe UI",11,FontStyle.Bold)}; login.FlatAppearance.BorderSize=0; login.Click+=Login_Click;
            language=new Button{FlatStyle=FlatStyle.Flat,BackColor=Color.FromArgb(225,240,244),ForeColor=Color.FromArgb(35,75,90),Size=new Size(110,34),Location=new Point(250,350)}; language.FlatAppearance.BorderSize=0; language.Click+=(s,e)=>{fa=!fa; ApplyLanguage();};
            message=new Label{ForeColor=Color.FromArgb(190,60,60),AutoSize=true,Location=new Point(40,255)};
            card.Controls.AddRange(new Control[]{title,subtitle,userBox,passBox,message,login,language}); AcceptButton=login;
        }
        void ApplyLanguage(){ SuspendLayout(); Localization.Persian=fa; RightToLeft=RightToLeft.No; RightToLeftLayout=false; title.Text=fa?"ورود به داروخانه اشکان":"Welcome back"; subtitle.Text=fa?"برای ادامه وارد حساب کاربری شوید":"Sign in to Ashkan Pharmacy"; login.Text=fa?"ورود به سامانه":"Sign in"; language.Text=fa?"English":"فارسی"; userBox.RightToLeft=fa?RightToLeft.Yes:RightToLeft.No; passBox.RightToLeft=RightToLeft.No; message.Text=""; if(card!=null){card.RightToLeft=fa?RightToLeft.Yes:RightToLeft.No;} ResumeLayout(true); }
        void Login_Click(object sender,EventArgs e){ var u=auth.Authenticate(userBox.Text,passBox.Text); if(u==null){message.Text=fa?"نام کاربری یا رمز عبور صحیح نیست.":"Invalid username or password.";return;} Session.SignIn(u); DialogResult=DialogResult.OK; Close(); }
    }
}
