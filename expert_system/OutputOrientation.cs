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
    public partial class OutputOrientation : Form
    {
        public float [,] m_flOrientation;
        public string m_strLogin;
        public string m_strOrientation;

        public OutputOrientation()
        {
            InitializeComponent();
        }

        public OutputOrientation(string login, string orientation)
        {
            InitializeComponent();
            m_strLogin = login;
            m_strOrientation = orientation;
        }

        private void OutputOrientation_Load(object sender, EventArgs e)
        {
            StreamReader readResult = new StreamReader(Path.GetFullPath(@"InfoUsers\" + m_strLogin + "result_" + m_strOrientation + ".txt"));

            double    maxValue = 0;
            string    orientation = "";
            string    pathFileFromOrientation = "";
            double    tempValue = 0;

            while (!readResult.EndOfStream)
            {
                maxValue = 0;
                orientation = readResult.ReadLine();
                for (int i = 0; i < 6; i++)
                {
                    tempValue = Convert.ToDouble(readResult.ReadLine());

                    if (tempValue > maxValue)
                    {
                        maxValue = tempValue;

                        switch (i)
                        {
                            case 0:
                                {
                                    pathFileFromOrientation = Path.GetFullPath(@"orientation\creative.txt");
                                    orientation = "творческое";
                                    break;
                                }
                            case 1:
                                {
                                    pathFileFromOrientation = Path.GetFullPath(@"orientation\humanitarian.txt");
                                    orientation = "гуманитарное";
                                    break;
                                }
                            case 2:
                                {
                                    pathFileFromOrientation = Path.GetFullPath(@"orientation\linguistic.txt");
                                    orientation = "лингвистическое";
                                    break;
                                }
                            case 3:
                                {
                                    pathFileFromOrientation = Path.GetFullPath(@"orientation\mathematical.txt");
                                    orientation = "математическое";
                                    break;
                                }
                            case 4:
                                {
                                    pathFileFromOrientation = Path.GetFullPath(@"orientation\sports.txt");
                                    orientation = "спортивное";
                                    break;
                                }
                            case 5:
                                {
                                    pathFileFromOrientation = Path.GetFullPath(@"orientation\technical.txt");
                                    orientation = "техническое";
                                    break;
                                }
                        }
                    }
                }
            }

            readResult.Close();

            label1.Text = "Ваше направление";
            label2.Text = orientation;

            StreamReader readOrientation = new StreamReader(pathFileFromOrientation);

            while (!readOrientation.EndOfStream)
            {
                textBox1.AppendText(readOrientation.ReadLine());
            }

            readOrientation.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormOutputResultDiagramUsers endResult = new FormOutputResultDiagramUsers(m_strLogin, m_strOrientation);
            endResult.Show();
        }
    }
}
