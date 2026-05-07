using AuthoTests.Entities;

namespace AuthoTests
{
    public class AuthBase : TestBase
    {
        protected AccountData validAccount;

        [SetUp]
        public void SetupAuth()
        {
            validAccount = new AccountData(Settings.Login, Settings.Password);

            app.Auth.Login(validAccount);

            Console.WriteLine($"Авторизация выполнена: {DateTime.Now}");
        }
    }
}
