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
            OutputResultsUser result = new OutputResultsUser();
            result.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormNumberUserDirection result = new FormNumberUserDirection();
            result.Show();
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
    }
}
