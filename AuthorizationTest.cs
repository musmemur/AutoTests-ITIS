using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

public class AuthorizationTest
{
    private ChromeDriver _driver;

    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [TearDown]
    public void TearDown()
    {
        _driver?.Quit();  
    }

    [Test]
    public void AuthorizationTest_ValidCredentials_ShouldLoginSuccessfully()
    {
        OpenHomePage();

        _driver.FindElement(By.CssSelector("[data-test=\"username\"]")).Clear();
        _driver.FindElement(By.CssSelector("[data-test=\"username\"]")).SendKeys("standard_user");
        _driver.FindElement(By.CssSelector("[data-test=\"password\"]")).Clear();
        _driver.FindElement(By.CssSelector("[data-test=\"password\"]")).SendKeys("secret_sauce");
        _driver.FindElement(By.CssSelector("[data-test=\"login-button\"]")).Click();

        bool isLoggedIn = _driver.Url.Contains("inventory");

        Assert.IsTrue(isLoggedIn, "Пользователь не авторизован!");
    }

    private void OpenHomePage()
    {
        _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    }
}