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
    public partial class us_ManageAppInApplicationSenter : UserControl
    {
        public us_ManageAppInApplicationSenter()
        {
            InitializeComponent();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Us_Applications us_Applications = new Us_Applications();
            us_Applications.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(us_Applications);
            this.Parent.Controls.Remove(this);
        }

        private void us_ManageAppInApplicationSenter_Load(object sender, EventArgs e)
        {
            us_Optimised_Table ApplicantTable = new us_Optimised_Table();
            us_HistoryCard ApplicantCard = new us_HistoryCard();
            ApplicantCard.Dock = DockStyle.Left;
            ApplicantTable.Dock = DockStyle.Right;
            pnlscreen.Controls.Add(ApplicantTable);
            pnlscreen.Controls.Add(ApplicantCard);
        }

        private void pnlscreen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
