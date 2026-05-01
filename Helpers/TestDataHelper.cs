using AuthoTests.Entities;
using System.Xml.Serialization;

namespace AuthoTests
{
    public static class TestDataHelper
    {
        /// <summary>
        /// Загружает данные контактов из XML файла
        /// </summary>
        public static IEnumerable<ContactData> LoadContactDataFromXmlFile(string filePath = "contacts.xml")
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<ContactData>));
                using var reader = new StreamReader(filePath);
                var contacts = (List<ContactData>)serializer.Deserialize(reader);
                return contacts;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Файл {filePath} не найден. Используйте генератор для создания тестовых данных.");
                return new List<ContactData>();
            }
        }

        /// <summary>
        /// Загружает данные аккаунтов из XML файла
        /// </summary>
        public static IEnumerable<AccountData> LoadAccountDataFromXmlFile(string filePath = "accounts.xml")
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<AccountData>));
                using var reader = new StreamReader(filePath);
                var accounts = (List<AccountData>)serializer.Deserialize(reader);
                return accounts;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Файл {filePath} не найден. Используйте генератор для создания тестовых данных.");
                return new List<AccountData>();
            }
        }
    }
}
