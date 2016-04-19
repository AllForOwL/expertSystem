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
    public partial class FormTableFromResult : Form
    {
        int m_iNumberYears;
        int m_iTypeTest;
        string m_strLogin;
        string m_strTest;
        bool m_blAnswer;

        public FormTableFromResult(string strTypeTest)
        {
            InitializeComponent();

            m_strTest = strTypeTest;

            ++dataGridView1.ColumnCount;
            dataGridView1.RowHeadersWidth = 50;

            int columnCount = dataGridView1.ColumnCount;

            string pathFileAll = Path.GetFullPath(@"InfoUsers\Allresult_" + strTypeTest + ".txt");

            if (!File.Exists(pathFileAll))
            {
                MessageBox.Show("Тест ещё никто не проходил");
                return;
            }

            StreamReader readResultOnOrientationAll = new StreamReader(pathFileAll);

            int rows = 0;

            dataGridView1.Columns[6].HeaderCell.Value = "Логин";

            while (!readResultOnOrientationAll.EndOfStream)
            {
                ++dataGridView1.RowCount;
                dataGridView1.Rows[rows].Cells[6].Value = readResultOnOrientationAll.ReadLine();

                for (int i = 0; i < 6; i++)
                {
                    ++dataGridView1.RowCount;
                    dataGridView1.Rows[rows].Cells[i].Value = readResultOnOrientationAll.ReadLine();
                }
                ++rows;
                dataGridView1.Rows[rows-1].HeaderCell.Value = rows.ToString();
            }
            
            readResultOnOrientationAll.Close();   
        }

        public FormTableFromResult(string loginUser, int typeTest, string strTypeTest, bool answer)
        {
            InitializeComponent();

            m_strLogin = loginUser;
            m_iTypeTest = typeTest;
            m_strTest = strTypeTest;
            m_blAnswer = answer;

            string nameOrientation = "";

            switch (m_iTypeTest)
            {
                case 0:
                    {
                        nameOrientation = "preschool_parent";
                        break;
                    }
                case 1:
                    {
                        nameOrientation = "three_class";
                        break;
                    }
                case 2:
                    {
                        nameOrientation = "five_class";
                        break;
                    }
                case 3:
                    {
                        nameOrientation = "preschool";
                        break;
                    }
                case 4:
                    {
                        nameOrientation = "parent";
                        break;
                    }
            }

            if (m_blAnswer)
            {
                string pathFileAnswer = Path.GetFullPath(@"InfoUsers\answer_" + nameOrientation + m_strLogin + ".txt");

                if (!File.Exists(pathFileAnswer))
                {
                    MessageBox.Show("Нету результатов в данном тесте");
                    return;
                }
                
                StreamReader readResultOnOrientationAnswer = new StreamReader(pathFileAnswer);

                dataGridView1.ColumnCount = 1;
                dataGridView1.Columns[0].HeaderCell.Value = "";
                dataGridView1.RowHeadersWidth = 50;

                int rowsInTable = 1;
                int rowsAll = 0;

                while (!readResultOnOrientationAnswer.EndOfStream)
                {
                    ++dataGridView1.RowCount;
                    dataGridView1.Rows[rowsAll].HeaderCell.Value = rowsInTable.ToString();
                    dataGridView1.Rows[rowsAll].Cells[0].Value = readResultOnOrientationAnswer.ReadLine();

                    ++rowsInTable;
                    ++rowsAll;

                    if (rowsInTable == 37)
                    {
                        rowsInTable = 0;
                        ++dataGridView1.RowCount;
                    }
                }


                readResultOnOrientationAnswer.Close();
                this.Show();
                return;
            }

            string pathFile = "";
            if (m_strTest == "нечеткая модель" || m_strTest == "Matlab")
            {
                pathFile = Path.GetFullPath(@"InfoUsers\" + m_strLogin + nameOrientation+ "result_from_logic.txt");

                if (!File.Exists(pathFile))
                {
                    MessageBox.Show("Тест не был пройден");
                    return;
                }

                StreamReader readFileForFuzzy = new StreamReader(pathFile);
               
                double valueFromFile;
                int rowsInTable = 0;
                double valueForTable = 0.0;
                double valueForTable_2 = 0.0;

                while (!readFileForFuzzy.EndOfStream)
                {
                    ++dataGridView1.RowCount;
                    for (int i = 0; i < 6; i++)
                    {
                        valueForTable_2 = 0.0;
                        valueFromFile = Convert.ToDouble(readFileForFuzzy.ReadLine());
                        //MessageBox.Show(valueForTable.ToString());

                        if (valueFromFile >= 0.0 && valueFromFile < 1.0)
                        {
                            valueForTable_2 = 0.0;
                            dataGridView1.Rows[rowsInTable].Cells[i].Value = valueForTable_2.ToString();
                        }
                        else if (valueFromFile >= 1.0 && valueFromFile < 2.0)
                        {
                            valueForTable_2 = 0.2;
                            dataGridView1.Rows[rowsInTable].Cells[i].Value = valueForTable_2.ToString();
                        }
                        else if (valueFromFile >= 2.0 && valueFromFile < 3.0)
                        {
                            valueForTable_2 = 0.4;
                            dataGridView1.Rows[rowsInTable].Cells[i].Value = valueForTable_2.ToString();
                        }
                        else if (valueFromFile >= 3.0 && valueFromFile < 4.0)
                        {
                            valueForTable_2 = 0.6;
                            dataGridView1.Rows[rowsInTable].Cells[i].Value = valueForTable_2.ToString();
                        }
                        else if (valueFromFile >= 4.0 && valueFromFile < 5.0)
                        {
                            valueForTable_2 = 0.8;
                            dataGridView1.Rows[rowsInTable].Cells[i].Value = valueForTable_2.ToString();
                        }
                        else if (valueFromFile >= 5.0)
                        {
                            valueForTable_2 = 1.0;
                            dataGridView1.Rows[rowsInTable].Cells[i].Value = valueForTable_2.ToString();
                        }
                    }
                    valueForTable = 0;
                    ++rowsInTable;
                }

                readFileForFuzzy.Close();
            }
            else
            {
                String pathFile3 = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "result_" + nameOrientation + ".txt");

                if (!File.Exists(pathFile3))
                {
                    MessageBox.Show("Тест не был пройден");
                    return;
                }

                StreamReader readFile = new StreamReader(pathFile3);

               // int valueFromFile;
                int rowsInTable = 0;
               // double valueForTable = 0.0;
                string tempOrientation;

                while (!readFile.EndOfStream)
                {
                    ++dataGridView1.RowCount;
                    tempOrientation = readFile.ReadLine();
                    for (int i = 0; i < 6; i++)
                    {
                        dataGridView1.Rows[rowsInTable].Cells[i].Value = readFile.ReadLine();             
                    }
                    ++rowsInTable;
                }

                readFile.Close();
            }
            this.Show();
        }

        public FormTableFromResult(string loginUser, int numberYears)
        {
            InitializeComponent();

            m_iNumberYears = numberYears;
            m_strLogin = loginUser;
            string nameOrientation = "";

            switch (m_iNumberYears)
            {
                case 0:
                    {
                        nameOrientation = "preschool_parent";
                        break;
                    }
                case 1:
                    {
                        nameOrientation = "three_class";
                        break;
                    }
                case 2:
                    {
                        nameOrientation = "five_class";
                        break;
                    }
                case 3:
                    {
                        nameOrientation = "preschool";
                        break;
                    }
                case 4:
                    {
                        nameOrientation = "parent";
                        break;
                    }
            }

            string pathFile = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "result_" + nameOrientation + ".txt");

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
                    colsInTable = 0;
                    ++rowsInTable;
                    dataGridView1.RowCount += 1;
                }
            }

        }

        private void FormTableFromResult_Load(object sender, EventArgs e)
        {

        }
    }
}
