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

       //static public void pnlAppClear()
       // {
       //     Us_Applications.pnlApplicationCenter.Controls.Clear();
       // }
       // public static  void SetRetakTest()
       // {
       //    // pnlApplicationCenter.Controls.Clear();
       //   Us_Applications.pnlAppClear();
       //     us_RetakTest newRetakTest = new us_RetakTest();
       //     newRetakTest.Dock = DockStyle.Fill;
       //     pnlApplicationCenter.Controls.Add(newRetakTest);
       // }

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
            pnlService_List.FillColor = System.Drawing.Color.FromArgb(18, 42, 111);

        }

        private void lblService_List_MouseLeave(object sender, EventArgs e)
        {
            pnlService_List.FillColor = System.Drawing.Color.FromArgb(10, 27, 77);
        }

        private void lblManage_Application_MouseEnter(object sender, EventArgs e)
        {
            pnlManage_Application.FillColor = System.Drawing.Color.FromArgb(90, 70, 180);

        }

     

        private void lblManage_Application_MouseLeave_1(object sender, EventArgs e)
        {
            pnlManage_Application.FillColor = System.Drawing.Color.FromArgb(10, 27, 77);

        }

        private void lblRelease_License_MouseEnter(object sender, EventArgs e)
        {
            pnlRelease_License.FillColor = System.Drawing.Color.FromArgb(20, 140, 140);

        }

        private void lblRelease_License_MouseLeave(object sender, EventArgs e)
        {
            pnlRelease_License.FillColor = System.Drawing.Color.FromArgb(10, 27, 77);

        }

        private void lblList_Of_Held_MouseEnter(object sender, EventArgs e)
        {
            pnlList_Of_Held.FillColor = System.Drawing.Color.Olive;

        }

        private void lblList_Of_Held_MouseLeave(object sender, EventArgs e)
        {
            pnlList_Of_Held.FillColor = System.Drawing.Color.FromArgb(10, 27, 77);

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblRelease_License_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblRelease_License_Click(object sender, EventArgs e)
        {
            Drive_License_App_Start drive_License_App_Start = (Drive_License_App_Start)this.FindForm();
            drive_License_App_Start.OverirGestionPermisClickBtnRenew();
        }

        private void lblList_Of_Held_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void lblList_Of_Held_Click(object sender, EventArgs e)
        {
            Drive_License_App_Start drive_License_App_Start = (Drive_License_App_Start)this.FindForm();
            drive_License_App_Start.OverirGestionPermisClickBtnDetainLicense();
        }

        private void lblManage_Application_Click(object sender, EventArgs e)
        {
            pnlApplicationCenter.Controls.Clear();
            us_ManageAppInApplicationSenter manageAppInApplicationSenter = new us_ManageAppInApplicationSenter(); 
            manageAppInApplicationSenter.Dock = DockStyle.Fill;
            pnlApplicationCenter.Controls.Add(manageAppInApplicationSenter);

        }

        private void lblService_List_Click(object sender, EventArgs e)
        {
            pnlApplicationCenterChoise.Controls.Clear();
            us_ServiceList ServiceLicet = new us_ServiceList();
            ServiceLicet.Dock = DockStyle.Fill;
            pnlApplicationCenterChoise.Controls.Add(ServiceLicet);
            btnGoBack.Visible = true;


        }

        private void lblService_List_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            pnlApplicationCenterChoise.Controls.Clear();
            pnlApplicationCenterChoise.Controls.Add(pnlService_List);
            pnlApplicationCenterChoise.Controls.Add(pnlManage_Application);
            pnlApplicationCenterChoise.Controls.Add(pnlRelease_License);
            pnlApplicationCenterChoise.Controls.Add(pnlList_Of_Held);

            btnGoBack.Visible = false;
        }

       
        public static void GoBackToApplicaionCenter()
        {
            Us_Applications us_Applications = Drive_License_App_Start.Cerrentapplications;
            us_Applications.pnlApplicationCenter.Controls.Clear();
            Us_Applications NewApp = new Us_Applications();

            NewApp.Dock = DockStyle.Fill;

            us_Applications.pnlApplicationCenter.Controls.Add(NewApp);
        }
        public static void ShowRetakTest()
        {
            Us_Applications us_Applications = Drive_License_App_Start.Cerrentapplications;
            us_RetakTest newRetakTest = new us_RetakTest();
            newRetakTest.Dock = DockStyle.Fill;

            us_Applications.pnlApplicationCenter.Controls.Clear();
            us_Applications.pnlApplicationCenter.Controls.Add(newRetakTest);
        }

        private void pnlManage_Application_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
