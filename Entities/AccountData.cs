namespace AuthoTests.Entities
{
    public class AccountData(string username, string password)
    {
        public string Email { get; set; } = username;
        public string Password { get; set; } = password;
    }
}
