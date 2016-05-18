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

        public float m_flCreativeParent;
        public float m_flLinguisticParent;
        public float m_flTechnicalParent;
        public float m_flHumanitarianParent;
        public float m_flMathematicalParent;
        public float m_flSportsParent;

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
        public int [] m_iArrayAnsweParent = new int[18];
        public int m_iCountAnswer;

        public FormTest()
        {
            InitializeComponent();
        }

        public FormTest(int yearUser, string loginUser)
        {
            InitializeComponent();

            m_iCountAnswer = 0;
            m_iYearUser = yearUser;
            m_strLoginUser = loginUser;
            m_iCountQuestion = 0;

            m_flCreative     = 0.0F;
            m_flHumanitarian = 0.0F;
            m_flLinguistic   = 0.0F;
            m_flMathematical = 0.0F;
            m_flSports       = 0.0F;
            m_flTechnical    = 0.0F;

            m_flCreativeParent = 0.0F;
            m_flHumanitarianParent = 0.0F;
            m_flLinguisticParent = 0.0F;
            m_flMathematicalParent = 0.0F;
            m_flSportsParent = 0.0F;
            m_flTechnicalParent = 0.0F;

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

            bool b_creative = false;
            bool b_humanitarian = false;
            bool b_linguistic = false;
            bool b_mathematical = false;
            bool b_sport = false;
            bool b_technical = false;

            if (m_iYearUser == 0 && m_iCountAnswer < 18)
            {
                if (parentAnswer1.Checked)
                {
                    if (m_iCountAnswer <= 3)
                    {
                        b_creative = true;
                        ++m_flCreativeParent;
                    }
                    else if (m_iCountAnswer > 3 && m_iCountAnswer <= 6)
                    {
                        b_humanitarian = true;
                        ++m_flHumanitarianParent;
                    }
                    else if (m_iCountAnswer > 6 && m_iCountAnswer <= 9)
                    {
                        b_linguistic = true;
                        ++m_flLinguisticParent;
                    }
                    else if (m_iCountAnswer > 9 && m_iCountAnswer <= 12)
                    {
                        b_mathematical = true;
                        ++m_flMathematicalParent;
                    }
                    else if (m_iCountAnswer > 12 && m_iCountAnswer <= 15)
                    {
                        b_sport = true;
                        ++m_flSportsParent;
                    }
                    else if (m_iCountAnswer > 15 && m_iCountAnswer <= 18)
                    {
                        b_technical = true;
                        ++m_flTechnicalParent;
                    }
                    m_iArrayAnsweParent[m_iCountAnswer] = 1;
                }
                else if (parentAnswer2.Checked)
                {
                    if (m_iCountAnswer <= 3)
                    {
                        m_flCreativeParent += 0.7f;
                    }
                    else if (m_iCountAnswer > 3 && m_iCountAnswer <= 6)
                    {
                        m_flHumanitarianParent += 0.7f;
                    }
                    else if (m_iCountAnswer > 9 && m_iCountAnswer <= 12)
                    {
                        m_flMathematicalParent += 0.7f;
                    }
                    else if (m_iCountAnswer > 12 && m_iCountAnswer <= 15)
                    {
                        m_flSportsParent += 0.7f;
                    }
                    else if (m_iCountAnswer > 15 && m_iCountAnswer <= 18)
                    {
                        m_flTechnicalParent += 0.7f;
                    }
                    m_iArrayAnsweParent[m_iCountAnswer] = 2;
                }
                else if (parentAnswer3.Checked)
                {
                    if (m_iCountAnswer <= 3)
                    {
                        m_flCreativeParent += 0.5f;
                    }
                    else if (m_iCountAnswer > 3 && m_iCountAnswer <= 6)
                    {
                        m_flHumanitarianParent += 0.5f;
                    }
                    else if (m_iCountAnswer > 9 && m_iCountAnswer <= 12)
                    {
                        m_flMathematicalParent += 0.5f;
                    }
                    else if (m_iCountAnswer > 12 && m_iCountAnswer <= 15)
                    {
                        m_flSportsParent += 0.5f;
                    }
                    else if (m_iCountAnswer > 15 && m_iCountAnswer <= 18)
                    {
                        m_flTechnicalParent += 0.5f;
                    }
                    m_iArrayAnsweParent[m_iCountAnswer] = 3;
                }
            }

            if (childAnswer1.Checked)
            {
                m_iArrayAnswer[m_iCountAnswer] = 1; 
            }
            else if (childAnswer2.Checked)
            {
                m_iArrayAnswer[m_iCountAnswer] = 2;
            }
            else if (childAnswer3.Checked)
            {
                m_iArrayAnswer[m_iCountAnswer] = 3;
            }
            else if (childAnswer4.Checked)
            {
                m_iArrayAnswer[m_iCountAnswer] = 4;
            }
            else if (childAnswer5.Checked)
            {
                m_iArrayAnswer[m_iCountAnswer] = 5;
            }

            ++m_iCountAnswer;

            // если вопрос в творческом направлении
             if (
                (m_iCountQuestion >= 0 && m_iCountQuestion < 18) ||
                (m_iCountQuestion >= 108 && m_iCountQuestion <126)
                )
            {
                if (childAnswer5.Checked)
                {
 
                }
                else if (childAnswer1.Checked && b_creative != true)
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
                (m_iCountQuestion >= 18 && m_iCountQuestion < 36) ||
                (m_iCountQuestion >= 126 && m_iCountQuestion < 144)
                )
            {
                if (childAnswer5.Checked)
                {

                }
                else if (childAnswer1.Checked && b_linguistic != true)
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
                (m_iCountQuestion >= 36 && m_iCountQuestion < 54) ||
                (m_iCountQuestion >= 144 && m_iCountQuestion < 162)
                )
            {
                if (childAnswer5.Checked)
                {

                }
                else if (childAnswer1.Checked && b_technical != true)
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
                (m_iCountQuestion >= 54 && m_iCountQuestion < 72) ||
                (m_iCountQuestion >= 180 && m_iCountQuestion < 196)
                )
            {
                if (childAnswer5.Checked)
                {

                }
                else if (childAnswer1.Checked && b_humanitarian != true)
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
                (m_iCountQuestion >= 72 && m_iCountQuestion < 90) ||
                (m_iCountQuestion >= 196 && m_iCountQuestion < 214)
                )
            {
                if (childAnswer5.Checked)
                {

                }
                else if (childAnswer1.Checked && b_mathematical != true)
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
                else if (childAnswer1.Checked && b_sport != true)
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

             if (m_iCountQuestion >= 210)
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

                 for (int i = 1; i < 6; i++)
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
                 bool writeAnswerParent = false;
                 // какого возраста пользователь
                 switch (m_iYearUser)
                 {
                     case 0:
                         {
                             writeAnswerParent = true;   
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

                 /*string pathFileAnswer = Path.GetFullPath(@"InfoUsers\answer_" + nameOrientation + m_strLoginUser + ".txt");
                 StreamWriter writeResultOnOrientationAnswer = new StreamWriter(pathFileAnswer, true);

                 for (int i = 0; i < 36; i++)
                 {
                     writeResultOnOrientationAnswer.WriteLine(m_iArrayAnswer[i]);
                 }

                 if (writeAnswerParent)
                 {
                     for (int i = 0; i < 18; i++)
                     {
                         writeResultOnOrientationAnswer.WriteLine(m_iArrayAnsweParent[i]);
                     }
                 }

                 writeResultOnOrientationAnswer.Close();
                 */
                 // запись результатоа без логики в файл

                 /*string pathFileAll = Path.GetFullPath(@"InfoUsers\Allresult_" + nameOrientation + ".txt");
                 StreamWriter writeResultOnOrientationAll = new StreamWriter(pathFileAll, true);

                 writeResultOnOrientationAll.WriteLine(m_strLoginUser + 0.0);
                 writeResultOnOrientationAll.WriteLine(m_flCreative + 0.0);
                 writeResultOnOrientationAll.WriteLine(m_flHumanitarian + 0.0);
                 writeResultOnOrientationAll.WriteLine(m_flLinguistic + 0.0);
                 writeResultOnOrientationAll.WriteLine(m_flMathematical + 0.0);
                 writeResultOnOrientationAll.WriteLine(m_flSports + 0.0);
                 writeResultOnOrientationAll.WriteLine(m_flTechnical + 0.0);
                 writeResultOnOrientationAll.WriteLine(m_strLoginUser + 0.0);

                 writeResultOnOrientationAll.Close();
                  */

                /* if (writeAnswerParent)
                 {
                     string pathFileAll2 = Path.GetFullPath(@"InfoUsers\Allresult_" + nameOrientation + "parent.txt");
                     StreamWriter writeResultOnOrientationAll2 = new StreamWriter(pathFileAll2, true);

                     writeResultOnOrientationAll2.WriteLine(m_flCreativeParent + 0.0);
                     writeResultOnOrientationAll2.WriteLine(m_flHumanitarianParent + 0.0);
                     writeResultOnOrientationAll2.WriteLine(m_flLinguisticParent + 0.0);
                     writeResultOnOrientationAll2.WriteLine(m_flMathematicalParent + 0.0);
                     writeResultOnOrientationAll2.WriteLine(m_flSportsParent + 0.0);
                     writeResultOnOrientationAll2.WriteLine(m_flTechnicalParent + 0.0);

                     writeResultOnOrientationAll2.Close();
                 }
                 */

                 string pathFile = Path.GetFullPath(@"InfoUsers\" + m_strLoginUser + "result_" + nameOrientation + ".txt");
                 StreamWriter writeResultOnOrientation = new StreamWriter(pathFile, true);

                 writeResultOnOrientation.WriteLine(m_flCreative);
                 writeResultOnOrientation.WriteLine(m_flHumanitarian);
                 writeResultOnOrientation.WriteLine(m_flLinguistic);
                 writeResultOnOrientation.WriteLine(m_flMathematical);
                 writeResultOnOrientation.WriteLine(m_flSports);
                 writeResultOnOrientation.WriteLine(m_flTechnical);

                 writeResultOnOrientation.Close();

                 if (writeAnswerParent)
                 {
                     string pathFileAll3 = Path.GetFullPath(@"InfoUsers\" + m_strLoginUser + "result_" + nameOrientation + "parent.txt");
                     StreamWriter writeResultOnOrientationAll3 = new StreamWriter(pathFileAll3, true);

                     writeResultOnOrientationAll3.WriteLine(m_flCreativeParent + 0.0);
                     writeResultOnOrientationAll3.WriteLine(m_flHumanitarianParent + 0.0);
                     writeResultOnOrientationAll3.WriteLine(m_flLinguisticParent + 0.0);
                     writeResultOnOrientationAll3.WriteLine(m_flMathematicalParent + 0.0);
                     writeResultOnOrientationAll3.WriteLine(m_flSportsParent + 0.0);
                     writeResultOnOrientationAll3.WriteLine(m_flTechnicalParent + 0.0);

                     writeResultOnOrientationAll3.Close();
                 }

                 string pathFileForAnswer = Path.GetFullPath(@"InfoUsers\" + m_strLoginUser + "answer_" + nameOrientation + ".txt");

                 StreamWriter writeAnswer = new StreamWriter(pathFileForAnswer, true);

                 for (int i = 0; i < 36; i++)
                 {
                     writeAnswer.WriteLine(m_iArrayAnswer[i]);
                 }

                 writeAnswer.Close();

                 if (writeAnswerParent)
                 {
                     string pathFileForAnswerParent = Path.GetFullPath(@"InfoUsers\" + m_strLoginUser + "answer_" + nameOrientation + "parent.txt");

                     StreamWriter writeAnswerParentFile = new StreamWriter(pathFileForAnswerParent, true);

                     for (int i = 0; i < 18; i++)
                     {
                         writeAnswerParentFile.WriteLine(m_iArrayAnsweParent[i]);
                     }
                     
                     writeAnswerParentFile.Close();
                 }

                 /*string pathFile_ = Path.GetFullPath(@"InfoUsers\" + m_strLoginUser + "result.txt");
                 StreamWriter writeResultOnOrientation_ = new StreamWriter(pathFile_, true);

                 writeResultOnOrientation_.WriteLine(m_flCreative);
                 writeResultOnOrientation_.WriteLine(m_flHumanitarian);
                 writeResultOnOrientation_.WriteLine(m_flLinguistic);
                 writeResultOnOrientation_.WriteLine(m_flMathematical);
                 writeResultOnOrientation_.WriteLine(m_flSports);
                 writeResultOnOrientation_.WriteLine(m_flTechnical);
                 writeResultOnOrientation_.Close();

                 string pathFile4 = Path.GetFullPath(@"InfoUsers\" + m_strLoginUser + "result_from_logic.txt");
                 StreamWriter writeResultOnOrientationLogic4 = new StreamWriter(pathFile4, true);

                 writeResultOnOrientationLogic4.WriteLine(m_flCreative);
                 writeResultOnOrientationLogic4.WriteLine(m_flHumanitarian);
                 writeResultOnOrientationLogic4.WriteLine(m_flLinguistic);
                 writeResultOnOrientationLogic4.WriteLine(m_flMathematical);
                 writeResultOnOrientationLogic4.WriteLine(m_flSports);
                 writeResultOnOrientationLogic4.WriteLine(m_flTechnical);

                 writeResultOnOrientationLogic4.Close();
                 */
                 OutputOrientation orientation = new OutputOrientation(m_strLoginUser, nameOrientation);
                 orientation.Show();

                 return;
             }

            // отвел ли родител и ребёнок
            m_banswerChild = false;
            m_banswerParent = false;

            // если последний вопро

            m_iCountQuestion+=6;

            questionChild.Text = m_arrayAnswerChild[m_iCountQuestion];
            childAnswer1.Text = m_arrayAnswerChild[m_iCountQuestion + 1];
            childAnswer2.Text = m_arrayAnswerChild[m_iCountQuestion + 2];
            childAnswer3.Text = m_arrayAnswerChild[m_iCountQuestion + 3];
            childAnswer4.Text = m_arrayAnswerChild[m_iCountQuestion + 4];
            childAnswer5.Text = m_arrayAnswerChild[m_iCountQuestion + 5];



            if (m_iCountAnswer <= 17)
            {
                questionParent.Text = m_arrayAnswerParent[0, m_iCountAnswer];
                parentAnswer1.Text = m_arrayAnswerParent[1, m_iCountAnswer];
                parentAnswer2.Text = m_arrayAnswerParent[2, m_iCountAnswer];
                parentAnswer3.Text = m_arrayAnswerParent[3, m_iCountAnswer];
            }

            childAnswer1.Checked = true;
            parentAnswer1.Checked = true;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }  
    }
}
