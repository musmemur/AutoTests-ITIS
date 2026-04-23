using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AuthoTests.Entities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace AuthoTests.Tests;

[TestFixture]
public class EditContactTest : TestBase {

  [Test]
  public void EditContact() {
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

    var editedContact = new ContactData(
        "Ivan",
        "Ivanov",
        "2015-06-25",
        "ivan.ivanov@example.com"
    );

    app.Navigation.OpenHomePage();
    app.Auth.Login(validAccount);
    app.Contact.AddContact(newContact);
    app.Contact.EditContact(editedContact);
    
  }
}
