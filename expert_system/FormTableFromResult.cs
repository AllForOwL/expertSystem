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
    public partial class FormTableFromResult : Form
    {
        int m_iNumberYears;
        int m_iTypeTest;
        string m_strLogin;
        string m_strTest;
        bool m_blAnswer;
        string m_strOrientation;
        int m_iOrientation;

        public FormTableFromResult(string typeTests, string login, string orientation)
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
                    ++dataGridView1.RowCount;
                    double valueFromFile = 0.0;
                    while (!readResult.EndOfStream)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            valueFromFile = Math.Round(Convert.ToDouble(readResult.ReadLine()), 2);
                            dataGridView1.Rows[countRows].Cells[i].Value = valueFromFile.ToString();
                        }

                        ++dataGridView1.RowCount;
                        ++countRows;
                    }
                }
                else //  нечеткая модель
                {
                    ++dataGridView1.RowCount;
                    double valueFromFile = 0.0;
                    while (!readResult.EndOfStream)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            valueFromFile = Convert.ToDouble(readResult.ReadLine());

                            if (valueFromFile >= 0 && valueFromFile < 2)
                            {
                                valueFromFile = 0.3;
                            }
                            else if (valueFromFile >= 2 && valueFromFile < 4)
                            {
                                valueFromFile = 0.6;
                            }
                            else if (valueFromFile >= 4 && valueFromFile < 5)
                            {
                                valueFromFile = 0.9;
                            }
                            else if (valueFromFile >= 5 && valueFromFile <= 6)
                            {
                                valueFromFile = 1.0;
                            }
                            dataGridView1.Rows[countRows].Cells[i].Value = valueFromFile.ToString();
                        }

                        ++dataGridView1.RowCount;
                        ++countRows;
                    }
                }

                readResult.Close();
            }
        }

        public FormTableFromResult(string typeTests, string login, int orientation)
        {
            InitializeComponent();

            string pathFile;

                // определяем кого показывать результат(дошкольник, родитель, или обоих)
            if (orientation == 0)   // дошкольник
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
                }
                else
                {
                    f_arrlistUsers.Add(login);
                }

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
                        ++dataGridView1.RowCount;
                        
                        double valueFromFile = 0.0;
                        while (!readResult.EndOfStream)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                valueFromFile = Convert.ToDouble(readResult.ReadLine());
                                dataGridView1.Rows[countRows].Cells[i].Value = valueFromFile.ToString();
                            }

                            ++dataGridView1.RowCount;
                            ++countRows;
                        }
                    }
                    else // дошкольник + нечеткая модель
                    {
                        ++dataGridView1.RowCount;
                        double valueFromFile = 0.0;
                        while (!readResult.EndOfStream)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                valueFromFile = Convert.ToDouble(readResult.ReadLine());

                                if (valueFromFile >= 0 && valueFromFile < 2)
                                {
                                    valueFromFile = 0.3;
                                }
                                else if (valueFromFile >= 2 && valueFromFile < 4)
                                {
                                    valueFromFile = 0.6;
                                }
                                else if (valueFromFile >= 4 && valueFromFile < 5)
                                {
                                    valueFromFile = 0.9;
                                }
                                else
                                {
                                    valueFromFile = 1.0;
                                }
                                dataGridView1.Rows[countRows].Cells[i].Value = valueFromFile.ToString();
                            }

                            ++dataGridView1.RowCount;
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
                }
                else
                {
                    f_arrlistUsers.Add(login);
                }

                for (int countUsers = 0; countUsers < f_arrlistUsers.Count; countUsers++)
                {

                    pathFile = Path.GetFullPath(@"InfoUsers\" + f_arrlistUsers[countUsers] + "result_preschool_parentparent.txt");

                    if (!File.Exists(pathFile))
                    {
                        MessageBox.Show("Тест не был пройден!");
                        return;
                    }

                    StreamReader readResult = new StreamReader(pathFile);

                    if (typeTests == "без нечеткой модели")
                    {
                        ++dataGridView1.RowCount;
                        double valueFromFile = 0.0;
                        while (!readResult.EndOfStream)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                valueFromFile = Math.Round(Convert.ToDouble(readResult.ReadLine()),2);
                                dataGridView1.Rows[countRows].Cells[i].Value = valueFromFile.ToString();
                            }

                            ++dataGridView1.RowCount;
                            ++countRows;
                        }
                    }
                    else // дошкольник + нечеткая модель
                    {
                        ++dataGridView1.RowCount;
                        double valueFromFile = 0.0;
                        while (!readResult.EndOfStream)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                valueFromFile = Convert.ToDouble(readResult.ReadLine());

                                if (valueFromFile >= 0 && valueFromFile < 2)
                                {
                                    valueFromFile = 0.3;
                                }
                                else if (valueFromFile >= 2 && valueFromFile < 4)
                                {
                                    valueFromFile = 0.6;
                                }
                                else if (valueFromFile >= 4 && valueFromFile < 5)
                                {
                                    valueFromFile = 0.9;
                                }
                                else
                                {
                                    valueFromFile = 1.0;
                                }
                                dataGridView1.Rows[countRows].Cells[i].Value = valueFromFile.ToString();
                            }

                            ++dataGridView1.RowCount;
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
                }
                else
                {
                    f_arrlistUsers.Add(login);
                }

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
                        ++dataGridView1.RowCount;

                        double valueFromFile = 0.0;
                        while (!readResult.EndOfStream)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                valueFromFile = Math.Round(Convert.ToDouble(readResult.ReadLine()), 2);
                                dataGridView1.Rows[countRows].Cells[i].Value = valueFromFile.ToString();
                            }

                            ++dataGridView1.RowCount;
                            ++countRows;
                        }
                    }
                    else // дошкольник + нечеткая модель
                    {
                        ++dataGridView1.RowCount;
                        double valueFromFile = 0.0;
                        while (!readResult.EndOfStream)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                valueFromFile = Convert.ToDouble(readResult.ReadLine());

                                if (valueFromFile >= 0 && valueFromFile < 2)
                                {
                                    valueFromFile = 0.3;
                                }
                                else if (valueFromFile >= 2 && valueFromFile < 4)
                                {
                                    valueFromFile = 0.6;
                                }
                                else if (valueFromFile >= 4 && valueFromFile < 5)
                                {
                                    valueFromFile = 0.9;
                                }
                                else
                                {
                                    valueFromFile = 1.0;
                                }
                                dataGridView1.Rows[countRows].Cells[i].Value = valueFromFile.ToString();
                            }

                            ++dataGridView1.RowCount;
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
                    f_arrlistUsers.Add(login);
                }

                for (int countUsers = 0; countUsers < f_arrlistUsers.Count; countUsers++)
                {

                    pathFile = Path.GetFullPath(@"InfoUsers\" + f_arrlistUsers[countUsers] + "result_preschool_parentparent.txt");

                    if (!File.Exists(pathFile))
                    {
                        MessageBox.Show("Тест не был пройден!");
                        return;
                    }

                    StreamReader readResult = new StreamReader(pathFile);

                    if (typeTests == "без нечеткой модели")
                    {
                        ++dataGridView1.RowCount;
                        double valueFromFile = 0.0;
                        while (!readResult.EndOfStream)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                valueFromFile = Convert.ToDouble(readResult.ReadLine());
                                dataGridView1.Rows[countRows].Cells[i].Value = valueFromFile.ToString();
                            }

                            ++dataGridView1.RowCount;
                            ++countRows;
                        }
                    }
                    else // дошкольник + нечеткая модель
                    {
                        ++dataGridView1.RowCount;
                        double valueFromFile = 0.0;
                        while (!readResult.EndOfStream)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                valueFromFile = Convert.ToDouble(readResult.ReadLine());

                                if (valueFromFile >= 0 && valueFromFile < 2)
                                {
                                    valueFromFile = 0.3;
                                }
                                else if (valueFromFile >= 2 && valueFromFile < 4)
                                {
                                    valueFromFile = 0.6;
                                }
                                else if (valueFromFile >= 4 && valueFromFile < 5)
                                {
                                    valueFromFile = 0.9;
                                }
                                else
                                {
                                    valueFromFile = 1.0;
                                }
                                dataGridView1.Rows[countRows].Cells[i].Value = valueFromFile.ToString();
                            }

                            ++dataGridView1.RowCount;
                            ++countRows;
                        }
                    }

                    readResult.Close();
                }
            }
            }

        public FormTableFromResult(string strTypeTest, string orientation)
        {
            InitializeComponent();

            m_strTest = strTypeTest;
            m_strOrientation = orientation;

            ++dataGridView1.ColumnCount;
            dataGridView1.RowHeadersWidth = 50;

            int columnCount = dataGridView1.ColumnCount;

            string pathFileAll = Path.GetFullPath(@"InfoUsers\Allresult_" + m_strOrientation + ".txt");

            if (!File.Exists(pathFileAll))
            {
                MessageBox.Show("Тест ещё никто не проходил");
                return;
            }

            StreamReader readResultOnOrientationAll = new StreamReader(pathFileAll);

            int rows = 0;

            dataGridView1.Columns[6].HeaderCell.Value = "Логин";

            while (!readResultOnOrientationAll.EndOfStream)
            {
                ++dataGridView1.RowCount;
                dataGridView1.Rows[rows].Cells[6].Value = readResultOnOrientationAll.ReadLine();

                double valueFromFile = 0.0;
                double valueForTable_2 = 0.0;

                for (int i = 0; i < 6; i++)
                {
                    ++dataGridView1.RowCount;
                    double vv = Convert.ToDouble(readResultOnOrientationAll.ReadLine());
                    valueFromFile = Convert.ToInt16(vv);

                    if (m_strTest == "нечеткая модель")
                    {
                        if (valueFromFile >= 0.0 && valueFromFile < 1.0)
                        {
                            valueForTable_2 = 0.0;
                            dataGridView1.Rows[rows].Cells[i].Value = valueForTable_2.ToString();
                        }
                        else if (valueFromFile >= 1.0 && valueFromFile < 2.0)
                        {
                            valueForTable_2 = 0.2;
                            dataGridView1.Rows[rows].Cells[i].Value = valueForTable_2.ToString();
                        }
                        else if (valueFromFile >= 2.0 && valueFromFile < 3.0)
                        {
                            valueForTable_2 = 0.4;
                            dataGridView1.Rows[rows].Cells[i].Value = valueForTable_2.ToString();
                        }
                        else if (valueFromFile >= 3.0 && valueFromFile < 4.0)
                        {
                            valueForTable_2 = 0.6;
                            dataGridView1.Rows[rows].Cells[i].Value = valueForTable_2.ToString();
                        }
                        else if (valueFromFile >= 4.0 && valueFromFile < 5.0)
                        {
                            valueForTable_2 = 0.8;
                            dataGridView1.Rows[rows].Cells[i].Value = valueForTable_2.ToString();
                        }
                        else if (valueFromFile >= 5.0)
                        {
                            valueForTable_2 = 1.0;
                            dataGridView1.Rows[rows].Cells[i].Value = valueForTable_2.ToString();
                        }

                        valueFromFile = 0.0;
                        valueForTable_2 = 0.0;
                    }
                }
                ++rows;
                dataGridView1.Rows[rows-1].HeaderCell.Value = rows.ToString();
            }
            
            readResultOnOrientationAll.Close();   
        }

        public FormTableFromResult(string loginUser, int typeTest, string strTypeTest, bool answer, int count)
        {
            InitializeComponent();

            if (loginUser == "root")
            {
                m_strTest = strTypeTest;

                ++dataGridView1.ColumnCount;
                dataGridView1.RowHeadersWidth = 50;

                int columnCount = dataGridView1.ColumnCount;

                string pathFileAll = Path.GetFullPath(@"InfoUsers\Allresult_" + strTypeTest + ".txt");

                if (!File.Exists(pathFileAll))
                {
                    MessageBox.Show("Тест ещё никто не проходил");
                    return;
                }

                StreamReader readResultOnOrientationAll = new StreamReader(pathFileAll);

                int rows = 0;

                dataGridView1.Columns[6].HeaderCell.Value = "Логин";

                while (!readResultOnOrientationAll.EndOfStream)
                {
                    ++dataGridView1.RowCount;
                    dataGridView1.Rows[rows].Cells[6].Value = readResultOnOrientationAll.ReadLine();

                    for (int i = 0; i < 6; i++)
                    {
                        ++dataGridView1.RowCount;
                        double vv = Convert.ToDouble(readResultOnOrientationAll.ReadLine());
                        int b = Convert.ToInt16(vv);
                        dataGridView1.Rows[rows].Cells[i].Value = b.ToString();
                    }
                    ++rows;
                    dataGridView1.Rows[rows - 1].HeaderCell.Value = rows.ToString();
                }

                readResultOnOrientationAll.Close();
                return;
            }

            m_strLogin = loginUser;
            m_iTypeTest = typeTest;
            m_strTest = strTypeTest;
            m_blAnswer = answer;
            int preschool_or_parent = 999;

            if (count == 3)
            {
                preschool_or_parent = 36;
            }
            else if (count == 4)
            {
                preschool_or_parent = 18;
            }

            string nameOrientation = "";

            switch (m_iTypeTest)
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



            if (m_blAnswer)
            {
                string pathFileAnswer = Path.GetFullPath(@"InfoUsers\answer_" + nameOrientation + m_strLogin + ".txt");

                if (!File.Exists(pathFileAnswer))
                {
                    MessageBox.Show("Нету результатов в данном тесте");
                    return;
                }
                
                StreamReader readResultOnOrientationAnswer = new StreamReader(pathFileAnswer);

                if (m_iTypeTest == 0)
                {
                    dataGridView1.ColumnCount = 2;
                }
                else
                {
                    dataGridView1.ColumnCount = 1;
                }

                if (m_iTypeTest == 3)
                {
                    preschool_or_parent = 36;
                }
                else if (preschool_or_parent == 4)
                {
                    preschool_or_parent = 18;
                }

                dataGridView1.Columns[0].HeaderCell.Value = "";
                dataGridView1.RowHeadersWidth = 50;

                int rowsInTable = 1;
                int rowsAll = 0;
                int cells = 0;

                int countAllAnswer = 0;
                int countAnswer = 0;
                string strAnswer   = " ";
                bool setCOuntAnswer = true;

                int countAnswer_ = 99999;

                while (!readResultOnOrientationAnswer.EndOfStream)
                {
                    --preschool_or_parent;
                    if (preschool_or_parent == 0)
                    {
                        break;
                    }

                    ++dataGridView1.RowCount;
                    if (setCOuntAnswer)
                    {
                        ++countAllAnswer;
                        dataGridView1.Rows[rowsAll].HeaderCell.Value = countAllAnswer.ToString();
                    }

                    countAnswer = Convert.ToInt16(readResultOnOrientationAnswer.ReadLine());

                    if (countAnswer == 1)
                    {
                        strAnswer = "да";
                    }
                    else if (countAnswer == 2)
                    {
                        strAnswer = "скорее да";
                    }
                    else if (countAnswer == 3)
                    {
                        strAnswer = "не знаю";
                    }
                    else if (countAnswer == 4)
                    {
                        strAnswer = "скорее нет";
                    }
                    else
                    {
                        strAnswer = "нет";
                    }

                    dataGridView1.Rows[rowsAll].Cells[cells].Value = strAnswer;

                    ++rowsInTable;
                    ++rowsAll;

                    if (rowsInTable == countAnswer_)
                    {
                        rowsInTable = 0;
                        ++dataGridView1.RowCount;
                        cells = 0;
                        countAnswer_ = 999999;
                        countAllAnswer = 0;
                      
                    }
                    else  if (rowsInTable == 37 && nameOrientation == "preschool_parent")
                    {
                        cells = 1;
                        rowsInTable = 0;
                        rowsAll = 0;
                        countAnswer_ = 18;
                        setCOuntAnswer = false;
                    }
                    else if (rowsInTable == 37)
                    {
                        rowsInTable = 0;
                        ++dataGridView1.RowCount;
                        cells = 0;
                        setCOuntAnswer = true;
                    }
                }


                readResultOnOrientationAnswer.Close();
                this.Show();
                return;
            }

            string pathFile = "";
            if (m_strTest == "нечеткая модель" || m_strTest == "Matlab")
            {
                pathFile = Path.GetFullPath(@"InfoUsers\" + m_strLogin + nameOrientation+ "result_from_logic.txt");

                if (!File.Exists(pathFile))
                {
                    MessageBox.Show("Тест не был пройден");
                    return;
                }

                StreamReader readFileForFuzzy = new StreamReader(pathFile);
               
                double valueFromFile;
                int rowsInTable = 0;
                double valueForTable = 0.0;
                double valueForTable_2 = 0.0;

               while (!readFileForFuzzy.EndOfStream)
               {
                    ++dataGridView1.RowCount;
                    for (int i = 0; i < 6; i++)
                    {
                        --preschool_or_parent;
                        if (preschool_or_parent == 0)
                        {
                            break;
                        }

                        valueForTable_2 = 0.0;
                        valueFromFile = Convert.ToDouble(readFileForFuzzy.ReadLine());
                        //MessageBox.Show(valueForTable.ToString());

                        if (valueFromFile >= 0.0 && valueFromFile < 1.0)
                        {
                            valueForTable_2 = 0.0;
                            dataGridView1.Rows[rowsInTable].Cells[i].Value = valueForTable_2.ToString();
                        }
                        else if (valueFromFile >= 1.0 && valueFromFile < 2.0)
                        {
                            valueForTable_2 = 0.2;
                            dataGridView1.Rows[rowsInTable].Cells[i].Value = valueForTable_2.ToString();
                        }
                        else if (valueFromFile >= 2.0 && valueFromFile < 3.0)
                        {
                            valueForTable_2 = 0.4;
                            dataGridView1.Rows[rowsInTable].Cells[i].Value = valueForTable_2.ToString();
                        }
                        else if (valueFromFile >= 3.0 && valueFromFile < 4.0)
                        {
                            valueForTable_2 = 0.6;
                            dataGridView1.Rows[rowsInTable].Cells[i].Value = valueForTable_2.ToString();
                        }
                        else if (valueFromFile >= 4.0 && valueFromFile < 5.0)
                        {
                            valueForTable_2 = 0.8;
                            dataGridView1.Rows[rowsInTable].Cells[i].Value = valueForTable_2.ToString();
                        }
                        else if (valueFromFile >= 5.0)
                        {
                            valueForTable_2 = 1.0;
                            dataGridView1.Rows[rowsInTable].Cells[i].Value = valueForTable_2.ToString();
                        }
                    }
                    valueForTable = 0;
                    ++rowsInTable;
                }

                readFileForFuzzy.Close();
            }
            else
            {
                String pathFile3 = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "result_" + nameOrientation + ".txt");

                if (!File.Exists(pathFile3))
                {
                    MessageBox.Show("Тест не был пройден");
                    return;
                }

                StreamReader readFile = new StreamReader(pathFile3);

               // int valueFromFile;
                int rowsInTable = 0;
               // double valueForTable = 0.0;
                string tempOrientation;

                while (!readFile.EndOfStream)
                {
                    if (count == 3 && rowsInTable <= 6)
                    {
                      
                        for (int i = 0; i < 6; i++)
                        {
                            // --preschool_or_parent;
                            ++dataGridView1.RowCount;
                            tempOrientation = readFile.ReadLine();
                            dataGridView1.Rows[rowsInTable].Cells[i].Value = readFile.ReadLine();
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            // --preschool_or_parent;
                            readFile.ReadLine();
                        }
                        //if (preschool_or_parent == 0)
                        //{
                         //   break;
                        //}
                        //++rowsInTable;
                    }
                    else if (count == 4 && rowsInTable <= 6)
                    {
                            for (int i = 0; i < 6; i++)
                            {
                                readFile.ReadLine();
                            }

    
                            for (int i = 0; i < 6; i++)
                            {
                                // --preschool_or_parent;
                                ++dataGridView1.RowCount;
                                tempOrientation = readFile.ReadLine();
                                dataGridView1.Rows[rowsInTable].Cells[i].Value = readFile.ReadLine();
                            }
                            
                    }
                     else if (count == 0)
                     {
                        ++dataGridView1.RowCount;
                           tempOrientation = readFile.ReadLine();
                            // --preschool_or_parent;
                           
                         //int i = 0;
                         for (int i = 0; i < 6; i++)
                         {
                         //     ++dataGridView1.RowCount;
                            dataGridView1.Rows[rowsInTable].Cells[i].Value = readFile.ReadLine();
                         }

                         ++dataGridView1.RowCount;
                         ++rowsInTable;

                         for (int i = 0; i < 6; i++)
                         {
                             //     ++dataGridView1.RowCount;
                             dataGridView1.Rows[rowsInTable].Cells[i].Value = readFile.ReadLine();
                         }

                        }

                rowsInTable = 0;
                }

                readFile.Close();
              }
            this.Show();
        }

        public FormTableFromResult(string loginUser, int numberYears)
        {
            InitializeComponent();

            m_iNumberYears = numberYears;
            m_strLogin = loginUser;
            string nameOrientation = "";

            switch (m_iNumberYears)
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

            string pathFile = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "result_" + nameOrientation + ".txt");

            StreamReader readFile = new StreamReader(pathFile);

            int rowsInTable = 0;
            int colsInTable = 0;

            dataGridView1.RowCount += 2;

            while (!readFile.EndOfStream)
            {
                dataGridView1.Rows[rowsInTable].Cells[colsInTable].Value = readFile.ReadLine();

                ++colsInTable;

                if (colsInTable == 6)
                {
                    colsInTable = 0;
                    ++rowsInTable;
                    dataGridView1.RowCount += 1;
                }
            }

        }

        private void FormTableFromResult_Load(object sender, EventArgs e)
        {

        }
    }
}
