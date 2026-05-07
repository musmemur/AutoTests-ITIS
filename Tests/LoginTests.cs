using AuthoTests.Entities;

namespace AuthoTests.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [SetUp]
        public void PreCondition()
        {
            app.Auth.Logout();
        }

        [Test]
        public void LoginWithValidData()
        {
            var validAccount = new AccountData(
                Settings.Login,
                Settings.Password
            );

            app.Auth.Login(validAccount);

            Assert.IsTrue(app.Auth.IsLoggedIn(), "Пользователь не залогинен после валидной авторизации");
        }

        [Test]
        public void LoginWithInvalidData()
        {
            var invalidAccount = new AccountData(
                "invalidemail@test.com",
                "wrongpassword"
            );

            try
            {
                app.Auth.Login(invalidAccount);
            }
            catch (Exception)
            {
                Assert.IsFalse(app.Auth.IsLoggedIn(), "Пользователь не должен быть залогинен с неверными данными");
                return;
            }

            Assert.Fail("Авторизация с неверными данными не должна проходить");
        }
    }
}
