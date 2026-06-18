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

        private void lblService_List_MouseEnter(object sender, EventArgs e)
        {
            lblService_List.FillColor = System.Drawing.Color.FromArgb(18, 42, 111);

        }

        private void lblService_List_MouseLeave(object sender, EventArgs e)
        {
            lblService_List.FillColor = System.Drawing.Color.FromArgb(10, 27, 77);
        }

        private void lblManage_Application_MouseEnter(object sender, EventArgs e)
        {
            lblManage_Application.FillColor = System.Drawing.Color.FromArgb(90, 70, 180);

        }

     

        private void lblManage_Application_MouseLeave_1(object sender, EventArgs e)
        {
            lblManage_Application.FillColor = System.Drawing.Color.FromArgb(10, 27, 77);

        }

        private void lblRelease_License_MouseEnter(object sender, EventArgs e)
        {
            lblRelease_License.FillColor = System.Drawing.Color.FromArgb(20, 140, 140);

        }

        private void lblRelease_License_MouseLeave(object sender, EventArgs e)
        {
            lblRelease_License.FillColor = System.Drawing.Color.FromArgb(10, 27, 77);

        }

        private void lblList_Of_Held_MouseEnter(object sender, EventArgs e)
        {
            lblList_Of_Held.FillColor = System.Drawing.Color.Olive;

        }

        private void lblList_Of_Held_MouseLeave(object sender, EventArgs e)
        {
            lblList_Of_Held.FillColor = System.Drawing.Color.FromArgb(10, 27, 77);

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
