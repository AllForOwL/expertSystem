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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strresult_ = comboBox1.Text;
            if (strresult_ == "")
            {
                MessageBox.Show("Выберите тип вывода результата");
                return;
            }
            string user;

            StreamReader readuser = new StreamReader(Path.GetFullPath(@"InfoUsers\AllUsers.txt"));

            user = readuser.ReadLine();
            
            readuser.Close();

            OutputResultsUser outputResult = new OutputResultsUser("root", strresult_);
            outputResult.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strresult_ = comboBox1.Text;
            if (strresult_ == "")
            {
                MessageBox.Show("Выберите тип вывода результата");
                return;
            }
            string user;

            StreamReader readuser = new StreamReader(Path.GetFullPath(@"InfoUsers\AllUsers.txt"));

            user = readuser.ReadLine();

            readuser.Close();

            OutputResultsUser outputResult = new OutputResultsUser(true, strresult_);
            outputResult.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormChangeQuestion changeQuestion = new FormChangeQuestion();
            changeQuestion.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormLoginPassword infoUsers = new FormLoginPassword();
            infoUsers.Show();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
