using Driver_License_System__Models;
using Driver_License_System_BLL;
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

namespace Drive_License_System_UI
{
    public partial class Drive_License_App_Start : Form
    {
        public Drive_License_App_Start()
        {
            this.AutoScaleDimensions = new System.Drawing.SizeF(1F, 1F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            InitializeComponent();

        }

        public void OverirGestionPermisClickBtnRenew()
        {
            btnRenewals.PerformClick();
        }

        public void OverirGestionPermisClickBtnApplication()
        {
            btnApplications.PerformClick();
        }


        public void OverirGestionPermisClickBtnExam()
        {
            btnExaminations.PerformClick();
        }

        public void OverirGestionPermisClickBtnServices_Exam()
        {
            btnServiceandExam.PerformClick();
        }




        public void OverirGestionPermisClickBtnDetainLicense()
        {
            btnDetain.PerformClick();
        }

        public void OverirGestionPermisClickBtnExamination()
        {
            btnExaminations.PerformClick();
        }

    


        private void Form1_Load(object sender, EventArgs e)
        {
            UserPhoto.Image = Image.FromFile(CurrentUserLogin.CurrentUserPhoto);
            lblUserName.Text = CurrentUserLogin.CurrentUserName;
            if (CurrentUserLogin.IsSuperAdmin)
            {
                lblUserRole.Text = "Super Admin";

                    }
            else
            {
                lblUserRole.Text = "Standard User";

            }

            



            //MessageBox.Show(pnlMainContent.Size.ToString());
            //MessageBox.Show(dashboard.Size.ToString());
        }

        enum enPageName
        {
            Home,
            LicenseCategories,
            Drivers,
            Users,
            Applications,
            Licenses,
            Renewals,
            Examinations,
            Detain_license,
            PrintDelivery,
            People,
            Service_Exam,
            OrderHistory,
            Settings,
            Help,
            None


        }

        private enPageName CerrentPage = enPageName.None;


        private void lblAppName_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLicenseCategories_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.LicenseCategories)
            {
                Us_License_Categories Screen = new Us_License_Categories();
                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);
                CerrentPage = enPageName.LicenseCategories;
            }
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.Drivers)
            {
                Us_Drivers Screen = new Us_Drivers();
                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);
                CerrentPage = enPageName.Drivers;
            }
        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void lblUserRole_Click(object sender, EventArgs e)
        {

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.Users)
            {
                Us_Users Screen = new Us_Users();
                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);
                CerrentPage = enPageName.Users;
            }

        }

        private void pnlMainContent_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.Home)
            {
                Us_welcom_s Screen = new Us_welcom_s();
                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);

                CerrentPage = enPageName.Home;
            }


        }

        public static Us_Applications Cerrentapplications = null;

        public Us_Applications ReturnUsApplications()
        {

            return Cerrentapplications;
        }


        private void btnApplications_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.Applications)
            {
                Us_Applications Screen = new Us_Applications();
                Cerrentapplications = Screen;

                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);
                CerrentPage = enPageName.Applications;
            }
        }

        private void btnLicenses_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.Licenses)
            {
                Us_Licenses Screen = new Us_Licenses();
                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);
                CerrentPage = enPageName.Licenses;
            }
        }

        private void btnRenewals_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.Renewals)
            {
                Us_Renewals Screen = new Us_Renewals();
                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);
                CerrentPage = enPageName.Renewals;
            }
        }

        private void btnExaminations_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.Examinations)
            {
                Us_Examinations Screen = new Us_Examinations();
                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);
                CerrentPage = enPageName.Examinations;
            }
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.Detain_license)
            {
                Us_LicenseDetain Screen = new Us_LicenseDetain();
                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);
                CerrentPage = enPageName.Detain_license;
            }
        }

        private void btnPrintDelivery_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.PrintDelivery)
            {
                Us_Print_Delivery Screen = new Us_Print_Delivery();
                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);
                CerrentPage = enPageName.PrintDelivery;
            }
        }

        private void btnPersons_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.People)
            {
                Us_Persens Screen = new Us_Persens();
                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);
                CerrentPage = enPageName.People;
            }
        }

        private void btnServiceandExam_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.Service_Exam)
            {
                Us_Services_Exam Screen = new Us_Services_Exam();
                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);
                CerrentPage = enPageName.Service_Exam;
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.OrderHistory)
            {
                Us_History Screen = new Us_History();
                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);
                CerrentPage = enPageName.OrderHistory;
            }
        }


        Us_Settings Screen;

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.Settings)
            {
                 Screen = new Us_Settings();
                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);
                CerrentPage = enPageName.Settings;
                
            }
        }


        private void pnlLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pnluserInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblMain_Click(object sender, EventArgs e)
        {

        }

        private void pnlTopBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.Help)
            {
                us_Help Screen = new us_Help();
                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);
                CerrentPage = enPageName.Help;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (pnlFullUserInformation.Visible)
            {
                pnlFullUserInformation.Visible = false;
                pnlFullUserInformation.BringToFront();


            }
            else
            {
                pnlFullUserInformation.Visible = true;
                pnlFullUserInformation.BringToFront();

            }
        }

        public void AddInMainContent(UserControl userControl)
        {
            pnlMainContent.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(userControl);
        }
        private void pnluserInfo_Click(object sender, EventArgs e)
        {
            pnlFullUserInformation.Visible = false;
            pnlFullUserInformation.BringToFront();

        }

        private void pnlMainContent_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Drive_License_App_Start_Shown(object sender, EventArgs e)
        {

         


                notifyIcon1.ShowBalloonTip(7000, "Data Updated", "The latest data has been successfully loaded and is now up to date.", ToolTipIcon.Info);
         
        }

        private void btnMoreInformation_Click(object sender, EventArgs e)
        {
            btnUsers.PerformClick();
        }

        private void btnChangepassword_Click(object sender, EventArgs e)
        {
            btnSettings.PerformClick();

            Screen.OverirGestionPermisClickBtnChangePassword();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Are you sure you want to log out ?", "Confirmation logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

            }

        public event Action LogoutClick;
    }
}