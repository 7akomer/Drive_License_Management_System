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
    public partial class Us_Persens : UserControl
    {
        public Us_Persens()
        {
            InitializeComponent();
        }

        private void Us_Persens_Load(object sender, EventArgs e)
        {
            us_Optimised_Table Persens = new us_Optimised_Table();
            us_PersonInformationCard userInfo = new us_PersonInformationCard();



            userInfo.Dock = DockStyle.Left;
            Persens.Dock = DockStyle.Right;
            pnlscreen.Controls.Add(userInfo);
            pnlscreen.Controls.Add(Persens);
        }
    }
}
