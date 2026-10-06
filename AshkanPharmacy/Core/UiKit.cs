using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace AshkanPharmacy.Core {
 public class RoundedPanel:Panel { public int Radius{get;set;}=20; public Color BorderColor{get;set;}=Color.FromArgb(225,232,240); protected override void OnPaint(PaintEventArgs e){base.OnPaint(e);e.Graphics.SmoothingMode=SmoothingMode.AntiAlias;using(var p=Path(ClientRectangle,Radius)){Region=new Region(p);using(var pen=new Pen(BorderColor,1))e.Graphics.DrawPath(pen,p);}} static GraphicsPath Path(Rectangle r,int rad){int d=rad*2;var p=new GraphicsPath();p.AddArc(r.X,r.Y,d,d,180,90);p.AddArc(r.Right-d-1,r.Y,d,d,270,90);p.AddArc(r.Right-d-1,r.Bottom-d-1,d,d,0,90);p.AddArc(r.X,r.Bottom-d-1,d,d,90,90);p.CloseFigure();return p;}}
 public class AccentButton:Button { public int Radius{get;set;}=12; protected override void OnPaint(PaintEventArgs e){e.Graphics.SmoothingMode=SmoothingMode.AntiAlias;using(var p=RoundedPanelPath(ClientRectangle,Radius)){e.Graphics.FillPath(new SolidBrush(BackColor),p);TextRenderer.DrawText(e.Graphics,Text,Font,ClientRectangle,ForeColor,TextFormatFlags.HorizontalCenter|TextFormatFlags.VerticalCenter);}} static GraphicsPath RoundedPanelPath(Rectangle r,int rad){int d=rad*2;var p=new GraphicsPath();p.AddArc(0,0,d,d,180,90);p.AddArc(r.Width-d-1,0,d,d,270,90);p.AddArc(r.Width-d-1,r.Height-d-1,d,d,0,90);p.AddArc(0,r.Height-d-1,d,d,90,90);p.CloseFigure();return p;}}
 public class SalesChart:Control { public SalesChart(){DoubleBuffered=true;} protected override void OnPaint(PaintEventArgs e){base.OnPaint(e);var g=e.Graphics;g.SmoothingMode=SmoothingMode.AntiAlias;int[] v={38,52,68,64,60,76,58};var area=new Rectangle(42,28,Width-65,Height-62);using(var pen=new Pen(Color.FromArgb(225,232,240))){for(int i=0;i<5;i++){int y=area.Top+i*area.Height/4;g.DrawLine(pen,area.Left,y,area.Right,y);}}int bw=Math.Max(20,area.Width/12);for(int i=0;i<v.Length;i++){int x=area.Left+20+i*(area.Width-50)/7;int h=area.Height*v[i]/100;var r=new Rectangle(x,area.Bottom-h,bw,h);using(var b=new LinearGradientBrush(r,Color.FromArgb(40,150,245),Color.FromArgb(79,188,255),90))g.FillRectangle(b,r);}using(var f=new Font("Segoe UI",8)){for(int i=0;i<7;i++)g.DrawString((i+9).ToString(),f,Brushes.DimGray,area.Left+22+i*(area.Width-50)/7,area.Bottom+8);}}}

 public class GradientPanel:Panel {
  public Color Color1{get;set;}=Color.FromArgb(22,153,139); public Color Color2{get;set;}=Color.FromArgb(52,107,168); public int Radius{get;set;}=22;
  public GradientPanel(){DoubleBuffered=true;}
  protected override void OnPaint(PaintEventArgs e){e.Graphics.SmoothingMode=SmoothingMode.AntiAlias;using(var p=MakePath(ClientRectangle,Radius))using(var b=new LinearGradientBrush(ClientRectangle,Color1,Color2,20f)){e.Graphics.FillPath(b,p);Region=new Region(p);}}
  static GraphicsPath MakePath(Rectangle r,int rad){int d=rad*2;var p=new GraphicsPath();p.AddArc(0,0,d,d,180,90);p.AddArc(r.Width-d-1,0,d,d,270,90);p.AddArc(r.Width-d-1,r.Height-d-1,d,d,0,90);p.AddArc(0,r.Height-d-1,d,d,90,90);p.CloseFigure();return p;}
 }
 public class DonutGauge:Control {
  public int Value{get;set;}=72; public string Caption{get;set;}="Inventory health"; public Color Accent{get;set;}=Color.FromArgb(25,154,136);
  public DonutGauge(){DoubleBuffered=true;}
  protected override void OnPaint(PaintEventArgs e){base.OnPaint(e);e.Graphics.SmoothingMode=SmoothingMode.AntiAlias;var r=new Rectangle(20,12,105,105);using(var p=new Pen(Color.FromArgb(215,227,230),12))e.Graphics.DrawArc(p,r,-90,360);using(var p=new Pen(Accent,12)){p.StartCap=LineCap.Round;p.EndCap=LineCap.Round;e.Graphics.DrawArc(p,r,-90,360*Value/100f);}using(var f=new Font("Segoe UI",18,FontStyle.Bold))using(var b=new SolidBrush(Theme.Navy)){var t=Value+"%";var z=e.Graphics.MeasureString(t,f);e.Graphics.DrawString(t,f,b,r.X+(r.Width-z.Width)/2,r.Y+(r.Height-z.Height)/2);}using(var f=new Font("Segoe UI",9,FontStyle.Bold))using(var b=new SolidBrush(Theme.Muted))e.Graphics.DrawString(Caption,f,b,145,48);}
 }
}
