using System;
using System.Collections.Generic;
using System.Text;

using AuthoTests.Entities;

namespace AuthoTests;

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

        OpenHomePage();
        Login(validAccount);
        AddContact(newContact);

        bool contactAdded = _wait.Until(driver =>
            driver.PageSource.Contains("Timur") &&
            driver.PageSource.Contains("Krivosheev")
        );

        Assert.IsTrue(contactAdded, "Контакт не был добавлен!");
    }
}
