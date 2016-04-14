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
    public partial class FormOutputResultDiagramUsers : Form
    {
        public string m_strLogin;
        public string m_strOrientation;

        public FormOutputResultDiagramUsers()
        {
            InitializeComponent();
        }

        public FormOutputResultDiagramUsers(string login, string orientation)
        {
            InitializeComponent();

            m_strLogin = login;
            m_strOrientation = orientation;
        }

        private void FormOutputResultDiagramUsers_Load(object sender, EventArgs e)
        {
            string pathFile;

            if (m_strOrientation == "без нечеткой модели")
            {
                pathFile = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "result.txt");
            }
            else
            {
                pathFile = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "result_from_logic.txt");
            }

            StreamReader readFile = new StreamReader(pathFile);

            string orientation;
            int[] arrayPoints = new int[6];

            while (!readFile.EndOfStream)
            {
                orientation = readFile.ReadLine();
                for (int i = 0; i < 6; i++)
                {
                    arrayPoints[i] = Convert.ToInt16(readFile.ReadLine());
                }
            }

            for (int i = 0; i < 6; i++)
            {
                chart1.Series[i].Points.Add(arrayPoints[i]);
            }

            readFile.Close();
        }
    }
}
