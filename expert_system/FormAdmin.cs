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
            if (comboBox1.Text == "Результаты")
            {
                MessageBox.Show("Введите по чём показывать результат");

                return;
            }

            string f_strTypeLogic = comboBox1.Text;

            OutputResultsUser outputResult = new OutputResultsUser("root", f_strTypeLogic);
            outputResult.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Результаты")
            {
                MessageBox.Show("Введите по чём показывать результат");

                return;
            }

            string typeLogic = comboBox1.Text;

            OutputResultsUser outputResult = new OutputResultsUser("root", typeLogic, true);
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
