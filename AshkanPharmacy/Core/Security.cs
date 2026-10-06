using System; using System.Security.Cryptography;
namespace AshkanPharmacy.Core {
 public static class Security {
  public static void HashPassword(string password,out string hash,out string salt) {
   var b=new byte[16]; using(var rng=RandomNumberGenerator.Create()) rng.GetBytes(b); salt=Convert.ToBase64String(b);
   using(var k=new Rfc2898DeriveBytes(password,b,100000)) hash=Convert.ToBase64String(k.GetBytes(32));
  }
  public static bool Verify(string password,string hash,string salt) {
   try { using(var k=new Rfc2898DeriveBytes(password,Convert.FromBase64String(salt),100000))
    return SlowEquals(Convert.FromBase64String(hash),k.GetBytes(32)); } catch { return false; }
  }
  static bool SlowEquals(byte[] a,byte[] b){uint d=(uint)a.Length^(uint)b.Length; for(int i=0;i<a.Length&&i<b.Length;i++) d|=(uint)(a[i]^b[i]); return d==0;}
 }
}