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
    public partial class FormLoginPassword : Form
    {
        public FormLoginPassword()
        {
            InitializeComponent();
        }

        private void FormLoginPassword_Load(object sender, EventArgs e)
        {
            StreamReader readLoginPass = new StreamReader(Path.GetFullPath(@"InfoUsers\AllUsers.txt"), false);

            int rows = 0;
            ++dataGridView1.RowCount;

            while (!readLoginPass.EndOfStream)
            {
                dataGridView1.Rows[rows].Cells[0].Value = readLoginPass.ReadLine();
                dataGridView1.Rows[rows].Cells[1].Value = readLoginPass.ReadLine();
                dataGridView1.Rows[rows].Cells[2].Value = readLoginPass.ReadLine();

                ++dataGridView1.RowCount;
                ++rows;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pathFileForEncryption = Path.GetFullPath(@"InfoUsers\AllUsers.txt");

            StreamReader readFileForEncryption = new StreamReader(pathFileForEncryption);

            string contentFile = "";

            while (!readFileForEncryption.EndOfStream)
            {
                contentFile += readFileForEncryption.ReadLine();
            }

            readFileForEncryption.Close();

                uint k = 0;
                //Строка, к которой применяется шифрованияе/дешифрование
         
                //Строка - результат шифрования/дешифрования
                string result = "";
                //Величина сдвига при шифровании/дешифровании
                uint shift;
                //Вывод сообщения на экран
                 shift = 5;
                //Если выбрано шифрование

                    for (int i = 0; i < contentFile.Length; i++)
                    {
                        //Если не кириллица
                        if (((int)(contentFile[i]) < 1040)||((int)(contentFile[i])>1103))
                            result += contentFile[i];
                        //Если буква является строчной
                        if ((Convert.ToInt16(contentFile[i]) >= 1072) && (Convert.ToInt16(contentFile[i]) <= 1103))
                        {
                            //Если буква, после сдвига выходит за пределы алфавита
                            if (Convert.ToInt16(contentFile[i]) + shift > 1103)
                                //Добавление в строку результатов символ
                                result += Convert.ToChar(Convert.ToInt16(contentFile[i]) + shift - 32);
                            //Если буква может быть сдвинута в пределах алфавита
                            else
                                //Добавление в строку результатов символ
                                result += Convert.ToChar(Convert.ToInt16(contentFile[i]) + shift);
                        }
                        //Если буква является прописной
                        if ((Convert.ToInt16(contentFile[i]) >= 1040) && (Convert.ToInt16(contentFile[i]) <= 1071))
                        {
                            //Если буква, после сдвига выходит за пределы алфавита
                            if (Convert.ToInt16(contentFile[i]) + shift > 1071)
                                //Добавление в строку результатов символ
                                result += Convert.ToChar(Convert.ToInt16(contentFile[i]) + shift - 32);
                            //Если буква может быть сдвинута в пределах алфавита
                            else
                                //Добавление в строку результатов символ
                                result += Convert.ToChar(Convert.ToInt16(contentFile[i]) + shift);
                        }
                    }
                
                StreamWriter writeDecryption = new StreamWriter(Path.GetFullPath(@"InfoUsers\allusers_decryption.txt"), false);
                
                writeDecryption.WriteLine(result);

                writeDecryption.Close();

                MessageBox.Show("Успешно зашыфровано");

           }

        private void button2_Click(object sender, EventArgs e)
        {

             uint k = 0;
                //Строка, к которой применяется шифрованияе/дешифрование
                //Строка - результат шифрования/дешифрования
                string result = "";
                //Величина сдвига при шифровании/дешифровании
                uint shift;

                 shift = 5;
                //Если выбрано шифрование

                string pathFileForEncryption = Path.GetFullPath(@"InfoUsers\allusers_decryption.txt");

            StreamReader readFileForEncryption = new StreamReader(pathFileForEncryption);

            string contentFile = "";

            while (!readFileForEncryption.EndOfStream)
            {
                contentFile += readFileForEncryption.ReadLine();
            }

            readFileForEncryption.Close();
 
                    for (int i = 0; i < contentFile.Length; i++)
                    {
                        if (Convert.ToInt16(contentFile[i]) == 32)
                            result += ' ';
                        //Если буква является строчной
                        if ((Convert.ToInt16(contentFile[i]) >= 1072) && (Convert.ToInt16(contentFile[i]) <= 1103))
                        {
                            //Если буква, после сдвига выходит за пределы алфавита
                            if (Convert.ToInt16(contentFile[i]) - shift < 1072)
                                //Добавление в строку результатов символ
                                result += Convert.ToChar(Convert.ToInt16(contentFile[i]) - shift + 32);
                            //Если буква может быть сдвинута в пределах алфавита
                            else
                                //Добавление в строку результатов символ
                                result += Convert.ToChar(Convert.ToInt16(contentFile[i]) - shift);
                        }
                        //Если буква является прописной
                        if ((Convert.ToInt16(contentFile[i]) >= 1040) && (Convert.ToInt16(contentFile[i]) <= 1071))
                        {
                            //Если буква, после сдвига выходит за пределы алфавита
                            if (Convert.ToInt16(contentFile[i]) - shift < 1040)
                                //Добавление в строку результатов символ
                                result += Convert.ToChar(Convert.ToInt16(contentFile[i]) - shift + 32);
                            //Если буква может быть сдвинута в пределах алфавита
                            else
                                //Добавление в строку результатов символ
                                result += Convert.ToChar(Convert.ToInt16(contentFile[i]) - shift);
                        }
                    }

            StreamWriter writeDecryption = new StreamWriter(Path.GetFullPath(@"InfoUsers\allusers_decipherment.txt"), false);
                
                writeDecryption.WriteLine(result);

                writeDecryption.Close();

                MessageBox.Show("Успешно розшыфровано");
        }
    }
}

