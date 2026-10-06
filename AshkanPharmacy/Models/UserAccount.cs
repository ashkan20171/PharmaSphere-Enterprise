namespace AshkanPharmacy.Models
{
    public sealed class UserAccount
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DisplayNameFa { get; set; }
        public string DisplayNameEn { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }
}
