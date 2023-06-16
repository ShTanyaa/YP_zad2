using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prakt2
{
    class PhoneBook
    {
        private Dictionary<string, string> contacts;
        private ListBox listBox;

        public PhoneBook (ListBox listBox)
        {
            contacts = new Dictionary<string, string>();
            this.listBox = listBox;
        }

        public void AddContact (string name, string phoneNumber)
        {
            if (contacts.ContainsKey(phoneNumber))
            {
                MessageBox.Show("контакт уже существует");
            } else
            {
                contacts[phoneNumber] = name;
            }
        }

        public void RemoveContact (string name)
        {
            if (contacts.ContainsKey(name))
            {
                contacts.Remove(name);
                MessageBox.Show("контакт удален: " + name);
            } else
            {
                MessageBox.Show("контакт не найден.");
            }
        }

        public void SearchContact (string name)
        {
            listBox.Items.Clear();
            bool contactFound = false;
            foreach (var contact in contacts)
            {
                string fullName = contact.Value;
                string phoneNumber = contact.Key;
                if (fullName.ToLower().Contains(name.ToLower()))
                {
                    MessageBox.Show("Имя: " + fullName + ", Телефон: " + phoneNumber);
                    contactFound = true;
                }
            }

            if (!contactFound)
            {
                MessageBox.Show("контакт не найден");
            }
        }

        public void GetAllContacts ()
        {
            if (contacts.Count > 0)
            {
                foreach (var contact in contacts)
                {
                    listBox.Items.Add(contact.Value + " " + contact.Key);
                }
            }
        }

        public Dictionary<string, string> GetContacts ()
        {
            return contacts;
        }

    }
}
