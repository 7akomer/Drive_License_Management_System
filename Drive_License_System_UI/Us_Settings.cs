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
    public partial class Us_Settings : UserControl
    {
        public Us_Settings()
        {
            InitializeComponent();
        }

        public void OverirGestionPermisClickBtnChangePassword()
        {
            btnSecurity.PerformClick();
        }

        private void pnlSettings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Us_Settings_Load(object sender, EventArgs e)
        {
           
        }

        private void btnDeloperInfo_Click(object sender, EventArgs e)
        {
            pnlSettings.Controls.Clear();
            us_DevloperInfo info = new us_DevloperInfo();

            info.Dock = DockStyle.Fill;

            pnlSettings.Controls.Add(info);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            us_Update Update = new us_Update();

            pnlSettings.Controls.Clear();
            Update.Dock = DockStyle.Fill;

            pnlSettings.Controls.Add(Update);
        }

        private void btnSecurity_Click(object sender, EventArgs e)
        {
            us_Security Security = new us_Security();

            pnlSettings.Controls.Clear();
            Security.Dock = DockStyle.Fill;

            pnlSettings.Controls.Add(Security);
        }

        private void btnApoutSystem_Click(object sender, EventArgs e)
        {
            us_AboutSystem AboutSystem = new us_AboutSystem();

            pnlSettings.Controls.Clear();
            AboutSystem.Dock = DockStyle.Fill;

            pnlSettings.Controls.Add(AboutSystem);
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            us_Notification Notification = new us_Notification();

            pnlSettings.Controls.Clear();
            Notification.Dock = DockStyle.Fill;

            pnlSettings.Controls.Add(Notification);
        }
    }
}
