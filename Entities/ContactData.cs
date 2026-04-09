using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoTests.Entities
{
    public class ContactData(string firstName, string lastName, string birthdate, string email)
    {
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string Birthdate { get; set; } = birthdate;
        public string Email { get; set; } = email;
    }
}
