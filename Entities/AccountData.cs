namespace AuthoTests.Entities
{
    public class AccountData
    {
        public AccountData()
        {
            Email = string.Empty;
            Password = string.Empty;
        }

        public AccountData(string username, string password)
        {
            Email = username;
            Password = password;
        }

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}