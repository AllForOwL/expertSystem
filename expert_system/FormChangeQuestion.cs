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
        public string[] m_arrayAnswerPreschoolChild = new string[36];
        public string[] m_arrayAnswerThreeClass = new string[36];
        public string[] m_arrayAnswerFiveClass = new string[36];
        public string[,] m_arrayAnswerParent = new string[5, 18];
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
            if (m_iCountQuestionFiveClassChild == 35)
            {
                return;
            }

            ++m_iCountQuestionFiveClassChild;

            label3.Text = m_arrayAnswerFiveClass[m_iCountQuestionFiveClassChild];
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

            for (int rows = 0; rows < 36; rows++)
            {
                m_arrayAnswerPreschoolChild[rows] = readFileChildQuestions.ReadLine();
                m_arrayAnswerThreeClass[rows]     = readFileThreeClassQuestions.ReadLine();
                m_arrayAnswerFiveClass[rows]      = readFileFiveClassQuestions.ReadLine();
            }

            readFileChildQuestions.Close();
            readFileThreeClassQuestions.Close();
            readFileFiveClassQuestions.Close();

            StreamReader readFileParentQuestions = new StreamReader(Path.GetFullPath(@"tests\preschool_child\child.txt"), false);

            int numberLineInFile = 0;
            while (numberLineInFile != 18)
            {
                for (int rows = 0; rows < 4; rows++)
                {
                    m_arrayAnswerParent[rows, numberLineInFile] = readFileParentQuestions.ReadLine();
                }
                ++numberLineInFile;
            }
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

            label4.Text = m_arrayAnswerParent[0, 0];
            radioButton16.Text = m_arrayAnswerParent[1, 0];
            radioButton17.Text = m_arrayAnswerParent[2, 0];
            radioButton18.Text = m_arrayAnswerParent[3, 0];

       }

        private void button5_Click(object sender, EventArgs e)
        {
            if (m_iCountQuestionPreschoolChild == 35)
            {
                return;
            }

            ++m_iCountQuestionPreschoolChild;

            label1.Text = m_arrayAnswerPreschoolChild[m_iCountQuestionPreschoolChild];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (m_iCountQuestionThreeClassChild == 35)
            {
                return;
            }

            ++m_iCountQuestionThreeClassChild;

            label2.Text = m_arrayAnswerThreeClass[m_iCountQuestionThreeClassChild];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (m_iCountQuestionParentChild == 18)
            {
                return;
            }

            ++m_iCountQuestionParentChild;

            label4.Text = m_arrayAnswerParent[0, m_iCountQuestionParentChild];
            radioButton16.Text = m_arrayAnswerParent[1, m_iCountQuestionParentChild];
            radioButton17.Text = m_arrayAnswerParent[2, m_iCountQuestionParentChild];
            radioButton18.Text = m_arrayAnswerParent[3, m_iCountQuestionParentChild];
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
                        break;
                    }
                case 1:
                    {
                        radioButton1.Text = strForChange;
                        break;
                    }
                case 2:
                    {
                        radioButton2.Text = strForChange;
                        break;
                    }
                case 3:
                    {
                        radioButton3.Text = strForChange;
                        break;
                    }
               case 4:
                    {
                        radioButton4.Text = strForChange;
                        break;
                    }
               case 5:
                    {
                        radioButton5.Text = strForChange;
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
                        break;
                    }
                case 1:
                    {
                        radioButton6.Text = strForChange;
                        break;
                    }
                case 2:
                    {
                        radioButton7.Text = strForChange;
                        break;
                    }
                case 3:
                    {
                        radioButton8.Text = strForChange;
                        break;
                    }
                case 4:
                    {
                        radioButton9.Text = strForChange;
                        break;
                    }
                case 5:
                    {
                        radioButton10.Text = strForChange;
                        break;
                    }
            }
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
                        break;
                    }
                case 1:
                    {
                        radioButton11.Text = strForChange;
                        break;
                    }
                case 2:
                    {
                        radioButton12.Text = strForChange;
                        break;
                    }
                case 3:
                    {
                        radioButton13.Text = strForChange;
                        break;
                    }
                case 4:
                    {
                        radioButton14.Text = strForChange;
                        break;
                    }
                case 5:
                    {
                        radioButton15.Text = strForChange;
                        break;
                    }
            }
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
        }
        }
    }