using AuthoTests;
using AuthoTests.Entities;

[TestFixture]
public class EditContactTest : AuthBase
{
    [Test]
    public void EditContact()
    {
        var newContact = new ContactData(
          "Timur",
          "Krivosheev",
          "2005-06-25",
          "timur.krivosheev@example.com"
        );

        var editedContact = new ContactData(
            "Ivan",
            "Ivanov",
            "2015-06-25",
            "ivan.ivanov@example.com"
        );

        app.Contact.AddContact(newContact);
        app.Contact.EditContact(editedContact);

        bool contactEdited = app.Driver.PageSource.Contains("Ivan") &&
                           app.Driver.PageSource.Contains("Ivanov");

        Assert.IsTrue(contactEdited, "Контакт не был отредактирован!");
    }
}