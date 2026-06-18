using Guna.UI2.WinForms;
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
    public partial class Us_Licenses : UserControl
    {
        public Us_Licenses()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();
        }

        private void tblLicenses_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlscreen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Us_Licenses_Load(object sender, EventArgs e)
        {
            us_LocalLicenses testTable1 = new us_LocalLicenses();
            us_Optimised_Table testTable2 = new us_Optimised_Table();

            testTable2.Dock = DockStyle.Right;

            testTable1.Dock = DockStyle.Left;
            pnlscreen.Controls.Add(testTable1);
            pnlscreen.Controls.Add(testTable2);

        }

        private void LabelLicenseNoRowLocalLicense_Click(object sender, EventArgs e)
        {

        }

        private void cxbLocalLicenseFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
