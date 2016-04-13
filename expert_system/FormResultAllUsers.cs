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
    public partial class FormResultAllUsers : Form
    {
        public FormResultAllUsers()
        {
            InitializeComponent();
        }

        private void FormResultAllUsers_Load(object sender, EventArgs e)
        {
            StreamReader readLoginAllUsers = new StreamReader(Path.GetFullPath(@"InfoUsers\surname_FIO.txt"));

            string surname;
            string login;
            int numberLine = 1;
            int numberLineInTable = 0;
            int valueFromFile;

            string direction = "";
            int maxDirection;

            while (!readLoginAllUsers.EndOfStream)
            {
                maxDirection = 0;
                surname = readLoginAllUsers.ReadLine();
                login = readLoginAllUsers.ReadLine();

                StreamReader readResultUsers = new StreamReader(Path.GetFullPath(@"InfoUsers\result_" + login + ".txt"));

                while (!readResultUsers.EndOfStream)
                {
                    for (int i = 1; i < 7; i++)
                    {
                        valueFromFile = Int16.Parse(readResultUsers.ReadLine());
                        if (valueFromFile > maxDirection)
                        {
                            numberLine = i;
                            maxDirection = valueFromFile;
                        }
                    }

                    switch (numberLine)
                    {
                        case 1:
                            {
                                direction = "творческий";

                                break;
                            }
                        case 2:
                            {
                                direction = "гуманитарный";

                                break;
                            }

                        case 3:
                            {
                                direction = "лингвистический";

                                break;
                            }

                        case 4:
                            {
                                direction = "математический";

                                break;
                            }

                        case 5:
                            {
                                direction = "спортивный";

                                break;
                            }

                        case 6:
                            {
                                direction = "технический";

                                break;
                            }
                    }

                    ++dataGridView1.RowCount;

                    dataGridView1.Rows[numberLineInTable].Cells[0].Value = surname;
                    dataGridView1.Rows[numberLineInTable].Cells[1].Value = maxDirection;
                    dataGridView1.Rows[numberLineInTable].Cells[2].Value = direction;

                    ++numberLineInTable;
                }
                readResultUsers.Close();
            }
            readLoginAllUsers.Close();
        }
    }
}
