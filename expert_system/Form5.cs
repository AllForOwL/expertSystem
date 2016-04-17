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

            readResult.ReadLine();
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
                        FormTest formTest = new FormTest((int)typeTest.preschool_parent, m_strLoginUser);
                        formTest.Show();

                    break;
                    }
                case (int)typeTest.three_class:
                    {
                        FormTest formTest = new FormTest((int)typeTest.three_class, m_strLoginUser);
                        formTest.Show();

                    break;
                    }
                case (int)typeTest.five_class:
                    {
                        FormTest formTest = new FormTest((int)typeTest.five_class, m_strLoginUser);
                        formTest.Show();

                    break;
                    }
                case (int)typeTest.preschool:
                    {
                        FormTest formTest = new FormTest((int)typeTest.preschool, m_strLoginUser);
                        formTest.Show();

                    break;
                    }
                case (int)typeTest.parent:
                    {
                        FormTest formTest = new FormTest((int)typeTest.parent, m_strLoginUser);
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

            string result = cmbResult.Text;


            OutputResultsUser outputResult = new OutputResultsUser(m_strLoginUser, result);
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

            FormOutputResultDiagramUsers diagramResult = new FormOutputResultDiagramUsers(m_strLoginUser, result);
            diagramResult.Show();
        }

        private void cmbResult_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string result = cmbResult.Text;


            OutputResultsUser outputResult = new OutputResultsUser(m_strLoginUser, result, true);
            outputResult.Show();
        }
    }
}
