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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Drive_License_System_UI
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void LogOutClick()
        {
            this.Close();
        }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Panel_full_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_full_Paint(object sender, PaintEventArgs e)
        {
         //   panel2_full.FillColor = Color.FromArgb(80, 0,0, 40);
        }

        private void guna2PictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(usernametextbox.Text))
                {
                usernametextbox.BorderColor = System.Drawing.Color.FromArgb(248, 113, 113);

                if(string.IsNullOrWhiteSpace(passwordtextbox.Text))
                {
                    passwordtextbox.BorderColor = System.Drawing.Color.FromArgb(248, 113, 113);
                }
                return;

            }

            if (string.IsNullOrWhiteSpace(passwordtextbox.Text))
            {
                passwordtextbox.BorderColor = System.Drawing.Color.FromArgb(248, 113, 113);
                return;
            }

            string UserName = usernametextbox.Text;
            string PassWord = passwordtextbox.Text;


            cls_Users Confirmation = new cls_Users();

            if (Confirmation.Authenticate_user(UserName, PassWord))
            {


                Form start = new Drive_License_App_Start();
                this.Hide();


                start.ShowDialog();



            }

            else
            {
                usernametextbox.BorderColor = System.Drawing.Color.FromArgb(248, 113, 113);

                passwordtextbox.BorderColor = System.Drawing.Color.FromArgb(248, 113, 113);

            }


        }

        private void guna2HtmlLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void more_dont_have_account_Click(object sender, EventArgs e)
        {

        }

        private void rememberMe_cheack_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature has not been set up yet.","Message",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void moretext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please contact your manager to assign an account to you", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
    }
}
