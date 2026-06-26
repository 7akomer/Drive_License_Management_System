using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drive_License_System_UI
{
    public partial class us_RetakTest : UserControl
    {
        public us_RetakTest()
        {
            InitializeComponent();
        }

        private void us_RetakTest_Load(object sender, EventArgs e)
        {
            us_Optimised_Table Listofthosewhofailed = new us_Optimised_Table();
            us_HistoryCard ApplicantCard = new us_HistoryCard();
            ApplicantCard.Dock = DockStyle.Left;
            Listofthosewhofailed.Dock = DockStyle.Right;
            pnlscreen.Controls.Add(Listofthosewhofailed);
            pnlscreen.Controls.Add(ApplicantCard);
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Us_Applications.GoBackToApplicaionCenter();
        }
    }
}
