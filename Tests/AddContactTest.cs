using AuthoTests.Entities;

namespace AuthoTests.Tests
{
    [TestFixture]
    public class AddContactTest : AuthBase
    {
        [Test]
        public void AddContactTest_ValidContactData_ShouldAddContactSuccessfully()
        {
            var newContact = new ContactData(
                "Timur",
                "Krivosheev",
                "2005-06-25",
                "timur.krivosheev@example.com"
            );

            app.Contact.AddContact(newContact);

            bool contactAdded = app.Driver.PageSource.Contains("Timur") &&
                               app.Driver.PageSource.Contains("Krivosheev");

            Assert.IsTrue(contactAdded, "Контакт не был добавлен!");
        }
    }
}
