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
using System.Collections;

namespace expert_system
{
    public partial class FormTest : Form
    {
        const string CNT_PRESCHOOL_PARENT = "preschool_parent";
        const string CNT_PARENT           = "parent";
        const string CNT_PRESCHOOL        = "preschool";
        const string CNT_THREE_CLASS      = "three_class";
        const string CNT_FIVE_CLASS       = "five_class";

        const int CNT_COUNT_QUESTION_CHILD  = 36;
        const int CNT_COUNT_QUESTION_PARENT = 18;
        const int CNT_COUNT_ORIENTATION     = 6;
        const int CNT_COUNT_ANSWER_CHILD    = 6;
        const int CNT_COUNT_ANSWER_PARENT   = 4;

        const int CNT_CREATIVE     = 0;
        const int CNT_HUMANITARIAN = 1;
        const int CNT_LINGUISTIC   = 2;
        const int CNT_MATHEMATICAL = 3;
        const int CNT_TECHNICAL    = 4;
        const int CNT_SPORT        = 5;

        string PATH_TO_RESULT_USER;
        string PATH_TO_ANSWER_USER;
        string PATH_TO_QUESTION_CHILD;
        string PATH_TO_QUESTION_PARENT;

        string m_strAge;
        string m_strLogin;

        string [,] m_arrstrQuestionChild;
        string [,] m_arrstrQuestionParent;

        int m_iCountQuestion;

        double [] m_arriCalculateForChild;
        double [] m_arriCalculateForParent;

        string [] m_arrstrAnswerChild;
        string [] m_arrstrAnswerParent;

        public FormTest()
        {
            InitializeComponent();
        }

        public FormTest(string age, string loginUser)
        {
            InitializeComponent();

            m_iCountQuestion = 0;

            m_strAge   = age;
            m_strLogin = loginUser;

        // { задаем путь для сохранения результатов и ответов
            PATH_TO_RESULT_USER    = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "_" + m_strAge + "_result.txt");
            PATH_TO_ANSWER_USER    = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "_" + m_strAge + "_answer.txt");
        // } задаем путь для сохранения результатов и ответов
        
        // { задаем путь для вопросов
            if (m_strAge == CNT_PRESCHOOL_PARENT)
            {
                PATH_TO_QUESTION_CHILD  = Path.GetFullPath(@"tests\preschool_parent\child.txt");
                PATH_TO_QUESTION_PARENT = Path.GetFullPath(@"tests\preschool_parent\parent.txt");
            }
            else if (m_strAge == CNT_THREE_CLASS)
            {
                PATH_TO_QUESTION_CHILD  = Path.GetFullPath(@"tests\three_class\child.txt");
                PATH_TO_QUESTION_PARENT = ""; 
            }
            else if (m_strAge == CNT_FIVE_CLASS)
            {
                PATH_TO_QUESTION_CHILD = Path.GetFullPath(@"tests\five_class\child.txt");
                PATH_TO_QUESTION_PARENT = "";
            }
            else if (m_strAge == CNT_PRESCHOOL)
            {
                PATH_TO_QUESTION_CHILD  = Path.GetFullPath(@"tests\preschool_parent\child.txt");
                PATH_TO_QUESTION_PARENT = "";
            }
            else if (m_strAge == CNT_PARENT)
            {
                PATH_TO_QUESTION_PARENT = Path.GetFullPath(@"tests\preschool_parent\parent.txt");
                PATH_TO_QUESTION_CHILD  = "";
            }
       // } задаем путь для вопросов

