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
    public partial class Us_History : UserControl
    {
        public Us_History()
        {
            InitializeComponent();
        }

        private void Us_History_Load(object sender, EventArgs e)
        {
           us_Optimised_Table  HistoryTable = new us_Optimised_Table();
          us_HistoryCard HistoryCard= new us_HistoryCard();

            HistoryCard.Dock = DockStyle.Left;

            HistoryTable.Dock = DockStyle.Right;
            pnlscreen.Controls.Add(HistoryTable);
             pnlscreen.Controls.Add(HistoryCard);

        }

        private void pnlscreen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
