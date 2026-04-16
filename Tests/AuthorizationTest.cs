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
                "timurkrivoscheev2005@gmail.com",
                "12345678"
            );

            app.Navigation.OpenHomePage();
            app.Auth.Login(validAccount);
        }
    }
}