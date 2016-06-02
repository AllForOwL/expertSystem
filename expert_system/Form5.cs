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
    public partial class FormUser : Form
    {
        string CNT_PRESCHOOL_PARENT = "preschool_parent";
        string CNT_PARENT           = "parent";
        string CNT_PRESCHOOL        = "preschool";
        string CNT_THREE_CLASS      = "three_class";
        string CNT_FIVE_CLASS       = "five_class";

        enum typeTest 
        { 
            preschool_parent = 0, 
            three_class,
            five_class,
            preschool,
            parent      
        };

        public string m_strFIOChild;
        public string m_strYears;
        public string m_strLoginUser;

        public FormUser()
        {
            InitializeComponent();
        }

        public FormUser(string loginUser)
        {
            InitializeComponent();
         
            m_strLoginUser = loginUser;
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            StreamReader readResult = new StreamReader(Path.GetFullPath(@"InfoUsers\" + m_strLoginUser + ".txt"));

            m_strFIOChild = readResult.ReadLine();
            m_strYears    = readResult.ReadLine();

            label1.Text = m_strFIOChild;
            label2.Text = m_strYears;

            readResult.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbChooiseTest.Text == "Выбор теста")
            {
                MessageBox.Show("Введите тип теста");

                return;
            }

            switch (cmbChooiseTest.SelectedIndex)
            {
                case (int)typeTest.preschool_parent:
                    {
                        FormTest formTest = new FormTest(CNT_PRESCHOOL_PARENT, m_strLoginUser);
                        formTest.Show();

                    break;
                    }
                case (int)typeTest.three_class:
                    {
                        FormTest formTest = new FormTest(CNT_THREE_CLASS, m_strLoginUser);
                        formTest.Show();

                    break;
                    }
                case (int)typeTest.five_class:
                    {
                        FormTest formTest = new FormTest(CNT_FIVE_CLASS, m_strLoginUser);
                        formTest.Show();

                    break;
                    }
                case (int)typeTest.preschool:
                    {
                        FormTest formTest = new FormTest(CNT_PRESCHOOL, m_strLoginUser);
                        formTest.Show();

                    break;
                    }
                case (int)typeTest.parent:
                    {
                        FormTest formTest = new FormTest(CNT_PARENT, m_strLoginUser);
                        formTest.Show();

                    break;
                    }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbResult.Text == "Результаты")
            {
                MessageBox.Show("Введите по чём показывать результат");

                return;
            }

            string f_strTypeLogic = cmbResult.Text;

            OutputResultsUser outputResult = new OutputResultsUser(m_strLoginUser, f_strTypeLogic);
            outputResult.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cmbResult.Text == "Результаты")
            {
                MessageBox.Show("Введите по чём показывать результат");

                return;
            }

            string result = cmbResult.Text;
            string typeTest = cmbChooiseTest.Text;

            OutputResultsUser outputResult = new OutputResultsUser(m_strLoginUser, result, true);
            outputResult.Show();
        }

        private void cmbResult_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string result = cmbResult.Text;

            OutputResultsUser outputResult = new OutputResultsUser(m_strLoginUser, true);
            outputResult.Show();
        }
    }
}
