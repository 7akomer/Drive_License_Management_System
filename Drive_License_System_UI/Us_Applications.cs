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
using System.Windows.Media.Media3D;

namespace Drive_License_System_UI
{
    public partial class Us_Applications : UserControl
    {
        public Us_Applications()
        {
            InitializeComponent();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picApplication_Click(object sender, EventArgs e)
        {

        }

        private void CenterPanel()
        {
            pnlOrderCard.Location = new Point(
                (this.Width - pnlOrderCard.Width) / 2,
                (this.Height - pnlOrderCard.Height) / 2
            );
        }

        private void Us_Applications_Load(object sender, EventArgs e)
        {
            CenterPanel();
        }
        //private void CenterTitle()
        //{
        //    lblTitle.Location = new Point(
        //       (this.Width - lblTitle.Width) / 2,
        //        (this.Height - lblTitle.Height) / 2);

        //    lblSubtitle.Location = new Point(
        //       (this.Width - lblSubtitle.Width) / 2,
        //        (this.Height - lblSubtitle.Height) / 2);

        //    picApplication.Location = new Point(
        //          (this.Width - picApplication.Width) / 2,
        //        (this.Height - picApplication.Height) / 2);



        //}

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlOrderCard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlHeader_Resize(object sender, EventArgs e)
        {
         //   CenterTitle();
        }
    }
}
