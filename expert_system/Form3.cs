using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace expert_system
{
    public partial class FormTest : Form
    {
        public bool  m_banswerChild;
        public bool  m_banswerParent;
        public float m_flCreative;
        public float m_flLinguistic;
        public float m_flTechnical;
        public float m_flHumanitarian;
        public float m_flMathematical;
        public float m_flSports;

        public int m_iWithoutLogicCreative;
        public int m_iWithoutLogicLinguistic;
        public int m_iWithoutLogicTechnical;
        public int m_iWithoutLogicHumanitarian;
        public int m_iWithoutLogicMathematical;
        public int m_iWithoutLogicSports;

        public int m_iYearUser;
        public string m_strLoginUser;

        public string[] m_arrayAnswerChild  = new string[36];
        public string[,] m_arrayAnswerParent = new string[5, 18];
        public int m_iCountQuestion;

        public FormTest()
        {
            InitializeComponent();
        }

        public FormTest(int yearUser, string loginUser)
        {
            InitializeComponent();

            m_iYearUser = yearUser;
            m_strLoginUser = loginUser;
            m_iCountQuestion = 0;

            m_flCreative     = 0.0F;
            m_flHumanitarian = 0.0F;
            m_flLinguistic   = 0.0F;
            m_flMathematical = 0.0F;
            m_flSports       = 0.0F;
            m_flTechnical    = 0.0F;

            m_iWithoutLogicCreative      = 0;
            m_iWithoutLogicLinguistic    = 0;
            m_iWithoutLogicTechnical     = 0;
            m_iWithoutLogicHumanitarian  = 0;
            m_iWithoutLogicMathematical  = 0;
            m_iWithoutLogicSports        = 0;

            m_banswerChild  = false;
            m_banswerParent = false;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            childAnswer1.Checked = true;

            parentAnswer1.Checked = true;

            string questionsChild = "";
            string questionsParent = "";

            switch (m_iYearUser)
            {
                case 0:
                    {
                        questionsChild  = Path.GetFullPath(@"tests\preschool_child\child.txt");
                        questionsParent = Path.GetFullPath(@"tests\preschool_child\parent.txt");

                    break;
                    }
                case 1:
                    {
                        questionsChild  = Path.GetFullPath(@"tests\three_class\child.txt");

                    break;
                    }
                case 2:
                    {
                        questionsChild  = Path.GetFullPath(@"tests\five_class\child.txt");

                    break;
                    }
                case 3:
                    {
                        questionsChild  = Path.GetFullPath(@"tests\preschool_child\child.txt");

                    break;
                    }
                case 4:
                    {
                        questionsParent  = Path.GetFullPath(@"tests\preschool_child\parent.txt");

                    break;
                    }
            }

            int numberLineInFile = 0;

            if (m_iYearUser != 4)
            {
                StreamReader readFileChildQuestions = new StreamReader(questionsChild, false);

                for (int rows = 0; rows < 36; rows++)
                {
                    m_arrayAnswerChild[rows] = readFileChildQuestions.ReadLine();
                }

                readFileChildQuestions.Close();

                groupBox1.Visible = true;

                questionChild.Text = m_arrayAnswerChild[m_iCountQuestion];
                childAnswer1.Text = "да";
                childAnswer2.Text = "скорее да";
                childAnswer3.Text = "не знаю";
                childAnswer4.Text = "скорее нет";
                childAnswer5.Text = "нет";
            }

            if (m_iYearUser == 0 || m_iYearUser == 4)
            {
                StreamReader readFileParentQuestions = new StreamReader(questionsParent, false);

                numberLineInFile = 0;
                while (numberLineInFile != 18)
                {
                    for (int rows = 0; rows < 4; rows++)
                    {
                        m_arrayAnswerParent[rows, numberLineInFile] = readFileParentQuestions.ReadLine();
                    }
                    ++numberLineInFile;
                }
                readFileParentQuestions.Close();

                groupBox2.Visible = true;

                questionParent.Text = m_arrayAnswerParent[0, m_iCountQuestion];
                parentAnswer1.Text = m_arrayAnswerParent[1, m_iCountQuestion];
                parentAnswer2.Text = m_arrayAnswerParent[2, m_iCountQuestion];
                parentAnswer3.Text = m_arrayAnswerParent[3, m_iCountQuestion];
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // если вопрос в творческом направлении
             if (
                (m_iCountQuestion >= 0 && m_iCountQuestion <= 2) ||
                (m_iCountQuestion >= 18 && m_iCountQuestion <= 20)
                )
            {
                if (childAnswer5.Checked)
                {
 
                }
                else if (childAnswer1.Checked)
                {
                    m_flCreative += 1.0F;
                    ++m_iWithoutLogicCreative;
                }
                else if (childAnswer2.Checked)
                {
                    m_flCreative += 0.7F;
                }
                else if (childAnswer3.Checked)
                {
                    m_flCreative += 0.5F;
                }
                else if (childAnswer4.Checked)
                {
                    m_flCreative += 0.3F;
                }
            }
                 // если вопрос в лингвистическом направлении
            else if (
                (m_iCountQuestion >= 3 && m_iCountQuestion <= 5) ||
                (m_iCountQuestion >= 21 && m_iCountQuestion <= 23)
                )
            {
                if (childAnswer5.Checked)
                {

                }
                else if (childAnswer1.Checked)
                {
                    m_flLinguistic += 1.0F;
                    ++m_iWithoutLogicLinguistic;
                }
                else if (childAnswer2.Checked)
                {
                    m_flLinguistic += 0.7F;
                }
                else if (childAnswer3.Checked)
                {
                    m_flLinguistic += 0.5F;
                }
                else if (childAnswer4.Checked)
                {
                    m_flLinguistic += 0.3F;
                }
            }
                 // если вопрос в техническом направлении
            else if (
                (m_iCountQuestion >= 6 && m_iCountQuestion <= 8) ||
                (m_iCountQuestion >= 24 && m_iCountQuestion <= 26)
                )
            {
                if (childAnswer5.Checked)
                {

                }
                else if (childAnswer1.Checked)
                {
                    m_flTechnical += 1.0F;
                    ++m_iWithoutLogicTechnical;
                }
                else if (childAnswer2.Checked)
                {
                    m_flTechnical += 0.7F;
                }
                else if (childAnswer3.Checked)
                {
                    m_flTechnical += 0.5F;
                }
                else if (childAnswer4.Checked)
                {
                    m_flTechnical += 0.3F;
                }
            }
                 // если вопрос в гуманитарном направлении
            else if (
                (m_iCountQuestion >= 9 && m_iCountQuestion <= 11) ||
                (m_iCountQuestion >= 27 && m_iCountQuestion <= 29)
                )
            {
                if (childAnswer5.Checked)
                {

                }
                else if (childAnswer1.Checked)
                {
                    m_flHumanitarian += 1.0F;
                    ++m_iWithoutLogicHumanitarian;
                }
                else if (childAnswer2.Checked)
                {
                    m_flHumanitarian += 0.7F;
                }
                else if (childAnswer3.Checked)
                {
                    m_flHumanitarian += 0.5F;
                }
                else if (childAnswer4.Checked)
                {
                    m_flHumanitarian += 0.3F;
                }
            }
                 // если вопрос в математическом направлении
            else if (
                (m_iCountQuestion >= 12 && m_iCountQuestion <= 14) ||
                (m_iCountQuestion >= 30 && m_iCountQuestion <= 32)
                )
            {
                if (childAnswer5.Checked)
                {

                }
                else if (childAnswer1.Checked)
                {
                    m_flMathematical += 1.0F;
                    ++m_iWithoutLogicMathematical;
                }
                else if (childAnswer2.Checked)
                {
                    m_flMathematical += 0.7F;
                }
                else if (childAnswer3.Checked)
                {
                    m_flMathematical += 0.5F;
                }
                else if (childAnswer4.Checked)
                {
                    m_flMathematical += 0.3F;
                }
            }
                 // если вопрос в спортивном направлении
            else 
            {
                if (childAnswer5.Checked)
                {

                }
                else if (childAnswer1.Checked)
                {
                    m_flSports += 1.0F;
                    ++m_iWithoutLogicSports;
                }
                else if (childAnswer2.Checked)
                {
                    m_flSports += 0.7F;
                }
                else if (childAnswer3.Checked)
                {
                    m_flSports += 0.5F;
                }
                else if (childAnswer4.Checked)
                {
                    m_flSports += 0.3F;
                }
            }

            // отвел ли родител и ребёнок
            m_banswerChild = false;
            m_banswerParent = false;

            // если последний вопрос
           if (m_iCountQuestion == 35)
            {
                int[] arrayValueOrientation = new int[6];

                arrayValueOrientation[0] = m_iWithoutLogicCreative;
                arrayValueOrientation[1] = m_iWithoutLogicHumanitarian;
                arrayValueOrientation[2] = m_iWithoutLogicLinguistic;
                arrayValueOrientation[3] = m_iWithoutLogicMathematical;
                arrayValueOrientation[4] = m_iWithoutLogicSports;
                arrayValueOrientation[5] = m_iWithoutLogicTechnical;

                float max = arrayValueOrientation[0];
                int numberElement = 0;
                string bigOrientation = "творческий";

                for (int i=1; i < 6; i++)
                {
                    if (arrayValueOrientation[i] > max)
                    {
                        max = arrayValueOrientation[i];
                        numberElement = i;
                    }
                }

               // определяем приоритетное направление
                switch (numberElement)
                {
                    case 1:
                        {
                            bigOrientation = "гуманитарный";
                            break;
                        }
                    case 2:
                        {
                            bigOrientation = "лингвистический";
                            break;
                        }
                    case 3:
                        {
                            bigOrientation = "математический";
                            break;
                        }
                    case 4:
                        {
                            bigOrientation = "спортивный";
                            break;
                        }
                    case 5:
                        {
                            bigOrientation = "технический";
                            break;
                        }

                }

                string nameOrientation = "";
               
                // какого возраста пользователь
                switch (m_iYearUser)
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

               // запись результатоа без логики в файл
                string pathFile = Path.GetFullPath(@"InfoUsers\" + m_strLoginUser + "result_" + nameOrientation + ".txt");
                StreamWriter writeResultOnOrientation = new StreamWriter(pathFile, true);
                writeResultOnOrientation.WriteLine(bigOrientation);

                for (int i = 0; i < 6; i++)
                {
                    writeResultOnOrientation.WriteLine(arrayValueOrientation[i]);
                }
                writeResultOnOrientation.Close();

                string pathFile_ = Path.GetFullPath(@"InfoUsers\" + m_strLoginUser + "result.txt");
                StreamWriter writeResultOnOrientation_ = new StreamWriter(pathFile_, true);

                for (int i = 0; i < 6; i++)
                {
                    writeResultOnOrientation_.WriteLine(arrayValueOrientation[i]);
                }
                writeResultOnOrientation_.Close();

                // запись результатов для определения значения нечёткой логики в файл
                string pathFile2 = Path.GetFullPath(@"InfoUsers\" + m_strLoginUser + nameOrientation + "result_from_logic.txt");
                StreamWriter writeResultOnOrientationLogic = new StreamWriter(pathFile2, true);

                writeResultOnOrientationLogic.WriteLine(m_flCreative);
                writeResultOnOrientationLogic.WriteLine(m_flHumanitarian);
                writeResultOnOrientationLogic.WriteLine(m_flLinguistic);
                writeResultOnOrientationLogic.WriteLine(m_flMathematical);
                writeResultOnOrientationLogic.WriteLine(m_flSports);
                writeResultOnOrientationLogic.WriteLine(m_flTechnical);

               writeResultOnOrientationLogic.Close();

               string pathFile4 = Path.GetFullPath(@"InfoUsers\" + m_strLoginUser + "result_from_logic.txt");
               StreamWriter writeResultOnOrientationLogic4 = new StreamWriter(pathFile4, true);

               writeResultOnOrientationLogic4.WriteLine(m_flCreative);
               writeResultOnOrientationLogic4.WriteLine(m_flHumanitarian);
               writeResultOnOrientationLogic4.WriteLine(m_flLinguistic);
               writeResultOnOrientationLogic4.WriteLine(m_flMathematical);
               writeResultOnOrientationLogic4.WriteLine(m_flSports);
               writeResultOnOrientationLogic4.WriteLine(m_flTechnical);

               writeResultOnOrientationLogic4.Close();

               /*pathFile = Path.GetFullPath(@"InfoUsers\result_" + m_strLoginUser + "_temp.txt");
               StreamWriter writeResult = new StreamWriter(pathFile, false);

               writeResult.WriteLine(m_flCreative);
               writeResult.WriteLine(m_flHumanitarian);
               writeResult.WriteLine(m_flLinguistic);
               writeResult.WriteLine(m_flMathematical);
               writeResult.WriteLine(m_flSports);
               writeResult.WriteLine(m_flTechnical);
               
               writeResult.Close();*/

                /*pathFile = Path.GetFullPath(@"InfoUsers\result_" + m_strLoginUser + ".txt");

                StreamWriter writeResult3 = new StreamWriter(pathFile, true);

                writeResult3.WriteLine(m_flCreative);
                writeResult3.WriteLine(m_flHumanitarian);
                writeResult3.WriteLine(m_flLinguistic);
                writeResult3.WriteLine(m_flMathematical);
                writeResult3.WriteLine(m_flSports);
                writeResult3.WriteLine(m_flTechnical);

                writeResult3.Close();*/

                OutputOrientation orientation = new OutputOrientation(m_strLoginUser, nameOrientation);
                orientation.Show();

                return;
            }

            ++m_iCountQuestion;

            questionChild.Text = m_arrayAnswerChild[m_iCountQuestion];

            if (m_iCountQuestion <= 17)
            {
                questionParent.Text = m_arrayAnswerParent[0, m_iCountQuestion];
                parentAnswer1.Text = m_arrayAnswerParent[1, m_iCountQuestion];
                parentAnswer2.Text = m_arrayAnswerParent[2, m_iCountQuestion];
                parentAnswer3.Text = m_arrayAnswerParent[3, m_iCountQuestion];
            }

            childAnswer1.Checked = true;
            parentAnswer1.Checked = true;

        }  
    }
}
