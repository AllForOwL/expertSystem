﻿using System;
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
        public string m_strTypeTest;
        public string[] m_arrayAccount = new string[30];

        public FormOutputResultDiagramUsers()
        {
            InitializeComponent();
            m_strTypeTest = "";
        }

        public FormOutputResultDiagramUsers(string login, string orientation)
        {
            InitializeComponent();

            m_strLogin = login;
            m_strOrientation = orientation;
            m_strTypeTest = "";
        }

        public FormOutputResultDiagramUsers(string login, string typeTest, string orientation, int iCount)
        {
            InitializeComponent();

            m_strLogin = login;
            m_strTypeTest = typeTest;
            m_strOrientation = orientation;
            m_iCount = iCount;
        }

        private void FormOutputResultDiagramUsers_Load(object sender, EventArgs e)
        {
            string pathFile;

            if (m_strLogin == "root")
            {
                pathFile = Path.GetFullPath(@"InfoUsers\AllUsers.txt");

                if (!File.Exists(pathFile))
                {
                    MessageBox.Show("Тест не был пройден");
                    this.Close();
                    return;
                }

                StreamReader readFile = new StreamReader(pathFile);

                string tempStr;

                int countUser = 0;

                while (!readFile.EndOfStream)
                {
                    tempStr = readFile.ReadLine();
                    m_arrayAccount[countUser] = readFile.ReadLine();
                    ++countUser;
                    tempStr = readFile.ReadLine();
                }             
                readFile.Close();

                int creative = 0;
                int hummanitarian = 0;
                int linguistic = 0;
                int mathematical = 0;
                int sports = 0;
                int technical = 0;

                for (int i = 0; i < countUser; i++)
                {
                    pathFile = Path.GetFullPath(@"InfoUsers\" + m_arrayAccount[i] + "result_" + m_strOrientation + ".txt");
                    if (!File.Exists(pathFile))
                    {
                        continue;
                    }

                    StreamReader readResult = new StreamReader(pathFile);

                    string orient;

                    while (!readResult.EndOfStream)
                    {
                        orient = readResult.ReadLine();

                        if (orient == "творческий")
                            ++creative;
                        else if (orient == "гумманитарный")
                            ++hummanitarian;
                        else if (orient == "лингвистический")
                            ++linguistic;
                        else if (orient == "математический")
                            ++mathematical;
                        else if (orient == "спортивный")
                            ++sports;
                        else if (orient == "технический")
                            ++technical;

                        for (int j = 0; j < 6; j++)
                            readResult.ReadLine();
                    }
                    readResult.Close();
                }

                chart1.Series[0].Points.Add(creative);
                chart1.Series[1].Points.Add(hummanitarian);
                chart1.Series[2].Points.Add(linguistic);
                chart1.Series[3].Points.Add(mathematical);
                chart1.Series[4].Points.Add(sports);
                chart1.Series[5].Points.Add(technical);

                return;
            }

            pathFile = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "result_" + m_strOrientation + ".txt");

            if (m_strTypeTest != "")
            {
                if (m_strTypeTest == "нечеткая модель")
                {
                    pathFile = Path.GetFullPath(@"InfoUsers\" + m_strLogin + m_strOrientation + "result_from_logic.txt");

                    if (!File.Exists(pathFile))
                    {
                        return;
                    }

                    StreamReader readFile_ = new StreamReader(pathFile);

                    string orientation;
                    double[] arrayPoints = new double[6] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };

                    int temp = 999;

                    if (m_iCount == 3)
                    {
                        temp = 36;
                    }
                    else if (m_iCount == 4)
                    {
                        temp = 18;
                    }


                    while (!readFile_.EndOfStream)
                    {
                        --temp;
                        if (temp == 0)
                        {
                            break;
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            arrayPoints[i] = Convert.ToDouble(readFile_.ReadLine());
                        }
                    }

                    for (int i = 0; i < 6; i++)
                    {
                        if (arrayPoints[i] >= 0.0 && arrayPoints[i] < 1.0)
                        {
                            chart1.Series[i].Points.Add(0.0);
                        }
                        else if (arrayPoints[i] >= 1.0 && arrayPoints[i] < 2.0)
                        {
                            chart1.Series[i].Points.Add(0.2);
                        }
                        else if (arrayPoints[i] >= 2.0 && arrayPoints[i] < 3.0)
                        {
                            chart1.Series[i].Points.Add(0.4);
                        }
                        else if (arrayPoints[i] >= 3.0 && arrayPoints[i] < 4.0)
                        {
                            chart1.Series[i].Points.Add(0.6);
                        }
                        else if (arrayPoints[i] >= 4.0 && arrayPoints[i] < 5.0)
                        {
                            chart1.Series[i].Points.Add(0.8);
                        }
                        else if (arrayPoints[i] >= 5.0)
                        {
                            chart1.Series[i].Points.Add(1.0);
                        }
                    }
                    readFile_.Close();
                    return;

                }
                else
                {
                    pathFile = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "result_" + m_strOrientation + ".txt");
                }

            }

            if (!File.Exists(pathFile))
            {
                MessageBox.Show("Тест не был пройден");
                this.Close();
                return;
            }
    
            StreamReader readFile__ = new StreamReader(pathFile);

            string orientation__;
            double[] arrayPoints__ = new double[6]{0.0, 0.0, 0.0, 0.0, 0.0, 0.0};

            while (!readFile__.EndOfStream)
            {
                orientation__ = readFile__.ReadLine();
                for (int i = 0; i < 6; i++)
                {
                    arrayPoints__[i] = Convert.ToDouble(readFile__.ReadLine());
                }
            }

            for (int i = 0; i < 6; i++)
            {
                chart1.Series[i].Points.Add(arrayPoints__[i]);
            }

            readFile__.Close();
        }
    }
}
