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

        public float m_flWithoutLogicCreative;
        public float m_flWithoutLogicLinguistic;
        public float m_flWithoutLogicTechnical;
        public float m_flWithoutLogicHumanitarian;
        public float m_flWithoutLogicMathematical;
        public float m_flWithoutLogicSports;

        public int m_iYearUser;
        public string m_strLoginUser;

        public string[] m_arrayAnswerChild  = new string[216];
        public string[,] m_arrayAnswerParent = new string[5, 18];
        public int m_iCountQuestion;

        public int [] m_iArrayAnswer = new int[216];

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

            m_flWithoutLogicCreative     = 0.0f;
            m_flWithoutLogicLinguistic   = 0.0f;
            m_flWithoutLogicTechnical    = 0.0f;
            m_flWithoutLogicHumanitarian = 0.0f;
            m_flWithoutLogicMathematical = 0.0f;
            m_flWithoutLogicSports       = 0.0f;

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

                for (int rows = 0; rows < 216; rows++)
                {
                    m_arrayAnswerChild[rows] = readFileChildQuestions.ReadLine();
                }

                readFileChildQuestions.Close();

                groupBox1.Visible = true;

                questionChild.Text = m_arrayAnswerChild[m_iCountQuestion];
                childAnswer1.Text = m_arrayAnswerChild[m_iCountQuestion+1];
                childAnswer2.Text = m_arrayAnswerChild[m_iCountQuestion+2];
                childAnswer3.Text = m_arrayAnswerChild[m_iCountQuestion+3];
                childAnswer4.Text = m_arrayAnswerChild[m_iCountQuestion+4];
                childAnswer5.Text = m_arrayAnswerChild[m_iCountQuestion+5];
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
            if (childAnswer1.Checked)
            {
                m_iArrayAnswer[m_iCountQuestion] = 1; 
            }
            else if (childAnswer2.Checked)
            {
                m_iArrayAnswer[m_iCountQuestion] = 2;
            }
            else if (childAnswer3.Checked)
            {
                m_iArrayAnswer[m_iCountQuestion] = 3;
            }
            else if (childAnswer4.Checked)
            {
                m_iArrayAnswer[m_iCountQuestion] = 4;
            }
            else if (childAnswer5.Checked)
            {
                m_iArrayAnswer[m_iCountQuestion] = 5;
            }

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
                    ++m_flWithoutLogicCreative;
                }
                else if (childAnswer2.Checked)
                {
                    m_flCreative += 0.7F;
                    m_flWithoutLogicCreative += 0.7f;
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
                    ++m_flWithoutLogicLinguistic;
                }
                else if (childAnswer2.Checked)
                {
                    m_flLinguistic += 0.7F;
                    m_flWithoutLogicLinguistic += 0.7f;
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
                    ++m_flWithoutLogicTechnical;
                }
                else if (childAnswer2.Checked)
                {
                    m_flTechnical += 0.7F;
                    m_flWithoutLogicTechnical += 0.7f;
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
                    ++m_flWithoutLogicHumanitarian;
                }
                else if (childAnswer2.Checked)
                {
                    m_flHumanitarian += 0.7F;
                    m_flWithoutLogicHumanitarian += 0.7f;
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
                    ++m_flWithoutLogicMathematical;
                }
                else if (childAnswer2.Checked)
                {
                    m_flMathematical += 0.7F;
                    m_flWithoutLogicMathematical += 0.7f;
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
                    ++m_flWithoutLogicSports;
                }
                else if (childAnswer2.Checked)
                {
                    m_flSports += 0.7F;
                    m_flWithoutLogicSports += 0.7f;
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
                float[] arrayValueOrientation = new float[6];

                arrayValueOrientation[0] = m_flWithoutLogicCreative;
                arrayValueOrientation[1] = m_flWithoutLogicHumanitarian;
                arrayValueOrientation[2] = m_flWithoutLogicLinguistic;
                arrayValueOrientation[3] = m_flWithoutLogicMathematical;
                arrayValueOrientation[4] = m_flWithoutLogicSports;
                arrayValueOrientation[5] = m_flWithoutLogicTechnical;

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

                string pathFileAnswer = Path.GetFullPath(@"InfoUsers\answer_" + nameOrientation + m_strLoginUser + ".txt");
                StreamWriter writeResultOnOrientationAnswer = new StreamWriter(pathFileAnswer, true);

                for (int i = 0; i < 36; i++)
                {
                    writeResultOnOrientationAnswer.WriteLine(m_iArrayAnswer[i]);
                }

                writeResultOnOrientationAnswer.Close();

               // запись результатоа без логики в файл

                string pathFileAll = Path.GetFullPath(@"InfoUsers\Allresult_" + nameOrientation + ".txt");
                StreamWriter writeResultOnOrientationAll = new StreamWriter(pathFileAll, true);
                
                writeResultOnOrientationAll.WriteLine(m_strLoginUser + 0.0);
                writeResultOnOrientationAll.WriteLine(m_flCreative + 0.0);
                writeResultOnOrientationAll.WriteLine(m_flHumanitarian + 0.0);
                writeResultOnOrientationAll.WriteLine(m_flLinguistic + 0.0);
                writeResultOnOrientationAll.WriteLine(m_flMathematical + 0.0);
                writeResultOnOrientationAll.WriteLine(m_flSports + 0.0);
                writeResultOnOrientationAll.WriteLine(m_flTechnical + 0.0);
                
                writeResultOnOrientationAll.Close();
               
                string pathFile = Path.GetFullPath(@"InfoUsers\" + m_strLoginUser + "result_" + nameOrientation + ".txt");
                StreamWriter writeResultOnOrientation = new StreamWriter(pathFile, true);
                writeResultOnOrientation.WriteLine(bigOrientation);

                writeResultOnOrientation.WriteLine(m_flCreative);
                writeResultOnOrientation.WriteLine(m_flHumanitarian);
                writeResultOnOrientation.WriteLine(m_flLinguistic);
                writeResultOnOrientation.WriteLine(m_flMathematical);
                writeResultOnOrientation.WriteLine(m_flSports);
                writeResultOnOrientation.WriteLine(m_flTechnical);
                writeResultOnOrientation.Close();

                string pathFile_ = Path.GetFullPath(@"InfoUsers\" + m_strLoginUser + "result.txt");
                StreamWriter writeResultOnOrientation_ = new StreamWriter(pathFile_, true);

                writeResultOnOrientation_.WriteLine(m_flCreative);
                writeResultOnOrientation_.WriteLine(m_flHumanitarian);
                writeResultOnOrientation_.WriteLine(m_flLinguistic);
                writeResultOnOrientation_.WriteLine(m_flMathematical);
                writeResultOnOrientation_.WriteLine(m_flSports);
                writeResultOnOrientation_.WriteLine(m_flTechnical);
                writeResultOnOrientation_.Close();

                // запись результатов для определения значения нечёткой логики в файл
                string pathFile2 = Path.GetFullPath(@"InfoUsers\" + m_strLoginUser + nameOrientation + "result_from_logic.txt");
                StreamWriter writeResultOnOrientationLogic = new StreamWriter(pathFile2, true);

                for (int i = 0; i < 6; i++)
                {
                    writeResultOnOrientationLogic.WriteLine(arrayValueOrientation[i]);
                }

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

            m_iCountQuestion+=6;

            questionChild.Text = m_arrayAnswerChild[m_iCountQuestion];
            childAnswer1.Text = m_arrayAnswerChild[m_iCountQuestion + 1];
            childAnswer2.Text = m_arrayAnswerChild[m_iCountQuestion + 2];
            childAnswer3.Text = m_arrayAnswerChild[m_iCountQuestion + 3];
            childAnswer4.Text = m_arrayAnswerChild[m_iCountQuestion + 4];
            childAnswer5.Text = m_arrayAnswerChild[m_iCountQuestion + 5];

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
