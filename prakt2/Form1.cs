using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace prakt2
{
    public partial class Form1 :Form
    {
        Contact ct = new Contact();
        PhoneBook ph;
        public Form1 ()
        {
            InitializeComponent();
        }
       
       
        private void button1_Click (object sender, EventArgs e)
        {
            ct.name = textBox1.Text;
            ct.phone = textBox2.Text;
            ph.AddContact(ct.name, ct.phone);
                listBox1.Items.Clear();
            ph.GetAllContacts();
                MessageBox.Show("контакт добавлен");
            
        }

        private void button2_Click (object sender, EventArgs e)
        {
            StreamWriter writer = File.AppendText("t.txt");
                foreach (var item in listBox1.Items)
                {
                    writer.WriteLine(item.ToString());
                }
            MessageBox.Show("сохранено в файл");
        }

        private void Form1_Load (object sender, EventArgs e)
        {
            ph = new PhoneBook(listBox1);
        }

        private void button3_Click (object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                ph.SearchContact(textBox4.Text);
                ph.GetAllContacts();
            } else
                MessageBox.Show("введите имя", "ошибка");
        }

        private void button4_Click (object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                listBox1.Items.Clear();
                ph.RemoveContact(textBox3.Text);
                listBox1.Items.Clear();
                ph.GetAllContacts();
            } else
                MessageBox.Show("введите номер телефона", "ошибка");
        }

        private void button5_Click (object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("t.txt");
            string linee;
            while(!sr.EndOfStream)
            {
                linee = sr.ReadLine();
                listBox1.Items.Add(linee);
            }
            sr.Close();
        }

        private void button6_Click (object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            listBox1.Visible = false;
            button2.Visible = false;
            button5.Visible = false;
            button7.Visible=true;
        }

        private void button7_Click (object sender, EventArgs e)
        {
            button7.Visible = false;
            tabControl1.Visible = true;
            listBox1.Visible = true;
            button2.Visible = true;
            button5.Visible = true;
        }

        private void listBox1_SelectedIndexChanged (object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex !=-1)
            {
                int i = listBox1.SelectedIndex;
                string[] zn = new string[3];
                zn = listBox1.Items[i].ToString().Split(' ');
                textBox6.Text = zn[0];
                textBox5.Text = zn[1];
                textBox7.Text = zn[2];
            }
        }
    }
}
