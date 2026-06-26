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
    public partial class us_TakeTast : UserControl
    {
        public us_TakeTast()
        {
            InitializeComponent();
        }

        private void pnlfull_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel7_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void guna2Panel7_Click(object sender, EventArgs e)
        {
            btnPass.Checked = false;
            btnFill.Checked = false;

        }

        private void us_TakeTast_Load(object sender, EventArgs e)
        {
            ProgressTest.Value   = 84;
        }
    }
}
