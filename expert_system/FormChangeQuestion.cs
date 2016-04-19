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
    public partial class FormChangeQuestion : Form
    {
        public string[] m_arrayAnswerPreschoolChild = new string[220];
        public string[] m_arrayAnswerThreeClass = new string[220];
        public string[] m_arrayAnswerFiveClass = new string[220];
        public string[] m_arrayAnswerParent = new string[220];
        public int m_iCountQuestionPreschoolChild;
        public int m_iCountQuestionThreeClassChild;
        public int m_iCountQuestionFiveClassChild;
        public int m_iCountQuestionParentChild;


        public FormChangeQuestion()
        {
            InitializeComponent();
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (m_iCountQuestionFiveClassChild == 216)
            {
                return;
            }

            m_iCountQuestionFiveClassChild += 6;

            label3.Text = m_arrayAnswerFiveClass[m_iCountQuestionFiveClassChild];
            radioButton11.Text = m_arrayAnswerFiveClass[m_iCountQuestionFiveClassChild + 1];
            radioButton12.Text = m_arrayAnswerFiveClass[m_iCountQuestionFiveClassChild + 2];
            radioButton13.Text = m_arrayAnswerFiveClass[m_iCountQuestionFiveClassChild + 3];
            radioButton14.Text = m_arrayAnswerFiveClass[m_iCountQuestionFiveClassChild + 4];
            radioButton15.Text = m_arrayAnswerFiveClass[m_iCountQuestionFiveClassChild + 5];
        }

        private void FormChangeQuestion_Load(object sender, EventArgs e)
        {
            m_iCountQuestionFiveClassChild = 0;
            m_iCountQuestionParentChild = 0;
            m_iCountQuestionPreschoolChild = 0;
            m_iCountQuestionThreeClassChild = 0;

            StreamReader readFileChildQuestions = new StreamReader(Path.GetFullPath(@"tests\preschool_child\child.txt"), false);
            StreamReader readFileThreeClassQuestions = new StreamReader(Path.GetFullPath(@"tests\three_class\child.txt"), false);
            StreamReader readFileFiveClassQuestions = new StreamReader(Path.GetFullPath(@"tests\five_class\child.txt"), false);
            StreamReader readFileParentQuestions = new StreamReader(Path.GetFullPath(@"tests\preschool_child\child.txt"), false);

            for (int rows = 0; rows < 216; rows++)
            {
                m_arrayAnswerPreschoolChild[rows] = readFileChildQuestions.ReadLine();
                m_arrayAnswerThreeClass[rows]     = readFileThreeClassQuestions.ReadLine();
                m_arrayAnswerFiveClass[rows]      = readFileFiveClassQuestions.ReadLine();
                m_arrayAnswerParent[rows]         = readFileParentQuestions.ReadLine();
            }

            readFileChildQuestions.Close();
            readFileThreeClassQuestions.Close();
            readFileFiveClassQuestions.Close();
            readFileParentQuestions.Close();

            label1.Text = m_arrayAnswerPreschoolChild[0];
            radioButton1.Text = "да";
            radioButton2.Text = "скорее да";
            radioButton3.Text = "не знаю";
            radioButton4.Text = "скорее нет";
            radioButton5.Text = "нет";

            label2.Text = m_arrayAnswerThreeClass[0];
            radioButton6.Text = "да";
            radioButton7.Text = "скорее да";
            radioButton8.Text = "не знаю";
            radioButton9.Text = "скорее нет";
            radioButton10.Text = "нет";

            label3.Text = m_arrayAnswerFiveClass[0];
            radioButton11.Text = "да";
            radioButton12.Text = "скорее да";
            radioButton13.Text = "не знаю";
            radioButton14.Text = "скорее нет";
            radioButton15.Text = "нет";

            label4.Text = m_arrayAnswerParent[0];
            radioButton16.Text = m_arrayAnswerParent[1];
            radioButton17.Text = m_arrayAnswerParent[2];
            radioButton18.Text = m_arrayAnswerParent[3];

       }

        private void button5_Click(object sender, EventArgs e)
        {
            if (m_iCountQuestionPreschoolChild == 216)
            {
                return;
            }

            m_iCountQuestionPreschoolChild += 6;

            label1.Text = m_arrayAnswerPreschoolChild[m_iCountQuestionPreschoolChild];
            radioButton1.Text = m_arrayAnswerPreschoolChild[m_iCountQuestionPreschoolChild+1];
            radioButton2.Text = m_arrayAnswerPreschoolChild[m_iCountQuestionPreschoolChild+2];
            radioButton3.Text = m_arrayAnswerPreschoolChild[m_iCountQuestionPreschoolChild+3];
            radioButton4.Text = m_arrayAnswerPreschoolChild[m_iCountQuestionPreschoolChild+4];
            radioButton5.Text = m_arrayAnswerPreschoolChild[m_iCountQuestionPreschoolChild+5];

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (m_iCountQuestionThreeClassChild == 216)
            {
                return;
            }
          
            m_iCountQuestionThreeClassChild += 6;

            label2.Text = m_arrayAnswerThreeClass[m_iCountQuestionThreeClassChild];
            radioButton6.Text = m_arrayAnswerThreeClass[m_iCountQuestionThreeClassChild + 1];
            radioButton7.Text = m_arrayAnswerThreeClass[m_iCountQuestionThreeClassChild + 2];
            radioButton8.Text = m_arrayAnswerThreeClass[m_iCountQuestionThreeClassChild + 3];
            radioButton9.Text = m_arrayAnswerThreeClass[m_iCountQuestionThreeClassChild + 4];
            radioButton10.Text = m_arrayAnswerThreeClass[m_iCountQuestionThreeClassChild + 5];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (m_iCountQuestionParentChild == 216)
            {
                return;
            }

            m_iCountQuestionParentChild += 6;

            label4.Text = m_arrayAnswerParent[0];
            radioButton16.Text = m_arrayAnswerParent[1];
            radioButton17.Text = m_arrayAnswerParent[2];
            radioButton18.Text = m_arrayAnswerParent[3];
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Visible = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Visible = true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strForChange = textBox1.Text;
            textBox1.Visible = false;
            textBox1.Clear();

            int numberSelectItem = comboBox1.SelectedIndex;

            switch (numberSelectItem)
            {
                case 0:
                    {
                        label1.Text = strForChange;
                        m_arrayAnswerPreschoolChild[m_iCountQuestionPreschoolChild] = strForChange;
                        break;
                    }
                case 1:
                    {
                        radioButton1.Text = strForChange;
                        m_arrayAnswerPreschoolChild[m_iCountQuestionPreschoolChild+1] = strForChange;
                        break;
                    }
                case 2:
                    {
                        radioButton2.Text = strForChange;
                        m_arrayAnswerPreschoolChild[m_iCountQuestionPreschoolChild + 2] = strForChange;
                        break;
                    }
                case 3:
                    {
                        radioButton3.Text = strForChange;
                        m_arrayAnswerPreschoolChild[m_iCountQuestionPreschoolChild + 3] = strForChange;
                        break;
                    }
               case 4:
                    {
                        radioButton4.Text = strForChange;
                        m_arrayAnswerPreschoolChild[m_iCountQuestionPreschoolChild + 4] = strForChange;
                        break;
                    }
               case 5:
                    {
                        radioButton5.Text = strForChange;
                        m_arrayAnswerPreschoolChild[m_iCountQuestionPreschoolChild + 5] = strForChange;
                        break;
                    }
               case 6:
                    {
                        label1.Text = "";
                        radioButton1.Text = "";
                        radioButton2.Text = "";
                        radioButton3.Text = "";
                        radioButton4.Text = "";
                        radioButton5.Text = "";

                        m_arrayAnswerPreschoolChild[m_iCountQuestionPreschoolChild] = "";

                        break;
                    }
               case 7:
                    {
                        label1.Text = "";
                        radioButton1.Text = "";
                        radioButton2.Text = "";
                        radioButton3.Text = "";
                        radioButton4.Text = "";
                        radioButton5.Text = "";
                        break;
                    }
            }  
       }

        private void button2_Click(object sender, EventArgs e)
        {
            string strForChange = textBox2.Text;
            textBox2.Visible = false;
            textBox2.Clear();

            int numberSelectItem = comboBox2.SelectedIndex;

            switch (numberSelectItem)
            {
                case 0:
                    {
                        label2.Text = strForChange;
                        m_arrayAnswerThreeClass[m_iCountQuestionThreeClassChild] = strForChange;
                        break;
                    }
                case 1:
                    {
                        radioButton6.Text = strForChange;
                        m_arrayAnswerThreeClass[m_iCountQuestionThreeClassChild+1] = strForChange;
                        break;
                    }
                case 2:
                    {
                        radioButton7.Text = strForChange;
                        m_arrayAnswerThreeClass[m_iCountQuestionThreeClassChild+2] = strForChange;
                        break;
                    }
                case 3:
                    {
                        radioButton8.Text = strForChange;
                        m_arrayAnswerThreeClass[m_iCountQuestionThreeClassChild+3] = strForChange;
                        break;
                    }
                case 4:
                    {
                        radioButton9.Text = strForChange;
                        m_arrayAnswerThreeClass[m_iCountQuestionThreeClassChild+4] = strForChange;
                        break;
                    }
                case 5:
                    {
                        radioButton10.Text = strForChange;
                        m_arrayAnswerThreeClass[m_iCountQuestionThreeClassChild+5] = strForChange;
                        break;
                    }
                case 6:
                    {
                        label1.Text = "";
                        radioButton1.Text = "";
                        radioButton2.Text = "";
                        radioButton3.Text = "";
                        radioButton4.Text = "";
                        radioButton5.Text = "";

                        m_arrayAnswerThreeClass[m_iCountQuestionThreeClassChild] = "";

                        break;
                    }
                case 7:
                    {
                        label2.Text = "";
                        radioButton6.Text = "";
                        radioButton7.Text = "";
                        radioButton8.Text = "";
                        radioButton9.Text = "";
                        radioButton10.Text = "";
                        break;
                    }
            }

            m_arrayAnswerThreeClass[m_iCountQuestionThreeClassChild] = textBox2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strForChange = textBox3.Text;
            textBox3.Visible = false;
            textBox3.Clear();

            int numberSelectItem = comboBox3.SelectedIndex;

            switch (numberSelectItem)
            {
                case 0:
                    {
                        label3.Text = strForChange;
                        m_arrayAnswerFiveClass[m_iCountQuestionFiveClassChild] = strForChange;
                        break;
                    }
                case 1:
                    {
                        radioButton11.Text = strForChange;
                        m_arrayAnswerFiveClass[m_iCountQuestionFiveClassChild+1] = strForChange;
                        break;
                    }
                case 2:
                    {
                        radioButton12.Text = strForChange;
                        m_arrayAnswerFiveClass[m_iCountQuestionFiveClassChild+2] = strForChange;
                        break;
                    }
                case 3:
                    {
                        radioButton13.Text = strForChange;
                        m_arrayAnswerFiveClass[m_iCountQuestionFiveClassChild+3] = strForChange;
                        break;
                    }
                case 4:
                    {
                        radioButton14.Text = strForChange;
                        m_arrayAnswerFiveClass[m_iCountQuestionFiveClassChild+4] = strForChange;
                        break;
                    }
                case 5:
                    {
                        radioButton15.Text = strForChange;
                        m_arrayAnswerFiveClass[m_iCountQuestionFiveClassChild+5] = strForChange;
                        break;
                    }
                case 6:
                    {
                        label3.Text = "";
                        radioButton11.Text = "";
                        radioButton12.Text = "";
                        radioButton13.Text = "";
                        radioButton14.Text = "";
                        radioButton15.Text = "";

                        m_arrayAnswerFiveClass[m_iCountQuestionFiveClassChild] = "";

                        break;
                    }
                case 7:
                    {
                        label3.Text = "";
                        radioButton11.Text = "";
                        radioButton12.Text = "";
                        radioButton13.Text = "";
                        radioButton14.Text = "";
                        radioButton15.Text = "";
                        break;
                    }
            }

            m_arrayAnswerFiveClass[m_iCountQuestionFiveClassChild] = textBox3.Text;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string strForChange = textBox4.Text;
            textBox4.Visible = false;
            textBox4.Clear();

            int numberSelectItem = comboBox4.SelectedIndex;

            switch (numberSelectItem)
            {
                case 0:
                    {
                        label4.Text = strForChange;
                        break;
                    }
                case 1:
                    {
                        radioButton16.Text = strForChange;
                        break;
                    }
                case 2:
                    {
                        radioButton17.Text = strForChange;
                        break;
                    }
                case 3:
                    {
                        radioButton18.Text = strForChange;
                        break;
                    }
            }

            m_arrayAnswerParent[m_iCountQuestionParentChild] = textBox4.Text;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            StreamWriter readFileChildQuestions = new StreamWriter(Path.GetFullPath(@"tests\preschool_child\child.txt"),  false);
            StreamWriter readFileThreeClassQuestions = new StreamWriter(Path.GetFullPath(@"tests\three_class\child.txt"), false);
            StreamWriter readFileFiveClassQuestions = new StreamWriter(Path.GetFullPath(@"tests\five_class\child.txt"),   false);

            for (int rows = 0; rows < 216; rows++)
            {
                readFileChildQuestions.WriteLine(m_arrayAnswerPreschoolChild[rows]);
                readFileThreeClassQuestions.WriteLine(m_arrayAnswerThreeClass[rows]);
                readFileFiveClassQuestions.WriteLine(m_arrayAnswerFiveClass[rows]);
            }

            readFileChildQuestions.Close();
            readFileThreeClassQuestions.Close();
            readFileFiveClassQuestions.Close();
        }
        }
    }