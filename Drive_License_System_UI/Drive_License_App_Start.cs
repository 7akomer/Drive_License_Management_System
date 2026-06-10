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

        private void Form1_Load(object sender, EventArgs e)
        {
           

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
            Payments,
            PrintDelivery,
            Roles,
            Offices,
            AuditLogs,
            Settings


        }   

        private enPageName CerrentPage = enPageName.Drivers;


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
                CerrentPage = enPageName.LicenseCategories  ;
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
                test_us Screen = new test_us();
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

        private void btnApplications_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.Applications)
            {
                Us_Applications Screen = new Us_Applications();
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

        private void btnPayments_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.Payments)
            {
                Us_Payments Screen = new Us_Payments();
                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);
                CerrentPage = enPageName.Payments;
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

        private void btnRoles_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.Roles)
            {
                Us_Roles_Permissions Screen = new Us_Roles_Permissions();
                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);
                CerrentPage = enPageName.Roles;
            }
        }

        private void btnOffices_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.Offices)
            {
                Us_Offices Screen = new Us_Offices();
                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);
                CerrentPage = enPageName.Offices;
            }
        }

        private void btnAuditLogs_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.AuditLogs)
            {
                Us_Audit_Logs Screen = new Us_Audit_Logs();
                pnlMainContent.Controls.Clear();
                Screen.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(Screen);
                CerrentPage = enPageName.AuditLogs;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (CerrentPage != enPageName.Settings)
            {
                Us_Settings Screen = new Us_Settings();
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
    }
}
