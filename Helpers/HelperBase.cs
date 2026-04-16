using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoTests.Helpers
{
    public class HelperBase(AppManager manager)
    {
        protected AppManager manager = manager;
        protected IWebDriver driver = manager.Driver;
        protected WebDriverWait wait = manager.Wait;
        protected bool acceptNextAlert = true;
        protected StringBuilder verificationErrors = manager.VerificationErrors;
    }
}
