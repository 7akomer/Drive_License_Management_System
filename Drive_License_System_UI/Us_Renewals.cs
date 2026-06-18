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
    public partial class Us_Renewals : UserControl
    {
        public Us_Renewals()
        {
            InitializeComponent();
        }

        private void pnlscreen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Us_Renewals_Load(object sender, EventArgs e)
        {
          
            us_Optimised_Table ExpiredLicenses = new us_Optimised_Table();
            us_LicenseInformationCard ExpiredLicenseCard = new us_LicenseInformationCard();

           
          
            ExpiredLicenseCard.Dock = DockStyle.Left;
            ExpiredLicenses.Dock = DockStyle.Right;
            pnlscreen.Controls.Add(ExpiredLicenseCard);
            pnlscreen.Controls.Add(ExpiredLicenses);
        }
    }
}
