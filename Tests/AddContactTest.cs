using AuthoTests.Entities;

namespace AuthoTests.Tests
{
    [TestFixture]
    public class AddContactTest : TestBase
    {
        [Test]
        public void AddContactTest_ValidContactData_ShouldAddContactSuccessfully()
        {
            var validAccount = new AccountData(
                "timurkrivoscheev2005@gmail.com",
                "12345678"
            );

            var newContact = new ContactData(
                "Timur",
                "Krivosheev",
                "2005-06-25",
                "timur.krivosheev@example.com"
            );

            app.Navigation.OpenHomePage();
            app.Auth.Login(validAccount);
            app.Contact.AddContact(newContact);

            bool contactAdded = app.Driver.PageSource.Contains("Timur") &&
                               app.Driver.PageSource.Contains("Krivosheev");

            Assert.IsTrue(contactAdded, "Контакт не был добавлен!");
        }
    }
}
