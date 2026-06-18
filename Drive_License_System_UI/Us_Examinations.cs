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
    public partial class Us_Examinations : UserControl
    {
        public Us_Examinations()
        {
            InitializeComponent();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Us_Examinations_Load(object sender, EventArgs e)
        {
            us_Optimised_Table exam = new us_Optimised_Table();
            us_TakeTast Taketest = new us_TakeTast();



            Taketest.Dock = DockStyle.Left;
            exam.Dock = DockStyle.Right;
            pnlscreen.Controls.Add(Taketest);
            pnlscreen.Controls.Add(exam);
        }

        private void pnlscreen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
