using AuthoTests.Entities;
using AuthoTests;
using System.Xml.Serialization;

namespace AuthoTests.DataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: DataGenerator.exe <data_type> <count> <filename> [format]");
                Console.WriteLine("data_type: contacts, accounts");
                Console.WriteLine("format: xml (default)");
                Console.WriteLine("");
                Console.WriteLine("Examples:");
                Console.WriteLine("  DataGenerator.exe contacts 5 contacts.xml xml");
                Console.WriteLine("  DataGenerator.exe accounts 2 accounts.xml");
                return;
            }

            string dataType = args[0].ToLower();
            int count = int.Parse(args[1]);
            string filename = args[2];
            string format = args.Length > 3 ? args[3].ToLower() : "xml";

            if (format != "xml")
            {
                Console.WriteLine($"Format '{format}' is not supported. Only XML is supported.");
                return;
            }

            GenerateTestData(dataType, count, filename);
        }

        static void GenerateTestData(string dataType, int count, string filename)
        {
            Console.WriteLine($"Generating {count} {dataType}...");

            if (dataType == "contacts")
            {
                var contacts = GenerateContactData(count);
                SaveToXml(contacts, filename);
                Console.WriteLine($"Generated {contacts.Count} contacts and saved to {filename}");
            }
            else if (dataType == "accounts")
            {
                var accounts = GenerateAccountData(count);
                SaveToXml(accounts, filename);
                Console.WriteLine($"Generated {accounts.Count} accounts and saved to {filename}");
            }
            else
            {
                Console.WriteLine($"Unknown data type: {dataType}. Supported types: contacts, accounts");
            }
        }

        static List<ContactData> GenerateContactData(int count)
        {
            var random = new Random();
            var contacts = new List<ContactData>();

            string[] firstNames = { "John", "Jane", "Mike", "Sarah", "David", "Anna", "Alex", "Maria", "Peter", "Elena" };
            string[] lastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez" };
            string[] domains = { "example.com", "test.com", "mail.com", "email.com", "web.com" };

            for (int i = 0; i < count; i++)
            {
                string firstName = firstNames[random.Next(firstNames.Length)];
                string lastName = lastNames[random.Next(lastNames.Length)];
                string birthdate = $"{random.Next(1950, 2010)}-{random.Next(1, 13):D2}-{random.Next(1, 29):D2}";
                string email = $"{firstName.ToLower()}.{lastName.ToLower()}{random.Next(1, 100)}@{domains[random.Next(domains.Length)]}";

                firstName = EscapeXmlString(firstName);
                lastName = EscapeXmlString(lastName);
                email = EscapeXmlString(email);

                var contact = new ContactData(firstName, lastName, birthdate, email);
                contacts.Add(contact);
            }

            return contacts;
        }

        static List<AccountData> GenerateAccountData(int count)
        {
            var random = new Random();
            var accounts = new List<AccountData>();

            string[] firstNames = { "user", "test", "admin", "demo", "john", "jane", "mike", "sarah" };
            string[] domains = { "example.com", "test.com", "mail.com" };

            for (int i = 0; i < count; i++)
            {
                string username = $"{firstNames[random.Next(firstNames.Length)]}{random.Next(1, 1000)}@{domains[random.Next(domains.Length)]}";
                string password = GenerateRandomPassword(random);

                AccountData account = new AccountData(username, password);
                accounts.Add(account);
            }

            return accounts;
        }

        static string GenerateRandomPassword(Random random)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%";
            return new string(Enumerable.Repeat(chars, 12)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static void SaveToXml<T>(List<T> data, string filename)
        {
            var serializer = new XmlSerializer(typeof(List<T>));
            using var writer = new StreamWriter(filename);
            serializer.Serialize(writer, data);
        }

        static string EscapeXmlString(string value)
        {
            if (string.IsNullOrEmpty(value)) return value;

            return value.Replace("&", "&amp;")
                       .Replace("<", "&lt;")
                       .Replace(">", "&gt;")
                       .Replace("\"", "&quot;")
                       .Replace("'", "&apos;");
        }
    }
}