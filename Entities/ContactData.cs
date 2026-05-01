using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoTests.Entities
{
    public class ContactData
    {
        public ContactData()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Birthdate = string.Empty;
            Email = string.Empty;
        }

        public ContactData(string firstName, string lastName, string birthdate, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Email = email;
        }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Birthdate { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
