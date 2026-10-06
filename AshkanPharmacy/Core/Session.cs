using AshkanPharmacy.Models;
namespace AshkanPharmacy.Core
{
    public static class Session
    {
        public static UserAccount CurrentUser { get; private set; }
        public static bool IsAuthenticated { get { return CurrentUser != null; } }
        public static void SignIn(UserAccount user) { CurrentUser = user; }
        public static void SignOut() { CurrentUser = null; }
        public static bool IsInRole(params string[] roles)
        {
            if (CurrentUser == null || roles == null) return false;
            foreach (var role in roles) if (string.Equals(CurrentUser.Role, role, System.StringComparison.OrdinalIgnoreCase)) return true;
            return false;
        }
    }
}
