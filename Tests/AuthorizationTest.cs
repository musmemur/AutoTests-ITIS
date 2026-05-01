using AuthoTests.Entities;

namespace AuthoTests.Tests
{
    [TestFixture]
    public class AuthorizationTest : TestBase
    {
        public static IEnumerable<AccountData> AccountDataFromXmlFile()
        {
            return TestDataHelper.LoadAccountDataFromXmlFile("accounts.xml");
        }

        [Test, TestCaseSource(nameof(AccountDataFromXmlFile))]
        public void AuthorizationTest_ValidCredentials_ShouldLoginSuccessfully(AccountData validAccount)
        {
            app.Navigation.OpenHomePage();
            app.Auth.Login(validAccount);

            Assert.IsTrue(app.Driver.Url.Contains("contactList"), "Пользователь не авторизован!");
        }
    }
}