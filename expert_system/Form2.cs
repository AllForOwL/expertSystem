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
    public partial class FormRegistration : Form
    {
        public FormRegistration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string PathAllUsers = Path.GetFullPath(@"InfoUsers\AllUsers.txt");
           
           StreamWriter writeNewUsers = new StreamWriter(PathAllUsers, true);

           string FIOUsers = textBox2.Text;
           string loginUsers = textBox4.Text;
           string passUsers  = textBox5.Text;
            
           writeNewUsers.WriteLine(FIOUsers + "\n" + loginUsers + "\n" + passUsers);
            
           writeNewUsers.Close();

           string nameFileNewUser = loginUsers;
           string PathNewUser = Path.GetFullPath(@"InfoUsers\" + nameFileNewUser + ".txt");

           string FIOChild  = textBox2.Text;
           string years     = textBox3.Text;

           StreamWriter writeInfoNewUser = new StreamWriter(PathNewUser, true);

           writeInfoNewUser.WriteLine(FIOChild + "\n" + years);
            
           writeInfoNewUser.Close();

           StreamWriter writeFIOSurname = new StreamWriter(Path.GetFullPath(@"InfoUsers\surname_FIO.txt"), true);
           
           writeFIOSurname.WriteLine(FIOChild);
           writeFIOSurname.WriteLine(loginUsers);

           writeFIOSurname.Close();

           MessageBox.Show("Вы успешно зарегистрированны!!!");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 47 && e.KeyChar <= 58)
                e.Handled = true;   
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
           if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8) 
               e.Handled = true;   
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormRegistration_Load(object sender, EventArgs e)
        {

        }
    }
}
