using AuthoTests.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

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

        public void EditContact(ContactData editedContact)
        {
            driver.FindElement(By.CssSelector(".contactTableBodyRow:last-child > td:nth-child(2)")).Click();
            driver.FindElement(By.Id("edit-contact")).Click();
            driver.FindElement(By.Id("firstName")).Click();
            {
                var element = driver.FindElement(By.Id("firstName"));
                Actions builder = new Actions(driver);
                builder.DoubleClick(element).Perform();
            }
            driver.FindElement(By.Id("firstName")).Click();
            driver.FindElement(By.Id("firstName")).Clear();
            driver.FindElement(By.Id("firstName")).SendKeys(editedContact.FirstName);

            driver.FindElement(By.Id("lastName")).Click();
            {
                var element = driver.FindElement(By.Id("lastName"));
                Actions builder = new Actions(driver);
                builder.DoubleClick(element).Perform();
            }
            driver.FindElement(By.Id("lastName")).Click();
            driver.FindElement(By.Id("lastName")).Clear();
            driver.FindElement(By.Id("lastName")).SendKeys(editedContact.LastName);

            driver.FindElement(By.Id("birthdate")).Click();
            {
                var element = driver.FindElement(By.Id("birthdate"));
                Actions builder = new Actions(driver);
                builder.DoubleClick(element).Perform();
            }
            driver.FindElement(By.Id("birthdate")).Click();
            driver.FindElement(By.Id("birthdate")).Clear();
            driver.FindElement(By.Id("birthdate")).SendKeys(editedContact.Birthdate);


            driver.FindElement(By.Id("email")).Click();
            {
                var element = driver.FindElement(By.Id("email"));
                Actions builder = new Actions(driver);
                builder.DoubleClick(element).Perform();
            }
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(editedContact.Email);

            driver.FindElement(By.Id("submit")).Click();
            driver.FindElement(By.Id("return")).Click();
        }


        public void SelectLastCreatedContact()
        {
            wait.Until(driver => driver.FindElements(By.CssSelector(".contactTableBodyRow")).Count > 0);
            driver.FindElement(By.CssSelector(".contactTableBodyRow:last-child > td:nth-child(2)")).Click();
        }

        public ContactData GetCreatedContactData(string expectedEmail)
        {
            var rows = driver.FindElements(By.CssSelector(".contactTableBodyRow"));

            foreach (var row in rows)
            {
                var emailCell = row.FindElement(By.CssSelector("td:nth-child(4)"));
                if (emailCell.Text == expectedEmail)
                {
                    var firstName = row.FindElement(By.CssSelector("td:nth-child(1)")).Text;
                    var lastName = row.FindElement(By.CssSelector("td:nth-child(2)")).Text;
                    var email = emailCell.Text;

                    return new ContactData(firstName, lastName, "", email);
                }
            }

            return null;
        }

        public void DeleteContact()
        {
            driver.FindElement(By.CssSelector(".contactTableBodyRow:last-child > td:nth-child(2)")).Click();
            driver.FindElement(By.Id("delete-contact")).Click();

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

            wait.Until(driver => driver.FindElement(By.Id("add-contact")).Displayed);
        }

        public bool IsContactExists(string firstName, string lastName)
        {
            var pageSource = driver.PageSource;
            return pageSource.Contains(firstName) && pageSource.Contains(lastName);
        }
    }
}
