using AuthoTests.Entities;
using OpenQA.Selenium;

namespace AuthoTests.Helpers
{
    public class LoginHelper(AppManager manager) : HelperBase(manager)
    {
        public bool IsLoggedIn()
        {
            try
            {
                wait.Until(driver => driver.FindElement(By.Id("logout")).Displayed);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsLoggedIn(string username)
        {
            try
            {
                if (!IsLoggedIn())
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account.Email))
                {
                    return;
                }
                Logout();
            }

            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(account.Email);
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys(account.Password);
            driver.FindElement(By.Id("submit")).Click();

            wait.Until(driver => driver.Url.Contains("contactList"));

            Assert.IsTrue(driver.Url.Contains("contactList"), "Пользователь не авторизован!");
        }

        public void Logout()
        {
            try
            {
                if (!IsLoggedIn())
                    return;

                wait.Until(driver => driver.FindElement(By.Id("logout")).Displayed &&
                                     driver.FindElement(By.Id("logout")).Enabled);

                var logoutButton = driver.FindElement(By.Id("logout"));
                logoutButton.Click();

                wait.Until(driver => !driver.Url.Contains("contactList"));

                Assert.IsTrue(driver.FindElement(By.Id("email")).Displayed,
                             "Выход из аккаунта не выполнен!");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при выходе из аккаунта: {ex.Message}");
            }
        }
    }
}
