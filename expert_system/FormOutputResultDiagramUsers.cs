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
        public int m_iCount;
        public string m_strLogin;
        public string m_strOrientation;
        public string m_strTypeTest;
        public string[] m_arrayAccount = new string[30];

        public FormOutputResultDiagramUsers()
        {
            InitializeComponent();
            m_strTypeTest = "";
        }

        public FormOutputResultDiagramUsers(string login, string orientation)
        {
            InitializeComponent();

            m_strLogin = login;
            m_strOrientation = orientation;
            m_strTypeTest = "";
        }

        public FormOutputResultDiagramUsers(string login, string typeTest, string orientation, int iCount)
        {
            InitializeComponent();

            m_strLogin = login;
            m_strTypeTest = typeTest;
            m_strOrientation = orientation;
            m_iCount = iCount;
        }

        private void FormOutputResultDiagramUsers_Load(object sender, EventArgs e)
        {
            string pathFile = Path.GetFullPath(@"InfoUsers\" + m_strLogin + "result_" + m_strOrientation + ".txt");

            double[] f_arrResultTests = new double[6];

            StreamReader readResult = new StreamReader(pathFile);

            for (int i = 0; i < 6; i++)
            {
                f_arrResultTests[i] = Convert.ToDouble(readResult.ReadLine());
            }

            for (int i = 0; i < 6; i++)
            {
                chart1.Series[i].Points.Add(f_arrResultTests[i]);
            }

            readResult.Close();
        }
    }
}
