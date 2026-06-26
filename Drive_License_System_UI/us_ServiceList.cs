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
    public partial class us_ServiceList : UserControl
    {
        public us_ServiceList()
        {
            InitializeComponent();
        }

        private void btnNewLocalLicense_Click(object sender, EventArgs e)
        {
           pnlServiceList.Controls.Clear();
            
            us_NewLocalLicense newLocalLicense = new us_NewLocalLicense();
            newLocalLicense.Dock = DockStyle.Fill;
            pnlServiceList.Controls.Add(newLocalLicense);


        }

        private void btnNewInternationalLicense_Click(object sender, EventArgs e)
        {
            pnlServiceList.Controls.Clear();

            us_NewInternationalLicense newInternationalLicense = new us_NewInternationalLicense();
            newInternationalLicense.Dock = DockStyle.Fill;
            pnlServiceList.Controls.Add(newInternationalLicense);

        }

        private void btnReplacement_Click(object sender, EventArgs e)
        {
            pnlServiceList.Controls.Clear();

            us_Replacement newReplacement = new us_Replacement();
            newReplacement.Dock = DockStyle.Fill;
            pnlServiceList.Controls.Add(newReplacement);


        }

        private void btnRetakeTest_Click(object sender, EventArgs e)
        {
            Drive_License_App_Start newDrive_License_App_Start = new Drive_License_App_Start();
            us_RetakTest newRetakTest = new us_RetakTest();
            Us_Applications.ShowRetakTest();

        }

        private void pnlServiceList_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
