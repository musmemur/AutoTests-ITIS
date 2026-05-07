using AuthoTests.Entities;

namespace AuthoTests.Tests
{
    [TestFixture]
    public class AuthorizationTest : TestBase
    {
        [Test]
        public void AuthorizationTest_ValidCredentials_ShouldLoginSuccessfully()
        {
            var validAccount = new AccountData(
                Settings.Login,
                Settings.Password
            );

            app.Auth.Logout();
            app.Auth.Login(validAccount);

            Assert.IsTrue(app.Auth.IsLoggedIn(), "Авторизация не выполнена");
        }
    }
}