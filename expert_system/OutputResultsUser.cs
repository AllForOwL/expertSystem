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
        public string m_strTypeTest;
        public bool   m_blAnswer; 

        public OutputResultsUser()
        {
            InitializeComponent();

            m_strLogin = "root";
        }

        public OutputResultsUser(string login, string typeTest)
        {
            InitializeComponent();

            m_strLogin = login;
            m_strTypeTest = typeTest;
            m_blAnswer = false;
        }

        public OutputResultsUser(string login, string typeTest, bool answer)
        {
            InitializeComponent();

            m_strLogin = login;
            m_strTypeTest = typeTest;
            m_blAnswer = true;
        }

        private void OutputResultsUser_Load(object sender, EventArgs e)
        {
           /* string pathFile = @"InfoUsers\result_" + m_strLogin + ".txt";

            StreamReader readFile = new StreamReader(pathFile);

            int rowsInTable = 0;
            int colsInTable = 0;

            dataGridView1.RowCount += 2;



            while (!readFile.EndOfStream)
            {
                dataGridView1.Rows[rowsInTable].Cells[colsInTable].Value = readFile.ReadLine();
                
                ++colsInTable;

                if (colsInTable == 6)
                {
                    dataGridView1.Rows[rowsInTable].Cells[colsInTable].Value = m_strTypeTest;

                    colsInTable = 0;
                    ++rowsInTable;
                    dataGridView1.RowCount += 1;
                }
            }*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m_strLogin == "root")
            {
                FormTableFromResult formResult = new FormTableFromResult();
                formResult.Show();
            }
            else
            {
                FormTableFromResult formResult = new FormTableFromResult(m_strLogin, 0, m_strTypeTest, m_blAnswer);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (m_strLogin == "root")
            {
                FormTableFromResult formResult = new FormTableFromResult();
                formResult.Show();
            }
            else
            {
                FormTableFromResult formResult = new FormTableFromResult(m_strLogin, 1, m_strTypeTest, m_blAnswer);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (m_strLogin == "root")
            {
                FormTableFromResult formResult = new FormTableFromResult();
                formResult.Show();
            }
            else
            {
                FormTableFromResult formResult = new FormTableFromResult(m_strLogin, 2, m_strTypeTest, m_blAnswer);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (m_strLogin == "root")
            {
                FormTableFromResult formResult = new FormTableFromResult();
                formResult.Show();
            }
            else
            {
                FormTableFromResult formResult = new FormTableFromResult(m_strLogin, 3, m_strTypeTest, m_blAnswer);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (m_strLogin == "root")
            {
                FormTableFromResult formResult = new FormTableFromResult();
                formResult.Show();
            }
            else
            {
                FormTableFromResult formResult = new FormTableFromResult(m_strLogin, 4, m_strTypeTest, m_blAnswer);
            }
        }
    }
}
