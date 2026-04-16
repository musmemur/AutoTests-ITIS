using AuthoTests.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Text;

namespace AuthoTests
{
    public class AppManager
    {
        private readonly StringBuilder verificationErrors;
        private readonly string baseURL;
        private readonly WebDriverWait wait;

        private readonly NavigationHelper navigation;
        private readonly LoginHelper auth;
        private readonly ContactHelper contact;

        public AppManager()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            baseURL = "https://thinking-tester-contact-list.herokuapp.com/";
            verificationErrors = new StringBuilder();

            navigation = new NavigationHelper(this, baseURL);
            auth = new LoginHelper(this);
            contact = new ContactHelper(this);
        }

        public IWebDriver Driver { get; }

        public WebDriverWait Wait
        {
            get { return wait; }
        }

        public StringBuilder VerificationErrors
        {
            get { return verificationErrors; }
        }

        public NavigationHelper Navigation
        {
            get { return navigation; }
        }

        public LoginHelper Auth
        {
            get { return auth; }
        }

        public ContactHelper Contact
        {
            get { return contact; }
        }

        public void Stop()
        {
            Driver.Quit();
        }
    }
}