       // { определяем проходит ли тест дошкольник + родитель или кто то один их них
            if (PATH_TO_QUESTION_PARENT != "" && PATH_TO_QUESTION_CHILD != "")
            {
                m_arrstrQuestionChild    = new string [CNT_COUNT_QUESTION_CHILD,  CNT_COUNT_ANSWER_CHILD];
                m_arrstrQuestionParent   = new string [CNT_COUNT_QUESTION_PARENT, CNT_COUNT_ANSWER_PARENT];

                m_arriCalculateForChild  = new double [CNT_COUNT_ORIENTATION];
                m_arriCalculateForParent = new double [CNT_COUNT_ORIENTATION];

                m_arrstrAnswerChild      = new string [CNT_COUNT_QUESTION_CHILD];
                m_arrstrAnswerParent     = new string [CNT_COUNT_QUESTION_PARENT];
            }
            else if (PATH_TO_QUESTION_CHILD != "")
            {
                m_arrstrQuestionChild   = new string [CNT_COUNT_QUESTION_CHILD, CNT_COUNT_ANSWER_CHILD];

                m_arriCalculateForChild = new double [CNT_COUNT_ORIENTATION];

                m_arrstrAnswerChild     = new string [CNT_COUNT_QUESTION_CHILD];

            }
            else
            {
                m_arrstrQuestionParent   = new string [CNT_COUNT_QUESTION_PARENT, CNT_COUNT_ANSWER_PARENT];

                m_arriCalculateForParent = new double [CNT_COUNT_ORIENTATION];

                m_arrstrAnswerParent     = new string [CNT_COUNT_QUESTION_PARENT];
            }
      // { определяем проходит ли тест дошкольник + родитель или кто то один их них

            ReadQuestionAndAnswer(); // read questions and answers for child and parent

      // { show question and answer
            if (PATH_TO_QUESTION_PARENT != "" && PATH_TO_QUESTION_CHILD != "")
            {
                this.questionChild.Text = m_arrstrQuestionChild[m_iCountQuestion, 0];
                this.childAnswer1.Text = m_arrstrQuestionChild[m_iCountQuestion, 1];
                this.childAnswer2.Text = m_arrstrQuestionChild[m_iCountQuestion, 2];
                this.childAnswer3.Text = m_arrstrQuestionChild[m_iCountQuestion, 3];
                this.childAnswer4.Text = m_arrstrQuestionChild[m_iCountQuestion, 4];
                this.childAnswer5.Text = m_arrstrQuestionChild[m_iCountQuestion, 5];

                this.questionParent.Text = m_arrstrQuestionParent[m_iCountQuestion, 0];
                this.parentAnswer1.Text = m_arrstrQuestionParent[m_iCountQuestion, 1];
                this.parentAnswer2.Text = m_arrstrQuestionParent[m_iCountQuestion, 2];
                this.parentAnswer3.Text = m_arrstrQuestionParent[m_iCountQuestion, 3];
            }
            else if (PATH_TO_QUESTION_CHILD != "")  // read file from question and answer for child
            {
                this.questionChild.Text = m_arrstrQuestionChild[m_iCountQuestion, 0];
                this.childAnswer1.Text = m_arrstrQuestionChild[m_iCountQuestion, 1];
                this.childAnswer2.Text = m_arrstrQuestionChild[m_iCountQuestion, 2];
                this.childAnswer3.Text = m_arrstrQuestionChild[m_iCountQuestion, 3];
                this.childAnswer4.Text = m_arrstrQuestionChild[m_iCountQuestion, 4];
                this.childAnswer5.Text = m_arrstrQuestionChild[m_iCountQuestion, 5];
            }
            else                                   //read file from question and answer for parent
            {
                this.questionParent.Text = m_arrstrQuestionParent[m_iCountQuestion, 0];
                this.parentAnswer1.Text = m_arrstrQuestionParent[m_iCountQuestion, 1];
                this.parentAnswer2.Text = m_arrstrQuestionParent[m_iCountQuestion, 2];
                this.parentAnswer3.Text = m_arrstrQuestionParent[m_iCountQuestion, 3];
            }
       // } show question and answer

