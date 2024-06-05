namespace MRMS.Model.Authentication
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string? Token { get; set; }
        public string? Role { get; set; }
    }
}
