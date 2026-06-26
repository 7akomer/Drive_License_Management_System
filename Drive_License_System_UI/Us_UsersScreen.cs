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
    public partial class Us_Users : UserControl
    {
        public Us_Users()
        {
            InitializeComponent();
        }

        private void Us_Users_Load(object sender, EventArgs e)
        {
            us_Optimised_Table UsersList = new us_Optimised_Table();
            us_PersonInformationCard userInfo = new us_PersonInformationCard();



            userInfo.Dock = DockStyle.Left;
            UsersList.Dock = DockStyle.Right;
            pnlscreen.Controls.Add(userInfo);
            pnlscreen.Controls.Add(UsersList);
        }

        private void pnlscreen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
