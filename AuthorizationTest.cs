using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

using AuthoTests.Entities;

namespace AuthoTests;

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

        OpenHomePage();
        Login(validAccount);
    }
}