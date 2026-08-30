using Driver_License_System__Models;
using Driver_License_System_BLL;
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
    public partial class us_LicenseInformationCard : UserControl
    {
        public us_LicenseInformationCard()
        {
            InitializeComponent();
        }

        public Action ExitLicenseInformationCard;
        public Action HeldLicense;
        public Action RenewalLicense;

        private void pnlfull_Paint(object sender, PaintEventArgs e)
        {

        }




        private void us_LicenseInformationCard_Load(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox5_Click(object sender, EventArgs e)
        {
            ExitLicenseInformationCard.Invoke();
        }

        private void btnHeld_Click(object sender, EventArgs e)
        {
            HeldLicense.Invoke();
        }

        private void btnRenewal_Click(object sender, EventArgs e)
        {
            RenewalLicense.Invoke();
        }
    }
}