            ++m_iCountQuestion;
        }
 
        private void Form3_Load(object sender, EventArgs e)
        {
          
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowQuesitonAndAnswer();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void ReadQuestionAndAnswer()
        {
        // { read file from question and answer for child
            if (PATH_TO_QUESTION_PARENT != "" && PATH_TO_QUESTION_CHILD != "")
            {
               StreamReader readFileQuestionChild = new StreamReader(PATH_TO_QUESTION_CHILD);

               for (int i = 0; i < CNT_COUNT_QUESTION_CHILD; i++)
               {
                   for (int j = 0; j < CNT_COUNT_ANSWER_CHILD; j++)
                   {
                       m_arrstrQuestionChild[i, j] = readFileQuestionChild.ReadLine();
                   }
               }

               readFileQuestionChild.Close();
        // } read file from question and answer for child
            
        // { read file from question and answer for parent
            StreamReader readFileQuestionParent = new StreamReader(PATH_TO_QUESTION_PARENT);

            for (int i = 0; i < CNT_COUNT_QUESTION_PARENT; i++)
            {
                for (int j = 0; j < CNT_COUNT_ANSWER_PARENT; j++)
                {
                    m_arrstrQuestionParent[i, j] = readFileQuestionParent.ReadLine();
                }
            }

            readFileQuestionParent.Close();

            this.groupBox1.Visible = true;
            this.groupBox2.Visible = true;

        // } read file from question and answer for parent
            }
            else if (PATH_TO_QUESTION_CHILD != "")  // read file from question and answer for child
            {
                StreamReader readFileQuestionChild = new StreamReader(PATH_TO_QUESTION_CHILD);

                for (int i = 0; i < CNT_COUNT_QUESTION_CHILD; i++)
                {
                    for (int j = 0; j < CNT_COUNT_ANSWER_CHILD; j++)
                    {
                        m_arrstrQuestionChild[i, j] = readFileQuestionChild.ReadLine();
                    }
                }

                readFileQuestionChild.Close();

                this.groupBox1.Visible = true;
            }
            else                                //read file from question and answer for parent
            {
                StreamReader readFileQuestionParent = new StreamReader(PATH_TO_QUESTION_PARENT);

                for (int i = 0; i < CNT_COUNT_QUESTION_PARENT; i++)
                {
                    for (int j = 0; j < CNT_COUNT_ANSWER_PARENT; j++)
                    {
                        m_arrstrQuestionParent[i, j] = readFileQuestionParent.ReadLine();
                    }
                }

                readFileQuestionParent.Close();

                this.groupBox2.Visible = true;
            }
        }

        public void ShowQuesitonAndAnswer()
        {
            if (PATH_TO_QUESTION_PARENT != "" && PATH_TO_QUESTION_CHILD != "")
            {
                this.questionChild.Text = m_arrstrQuestionChild[m_iCountQuestion, 0];
                this.childAnswer1.Text = m_arrstrQuestionChild[m_iCountQuestion, 1];
                this.childAnswer2.Text = m_arrstrQuestionChild[m_iCountQuestion, 2];
                this.childAnswer3.Text = m_arrstrQuestionChild[m_iCountQuestion, 3];
                this.childAnswer4.Text = m_arrstrQuestionChild[m_iCountQuestion, 4];
                this.childAnswer5.Text = m_arrstrQuestionChild[m_iCountQuestion, 5];

                this.questionParent.Text = m_arrstrQuestionParent[m_iCountQuestion, 0];
                this.parentAnswer1.Text = m_arrstrQuestionParent[m_iCountQuestion, 1];
                this.parentAnswer2.Text = m_arrstrQuestionParent[m_iCountQuestion, 2];
                this.parentAnswer3.Text = m_arrstrQuestionParent[m_iCountQuestion, 3];
            }
            else if (PATH_TO_QUESTION_CHILD != "")  // read file from question and answer for child
            {
                this.questionChild.Text = m_arrstrQuestionChild[m_iCountQuestion, 0];
                this.childAnswer1.Text = m_arrstrQuestionChild[m_iCountQuestion, 1];
                this.childAnswer2.Text = m_arrstrQuestionChild[m_iCountQuestion, 2];
                this.childAnswer3.Text = m_arrstrQuestionChild[m_iCountQuestion, 3];
                this.childAnswer4.Text = m_arrstrQuestionChild[m_iCountQuestion, 4];
                this.childAnswer5.Text = m_arrstrQuestionChild[m_iCountQuestion, 5];
            }
            else                                   //read file from question and answer for parent
            {
                this.questionParent.Text = m_arrstrQuestionParent[m_iCountQuestion, 0];
                this.parentAnswer1.Text = m_arrstrQuestionParent[m_iCountQuestion, 1];
                this.parentAnswer2.Text = m_arrstrQuestionParent[m_iCountQuestion, 2];
                this.parentAnswer3.Text = m_arrstrQuestionParent[m_iCountQuestion, 3];
            }
            ++m_iCountQuestion;
        }

        public void Calculation()
        {
            if (PATH_TO_QUESTION_PARENT != "" && PATH_TO_QUESTION_CHILD != "")
            {
                CalculationForChild  ();
                CalculationForParent ();
            }
            else if (PATH_TO_QUESTION_CHILD != "")  
            {
                CalculationForChild  ();
            }
            else                               
            {
                CalculationForParent ();
            }
        }

        public void CalculationForChild()
        {
            if (
                   (m_iCountQuestion <= 2) ||
                   (m_iCountQuestion >= 18 && m_iCountQuestion <= 20)
                  )
            {
                if (this.childAnswer1.Checked)
                {
                    ++m_arriCalculateForChild[CNT_CREATIVE];
                }
                else if (this.childAnswer2.Checked)
                {
                    m_arriCalculateForChild[CNT_CREATIVE] += 0.7;
                }
                else if (this.childAnswer3.Checked)
                {
                    m_arriCalculateForChild[CNT_CREATIVE] += 0.5;
                }
                else if (this.childAnswer4.Checked)
                {
                    m_arriCalculateForChild[CNT_CREATIVE] += 0.3;
                }
            }
            else if (
                     (m_iCountQuestion >= 3 && m_iCountQuestion >= 5) ||
                     (m_iCountQuestion >= 21 && m_iCountQuestion <= 23)
                    )
            {
                if (this.childAnswer1.Checked)
                {
                    ++m_arriCalculateForChild[CNT_HUMANITARIAN];
                }
                else if (this.childAnswer2.Checked)
                {
                    m_arriCalculateForChild[CNT_HUMANITARIAN] += 0.7;
                }
                else if (this.childAnswer3.Checked)
                {
                    m_arriCalculateForChild[CNT_HUMANITARIAN] += 0.5;
                }
                else if (this.childAnswer4.Checked)
                {
                    m_arriCalculateForChild[CNT_HUMANITARIAN] += 0.3;
                }
            }
            else if (
                     (m_iCountQuestion >= 6 && m_iCountQuestion <= 8) ||
                     (m_iCountQuestion >= 24 && m_iCountQuestion <= 26)
                    )
            {
                if (this.childAnswer1.Checked)
                {
                    ++m_arriCalculateForChild[CNT_LINGUISTIC];
                }
                else if (this.childAnswer2.Checked)
                {
                    m_arriCalculateForChild[CNT_LINGUISTIC] += 0.7;
                }
                else if (this.childAnswer3.Checked)
                {
                    m_arriCalculateForChild[CNT_LINGUISTIC] += 0.5;
                }
                else if (this.childAnswer4.Checked)
                {
                    m_arriCalculateForChild[CNT_LINGUISTIC] += 0.3;
                }
            }
            else if (
                     (m_iCountQuestion >= 9 && m_iCountQuestion <= 11) ||
                     (m_iCountQuestion >= 27 && m_iCountQuestion <= 29)
                    )
            {
                if (this.childAnswer1.Checked)
                {
                    ++m_arriCalculateForChild[CNT_MATHEMATICAL];
                }
                else if (this.childAnswer2.Checked)
                {
                    m_arriCalculateForChild[CNT_MATHEMATICAL] += 0.7;
                }
                else if (this.childAnswer3.Checked)
                {
                    m_arriCalculateForChild[CNT_MATHEMATICAL] += 0.5;
                }
                else if (this.childAnswer4.Checked)
                {
                    m_arriCalculateForChild[CNT_MATHEMATICAL] += 0.3;
                }
            }
            else if (
                     (m_iCountQuestion >= 12 && m_iCountQuestion <= 14) ||
                     (m_iCountQuestion >= 30 && m_iCountQuestion <= 32)
                    )
            {
                if (this.childAnswer1.Checked)
                {
                    ++m_arriCalculateForChild[CNT_TECHNICAL];
                }
                else if (this.childAnswer2.Checked)
                {
                    m_arriCalculateForChild[CNT_TECHNICAL] += 0.7;
                }
                else if (this.childAnswer3.Checked)
                {
                    m_arriCalculateForChild[CNT_TECHNICAL] += 0.5;
                }
                else if (this.childAnswer4.Checked)
                {
                    m_arriCalculateForChild[CNT_TECHNICAL] += 0.3;
                }
            }
            else
            {
                if (this.childAnswer1.Checked)
                {
                    ++m_arriCalculateForChild[CNT_SPORT];
                }
                else if (this.childAnswer2.Checked)
                {
                    m_arriCalculateForChild[CNT_SPORT] += 0.7;
                }
                else if (this.childAnswer3.Checked)
                {
                    m_arriCalculateForChild[CNT_SPORT] += 0.5;
                }
                else if (this.childAnswer4.Checked)
                {
                    m_arriCalculateForChild[CNT_SPORT] += 0.3;
                }
            }
        }

        public void CalculationForParent()
        {
            if (m_iCountQuestion <= 2)
            {
                if (this.parentAnswer1.Checked)
                {
                    ++m_arriCalculateForParent[CNT_CREATIVE];
                }
                else if (this.parentAnswer1.Checked)
                {
                    m_arriCalculateForParent[CNT_CREATIVE] += 0.5;
                }
            }
            else if (m_iCountQuestion >= 3 && m_iCountQuestion >= 5)
            {
                if (this.parentAnswer1.Checked)
                {
                    ++m_arriCalculateForParent[CNT_HUMANITARIAN];
                }
                else if (this.parentAnswer1.Checked)
                {
                    m_arriCalculateForParent[CNT_HUMANITARIAN] += 0.5;
                }
            }
            else if (m_iCountQuestion >= 6 && m_iCountQuestion <= 8)
            {
                if (this.parentAnswer1.Checked)
                {
                    ++m_arriCalculateForParent[CNT_LINGUISTIC];
                }
                else if (this.parentAnswer1.Checked)
                {
                    m_arriCalculateForParent[CNT_LINGUISTIC] += 0.5;
                }
            }
            else if (m_iCountQuestion >= 9 && m_iCountQuestion <= 11)
            {
                if (this.parentAnswer1.Checked)
                {
                    ++m_arriCalculateForParent[CNT_MATHEMATICAL];
                }
                else if (this.parentAnswer1.Checked)
                {
                    m_arriCalculateForParent[CNT_MATHEMATICAL] += 0.5;
                }
            }
            else if (m_iCountQuestion >= 12 && m_iCountQuestion <= 14)
            {
                if (this.parentAnswer1.Checked)
                {
                    ++m_arriCalculateForParent[CNT_TECHNICAL];
                }
                else if (this.parentAnswer1.Checked)
                {
                    m_arriCalculateForParent[CNT_TECHNICAL] += 0.5;
                }
            }
            else
            {
                if (this.parentAnswer1.Checked)
                {
                    ++m_arriCalculateForParent[CNT_SPORT];
                }
                else if (this.parentAnswer1.Checked)
                {
                    m_arriCalculateForParent[CNT_SPORT] += 0.5;
                }
            }
        }

        public void RemembertAnswer()
        {
            if (PATH_TO_QUESTION_PARENT != "" && PATH_TO_QUESTION_CHILD != "")
            {
                for (int i = 0; i < 5; i++)
                {
                    if (((RadioButton)groupBox1.Controls[i]).Checked == true) 
                    {
                        m_arrstrAnswerChild[m_iCountQuestion] = ((RadioButton)groupBox1.Controls[i]).Text;
                        break;
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    if (((RadioButton)groupBox2.Controls[i]).Checked == true)
                    {
                        m_arrstrAnswerParent[m_iCountQuestion] = ((RadioButton)groupBox2.Controls[i]).Text;
                        break;
                    }
                }

            }
            else if (PATH_TO_QUESTION_CHILD != "")
            {

            }
            else
            {

            }
        }
    }
}
