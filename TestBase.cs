using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using AuthoTests.Entities;

namespace AuthoTests
{
    public class TestBase
    {
        protected ChromeDriver _driver;
        protected WebDriverWait _wait;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
        }

        public void OpenHomePage()
        {
            _driver.Navigate().GoToUrl("https://thinking-tester-contact-list.herokuapp.com/");
        }

        public void Login(AccountData account)
        {
            _driver.FindElement(By.Id("email")).Clear();
            _driver.FindElement(By.Id("email")).SendKeys(account.Email);
            _driver.FindElement(By.Id("password")).Clear();
            _driver.FindElement(By.Id("password")).SendKeys(account.Password);
            _driver.FindElement(By.Id("submit")).Click();

            _wait.Until(driver => driver.Url.Contains("contactList"));

            Assert.IsTrue(_driver.Url.Contains("contactList"), "Пользователь не авторизован!");
        }

        public void AddContact(ContactData contact)
        {
            _driver.FindElement(By.Id("add-contact")).Click();

            _driver.FindElement(By.Id("firstName")).Clear();
            _driver.FindElement(By.Id("firstName")).SendKeys(contact.FirstName);

            _driver.FindElement(By.Id("lastName")).Clear();
            _driver.FindElement(By.Id("lastName")).SendKeys(contact.LastName);

            _driver.FindElement(By.Id("birthdate")).Clear();
            _driver.FindElement(By.Id("birthdate")).SendKeys(contact.Birthdate);

            _driver.FindElement(By.Id("email")).Clear();
            _driver.FindElement(By.Id("email")).SendKeys(contact.Email);

            _driver.FindElement(By.Id("submit")).Click();

            _wait.Until(driver => driver.FindElement(By.CssSelector(".contactTableBodyRow")).Displayed);
        }
    }
}
