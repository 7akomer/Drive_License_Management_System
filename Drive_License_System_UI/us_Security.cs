using Driver_License_System__Models;
using Driver_License_System_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Drive_License_System_UI
{
    public partial class us_Security : UserControl
    {
        public us_Security()
        {
            InitializeComponent();
        }

        private void us_Security_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirmChangePassword_Click(object sender, EventArgs e)
        {

            bool TheDataIsClean = true;
            if (string.IsNullOrWhiteSpace(txbCurrentpassword.Text))
            {
                txbCurrentpassword.BorderColor = System.Drawing.Color.FromArgb(248, 113, 113);

                TheDataIsClean = false;

            }
            else
            {
                txbCurrentpassword.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);

            }

            if (string.IsNullOrWhiteSpace(txbNewpassword.Text) || txbNewpassword.Text.Length < 8)
            {
                txbNewpassword.BorderColor = System.Drawing.Color.FromArgb(248, 113, 113);
                TheDataIsClean = false;

            }
            else
            {
                txbNewpassword.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);

            }


            if (string.IsNullOrWhiteSpace(txbConfirmpassword.Text) || txbConfirmpassword.Text.Length < 8 || txbConfirmpassword.Text != txbNewpassword.Text)
            {
                txbConfirmpassword.BorderColor = System.Drawing.Color.FromArgb(248, 113, 113);
                TheDataIsClean = false;

            }
            else
            {
                txbConfirmpassword.BorderColor = System.Drawing.Color.FromArgb(213, 218, 223);

            }

            if (TheDataIsClean)
            {

                DialogResult result = MessageBox.Show("Are you sure about update your password ?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    cls_Users Confirmation = new cls_Users();
                    user_Information_Class NewPassWord = new user_Information_Class();


                    if (Confirmation.Authenticate_user(CurrentUserLogin.CurrentUserName, txbCurrentpassword.Text))
                    {
                        NewPassWord.userPassword = txbNewpassword.Text;

                        if (Confirmation.Update_Password(NewPassWord))
                        {
                            MessageBox.Show($"The password has been successfully updated.", "The operation was successful", MessageBoxButtons.OK);
                            txbCurrentpassword.Text = null;
                            txbNewpassword.Text = null;
                            txbConfirmpassword.Text = null;
                            btnConfirmChangePassword.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("An errore occurred while attempting to save in database", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        txbCurrentpassword.BorderColor = System.Drawing.Color.FromArgb(248, 113, 113);
                        return;
                    }
                }
                else
                {



                }
            }
        }
    }
}
