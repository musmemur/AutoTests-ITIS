using AuthoTests.Entities;

namespace AuthoTests.Tests
{
    [TestFixture]
    public class AddContactTest : TestBase
    {
        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return TestDataHelper.LoadContactDataFromXmlFile("contacts.xml");
        }

        [Test, TestCaseSource(nameof(ContactDataFromXmlFile))]
        public void AddContactTest_ValidContactData_ShouldAddContactSuccessfully(ContactData newContact)
        {
            var validAccount = new AccountData(
                "timurkrivoscheev2005@gmail.com",
                "12345678"
            );

            app.Navigation.OpenHomePage();
            app.Auth.Login(validAccount);
            app.Contact.AddContact(newContact);

            bool contactAdded = app.Driver.PageSource.Contains(newContact.FirstName) &&
                               app.Driver.PageSource.Contains(newContact.LastName);

            Assert.IsTrue(contactAdded, $"Контакт {newContact.FirstName} {newContact.LastName} не был добавлен!");
        }

        [Test, TestCaseSource(nameof(ContactDataFromXmlFile))]
        public void AddMultipleContactsTest(ContactData newContact)
        {
            var validAccount = new AccountData(
                "timurkrivoscheev2005@gmail.com",
                "12345678"
            );

            app.Navigation.OpenHomePage();
            app.Auth.Login(validAccount);
            app.Contact.AddContact(newContact);

            Assert.IsTrue(app.Contact.IsContactExists(newContact.FirstName, newContact.LastName),
                $"Контакт {newContact.FirstName} {newContact.LastName} не существует!");
        }
    }
}
