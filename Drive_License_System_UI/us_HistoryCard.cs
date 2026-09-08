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
    public partial class us_HistoryCard : UserControl
    {
        public us_HistoryCard()
        {
            InitializeComponent();
        }

       public  event Action SchedulingClick;
        private void guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void pnlfull_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnScheduling_Click(object sender, EventArgs e)
        {
            SchedulingClick.Invoke();
        }
    }
}
