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
        public int m_iCount;
        public string m_strLogin;
        public string m_strOrientation;
        public int m_iOrientation;
        public string m_strTypeTest;
        public string[] m_arrayAccount = new string[30];

        public FormOutputResultDiagramUsers()
        {
            InitializeComponent();
            m_strTypeTest = "";
        }

        public FormOutputResultDiagramUsers(string typeTests, string login, int orientation)
        {
            InitializeComponent();

            string pathFile;

            // определяем кого показывать результат(дошкольник, родитель, или обоих)
            if (orientation == 0)   // докшкольник
            {
                ArrayList f_arrlistUsers = new ArrayList();
                int countRows = 0;

                if (login == "root")
                {
                    string pathFileLocal = Path.GetFullPath(@"InfoUsers\AllUsers.txt");

                    StreamReader readResultlocal = new StreamReader(pathFileLocal);

                    string tempValue = "";

                    while (!readResultlocal.EndOfStream)
                    {
                        tempValue = readResultlocal.ReadLine();
                        f_arrlistUsers.Add(readResultlocal.ReadLine());
                        tempValue = readResultlocal.ReadLine();
                    }

                    readResultlocal.Close();

                    int f_iCountHummanitarian = 0;
                    int f_iCountLinguistic    = 0;
                    int f_iCountTechnical     = 0;
                    int f_iCountMathematical  = 0;
                    int f_iCountSport         = 0;
                    int f_iCountCreative      = 0;

                    int f_iCountUsers = f_arrlistUsers.Count;

                    for (int i = 0; i < f_iCountUsers; i++)
                    {
                        pathFile = Path.GetFullPath(@"InfoUsers\" + f_arrlistUsers[i] + "result_preschool.txt");

                        if (!File.Exists(pathFile))
                        {
                            continue;
                        }

                        StreamReader readResult = new StreamReader(pathFile);

                        double []valueFromFile = new double[6];
                        double maxValue = 0.0;
                        int iter = 0;
                        while (!readResult.EndOfStream)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                valueFromFile[j] = Math.Round(Convert.ToDouble(readResult.ReadLine()), 2);
                                if (valueFromFile[j] > maxValue)
                                {
                                    maxValue = valueFromFile[j];
                                    iter = j;
                                }
                            }
                        }

                        switch (iter)
                        {
                            case 0:
                                {
                                    ++f_iCountCreative;
                                    break;
                                }
                            case 1:
                                {
                                    ++f_iCountHummanitarian;
                                    break;
                                }
                            case 2:
                                {
                                    ++f_iCountLinguistic;
                                    break;
                                }
                            case 3:
                                {
                                    ++f_iCountMathematical;
                                    break;
                                }
                            case 4:
                                {
                                    ++f_iCountTechnical;
                                    break;
                                }
                            case 5:
                                {
                                    ++f_iCountSport;
                                    break;
                                }
                        }

                        readResult.Close();
                    }

                    chart1.Series[0].Points.Add(f_iCountCreative);
                    chart1.Series[1].Points.Add(f_iCountHummanitarian);
                    chart1.Series[2].Points.Add(f_iCountLinguistic);
                    chart1.Series[3].Points.Add(f_iCountMathematical);
                    chart1.Series[4].Points.Add(f_iCountTechnical);
                    chart1.Series[5].Points.Add(f_iCountSport);

                    return;
                }
                else
                {
                    f_arrlistUsers.Add(login);
                }

                for (int countUser = 0; countUser < f_arrlistUsers.Count; countUser++)
                {

                    pathFile = Path.GetFullPath(@"InfoUsers\" + f_arrlistUsers[countUser] + "result_preschool.txt");

                    if (!File.Exists(pathFile))
                    {
                        MessageBox.Show("Тест не был пройден!");
                        return;
                    }

                    StreamReader readResult = new StreamReader(pathFile);

                    if (typeTests == "без нечеткой модели")
                    {
                        double valueFromFile = 0.0;
                        while (!readResult.EndOfStream)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                valueFromFile = Math.Round(Convert.ToDouble(readResult.ReadLine()), 2);
                                chart1.Series[i].Points.Add(valueFromFile);
                            }
                            ++countRows;
                        }
                    }
                    else // дошкольник + нечеткая модель
                    {
                        double valueFromFile = 0.0;
                        while (!readResult.EndOfStream)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                valueFromFile = Convert.ToDouble(readResult.ReadLine());

                                if (valueFromFile >= 0 && valueFromFile < 2)
                                {
                                    valueFromFile = 0.2;
                                }
                                else if (valueFromFile >= 2 && valueFromFile < 3)
                                {
                                    valueFromFile = 0.4;
                                }
                                else if (valueFromFile >= 3 && valueFromFile < 4)
                                {
                                    valueFromFile = 0.6;
                                }
                                else if (valueFromFile >= 4 && valueFromFile < 5)
                                {
                                    valueFromFile = 0.8;
                                }
                                else
                                {
                                    valueFromFile = 1.0;
                                }

                                chart1.Series[i].Points.Add(valueFromFile);
                            }
                            ++countRows;
                        }
                    }

                    readResult.Close();
                }

            }
            else if (orientation == 1) // родитель
            {
                ArrayList f_arrlistUsers = new ArrayList();
                int countRows = 0;

                if (login == "root")
                {
                    string pathFileLocal = Path.GetFullPath(@"InfoUsers\AllUsers.txt");

                    StreamReader readResultlocal = new StreamReader(pathFileLocal);

                    string tempValue = "";

                    while (!readResultlocal.EndOfStream)
                    {
                        tempValue = readResultlocal.ReadLine();
                        f_arrlistUsers.Add(readResultlocal.ReadLine());
                        tempValue = readResultlocal.ReadLine();
                    }

                    readResultlocal.Close();

                    int f_iCountHummanitarian = 0;
                    int f_iCountLinguistic = 0;
                    int f_iCountTechnical = 0;
                    int f_iCountMathematical = 0;
                    int f_iCountSport = 0;
                    int f_iCountCreative = 0;

                    int f_iCountUsers = f_arrlistUsers.Count;

                    for (int i = 0; i < f_iCountUsers; i++)
                    {
                        pathFile = Path.GetFullPath(@"InfoUsers\" + f_arrlistUsers[i] + "result_preschool_parentparent.txt");

                        if (!File.Exists(pathFile))
                        {
                            continue;
                        }

                        StreamReader readResult = new StreamReader(pathFile);

                        double[] valueFromFile = new double[6];
                        double maxValue = 0.0;
                        int iter = 0;
                        while (!readResult.EndOfStream)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                valueFromFile[j] = Math.Round(Convert.ToDouble(readResult.ReadLine()), 2);
                                if (valueFromFile[j] > maxValue)
                                {
                                    maxValue = valueFromFile[j];
                                    iter = j;
                                }
                            }
                        }

                        switch (iter)
                        {
                            case 0:
                                {
                                    ++f_iCountCreative;
                                    break;
                                }
                            case 1:
                                {
                                    ++f_iCountHummanitarian;
                                    break;
                                }
                            case 2:
                                {
                                    ++f_iCountLinguistic;
                                    break;
                                }
                            case 3:
                                {
                                    ++f_iCountMathematical;
                                    break;
                                }
                            case 4:
                                {
                                    ++f_iCountTechnical;
                                    break;
                                }
                            case 5:
                                {
                                    ++f_iCountSport;
                                    break;
                                }
                        }

                        readResult.Close();
                    }

                    chart1.Series[0].Points.Add(f_iCountCreative);
                    chart1.Series[1].Points.Add(f_iCountHummanitarian);
                    chart1.Series[2].Points.Add(f_iCountLinguistic);
                    chart1.Series[3].Points.Add(f_iCountMathematical);
                    chart1.Series[4].Points.Add(f_iCountTechnical);
                    chart1.Series[5].Points.Add(f_iCountSport);

                    return;


                }
                else
                {
                    f_arrlistUsers.Add(login);
                }

                for (int countUser = 0; countUser < f_arrlistUsers.Count; countUser++)
                {

                    pathFile = Path.GetFullPath(@"InfoUsers\" + f_arrlistUsers[countUser] + "result_preschool_parentparent.txt");

                    if (!File.Exists(pathFile))
                    {
                        //MessageBox.Show("Тест не был пройден!");
                        return;
                    }

                    StreamReader readResult = new StreamReader(pathFile);

                    if (typeTests == "без нечеткой модели")
                    {

                        double valueFromFile = 0.0;
                        while (!readResult.EndOfStream)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                valueFromFile = Math.Round(Convert.ToDouble(readResult.ReadLine()), 2);
                                chart1.Series[i].Points.Add(valueFromFile);
                            }
                            ++countRows;
                        }
                    }
                    else // дошкольник + нечеткая модель
                    {
                        double valueFromFile = 0.0;
                        while (!readResult.EndOfStream)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                valueFromFile = Convert.ToDouble(readResult.ReadLine());

                                if (valueFromFile >= 0 && valueFromFile < 1)
                                {
                                    valueFromFile = 0.3;
                                }
                                else if (valueFromFile >= 1 && valueFromFile < 2)
                                {
                                    valueFromFile = 0.6;
                                }
                                else if (valueFromFile >= 2 && valueFromFile < 3)
                                {
                                    valueFromFile = 0.8;
                                }
                                else if (valueFromFile >= 3)
                                {
                                    valueFromFile = 1.0;
                                }
                                chart1.Series[i].Points.Add(valueFromFile);
                            }
                            ++countRows;
                        }
                    }

                    readResult.Close();
                }

            }
            else // дошкольник+родитель
            {
                ArrayList f_arrlistUsers = new ArrayList();
                int countRows = 0;

                if (login == "root")
                {
                    string pathFileLocal = Path.GetFullPath(@"InfoUsers\AllUsers.txt");

                    StreamReader readResultlocal = new StreamReader(pathFileLocal);

                    string tempValue = "";

                    while (!readResultlocal.EndOfStream)
                    {
                        tempValue = readResultlocal.ReadLine();
                        f_arrlistUsers.Add(readResultlocal.ReadLine());
                        tempValue = readResultlocal.ReadLine();
                    }

                    readResultlocal.Close();


                    int f_iCountHummanitarian = 0;
                    int f_iCountLinguistic = 0;
                    int f_iCountTechnical = 0;
                    int f_iCountMathematical = 0;
                    int f_iCountSport = 0;
                    int f_iCountCreative = 0;

                    int f_iCountUsers = f_arrlistUsers.Count;

                    for (int i = 0; i < f_iCountUsers; i++)
                    {
                        pathFile = Path.GetFullPath(@"InfoUsers\" + f_arrlistUsers[i] + "result_preschool_parent.txt");

                        if (!File.Exists(pathFile))
                        {
                            continue;
                        }

                        StreamReader readResult = new StreamReader(pathFile);

                        double[] valueFromFile = new double[6];
                        double maxValue = 0.0;
                        int iter = 0;
                        while (!readResult.EndOfStream)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                valueFromFile[j] = Math.Round(Convert.ToDouble(readResult.ReadLine()), 2);
                                if (valueFromFile[j] > maxValue)
                                {
                                    maxValue = valueFromFile[j];
                                    iter = j;
                                }
                            }
                        }

                        switch (iter)
                        {
                            case 0:
                                {
                                    ++f_iCountCreative;
                                    break;
                                }
                            case 1:
                                {
                                    ++f_iCountHummanitarian;
                                    break;
                                }
                            case 2:
                                {
                                    ++f_iCountLinguistic;
                                    break;
                                }
                            case 3:
                                {
                                    ++f_iCountMathematical;
                                    break;
                                }
                            case 4:
                                {
                                    ++f_iCountTechnical;
                                    break;
                                }
                            case 5:
                                {
                                    ++f_iCountSport;
                                    break;
                                }
                        }

                        readResult.Close();
                    }

                    chart1.Series[0].Points.Add(f_iCountCreative);
                    chart1.Series[1].Points.Add(f_iCountHummanitarian);
                    chart1.Series[2].Points.Add(f_iCountLinguistic);
                    chart1.Series[3].Points.Add(f_iCountMathematical);
                    chart1.Series[4].Points.Add(f_iCountTechnical);
                    chart1.Series[5].Points.Add(f_iCountSport);

                    return;

                }
                else
                {
                    f_arrlistUsers.Add(login);
                }

                double[] arrayResultPreschool = new double[24];

                for (int countUser = 0; countUser < f_arrlistUsers.Count; countUser++)
                {
                    pathFile = Path.GetFullPath(@"InfoUsers\" + f_arrlistUsers[countUser] + "result_preschool_parent.txt");

                    if (!File.Exists(pathFile))
                    {
                        MessageBox.Show("Тест не был пройден!");
                        return;
                    }

                    StreamReader readResult = new StreamReader(pathFile);

                    if (typeTests == "без нечеткой модели")
                    {
                        double[] arr = new double[6];
                        int iter = 0;
                        double valueFromFile = 0.0;
                        while (!readResult.EndOfStream)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                valueFromFile = Math.Round(Convert.ToDouble(readResult.ReadLine()), 2);
                                arr[i] = valueFromFile;
                                //chart1.Series[i].Points.Add(valueFromFile);

                                ++iter;
                            }

                            ++countRows;
                        }

                        for (int i = 0; i < 6; i++)
                        {
                            arrayResultPreschool[i] = arr[i];
                        }

                    }
                    else // дошкольник + нечеткая модель
                    {
                        int iter = 0;
                        double valueFromFile = 0.0;
                        while (!readResult.EndOfStream)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                valueFromFile = Math.Round(Convert.ToDouble(readResult.ReadLine()), 2);
                                arrayResultPreschool[iter] = valueFromFile;

                               /* if (valueFromFile >= 0 && valueFromFile < 2)
                                {
                                    valueFromFile = 0.2;
                                }
                                else if (valueFromFile >= 2 && valueFromFile < 3)
                                {
                                    valueFromFile = 0.4;
                                }
                                else if (valueFromFile >= 3 && valueFromFile < 4)
                                {
                                    valueFromFile = 0.6;
                                }
                                else if (valueFromFile >= 4 && valueFromFile <= 5)
                                {
                                    valueFromFile = 0.8;
                                }
                                else if (valueFromFile >= 6)
                                {
                                    valueFromFile = 1.0;
                                }*/

                                ++iter;
                               // chart1.Series[i].Points.Add(valueFromFile);
                            }
                            ++countRows;
                        }
                    }

                    readResult.Close();
                }

                if (login == "root")
                {
                    string pathFileLocal = Path.GetFullPath(@"InfoUsers\AllUsers.txt");

                    StreamReader readResultlocal = new StreamReader(pathFileLocal);

                    string tempValue = "";

                    while (!readResultlocal.EndOfStream)
                    {
                        tempValue = readResultlocal.ReadLine();
                        f_arrlistUsers.Add(readResultlocal.ReadLine());
                        tempValue = readResultlocal.ReadLine();
                    }

                    readResultlocal.Close();
                }
                else
                {
                    f_arrlistUsers.Clear();
                    f_arrlistUsers.Add(login);
                }

                for (int countUsers = 0; countUsers < f_arrlistUsers.Count; countUsers++)
                {

                    pathFile = Path.GetFullPath(@"InfoUsers\" + f_arrlistUsers[countUsers] + "result_preschool_parentparent.txt");

                    if (!File.Exists(pathFile))
                    {
                        continue;
                        //return;
                    }

                    StreamReader readResult = new StreamReader(pathFile);

                    if (typeTests == "без нечеткой модели")
                    { double[] arr = new double[6];
                        int iter = 0;
                        double valueFromFile = 0.0;
                        while (!readResult.EndOfStream)
                        {
                           
                            iter = 0;
                            for (int i = 0; i < 6; i++)
                            {
                                valueFromFile = Math.Round(Convert.ToDouble(readResult.ReadLine()), 2);
                                arr[i] = valueFromFile;
                                //chart1.Series[i].Points.Add(valueFromFile);
                                ++iter;
                            }
                            ++countRows;
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            chart1.Series[i].Points.Add(arrayResultPreschool[i] + arr[i]);
                        }
                    }
                    else // дошкольник + parent нечеткая модель
                    {
                        int iter = 0;
                        double valueFromFile = 0.0;
                        while (!readResult.EndOfStream)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                valueFromFile = Convert.ToDouble(readResult.ReadLine());
                                valueFromFile += arrayResultPreschool[iter];

                                if (valueFromFile >= 0 && valueFromFile < 2)
                                {
                                    valueFromFile = 0.1;
                                }
                                else if (valueFromFile >= 2 && valueFromFile < 3)
                                {
                                    valueFromFile = 0.2;
                                }
                                else if (valueFromFile >= 3 && valueFromFile < 4)
                                {
                                    valueFromFile = 0.3;
                                }
                                else if (valueFromFile >= 4 && valueFromFile < 5)
                                {
                                    valueFromFile = 0.4;
                                }
                                if (valueFromFile >= 5 && valueFromFile < 6)
                                {
                                    valueFromFile = 0.5;
                                }
                                else if (valueFromFile >= 6 && valueFromFile < 7)
                                {
                                    valueFromFile = 0.6;
                                }
                                else if (valueFromFile >= 7 && valueFromFile < 8)
                                {
                                    valueFromFile = 0.7;
                                }
                                else if (valueFromFile >= 8 && valueFromFile < 9)
                                {
                                    valueFromFile = 0.8;
                                }
                                else if (valueFromFile >= 9)
                                {
                                    valueFromFile = 1.0;
                                }


                                ++iter;
                                chart1.Series[i].Points.Add(valueFromFile);
                            }

                            ++countRows;
                        }
                    }

                    readResult.Close();
                }
            }
        }

        public FormOutputResultDiagramUsers(string login, string orientation)
        {
            InitializeComponent();

            m_strLogin = login;
            m_strOrientation = orientation;
            m_strTypeTest = "";
        }

        public FormOutputResultDiagramUsers(string login, string typeTests, string orientation)
        {
            InitializeComponent();

            ArrayList f_arrlistUsers = new ArrayList();
            int countRows = 0;

            if (login == "root")
            {
                string pathFileLocal = Path.GetFullPath(@"InfoUsers\AllUsers.txt");

                StreamReader readResultlocal = new StreamReader(pathFileLocal);

                string tempValue = "";

                while (!readResultlocal.EndOfStream)
                {
                    tempValue = readResultlocal.ReadLine();
                    f_arrlistUsers.Add(readResultlocal.ReadLine());
                    tempValue = readResultlocal.ReadLine();
                }

                readResultlocal.Close();
            }
            else
            {
                f_arrlistUsers.Add(login);
            }

            for (int countUsers = 0; countUsers < f_arrlistUsers.Count; countUsers++)
            {
                string pathFile = Path.GetFullPath(@"InfoUsers\" + f_arrlistUsers[countUsers] + "result_" + orientation + ".txt");

                if (!File.Exists(pathFile))
                {
                    //    MessageBox.Show("Тест не был пройден!");
                    return;
                }

                StreamReader readResult = new StreamReader(pathFile);

                if (typeTests == "без нечеткой модели")
                {
                    double valueFromFile = 0.0;
                    while (!readResult.EndOfStream)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            valueFromFile = Math.Round(Convert.ToDouble(readResult.ReadLine()), 2);

                            if (valueFromFile >= 0 && valueFromFile < 2)
                            {
                                valueFromFile = 1.5;
                            }
                            else if (valueFromFile >= 2 && valueFromFile < 3)
                            {
                                valueFromFile = 2.5;
                            }
                            else if (valueFromFile >= 3 && valueFromFile < 4)
                            {
                                valueFromFile = 3.5;
                            }
                            else if (valueFromFile >= 4 && valueFromFile <= 5)
                            {
                                valueFromFile = 4.5;
                            }
                            if (valueFromFile >= 5 && valueFromFile <= 6)
                            {
                                valueFromFile = 5.2;
                            }
                            else if (valueFromFile >= 6 && valueFromFile <= 7)
                            {
                                valueFromFile = 6.4;
                            }
                            else if (valueFromFile >= 7 && valueFromFile <= 8)
                            {
                                valueFromFile = 7.6;
                            }
                            else if (valueFromFile >= 8 && valueFromFile <= 9)
                            {
                                valueFromFile = 8.8;
                            }
                            else if (valueFromFile >= 9)
                            {
                                valueFromFile = 9.0;
                            }

                            chart1.Series[i].Points.Add(valueFromFile);
                        }
                        ++countRows;
                    }
                }
                else //  нечеткая модель
                {
                    double valueFromFile = 0.0;
                    while (!readResult.EndOfStream)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            valueFromFile = Convert.ToDouble(readResult.ReadLine());

                            if (valueFromFile >= 0 && valueFromFile < 2)
                            {
                                valueFromFile = 0.2;
                            }
                            else if (valueFromFile >= 2 && valueFromFile < 3)
                            {
                                valueFromFile = 0.4;
                            }
                            else if (valueFromFile >= 3 && valueFromFile < 4)
                            {
                                valueFromFile = 0.6;
                            }
                            else if (valueFromFile >= 4 && valueFromFile < 5)
                            {
                                valueFromFile = 0.8;
                            }
                            else
                            {
                                valueFromFile = 1.0;
                            }
                            chart1.Series[i].Points.Add(valueFromFile);
                        }
                        ++countRows;
                    }
                }

                readResult.Close();
            }

        }

        private void FormOutputResultDiagramUsers_Load(object sender, EventArgs e)
        {
        }
    }
}
