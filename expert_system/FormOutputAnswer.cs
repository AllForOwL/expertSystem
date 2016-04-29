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
    public partial class FormOutputAnswer : Form
    {
        public string m_strLogin;
        public string m_strOrientation;
        public int    m_iOrientation;

        public FormOutputAnswer()
        {
            InitializeComponent();
        }

        public FormOutputAnswer(string login, string orientation)
        {
            InitializeComponent();

            m_strLogin       = login;
            m_strOrientation = orientation;

            string pathFile;

            if (m_iOrientation == 0)
            {
                pathFile = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "answer_" + m_strOrientation + ".txt");

                if (!File.Exists(pathFile))
                {
                    MessageBox.Show("Тест не был пройден");
                    return;
                }

                StreamReader readAnswer = new StreamReader(pathFile);

                gridOutputAnswer.RowHeadersWidth = 60;
                gridOutputAnswer.ColumnCount = 1;
                ++gridOutputAnswer.RowCount;

                int countRows = 0;
                int countAnswer = 1;
                int valueFromFile;

                while (!readAnswer.EndOfStream)
                {
                    valueFromFile = Convert.ToInt32(readAnswer.ReadLine());

                    if (valueFromFile == 1)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "да";
                    }
                    else if (valueFromFile == 2)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "скорее да";
                    }
                    else if (valueFromFile == 3)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "не знаю";
                    }
                    else if (valueFromFile == 4)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "скорее нет";
                    }
                    else if (valueFromFile == 5)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "нет";
                    }

                    gridOutputAnswer.Rows[countRows].HeaderCell.Value = countAnswer.ToString();
                    ++countRows;
                    ++gridOutputAnswer.RowCount;

                    if (countAnswer < 36)
                    {
                        ++countAnswer;
                    }
                    else
                    {
                        countAnswer = 1;
                    }
                }

                readAnswer.Close();
            }

        }

        public FormOutputAnswer(string login, int orientation)
        {
            InitializeComponent();

            m_strLogin = login;
            m_iOrientation = orientation;

            string pathFile;

            if (m_iOrientation == 0)
            {
                pathFile = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "answer_preschool_parent.txt");

                if (!File.Exists(pathFile))
                {
                    MessageBox.Show("Тест не был пройден");
                    return;
                }

                StreamReader readAnswer = new StreamReader(pathFile);

                gridOutputAnswer.RowHeadersWidth = 60;
                gridOutputAnswer.ColumnCount = 1;
                ++gridOutputAnswer.RowCount;

                int countRows = 0;
                int countAnswer = 1;
                int valueFromFile;

                while (!readAnswer.EndOfStream)
                {
                    valueFromFile = Convert.ToInt32(readAnswer.ReadLine());

                    if (valueFromFile == 1)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "да";
                    }
                    else if (valueFromFile == 2)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "скорее да";
                    }
                    else if (valueFromFile == 3)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "не знаю";
                    }
                    else if (valueFromFile == 4)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "скорее нет";
                    }
                    else if (valueFromFile == 5)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "нет";
                    }

                    gridOutputAnswer.Rows[countRows].HeaderCell.Value = countAnswer.ToString();
                    ++countRows;
                    ++gridOutputAnswer.RowCount;

                    if (countAnswer < 36)
                    {
                        ++countAnswer;
                    }
                    else
                    {
                        countAnswer = 0;
                    }
                }

                readAnswer.Close();
            }
            else if (m_iOrientation == 1)
            {
                pathFile = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "answer_preschool_parentparent.txt");

                if (!File.Exists(pathFile))
                {
                    MessageBox.Show("Тест не был пройден");
                    return;
                }

                StreamReader readAnswer = new StreamReader(pathFile);

                gridOutputAnswer.RowHeadersWidth = 60;
                gridOutputAnswer.ColumnCount = 1;
                ++gridOutputAnswer.RowCount;

                int countRows = 0;
                int countAnswer = 1;
                int valueFromFile;

                while (!readAnswer.EndOfStream)
                {
                    valueFromFile = Convert.ToInt32(readAnswer.ReadLine());

                    if (valueFromFile == 1)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "да";
                    }
                    else if (valueFromFile == 2)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "скорее да";
                    }
                    else if (valueFromFile == 3)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "не знаю";
                    }
                    else if (valueFromFile == 4)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "скорее нет";
                    }
                    else if (valueFromFile == 5)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "нет";
                    }

                    gridOutputAnswer.Rows[countRows].HeaderCell.Value = countAnswer.ToString();
                    ++countRows;
                    ++gridOutputAnswer.RowCount;

                    if (countAnswer < 18)
                    {
                        ++countAnswer;
                    }
                    else
                    {
                        countAnswer = 1;
                    }
                }

                readAnswer.Close();
            }
            else
            {
                gridOutputAnswer.ColumnCount = 2;
                gridOutputAnswer.RowHeadersWidth = 60;
                ++gridOutputAnswer.RowCount;

                int countAnswer = 1;
                int countRows = 0;

                pathFile = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "answer_preschool_parent.txt");

                if (!File.Exists(pathFile))
                {
                    MessageBox.Show("Тест не был пройден");
                    return;
                }

                StreamReader readAnswer = new StreamReader(pathFile);

                int valueFromFile;

                while (!readAnswer.EndOfStream)
                {
                    valueFromFile = Convert.ToInt32(readAnswer.ReadLine());

                    if (valueFromFile == 1)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "да";
                    }
                    else if (valueFromFile == 2)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "скорее да";
                    }
                    else if (valueFromFile == 3)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "не знаю";
                    }
                    else if (valueFromFile == 4)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "скорее нет";
                    }
                    else if (valueFromFile == 5)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[0].Value = "нет";
                    }

                    gridOutputAnswer.Rows[countRows].HeaderCell.Value = countAnswer.ToString();
                    ++countRows;
                    ++gridOutputAnswer.RowCount;

                    if (countAnswer < 36)
                    {
                        ++countAnswer;
                    }
                    else
                    {
                        countAnswer = 1;
                    }
                }

                readAnswer.Close();

                pathFile = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "answer_preschool_parentparent.txt");

                if (!File.Exists(pathFile))
                {
                    MessageBox.Show("Тест не был пройден");
                    return;
                }

                readAnswer = new StreamReader(pathFile);

                countRows = 0;

                while (!readAnswer.EndOfStream)
                {
                    valueFromFile = Convert.ToInt32(readAnswer.ReadLine());

                    if (valueFromFile == 1)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[1].Value = "да";
                    }
                    else if (valueFromFile == 2)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[1].Value = "скорее да";
                    }
                    else if (valueFromFile == 3)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[1].Value = "не знаю";
                    }
                    else if (valueFromFile == 4)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[1].Value = "скорее нет";
                    }
                    else if (valueFromFile == 5)
                    {
                        gridOutputAnswer.Rows[countRows].Cells[1].Value = "нет";
                    }

                    ++countRows;

                    if (countRows == 18)
                    {
                        countRows += 18;
                    }
                }

                readAnswer.Close();

            }
        }

        private void gridOutputAnswer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
