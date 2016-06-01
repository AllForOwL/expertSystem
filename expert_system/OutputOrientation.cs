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
        const int CNT_CREATIVE      = 0;
        const int CNT_HUMMANITARIAN = 1;
        const int CNT_LINGUISTIC    = 2;
        const int CNT_MATHEMATICAL  = 3;
        const int CNT_TECHNICAL     = 4;
        const int CNT_SPORT         = 5;

        const int CNT_COUNT_ORIENTATION = 6;

        const string CNT_PRESCHOOL_PARENT = "preschool_parent";
        const string CNT_PARENT           = "parent";
        const string CNT_PRESCHOOL        = "preschool";
        const string CNT_THREE_CLASS      = "three_class";
        const string CNT_FIVE_CLASS       = "five_class";

        string PATH_TO_FILE_FROM_RESULT;

        public float [,] m_flOrientation;
        public string m_strLogin;
        public string m_strAge;

        public OutputOrientation()
        {
            InitializeComponent();
        }

        public OutputOrientation(string login, string age)
        {
            InitializeComponent();
            m_strLogin = login;
            m_strAge = age;

            PATH_TO_FILE_FROM_RESULT = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "_" + m_strAge + "_result.txt");
        }

        private void OutputOrientation_Load(object sender, EventArgs e)
        {
            int f_iCountLotOrientation    = RecommendedOrientation();
            string f_strPathToOrientation = "";
            string f_strWordOrientation   = "";

            switch (f_iCountLotOrientation)
            {
                case CNT_CREATIVE:
                    {
                        f_strPathToOrientation = Path.GetFullPath(@"orientation\creative.txt");
                        f_strWordOrientation = "творческое";
                    
                    break;
                    }
                case CNT_HUMMANITARIAN:
                    {
                        f_strPathToOrientation = Path.GetFullPath(@"orientation\humanitarian.txt");
                        f_strWordOrientation = "гуманитарное";
                        
                    break;
                    }
                case CNT_LINGUISTIC:
                    {
                        f_strPathToOrientation = Path.GetFullPath(@"orientation\linguistic.txt");
                        f_strWordOrientation = "лингвистическое";
                        
                    break;
                    }
                case CNT_MATHEMATICAL:
                    {
                        f_strPathToOrientation = Path.GetFullPath(@"orientation\mathematical.txt");
                        f_strWordOrientation = "математическое";
                        
                    break;
                    }
                case CNT_TECHNICAL:
                    {
                        f_strPathToOrientation = Path.GetFullPath(@"orientation\technical.txt");
                        f_strWordOrientation = "техническое";
                        
                    break;
                    }
                case CNT_SPORT:
                    {
                        f_strPathToOrientation = Path.GetFullPath(@"orientation\sports.txt");
                        f_strWordOrientation = "спортивное";
                        
                    break;
                    }
            }

            label1.Text = "Ваше направление";
            label2.Text = f_strWordOrientation;

            StreamReader readOrientation = new StreamReader(f_strPathToOrientation);

            while (!readOrientation.EndOfStream)
            {
                textBox1.AppendText(readOrientation.ReadLine());
            }
            readOrientation.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormOutputResultDiagramUsers endResult = new FormOutputResultDiagramUsers(m_strLogin, "без нечеткой модели", m_strAge);
            endResult.Show();
        }

        public int RecommendedOrientation()
        {
            StreamReader readResult = new StreamReader(PATH_TO_FILE_FROM_RESULT);

            int f_iMaxValue = 0;
            double [] f_arrdResultUser = new double [CNT_COUNT_ORIENTATION];

            if (m_strAge == CNT_PRESCHOOL_PARENT)
            {
                while (!readResult.EndOfStream)
                {
                    for (int i = 0; i < 6; i++) { f_arrdResultUser[i] = 0; }
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            f_arrdResultUser[j] += Convert.ToDouble(readResult.ReadLine());
                        }
                    }
                }
            }
            else
            {
                while (!readResult.EndOfStream)
                {
                    for (int i = 0; i < 6; i++) { f_arrdResultUser[i] = 0; }
                    for (int j = 0; j < 6; j++)
                    {
                        f_arrdResultUser[j] += Convert.ToDouble(readResult.ReadLine());
                    }
                }
            }

            for (int i = 1; i < 6; i++)
            {
                if (f_arrdResultUser[i] > f_arrdResultUser[f_iMaxValue])
                {
                    f_iMaxValue = i;
                }
            }

            readResult.Close();
         
            return f_iMaxValue;
        }
    
    }
}
