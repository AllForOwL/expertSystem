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
    public partial class FormOutputResultDiagramUsers : Form
    {
        public int m_iCount;
        public string m_strLogin;
        public string m_strOrientation;
        public int m_iOrientation;
        public string m_strTypeTest;
        public string[] m_arrayAccount = new string[30];

        public FormOutputResultDiagramUsers()
        {
            InitializeComponent();
            m_strTypeTest = "";
        }

        public FormOutputResultDiagramUsers(string typeTests, string login, int orientation)
        {
            InitializeComponent();

            string pathFile;

            // определяем кого показывать результат(дошкольник, родитель, или обоих)
            if (orientation == 0)   // докшкольник
            {
                pathFile = Path.GetFullPath(@"InfoUsers\" + login + "result_preschool_parent.txt");

                if (!File.Exists(pathFile))
                {
                    MessageBox.Show("Тест не был пройден!");
                    return;
                }

                StreamReader readResult = new StreamReader(pathFile);

                if (typeTests == "без нечеткой модели")
                {
                    int countRows = 0;
                    double valueFromFile = 0.0;
                    while (!readResult.EndOfStream)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            valueFromFile = Convert.ToDouble(readResult.ReadLine());
                            chart1.Series[i].Points.Add(valueFromFile);
                        }
                        ++countRows;
                    }
                }
                else // дошкольник + нечеткая модель
                {
                    int countRows = 0;
                    double valueFromFile = 0.0;
                    while (!readResult.EndOfStream)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            valueFromFile = Convert.ToDouble(readResult.ReadLine());

                            if (valueFromFile >= 0 && valueFromFile < 2)
                            {
                                valueFromFile = 0.3;
                            }
                            else if (valueFromFile >= 2 && valueFromFile < 4)
                            {
                                valueFromFile = 0.6;
                            }
                            else if (valueFromFile >= 4 && valueFromFile < 5)
                            {
                                valueFromFile = 0.9;
                            }
                            else if (valueFromFile >= 5 && valueFromFile <= 6)
                            {
                                valueFromFile = 1.0;
                            }
                            chart1.Series[i].Points.Add(valueFromFile);
                        }
                        ++countRows;
                    }
                }

                readResult.Close();

            }
            else if (orientation == 1) // родитель
            {
                pathFile = Path.GetFullPath(@"InfoUsers\" + login + "result_preschool_parentparent.txt");

                if (!File.Exists(pathFile))
                {
                    MessageBox.Show("Тест не был пройден!");
                    return;
                }

                StreamReader readResult = new StreamReader(pathFile);

                if (typeTests == "без нечеткой модели")
                {
                    int countRows = 0;
                    double valueFromFile = 0.0;
                    while (!readResult.EndOfStream)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            valueFromFile = Convert.ToDouble(readResult.ReadLine());
                            chart1.Series[i].Points.Add(valueFromFile);
                        }
                        ++countRows;
                    }
                }
                else // дошкольник + нечеткая модель
                {
                    int countRows = 0;
                    double valueFromFile = 0.0;
                    while (!readResult.EndOfStream)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            valueFromFile = Convert.ToDouble(readResult.ReadLine());

                            if (valueFromFile >= 0 && valueFromFile < 2)
                            {
                                valueFromFile = 0.3;
                            }
                            else if (valueFromFile >= 2 && valueFromFile < 4)
                            {
                                valueFromFile = 0.6;
                            }
                            else if (valueFromFile >= 4 && valueFromFile < 5)
                            {
                                valueFromFile = 0.9;
                            }
                            else if (valueFromFile >= 5 && valueFromFile <= 6)
                            {
                                valueFromFile = 1.0;
                            }
                            chart1.Series[i].Points.Add(valueFromFile);
                        }
                        ++countRows;
                    }
                }

                readResult.Close();

            }
            else // дошкольник+родитель
            {

                int countRows = 0;
                pathFile = Path.GetFullPath(@"InfoUsers\" + login + "result_preschool_parent.txt");

                if (!File.Exists(pathFile))
                {
                    MessageBox.Show("Тест не был пройден!");
                    return;
                }

                StreamReader readResult = new StreamReader(pathFile);

                if (typeTests == "без нечеткой модели")
                {
                    double valueFromFile = 0.0;
                    while (!readResult.EndOfStream)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            valueFromFile = Convert.ToDouble(readResult.ReadLine());
                            chart1.Series[i].Points.Add(valueFromFile);
                        }
                        ++countRows;
                    }
                }
                else // дошкольник + нечеткая модель
                {
                    double valueFromFile = 0.0;
                    while (!readResult.EndOfStream)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            valueFromFile = Convert.ToDouble(readResult.ReadLine());

                            if (valueFromFile >= 0 && valueFromFile < 2)
                            {
                                valueFromFile = 0.3;
                            }
                            else if (valueFromFile >= 2 && valueFromFile < 4)
                            {
                                valueFromFile = 0.6;
                            }
                            else if (valueFromFile >= 4 && valueFromFile < 5)
                            {
                                valueFromFile = 0.9;
                            }
                            else if (valueFromFile >= 5 && valueFromFile <= 6)
                            {
                                valueFromFile = 1.0;
                            }
                            chart1.Series[i].Points.Add(valueFromFile);
                        }
                        ++countRows;
                    }
                }

                readResult.Close();

                pathFile = Path.GetFullPath(@"InfoUsers\" + login + "result_preschool_parentparent.txt");

                if (!File.Exists(pathFile))
                {
                    MessageBox.Show("Тест не был пройден!");
                    return;
                }

                readResult = new StreamReader(pathFile);

                if (typeTests == "без нечеткой модели")
                {
                    double valueFromFile = 0.0;
                    while (!readResult.EndOfStream)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            valueFromFile = Convert.ToDouble(readResult.ReadLine());
                            chart1.Series[i].Points.Add(valueFromFile);
                        }
                        ++countRows;
                    }
                }
                else // дошкольник + нечеткая модель
                {
                    double valueFromFile = 0.0;
                    while (!readResult.EndOfStream)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            valueFromFile = Convert.ToDouble(readResult.ReadLine());

                            if (valueFromFile >= 0 && valueFromFile < 2)
                            {
                                valueFromFile = 0.3;
                            }
                            else if (valueFromFile >= 2 && valueFromFile < 4)
                            {
                                valueFromFile = 0.6;
                            }
                            else if (valueFromFile >= 4 && valueFromFile < 5)
                            {
                                valueFromFile = 0.9;
                            }
                            else if (valueFromFile >= 5 && valueFromFile <= 6)
                            {
                                valueFromFile = 1.0;
                            }
                            chart1.Series[i].Points.Add(valueFromFile);
                        }
                        ++countRows;
                    }
                }

                readResult.Close();

            }
        }

        public FormOutputResultDiagramUsers(string login, string orientation)
        {
            InitializeComponent();

            m_strLogin = login;
            m_strOrientation = orientation;
            m_strTypeTest = "";
        }

        public FormOutputResultDiagramUsers(string login, string typeTests, string orientation)
        {
            InitializeComponent();

            string pathFile;

            pathFile = Path.GetFullPath(@"InfoUsers\" + login + "result_" + orientation + ".txt");

            if (!File.Exists(pathFile))
            {
                MessageBox.Show("Тест не был пройден!");
                return;
            }

            StreamReader readResult = new StreamReader(pathFile);

            if (typeTests == "без нечеткой модели")
            {
                int countRows = 0;
                double valueFromFile = 0.0;
                while (!readResult.EndOfStream)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        valueFromFile = Convert.ToDouble(readResult.ReadLine());
                        chart1.Series[i].Points.Add(valueFromFile);
                    }
                    ++countRows;
                }
            }
            else // дошкольник + нечеткая модель
            {
                int countRows = 0;
                double valueFromFile = 0.0;
                while (!readResult.EndOfStream)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        valueFromFile = Convert.ToDouble(readResult.ReadLine());

                        if (valueFromFile >= 0 && valueFromFile < 2)
                        {
                            valueFromFile = 0.3;
                        }
                        else if (valueFromFile >= 2 && valueFromFile < 4)
                        {
                            valueFromFile = 0.6;
                        }
                        else if (valueFromFile >= 4 && valueFromFile < 5)
                        {
                            valueFromFile = 0.9;
                        }
                        else if (valueFromFile >= 5 && valueFromFile <= 6)
                        {
                            valueFromFile = 1.0;
                        }
                        chart1.Series[i].Points.Add(valueFromFile);
                    }
                    ++countRows;
                }
            }

            readResult.Close();

        }

        private void FormOutputResultDiagramUsers_Load(object sender, EventArgs e)
        {
        }
    }
}
