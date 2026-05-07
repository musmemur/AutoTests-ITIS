using AuthoTests.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
            Console.WriteLine(editedContact);
            wait.Until(driver => driver.FindElements(By.CssSelector(".contactTableBodyRow")).Count > 0);
            driver.FindElement(By.CssSelector(".contactTableBodyRow:last-child > td:nth-child(2)")).Click();

            wait.Until(driver => driver.FindElement(By.Id("edit-contact")).Displayed);
            driver.FindElement(By.Id("edit-contact")).Click();

            wait.Until(driver => driver.FindElement(By.Id("firstName")).Displayed);

            var firstNameField = driver.FindElement(By.Id("firstName"));
            firstNameField.Clear();
            firstNameField.SendKeys(editedContact.FirstName);

            var lastNameField = driver.FindElement(By.Id("lastName"));
            lastNameField.Clear();
            lastNameField.SendKeys(editedContact.LastName);

            var birthdateField = driver.FindElement(By.Id("birthdate"));
            birthdateField.Clear();
            birthdateField.SendKeys(editedContact.Birthdate);

            var emailField = driver.FindElement(By.Id("email"));
            emailField.Clear();
            emailField.SendKeys(editedContact.Email);

            driver.FindElement(By.Id("submit")).Click();

            wait.Until(driver => driver.FindElement(By.Id("return")).Displayed);
            driver.FindElement(By.Id("return")).Click();

            wait.Until(driver => driver.FindElements(By.CssSelector(".contactTableBodyRow")).Count > 0);
        }

        public void EditContactOptimized(ContactData editedContact)
        {
            wait.Until(driver => driver.FindElements(By.CssSelector(".contactTableBodyRow")).Count > 0);
            driver.FindElement(By.CssSelector(".contactTableBodyRow:last-child > td:nth-child(2)")).Click();

            wait.Until(driver => driver.FindElement(By.Id("edit-contact")).Displayed);
            driver.FindElement(By.Id("edit-contact")).Click();

            wait.Until(driver => driver.FindElement(By.Id("firstName")).Displayed);

            ExecuteJavaScript("arguments[0].value = arguments[1];", driver.FindElement(By.Id("firstName")), editedContact.FirstName);
            ExecuteJavaScript("arguments[0].value = arguments[1];", driver.FindElement(By.Id("lastName")), editedContact.LastName);
            ExecuteJavaScript("arguments[0].value = arguments[1];", driver.FindElement(By.Id("birthdate")), editedContact.Birthdate);
            ExecuteJavaScript("arguments[0].value = arguments[1];", driver.FindElement(By.Id("email")), editedContact.Email);

            driver.FindElement(By.Id("submit")).Click();

            wait.Until(driver => driver.FindElement(By.Id("return")).Displayed);
            driver.FindElement(By.Id("return")).Click();

            wait.Until(driver => driver.FindElements(By.CssSelector(".contactTableBodyRow")).Count > 0);
        }

        private void ExecuteJavaScript(string script, IWebElement element, string value)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(script, element, value);
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

        public ContactData GetLastContact()
        {
            wait.Until(driver => driver.FindElements(By.CssSelector(".contactTableBodyRow")).Count > 0);

            var lastRow = driver.FindElements(By.CssSelector(".contactTableBodyRow")).Last();
            var firstName = lastRow.FindElement(By.CssSelector("td:nth-child(1)")).Text;
            var lastName = lastRow.FindElement(By.CssSelector("td:nth-child(2)")).Text;
            var email = lastRow.FindElement(By.CssSelector("td:nth-child(4)")).Text;

            return new ContactData(firstName, lastName, "", email);
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
            wait.Until(driver => driver.FindElements(By.CssSelector(".contactTableBodyRow")).Count > 0);

            var rows = driver.FindElements(By.CssSelector(".contactTableBodyRow"));

            foreach (var row in rows)
            {
                try
                {
                    var firstNameCell = row.FindElement(By.CssSelector("td:nth-child(1)"));
                    var lastNameCell = row.FindElement(By.CssSelector("td:nth-child(2)"));

                    if (firstNameCell.Text == firstName && lastNameCell.Text == lastName)
                    {
                        return true;
                    }
                }
                catch
                {
                    continue;
                }
            }

            return false;
        }

        public bool IsContactExistsWithWait(string firstName, string lastName, int timeoutSeconds = 5)
        {
            try
            {
                WebDriverWait customWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));

                return customWait.Until(driver =>
                {
                    var rows = driver.FindElements(By.CssSelector(".contactTableBodyRow"));
                    return rows.Any(row =>
                    {
                        try
                        {
                            return row.FindElement(By.CssSelector("td:nth-child(1)")).Text == firstName &&
                                   row.FindElement(By.CssSelector("td:nth-child(2)")).Text == lastName;
                        }
                        catch
                        {
                            return false;
                        }
                    });
                });
            }
            catch
            {
                return false;
            }
        }
    }
}
