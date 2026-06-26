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
    public partial class Us_Drivers : UserControl
    {
        public Us_Drivers()
        {
            InitializeComponent();
        }

        private void Us_Drivers_Load(object sender, EventArgs e)
        {
            us_Optimised_Table drivers = new us_Optimised_Table();
            us_DriverInformationCard Drivers = new us_DriverInformationCard();



            Drivers.Dock = DockStyle.Left;
            drivers.Dock = DockStyle.Right;
            pnlscreen.Controls.Add(Drivers);
            pnlscreen.Controls.Add(drivers);
        }

        private void pnlscreen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
