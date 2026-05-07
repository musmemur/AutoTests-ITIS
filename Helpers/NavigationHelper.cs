namespace AuthoTests.Helpers
{
    public class NavigationHelper(AppManager manager, string baseURL) : HelperBase(manager)
    {
        private readonly string baseURL = baseURL;

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

    }
}
