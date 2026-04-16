using AuthoTests.Entities;
using OpenQA.Selenium;

namespace AuthoTests.Helpers
{
    public class ContactHelper(AppManager manager) : HelperBase(manager)
    {
        public void AddContact(ContactData contact)
        {
            driver.FindElement(By.Id("add-contact")).Click();

            driver.FindElement(By.Id("firstName")).Clear();
            driver.FindElement(By.Id("firstName")).SendKeys(contact.FirstName);

            driver.FindElement(By.Id("lastName")).Clear();
            driver.FindElement(By.Id("lastName")).SendKeys(contact.LastName);

            driver.FindElement(By.Id("birthdate")).Clear();
            driver.FindElement(By.Id("birthdate")).SendKeys(contact.Birthdate);

            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(contact.Email);

            driver.FindElement(By.Id("submit")).Click();

            wait.Until(driver => driver.FindElement(By.CssSelector(".contactTableBodyRow")).Displayed);
        }
    }
}
