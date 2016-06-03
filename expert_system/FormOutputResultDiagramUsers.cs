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
using System.Collections;

namespace expert_system
{
    public partial class FormOutputResultDiagramUsers : Form
    {
       /* public int m_iCount;
        public string m_strLogin;
        public string m_strOrientation;
        public int m_iOrientation;
        public string m_strTypeTest;
        public string[] m_arrayAccount = new string[30];
        */

        const int PRESCHOOL = 0;
        const int PARENT = 1;
        const int PRESCHOOL_PARENT = 2;
        const int ONLY_PRESCHOOL = 3;
        const int ONLY_PARENT = 4;
        const int THREE_CLASS = 5;
        const int FIVE_CLASS = 6;

        const string CNT_ROOT = "root";

        ArrayList m_arrlsdResultPreschool;
        ArrayList m_arrlsResultAccessory;
        string m_strLogin;
        string m_strAge;

        public FormOutputResultDiagramUsers()
        {
            InitializeComponent();
            //m_strTypeTest = "";
        }

        public FormOutputResultDiagramUsers(string login, string age)
        {
            InitializeComponent();

            const int CNT_COUNT_ORIENTATION = 6;

            const string CNT_PRESCHOOL_PARENT  = "preschool_parent";

            string f_strLogin = login;
            string f_strAge   = age;
            string PATH_TO_FILE_READ_RESULT = Path.GetFullPath(@"InfoUsers\" + f_strLogin + "_" + f_strAge + "_result.txt");

            StreamReader readResult = new StreamReader(PATH_TO_FILE_READ_RESULT);

            int f_iMaxValue = 0;
            double [] f_arrdResultUser = new double [CNT_COUNT_ORIENTATION];

            if (f_strAge == CNT_PRESCHOOL_PARENT)
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
            readResult.Close();
         
            for (int i = 0; i < CNT_COUNT_ORIENTATION; i++)
            {
                chart1.Series[i].Points.Add(f_arrdResultUser[i]);
            }
        }

        public FormOutputResultDiagramUsers(string typeLogic, string login, int age)
        {
            InitializeComponent();

            m_arrlsdResultPreschool = new ArrayList();
            m_arrlsResultAccessory = new ArrayList();
            m_strLogin = login;
            m_strAge = "preschool_parent";

            const string CNT_FUZZY_LOGIC = "нечеткая модель";
            const string CNT_WITHOUT_FUZZY = "без нечеткой модели";

            if (typeLogic == CNT_FUZZY_LOGIC)
            {
                switch (age)
                {
                    case PRESCHOOL:
                        {
                            if (m_strLogin == CNT_ROOT)
                            {
                                string CNT_PATH_TO_ALL_USER = Path.GetFullPath(@"InfoUsers\AllLogin.txt");
                                StreamReader readAllUsers = new StreamReader(CNT_PATH_TO_ALL_USER);
                                while (!readAllUsers.EndOfStream)
                                {
                                    m_strLogin = readAllUsers.ReadLine();
                                    ReadResultUser(PRESCHOOL);
                                    CalculateFuzzyLogic(PRESCHOOL);
                                    OutputResultInDiagram();
                                }
                                readAllUsers.Close();
                            }
                            else
                            {
                                ReadResultUser(PRESCHOOL);
                                CalculateFuzzyLogic(PRESCHOOL);
                                OutputResultInDiagram();
                            }

                            break;
                        }
                    case PARENT:
                        {
                            if (m_strLogin == CNT_ROOT)
                            {
                                string CNT_PATH_TO_ALL_USER = Path.GetFullPath(@"InfoUsers\AllLogin.txt");
                                StreamReader readAllUsers = new StreamReader(CNT_PATH_TO_ALL_USER);
                                while (!readAllUsers.EndOfStream)
                                {
                                    m_strLogin = readAllUsers.ReadLine();
                                    ReadResultUser(PARENT);
                                    CalculateFuzzyLogic(PARENT);
                                    OutputResultInDiagram();
                                }
                                readAllUsers.Close();
                            }
                            else
                            {
                                ReadResultUser(PARENT);
                                CalculateFuzzyLogic(PARENT);
                                OutputResultInDiagram();
                            }

                            break;
                        }
                    case PRESCHOOL_PARENT:
                        {
                            if (m_strLogin == CNT_ROOT)
                            {
                                string CNT_PATH_TO_ALL_USER = Path.GetFullPath(@"InfoUsers\AllLogin.txt");
                                StreamReader readAllUsers = new StreamReader(CNT_PATH_TO_ALL_USER);
                                while (!readAllUsers.EndOfStream)
                                {
                                    m_strLogin = readAllUsers.ReadLine();
                                    ReadResultUser(PRESCHOOL_PARENT);
                                    CalculateFuzzyLogic(PRESCHOOL_PARENT);
                                    OutputResultInDiagram();
                                }
                                readAllUsers.Close();
                            }
                            else
                            {
                                ReadResultUser(PRESCHOOL_PARENT);
                                CalculateFuzzyLogic(PRESCHOOL_PARENT);
                                OutputResultInDiagram();
                            }

                            break;
                        }
                    case ONLY_PRESCHOOL:
                        {
                            if (m_strLogin == CNT_ROOT)
                            {
                                string CNT_PATH_TO_ALL_USER = Path.GetFullPath(@"InfoUsers\AllLogin.txt");
                                StreamReader readAllUsers = new StreamReader(CNT_PATH_TO_ALL_USER);
                                while (!readAllUsers.EndOfStream)
                                {
                                    m_strLogin = readAllUsers.ReadLine();
                                    ReadResultUser(ONLY_PRESCHOOL);
                                    CalculateFuzzyLogic(ONLY_PRESCHOOL);
                                    OutputResultInDiagram();
                                }
                                readAllUsers.Close();
                            }
                            else
                            {
                                ReadResultUser(ONLY_PRESCHOOL);
                                CalculateFuzzyLogic(ONLY_PRESCHOOL);
                                OutputResultInDiagram();
                            }

                            break;
                        }
                    case ONLY_PARENT:
                        {
                            if (m_strLogin == CNT_ROOT)
                            {
                                string CNT_PATH_TO_ALL_USER = Path.GetFullPath(@"InfoUsers\AllLogin.txt");
                                StreamReader readAllUsers = new StreamReader(CNT_PATH_TO_ALL_USER);
                                while (!readAllUsers.EndOfStream)
                                {
                                    m_strLogin = readAllUsers.ReadLine();
                                    ReadResultUser(ONLY_PARENT);
                                    CalculateFuzzyLogic(ONLY_PARENT);
                                    OutputResultInDiagram();
                                }
                                readAllUsers.Close();
                            }
                            else
                            {
                                ReadResultUser(ONLY_PARENT);
                                CalculateFuzzyLogic(ONLY_PARENT);
                                OutputResultInDiagram();
                            }

                            break;
                        }
                    case THREE_CLASS:
                        {
                            if (m_strLogin == CNT_ROOT)
                            {
                                string CNT_PATH_TO_ALL_USER = Path.GetFullPath(@"InfoUsers\AllLogin.txt");
                                StreamReader readAllUsers = new StreamReader(CNT_PATH_TO_ALL_USER);
                                while (!readAllUsers.EndOfStream)
                                {
                                    m_strLogin = readAllUsers.ReadLine();
                                    ReadResultUser(THREE_CLASS);
                                    CalculateFuzzyLogic(THREE_CLASS);
                                    OutputResultInDiagram();
                                }
                                readAllUsers.Close();
                            }
                            else
                            {
                                ReadResultUser(THREE_CLASS);
                                CalculateFuzzyLogic(THREE_CLASS);
                                OutputResultInDiagram();
                            }

                            break;
                        }
                    case FIVE_CLASS:
                        {
                            if (m_strLogin == CNT_ROOT)
                            {
                                string CNT_PATH_TO_ALL_USER = Path.GetFullPath(@"InfoUsers\AllLogin.txt");
                                StreamReader readAllUsers = new StreamReader(CNT_PATH_TO_ALL_USER);
                                while (!readAllUsers.EndOfStream)
                                {
                                    m_strLogin = readAllUsers.ReadLine();
                                    ReadResultUser(FIVE_CLASS);
                                    CalculateFuzzyLogic(FIVE_CLASS);
                                    OutputResultInDiagram();
                                }
                                readAllUsers.Close();
                            }
                            else
                            {
                                ReadResultUser(FIVE_CLASS);
                                CalculateFuzzyLogic(FIVE_CLASS);
                                OutputResultInDiagram();
                            }

                            break;
                        }
                }
            }
            else
            {
                switch (age)
                {
                    case PRESCHOOL:
                        {
                            if (m_strLogin == CNT_ROOT)
                            {
                                string CNT_PATH_TO_ALL_USER = Path.GetFullPath(@"InfoUsers\AllLogin.txt");
                                StreamReader readAllUsers = new StreamReader(CNT_PATH_TO_ALL_USER);
                                while (!readAllUsers.EndOfStream)
                                {
                                    m_strLogin = readAllUsers.ReadLine();
                                    ReadResultUser(PRESCHOOL);
                                    OutputResultInDiagram();
                                }
                                readAllUsers.Close();
                            }
                            else
                            {
                                ReadResultUser(PRESCHOOL);
                                OutputResultInDiagram();
                            }

                            break;
                        }
                    case PARENT:
                        {
                            if (m_strLogin == CNT_ROOT)
                            {
                                string CNT_PATH_TO_ALL_USER = Path.GetFullPath(@"InfoUsers\AllLogin.txt");
                                StreamReader readAllUsers = new StreamReader(CNT_PATH_TO_ALL_USER);
                                while (!readAllUsers.EndOfStream)
                                {
                                    m_strLogin = readAllUsers.ReadLine();
                                    ReadResultUser(PARENT);
                                    OutputResultInDiagram();
                                }
                                readAllUsers.Close();
                            }
                            else
                            {
                                ReadResultUser(PARENT);
                                OutputResultInDiagram();
                            }

                            break;
                        }
                    case PRESCHOOL_PARENT:
                        {
                            if (m_strLogin == CNT_ROOT)
                            {
                                string CNT_PATH_TO_ALL_USER = Path.GetFullPath(@"InfoUsers\AllLogin.txt");
                                StreamReader readAllUsers = new StreamReader(CNT_PATH_TO_ALL_USER);
                                while (!readAllUsers.EndOfStream)
                                {
                                    m_strLogin = readAllUsers.ReadLine();
                                    ReadResultUser(PRESCHOOL_PARENT);
                                    OutputResultInDiagram();
                                }
                                readAllUsers.Close();
                            }
                            else
                            {
                                ReadResultUser(PRESCHOOL_PARENT);
                                OutputResultInDiagram();
                            }

                            break;
                        }
                    case ONLY_PRESCHOOL:
                        {
                            if (m_strLogin == CNT_ROOT)
                            {
                                string CNT_PATH_TO_ALL_USER = Path.GetFullPath(@"InfoUsers\AllLogin.txt");
                                StreamReader readAllUsers = new StreamReader(CNT_PATH_TO_ALL_USER);
                                while (!readAllUsers.EndOfStream)
                                {
                                    m_strLogin = readAllUsers.ReadLine();
                                    ReadResultUser(ONLY_PRESCHOOL);
                                    OutputResultInDiagram();
                                }
                                readAllUsers.Close();
                            }
                            else
                            {
                                ReadResultUser(ONLY_PRESCHOOL);
                                OutputResultInDiagram();
                            }

                            break;
                        }
                    case ONLY_PARENT:
                        {
                            if (m_strLogin == CNT_ROOT)
                            {
                                string CNT_PATH_TO_ALL_USER = Path.GetFullPath(@"InfoUsers\AllLogin.txt");
                                StreamReader readAllUsers = new StreamReader(CNT_PATH_TO_ALL_USER);
                                while (!readAllUsers.EndOfStream)
                                {
                                    m_strLogin = readAllUsers.ReadLine();
                                    ReadResultUser(ONLY_PARENT);
                                    OutputResultInDiagram();
                                }
                                readAllUsers.Close();
                            }
                            else
                            {
                                ReadResultUser(ONLY_PARENT);
                                OutputResultInDiagram();
                            }

                            break;
                        }
                    case THREE_CLASS:
                        {
                            if (m_strLogin == CNT_ROOT)
                            {
                                string CNT_PATH_TO_ALL_USER = Path.GetFullPath(@"InfoUsers\AllLogin.txt");
                                StreamReader readAllUsers = new StreamReader(CNT_PATH_TO_ALL_USER);
                                while (!readAllUsers.EndOfStream)
                                {
                                    m_strLogin = readAllUsers.ReadLine();
                                    ReadResultUser(THREE_CLASS);
                                    OutputResultInDiagram();
                                }
                                readAllUsers.Close();
                            }
                            else
                            {
                                ReadResultUser(THREE_CLASS);
                                OutputResultInDiagram();
                            }

                            break;
                        }
                    case FIVE_CLASS:
                        {
                            if (m_strLogin == CNT_ROOT)
                            {
                                string CNT_PATH_TO_ALL_USER = Path.GetFullPath(@"InfoUsers\AllLogin.txt");
                                StreamReader readAllUsers = new StreamReader(CNT_PATH_TO_ALL_USER);
                                while (!readAllUsers.EndOfStream)
                                {
                                    m_strLogin = readAllUsers.ReadLine();
                                    ReadResultUser(FIVE_CLASS);
                                    OutputResultInDiagram();
                                }
                                readAllUsers.Close();
                            }
                            else
                            {
                                ReadResultUser(FIVE_CLASS);
                                OutputResultInDiagram();
                            }

                            break;
                        }
                }
            }
        }

        public void ReadResultUser(int typeUser)
        {
            m_arrlsdResultPreschool.Clear();
            m_arrlsResultAccessory.Clear();

            string PATH_TO_FILE_FROM_RESULT = "";
            if (typeUser >= 3)
            {
                switch (typeUser)
                {
                    case ONLY_PRESCHOOL:
                        {
                            PATH_TO_FILE_FROM_RESULT = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "_preschool_result.txt");

                            break;
                        }
                    case ONLY_PARENT:
                        {
                            PATH_TO_FILE_FROM_RESULT = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "_parent_result.txt");

                            break;
                        }
                    case THREE_CLASS:
                        {
                            PATH_TO_FILE_FROM_RESULT = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "_three_class_result.txt");

                            break;
                        }
                    case FIVE_CLASS:
                        {
                            PATH_TO_FILE_FROM_RESULT = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "_five_class_result.txt");

                            break;
                        }
                }
            }
            else
            {
                PATH_TO_FILE_FROM_RESULT = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "_" + m_strAge + "_result.txt");
            }

            StreamReader readResultUser = new StreamReader(PATH_TO_FILE_FROM_RESULT);
            const int CNT_COUNT_ORIENTATION = 6;
            while (!readResultUser.EndOfStream)
            {
                switch (typeUser)
                {
                    case PRESCHOOL:
                        {
                            for (int i = 0; i < CNT_COUNT_ORIENTATION; i++)
                            {
                                m_arrlsdResultPreschool.Add(Convert.ToDouble(readResultUser.ReadLine()));
                            }
                            for (int i = 0; i < 6; i++) { }

                            break;
                        }
                    case PARENT:
                        {
                            for (int i = 0; i < 6; i++) { }
                            for (int i = 0; i < CNT_COUNT_ORIENTATION; i++)
                            {
                                m_arrlsdResultPreschool.Add(Convert.ToDouble(readResultUser.ReadLine()));
                            }
                            break;
                        }
                    case PRESCHOOL_PARENT:
                        {
                            double[] f_arrdSumResult = new double[6];
                            while (!readResultUser.EndOfStream)
                            {
                                for (int i = 0; i < 6; i++) { f_arrdSumResult[i] = 0.0; }
                                for (int i = 0; i < 6; i++)
                                {
                                    f_arrdSumResult[i] = Convert.ToDouble(readResultUser.ReadLine());
                                }
                                for (int i = 0; i < 6; i++)
                                {
                                    f_arrdSumResult[i] += Convert.ToDouble(readResultUser.ReadLine());
                                    m_arrlsdResultPreschool.Add(f_arrdSumResult[i]);
                                }
                            }

                            break;
                        }
                    case ONLY_PRESCHOOL:
                        {
                            while (!readResultUser.EndOfStream)
                            {
                                m_arrlsdResultPreschool.Add(Convert.ToDouble(readResultUser.ReadLine()));
                            }

                            break;
                        }
                    case ONLY_PARENT:
                        {
                            while (!readResultUser.EndOfStream)
                            {
                                m_arrlsdResultPreschool.Add(Convert.ToDouble(readResultUser.ReadLine()));
                            }

                            break;
                        }
                    case THREE_CLASS:
                        {
                            while (!readResultUser.EndOfStream)
                            {
                                m_arrlsdResultPreschool.Add(Convert.ToDouble(readResultUser.ReadLine()));
                            }

                            break;
                        }
                    case FIVE_CLASS:
                        {
                            while (!readResultUser.EndOfStream)
                            {
                                m_arrlsdResultPreschool.Add(Convert.ToDouble(readResultUser.ReadLine()));
                            }

                            break;
                        }
                }
            }
            readResultUser.Close();
        }

        public void CalculateFuzzyLogic(int typeUser)
        {
            const double RESULT_ACCESSORY_NO = 0.0;
            const double RESULT_ACCESSORY_LESS = 0.3;
            const double RESULT_ACCESSORY_MIDDLE = 0.6;
            const double RESULT_ACCESORY_HIGH = 0.9;
            const double RESULT_ACCESORY_FULL = 1.0;

            switch (typeUser)
            {
                case PRESCHOOL:
                    {
                        for (int i = 0; i < m_arrlsdResultPreschool.Count; i++)
                        {
                            double t_dResult = Convert.ToDouble(m_arrlsdResultPreschool[i]);
                            if (t_dResult < 1.0)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_NO);
                            }
                            else if (t_dResult >= 0.0 && t_dResult <= 2)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_LESS);
                            }
                            else if (t_dResult > 2 && t_dResult <= 4)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_MIDDLE);
                            }
                            else if (t_dResult > 4 && t_dResult <= 5)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESORY_HIGH);
                            }
                            else
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESORY_FULL);
                            }
                        }

                        break;
                    }
                case PARENT:
                    {
                        for (int i = 0; i < m_arrlsdResultPreschool.Count; i++)
                        {
                            double t_dResult = Convert.ToDouble(m_arrlsdResultPreschool[i]);
                            if (t_dResult < 1.0)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_NO);
                            }
                            else if (t_dResult >= 0.0 && t_dResult <= 1)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_LESS);
                            }
                            else if (t_dResult > 1 && t_dResult <= 2)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_MIDDLE);
                            }
                            else if (t_dResult > 2 && t_dResult < 3)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESORY_HIGH);
                            }
                            else
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESORY_FULL);
                            }
                        }

                        break;
                    }
                case PRESCHOOL_PARENT:
                    {
                        for (int i = 0; i < m_arrlsdResultPreschool.Count; i++)
                        {
                            double t_dResult = Convert.ToDouble(m_arrlsdResultPreschool[i]);
                            if (t_dResult < 1.0)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_NO);
                            }
                            else if (t_dResult >= 0.0 && t_dResult <= 3)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_LESS);
                            }
                            else if (t_dResult > 3 && t_dResult <= 7)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_MIDDLE);
                            }
                            else if (t_dResult > 7 && t_dResult < 9)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESORY_HIGH);
                            }
                            else
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESORY_FULL);
                            }
                        }

                        break;
                    }
                case ONLY_PRESCHOOL:
                    {
                        for (int i = 0; i < m_arrlsdResultPreschool.Count; i++)
                        {
                            double t_dResult = Convert.ToDouble(m_arrlsdResultPreschool[i]);
                            if (t_dResult < 1.0)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_NO);
                            }
                            else if (t_dResult >= 0.0 && t_dResult <= 2)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_LESS);
                            }
                            else if (t_dResult > 2 && t_dResult <= 4)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_MIDDLE);
                            }
                            else if (t_dResult > 4 && t_dResult <= 5)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESORY_HIGH);
                            }
                            else
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESORY_FULL);
                            }
                        }

                        break;
                    }
                case ONLY_PARENT:
                    {
                        for (int i = 0; i < m_arrlsdResultPreschool.Count; i++)
                        {
                            double t_dResult = Convert.ToDouble(m_arrlsdResultPreschool[i]);
                            if (t_dResult < 1.0)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_NO);
                            }
                            else if (t_dResult >= 0.0 && t_dResult <= 1)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_LESS);
                            }
                            else if (t_dResult > 1 && t_dResult <= 2)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_MIDDLE);
                            }
                            else if (t_dResult > 2 && t_dResult < 3)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESORY_HIGH);
                            }
                            else
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESORY_FULL);
                            }
                        }

                        break;
                    }
                case THREE_CLASS:
                    {
                        for (int i = 0; i < m_arrlsdResultPreschool.Count; i++)
                        {
                            double t_dResult = Convert.ToDouble(m_arrlsdResultPreschool[i]);
                            if (t_dResult < 1.0)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_NO);
                            }
                            else if (t_dResult >= 0.0 && t_dResult <= 2)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_LESS);
                            }
                            else if (t_dResult > 2 && t_dResult <= 4)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_MIDDLE);
                            }
                            else if (t_dResult > 4 && t_dResult <= 5)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESORY_HIGH);
                            }
                            else
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESORY_FULL);
                            }
                        }

                        break;
                    }
                case FIVE_CLASS:
                    {
                        for (int i = 0; i < m_arrlsdResultPreschool.Count; i++)
                        {
                            double t_dResult = Convert.ToDouble(m_arrlsdResultPreschool[i]);
                            if (t_dResult < 1.0)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_NO);
                            }
                            else if (t_dResult >= 0.0 && t_dResult <= 2)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_LESS);
                            }
                            else if (t_dResult > 2 && t_dResult <= 4)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESSORY_MIDDLE);
                            }
                            else if (t_dResult > 4 && t_dResult <= 5)
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESORY_HIGH);
                            }
                            else
                            {
                                m_arrlsResultAccessory.Add(RESULT_ACCESORY_FULL);
                            }
                        }

                        break;
                    }
            }
        }

        public void OutputResultInDiagram()
        {
            const int CNT_COUNT_ORIENTATION = 6;
            int CNT_COUNT_ROWS = 0;
            if (m_arrlsResultAccessory.Count != 0)
            {
                CNT_COUNT_ROWS = m_arrlsResultAccessory.Count / 6;
                int f_iCountElementInArrayAccessory = 0;
                //dataGridView1.RowCount = CNT_COUNT_ROWS;

                for (int i = 0; i < CNT_COUNT_ROWS; i++)
                {
                    for (int j = 0; j < CNT_COUNT_ORIENTATION; j++)
                    {
                        chart1.Series[j].Points.Add(Convert.ToDouble(m_arrlsResultAccessory[f_iCountElementInArrayAccessory]));
                        ++f_iCountElementInArrayAccessory;
                    }
                }
            }
            else
            {
                CNT_COUNT_ROWS = m_arrlsdResultPreschool.Count / 6;
                int f_iCountElementInArrayAccessory = 0;
                //dataGridView1.RowCount = CNT_COUNT_ROWS;

                for (int i = 0; i < CNT_COUNT_ROWS; i++)
                {
                    for (int j = 0; j < CNT_COUNT_ORIENTATION; j++)
                    {
                        chart1.Series[j].Points.Add(Convert.ToDouble(m_arrlsdResultPreschool[f_iCountElementInArrayAccessory]));
                        ++f_iCountElementInArrayAccessory;
                    }
                }
            }

            
        }

        private void FormOutputResultDiagramUsers_Load(object sender, EventArgs e)
        {
        }
    }
    
    }
