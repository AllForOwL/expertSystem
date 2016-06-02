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
    public partial class OutputResultsUser : Form
    {
        public string m_strLogin;
        public string m_strTypeLogic;
        public string m_strOrientation;
        public bool   m_blAnswer;
        public bool   m_blDiagram;

        public OutputResultsUser()
        {
            InitializeComponent();

            m_strLogin = "root";
        }

        public OutputResultsUser(string typeTest)
        {
            InitializeComponent();

            m_strLogin = "root";
            m_strTypeLogic = typeTest;
        }

        public OutputResultsUser(int diagram)
        {
            InitializeComponent();

            m_strLogin = "root";
            m_blDiagram = true;
        }

        public OutputResultsUser(bool diagram)
        {
            InitializeComponent();

            m_blDiagram = true;
            m_strLogin = "root";
        }

        public OutputResultsUser(bool diagram, string typeTest)
        {
            InitializeComponent();

            m_blDiagram = true;
            m_strLogin = "root";
            m_strTypeLogic = typeTest;
        }

        public OutputResultsUser(string login, bool answer)
        {
            InitializeComponent();

            m_strLogin = login;
            m_blAnswer = true;
            m_blDiagram = false;
        }

        public OutputResultsUser(string login, string typeLogic)
        {
            InitializeComponent();

            m_strLogin     = login;
            m_strTypeLogic = typeLogic;
            m_blAnswer     = false;
            m_blDiagram    = false;
        }

        public OutputResultsUser(string login, string result, bool diagram)
        {
            InitializeComponent();

            m_strLogin = login;
            m_strTypeLogic = result;
            m_blAnswer = false;
            m_blDiagram = true;
        }

        public OutputResultsUser(string login, string result, bool answer, bool diagram)
        {
            InitializeComponent();

            m_strLogin = login;
            m_strTypeLogic = result;
            m_blAnswer = true;
            m_blDiagram = false;
        }

        private void OutputResultsUser_Load(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m_blDiagram)    // строить диаграмму
            {
                int f_iOrientation = 0; ;

                if (comboBox1.Text == "дошкольник")
                {
                    m_strOrientation = "preschool";
                    f_iOrientation = 0;
                }
                else if (comboBox1.Text == "родитель")
                {
                    m_strOrientation = "parent";
                    f_iOrientation = 1;
                }
                else if (comboBox1.Text == "дошкольник+родитель")
                {
                    m_strOrientation = "preschool_parent";
                    f_iOrientation = 2;
                }

                FormOutputResultDiagramUsers answer = new FormOutputResultDiagramUsers(m_strTypeLogic, m_strLogin, f_iOrientation);
                answer.Show();
            }
            else if (m_blAnswer)    // показать ответы
            {
                int f_iOrientation = 0; ;

                if (comboBox1.Text == "дошкольник")
                {
                    m_strOrientation = "preschool";
                    f_iOrientation = 0;
                }
                else if (comboBox1.Text == "родитель")
                {
                    m_strOrientation = "parent";
                    f_iOrientation = 1;
                }
                else if (comboBox1.Text == "дошкольник+родитель")
                {
                    m_strOrientation = "preschool_parent";
                    f_iOrientation = 2;
                }

                FormOutputAnswer answer = new FormOutputAnswer(m_strLogin, f_iOrientation);
                answer.Show();
            }
            else    // отобразить результаты
            {
                const int CNT_PRESCHOOL        = 0;
                const int CNT_PARENT           = 1;
                const int CNT_PRESCHOOL_PARENT = 2;

                int f_iOrientation = 0;

                if (comboBox1.Text == "дошкольник")
                {
                    f_iOrientation = CNT_PRESCHOOL;
                }
                else if (comboBox1.Text == "родитель")
                {
                    f_iOrientation = CNT_PARENT;
                }
                else if (comboBox1.Text == "дошкольник+родитель")
                {
                    f_iOrientation = CNT_PRESCHOOL_PARENT;
                }

                FormTableFromResult formResult = new FormTableFromResult(m_strTypeLogic/*четкая - нечеткая*/, m_strLogin, f_iOrientation/*возраст(родитель или дошкольник)*/);
                formResult.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_strOrientation = "three_class";

            if (m_blDiagram)
            {
                FormOutputResultDiagramUsers answer = new FormOutputResultDiagramUsers(m_strLogin, m_strTypeLogic, m_strOrientation);
                answer.Show();
            }
            else if (m_blAnswer)
            {
                FormOutputAnswer answer = new FormOutputAnswer(m_strLogin, m_strOrientation);
                answer.Show();
            }
            else
            { 
                FormTableFromResult formResult = new FormTableFromResult(m_strTypeLogic/*четкая или нечеткая*/, m_strLogin, 5/*возраст*/);
                formResult.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            m_strOrientation = "five_class";

            if (m_blDiagram)
            {
                FormOutputResultDiagramUsers answer = new FormOutputResultDiagramUsers(m_strLogin, m_strTypeLogic,  m_strOrientation);
                answer.Show();
            }
            else if (m_blAnswer)
            {
                FormOutputAnswer answer = new FormOutputAnswer(m_strLogin, m_strOrientation);
                answer.Show();
            }
            else
            {
                FormTableFromResult formResult = new FormTableFromResult(m_strTypeLogic/*четкая или нечеткая*/, m_strLogin, 6/*возраст*/);
                formResult.Show();
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            m_strOrientation = "five_class";
           
            FormTableFromResult formResult = new FormTableFromResult(m_strTypeLogic/*четкая или нечеткая*/, m_strLogin, m_strOrientation/*возраст*/);
            formResult.Show();
         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormTableFromResult formResult = new FormTableFromResult(m_strTypeLogic/*четкая или нечеткая*/, m_strLogin, m_strOrientation/*возраст*/);
            formResult.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (m_blDiagram)    // строить диаграмму
            {
                const int CNT_ONLY_PRESCHOOL = 3;
                int f_iOrientation = CNT_ONLY_PRESCHOOL;

                FormOutputResultDiagramUsers answer = new FormOutputResultDiagramUsers(m_strTypeLogic, m_strLogin, f_iOrientation);
                answer.Show();
            }
            else if (m_blAnswer)    // показать ответы
            {
                const int CNT_ONLY_PRESCHOOL = 3;
                int f_iOrientation = CNT_ONLY_PRESCHOOL;

                FormOutputAnswer answer = new FormOutputAnswer(m_strLogin, f_iOrientation);
                answer.Show();
            }
            else    // отобразить результаты
            {
                const int CNT_ONLY_PRESCHOOL = 3;
                int f_iOrientation = CNT_ONLY_PRESCHOOL;

                FormTableFromResult formResult = new FormTableFromResult(m_strTypeLogic/*четкая - нечеткая*/, m_strLogin, f_iOrientation/*возраст(родитель или дошкольник)*/);
                formResult.Show();
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (m_blDiagram)    // строить диаграмму
            {
                const int CNT_ONLY_PARENT = 4;
                int f_iOrientation = CNT_ONLY_PARENT;

                FormOutputResultDiagramUsers answer = new FormOutputResultDiagramUsers(m_strTypeLogic, m_strLogin, f_iOrientation);
                answer.Show();
            }
            else if (m_blAnswer)    // показать ответы
            {
                const int CNT_ONLY_PARENT = 4;
                int f_iOrientation = CNT_ONLY_PARENT;

                FormOutputAnswer answer = new FormOutputAnswer(m_strLogin, f_iOrientation);
                answer.Show();
            }
            else    // отобразить результаты
            {
                const int CNT_ONLY_PARENT = 4;
                int f_iOrientation = CNT_ONLY_PARENT;

                FormTableFromResult formResult = new FormTableFromResult(m_strTypeLogic/*четкая - нечеткая*/, m_strLogin, f_iOrientation/*возраст(родитель или дошкольник)*/);
                formResult.Show();
            }
        }
    }
}