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
    public partial class Us_LicenseDetain : UserControl
    {
        public Us_LicenseDetain()
        {
            InitializeComponent();
        }

        private void pnlscreen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Us_LicenseDetain_Click(object sender, EventArgs e)
        {

        }

        private void Us_LicenseDetain_Load(object sender, EventArgs e)
        {
            us_Optimised_Table Detain = new us_Optimised_Table();
            us_LocalLicenses License = new us_LocalLicenses();



            License.Dock = DockStyle.Left;
            Detain.Dock = DockStyle.Right;
            pnlscreen.Controls.Add(License);
            pnlscreen.Controls.Add(Detain);
        }
    }
}
