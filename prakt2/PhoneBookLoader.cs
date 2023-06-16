using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace prakt2
{
    class PhoneBookLoader
    {
        public static void Load (PhoneBook phoneBook, string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(' ');
                    if (parts.Length >= 3)
                    {
                        string fullName = parts[0] + " " + parts[1];
                        string phoneNumber = parts[2];
                        phoneBook.AddContact(fullName, phoneNumber);
                    } else if (parts.Length == 2)
                    {
                        string fullName = parts[0];
                        string phoneNumber = parts[1];
                        phoneBook.AddContact(fullName, phoneNumber);
                    }
                }
                MessageBox.Show("данные загружены из файла");
            }
            catch 
            {
                MessageBox.Show("ошибка при загрузке данных: " ,"ошибка");

            }
        }

        public static void Save (PhoneBook phoneBook, string fileName)
        {
            try
            {
                List<string> lines = new List<string>();
                Dictionary<string, string> contacts = phoneBook.GetContacts();
                foreach (var contact in contacts)
                {
                    string[] fullNameParts = contact.Key.Split(' ');
                    string familia = fullNameParts[0];
                    string name = fullNameParts[1];
                    string phoneNumber = contact.Value;
                    string line = $"{familia} {name} {phoneNumber}";
                    lines.Add(line);
                }
                File.WriteAllLines(fileName, lines);
                MessageBox.Show("данные сохранены в файл");
            } 
            catch
            {
                MessageBox.Show("ошибка при сохранении данных","ошибка");
            }
        }
    }
}
