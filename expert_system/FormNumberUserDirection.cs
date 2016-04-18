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
    public partial class FormNumberUserDirection : Form
    {
        public string m_typeTest;

        public FormNumberUserDirection()
        {
            InitializeComponent();

        }

        private void FormNumberUserDirection_Load(object sender, EventArgs e)
        {
            int numberCreative = 0;
            int numberHumanitarian = 0;
            int numberLinguistic = 0;
            int numberMathematical = 0;
            int numberSports = 0;
            int numberTechnical = 0;

            string surname;
            string login;
            int numberLine = 1;
            int numberLineInTable = 0;
            double valueFromFile;

            string direction = "";
            double maxDirection;

            string []arrayOrientation = new string[5];
            arrayOrientation[0] = "preschool_child";
            arrayOrientation[1] = "three_class";
            arrayOrientation[2] = "five_class";
            arrayOrientation[3] = "preschool";
            arrayOrientation[4] = "parent";

            int numberOrientation = 0;

            while (numberOrientation != 5)
            {
                maxDirection = 0;

                if (!File.Exists(Path.GetFullPath(@"InfoUsers\Allresult_" + arrayOrientation[numberOrientation] + ".txt")))
                {
                    ++numberOrientation;
                    continue;
                }

                StreamReader readResultUsers = new StreamReader(Path.GetFullPath(@"InfoUsers\Allresult_" + arrayOrientation[numberOrientation] + ".txt"));

                login = readResultUsers.ReadLine();
                while (!readResultUsers.EndOfStream)
                {

                    for (int i = 1; i < 7; i++)
                    {
                        valueFromFile = Convert.ToDouble((readResultUsers.ReadLine()));
                        if (valueFromFile > maxDirection)
                        {
                            numberLine = i;
                            maxDirection = valueFromFile;
                        }
                    }

                    switch (numberLine)
                    {
                        case 1:
                            {
                                ++numberCreative;

                                break;
                            }
                        case 2:
                            {
                                ++numberHumanitarian;

                                break;
                            }

                        case 3:
                            {
                                ++numberLinguistic;

                                break;
                            }

                        case 4:
                            {
                                ++numberMathematical;

                                break;
                            }

                        case 5:
                            {
                                ++numberSports;

                                break;
                            }

                        case 6:
                            {
                                ++numberTechnical;

                                break;
                            }
                    }
                }
                readResultUsers.Close();
                ++numberOrientation;
            }
            

            chart1.Series[0].Points.Add(numberCreative);
            chart1.Series[1].Points.Add(numberHumanitarian);
            chart1.Series[2].Points.Add(numberLinguistic);
            chart1.Series[3].Points.Add(numberMathematical);
            chart1.Series[4].Points.Add(numberSports);
            chart1.Series[5].Points.Add(numberTechnical);
            

        }
    }
}
