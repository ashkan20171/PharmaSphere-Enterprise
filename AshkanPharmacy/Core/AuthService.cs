using System; using System.Linq; using AshkanPharmacy.Models;
namespace AshkanPharmacy.Core
{
    public sealed class AuthService
    {
        public UserAccount Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password)) return null;
            return AppStore.Users.FirstOrDefault(x => x.IsActive && string.Equals(x.Username, username.Trim(), StringComparison.OrdinalIgnoreCase) && x.Password == password);
        }
    }
}
