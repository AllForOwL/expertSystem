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

namespace expert_system
{
    public partial class FormSignIn : Form
    {
        public FormSignIn()
        {
            InitializeComponent();
        }

        public String login;
        public String password;

        private void button2_Click(object sender, EventArgs e)
        {
            FormRegistration formRegistration = new FormRegistration();
            formRegistration.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login = textBox1.Text;
            password = textBox2.Text;

            if (login == "admin" && password == "admin")
            {
                FormAdmin formAdmin = new FormAdmin();
                 formAdmin.Show();
            }
            else if (login == "admin")
            {
                MessageBox.Show("Не верный пароль");
                return;
            }
            else
            {
                string PathAllUsers = Path.GetFullPath(@"InfoUsers\AllUsers.txt");

                StreamReader readAllUsers = new StreamReader(PathAllUsers, false);

                string tempLogin, tempPassword;
                string tempLoginPass;

                while (!readAllUsers.EndOfStream)
                {
                    tempLoginPass = readAllUsers.ReadLine();
                    tempLogin = readAllUsers.ReadLine();
                    tempPassword = readAllUsers.ReadLine();

                    if (login == tempLogin && password == tempPassword)
                    {
                        FormUser formUser = new FormUser(login);
                        formUser.Show();
                        return;
                    }
                }

                MessageBox.Show("Не зарегистрированный пользователь");
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 47 && e.KeyChar <= 58)
                e.Handled = true;         
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 47 && e.KeyChar <= 58)
                e.Handled = true;   
        }
    }
}
