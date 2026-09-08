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
    public partial class us_LicenseDetainCard : UserControl
    {
        public us_LicenseDetainCard()
        {
            InitializeComponent();
        }

        public Action ExitLicenseReleaseCard;
        public Action ReleaseLicense;


        private void pnlfull_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            ExitLicenseReleaseCard.Invoke();

        }

        private void btnHeld_Click(object sender, EventArgs e)
        {
            ReleaseLicense.Invoke();
        }
    }
}
