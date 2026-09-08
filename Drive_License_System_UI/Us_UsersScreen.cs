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
    public partial class Us_Users : UserControl
    {
        public Us_Users()
        {
            InitializeComponent();
        }

        //Table Full Settings

        private us_Optimised_Table UsersTable;
        private cls_Users cls__Users;
        private List<Person_Information_class> UsersList;
        private List<Person_Information_class> CurrentPageList;


    
        private string ReturnTableFullName(string FirstName, string LastName)
        {

            if (FirstName.Length + LastName.Length > 12)
            {
                return FirstName + " " + LastName[0] + LastName[1] + "..";
            }
            else
            {
                return FirstName + " " + LastName;
            }
        }
        private void OptimiseTableToPersensTableForm()
        {
            UsersTable.lplTitleEntityOptimiseTableLisensee.Text = "USER";
            UsersTable.picOptimiseTableIcon.BackgroundImage = (Drive_License_System_UI.Properties.Resources.Picsart_26_06_16_14_07_02_6192);
            UsersTable.lblOptimiseTableTitle.Text = "USERS";
            UsersTable.releasedateRowOptimiseTable.Text = "BIRTH DAY";
            UsersTable.StatusRowOptimiseTable.Text = "DR ELIGIBLE";
            UsersTable.LabelLicenseNoRowOptimiseTable.Text = "NATIONAL ID";

            UsersTable.cxbOptimiseTableFilter.Visible = false;
            UsersTable.txbOptimiseTableSearch.Visible = false;

            UserInfo.contactslbl.Text = "USER";



            UserInfo.lblCardPersonTitle.Text = "User Card";


            UserInfo.guna2CirclePictureBox6.BackgroundImage = (Drive_License_System_UI.Properties.Resources.t);
             
          UserInfo.guna2CirclePictureBox5.BackgroundImage = (Drive_License_System_UI.Properties.Resources.Picsart_26_06_16_14_07_02_6191);

            UserInfo.phonenumber.Visible = false;
            UserInfo.EditUser_Name.Visible = true;
            UserInfo.lblcontact.Text = "Username";
            UserInfo.pnlEmail.Text = "Permission";
            UsersTable.lineOptimiseTable.Location = new Point(160,18);
            UsersTable.DeleteRow1.Visible = false;
            UsersTable.DeleteRow2.Visible = false;
            UsersTable.DeleteRow3.Visible = false;
            UsersTable.DeleteRow4.Visible = false;
            UsersTable.DeleteRow5.Visible = false;
            UsersTable.DeleteRow6.Visible = false;
            UsersTable.DeleteRow7.Visible = false;
            UsersTable.DeleteRow8.Visible = false;
            UsersTable.DeleteRow9.Visible = false;
            UsersTable.DeleteRow10.Visible = false;

            

            UsersTable.EditRow1.Visible = false;
            UsersTable.EditRow2.Visible = false;
            UsersTable.EditRow3.Visible = false;
            UsersTable.EditRow4.Visible = false;
            UsersTable.EditRow5.Visible = false;
            UsersTable.EditRow6.Visible = false;
            UsersTable.EditRow7.Visible = false;
            UsersTable.EditRow8.Visible = false;
            UsersTable.EditRow9.Visible = false;
            UsersTable.EditRow10.Visible = false;

            UserInfo.pnlAddress.Visible = false;
            UserInfo.Save.Visible = true;

            UserInfo.cmbEditPermission.Items.Clear();

            UserInfo.cmbEditPermission.Items.Add("Standard User");
            UserInfo.cmbEditPermission.Items.Add("Super Admin");





        }

        private void AddLineToTable(int PersonNumber, int LineNumber)
        {
            bool is_Eligible = false;
            UsersTable.panelLine[LineNumber].Visible = true;
            try
            {
                UsersTable.PicColumn[LineNumber].Image = Image.FromFile(UsersList[PersonNumber].Personal_Photo);
            }
            catch
            {

            }
            UsersTable.LableColumn1[LineNumber].Text = ReturnTableFullName(UsersList[PersonNumber].FirstName, UsersList[PersonNumber].LastName);
            UsersTable.LableColumn2[LineNumber].Text = UsersList[PersonNumber].National_ID;
            UsersTable.LableColumn3[LineNumber].Text = UsersList[PersonNumber].Date_Of_Birth.Year.ToString() + "/" + UsersList[PersonNumber].Date_Of_Birth.Month.ToString() + "/" + UsersList[PersonNumber].Date_Of_Birth.Day.ToString();

            is_Eligible = UsersList[PersonNumber].Date_Of_Birth <= DateTime.Today.AddYears(-18);


            if (CurrentUserLogin.CurrentUserID == UsersList[PersonNumber].UserID && CurrentUserLogin.IsSuperAdmin)
            {
                UsersTable.LableColumn4[LineNumber].ForeColor = Color.LimeGreen;


                UsersTable.LableColumn4[LineNumber].Text = "ADMIN";
                UsersTable.PanelColumn4[LineNumber].FillColor = Color.FromArgb(0, 64, 0);
            }
            else
            {
                UsersTable.LableColumn4[LineNumber].ForeColor = Color.Silver;
                UsersTable.LableColumn4[LineNumber].Text = "USER";
                UsersTable.PanelColumn4[LineNumber].FillColor = Color.FromArgb(64, 64, 64);

             
            }

            UsersTable.LableColumn4[LineNumber].Location = new Point(
           (UsersTable.PanelColumn4[LineNumber].Width - UsersTable.LableColumn4[LineNumber].Width) / 2,
           (UsersTable.PanelColumn4[LineNumber].Height - UsersTable.LableColumn4[LineNumber].Height) / 2);

            CurrentPageList.Add(UsersList[PersonNumber]);
        }

        private void FullTableInformation()
        {
            CurrentPageList.Clear();


            if (UsersList != null && UsersList.Count > 0)
            {

                UsersTable.TotalPages = (int)Math.Ceiling((double)UsersList.Count / 10);


                for (int i = 9; i >= 0; i--)
                {
                    UsersTable.panelLine[i].Visible = false;
                }



                {



                    if (UsersTable.TotalPages == UsersTable.CurrentPage)

                    {
                        UsersTable.NumberOfRowsInThis = UsersList.Count % 10;
                    }
                    else
                    {
                        UsersTable.NumberOfRowsInThis = 10;

                    }

                    UsersTable.txtCountOptimiseTable.Text = "Showing 1 - " + UsersTable.NumberOfRowsInThis + " of " + UsersList.Count + " users";
                    UsersTable.ShowListCountOptimiseTable.Text = UsersTable.CurrentPage + " of " + UsersTable.TotalPages;
                    for (int i = 0; i < UsersTable.NumberOfRowsInThis; i++)
                    {
                        AddLineToTable(UsersTable.CurrentLineInfo, i);

                        UsersTable.CurrentLineInfo++;


                    }


                }
            }
            else
            {
                UsersTable.txtCountOptimiseTable.Text = "There is no one matching this search";
                UsersTable.ShowListCountOptimiseTable.Text = "0 page";
                UserInfo.pnlfull.Visible = false;



                for (int i = 9; i >= 0; i--)
                {
                    UsersTable.panelLine[i].Visible = false;

                }
            }


        }

        private void PersonsTable_NextPageButtonClicked()
        {

            if (UsersTable.CurrentPage < UsersTable.TotalPages)
            {
                UsersTable.CurrentPage++;

                FullTableInformation();


            }
        }

        private void PersonsTable_PreviousPageButtonClicked()
        {
            if (UsersTable.CurrentPage > 1)
            {
                UsersTable.CurrentPage--;
                UsersTable.CurrentLineInfo = UsersTable.CurrentLineInfo - (10 + UsersTable.NumberOfRowsInThis);

                FullTableInformation();
            }
        }

        private void PersonsTable_ShearchTextChange(object sender, EventArgs e)
        {
         
        }

        private void SelectedIndexChanged()
        {
        }

        private void ActionShowMoreDetilePerson_Click()
        {

            FullPersonalCardInfo();
        }

        //

        //user Card Full Settings

        us_PersonInformationCard UserInfo;
        private enum enEditWhat
        {
            UserName = 1,
            Permission = 2,
            Non = 3
        }

        private int UserID = -1;
        private string UserName;

        private byte EditWhat = (int)enEditWhat.Non;
        
        private void FullPersonalCardInfo()
        {
            UserInfo.Visible = true;
            UserInfo.Save.Visible = false;

                        UserInfo.EditUser_Name.ReadOnly = true;


            int ThisPerson = UsersTable.CurrentActionLinePersonDetile - 1;
            if (CurrentPageList.Count > 0)
            {

                try
                {
                    UserInfo.PersonalPhoto.Image = Image.FromFile(CurrentPageList[ThisPerson].Personal_Photo);
                }
                catch
                {

                }
                UserInfo.personalName.Text = CurrentPageList[ThisPerson].FirstName + " " + CurrentPageList[ThisPerson].LastName;

                UserInfo.FullName.Text = CurrentPageList[ThisPerson].FirstName + " " + CurrentPageList[ThisPerson].SecondName + " " + CurrentPageList[ThisPerson].ThirdName + " " + CurrentPageList[ThisPerson].LastName;

                UserInfo.NationalID.Text = CurrentPageList[ThisPerson].National_ID;

                UserInfo.nationality.Text = CurrentPageList[ThisPerson].country_name;

                UserInfo.DateofBirth.Text = CurrentPageList[ThisPerson].Date_Of_Birth.Year.ToString() + "/" + CurrentPageList[ThisPerson].Date_Of_Birth.Month.ToString() + "/" + CurrentPageList[ThisPerson].Date_Of_Birth.Day.ToString();

                UserID = CurrentPageList[ThisPerson].UserID;
                UserName = CurrentPageList[ThisPerson].UserName;


                if (CurrentPageList[ThisPerson].Gender == "M" || CurrentPageList[ThisPerson].Gender == "m")
                {
                    UserInfo.GenderPicBox.BackgroundImage = (Drive_License_System_UI.Properties.Resources.Picsart_26_06_16_11);


                    UserInfo.Gender.Text = "Male";
                }
                else
                {
                    UserInfo.Gender.Text = "Female";
                    UserInfo.GenderPicBox.BackgroundImage = (Drive_License_System_UI.Properties.Resources.Picsart_26_06_16_14);

                }


                if (CurrentUserLogin.IsSuperAdmin == true)
                {
                    AddUser.Visible = true;
                    UserInfo.EditPermissions.Visible = true;
                }
                else
                {
                    UserInfo.EditPermissions.Visible = false;

                    AddUser.Visible = false;

                }

                UserInfo.EditUser_Name.Text = CurrentPageList[ThisPerson].UserName;

                if(CurrentPageList[ThisPerson].Is_Supper_Admin)
                {
                    UserInfo.Email.Text = "Super Administrator";

                    if (CurrentUserLogin.CurrentUserName == CurrentPageList[ThisPerson].UserName)
                    {
                        UserInfo.EditPermissions.Visible = false;

                    }
                    else
                    {
                        UserInfo.EditPermissions.Visible = true;

                    }


                }
                else
                {
                    UserInfo.Email.Text = "Standard User";

                }



                if (CurrentUserLogin.CurrentUserName == CurrentPageList[ThisPerson].UserName)
                {
                    UserInfo.EditUserName.Visible = true;

                }
                else
                {
                    UserInfo.EditUserName.Visible = false;

                }

           



                UserInfo.address.Text = CurrentPageList[ThisPerson].Address;

                UserInfo.pnlfull.Visible = true;


            }
            else
            {
                UserInfo.pnlfull.Visible = false;
            }
        }


        private void EditPermisssionClick()
        {
            UserInfo.EditUserName.Visible = false;
            UserInfo.EditPermissions.Visible = false;
            UserInfo.cmbEditPermission.Visible = true;


            EditWhat = (int)enEditWhat.Permission;

            UserInfo.Save.Visible = true;
            
        }

        private void EditUserNameClick()
        {
            UserInfo.EditUserName.Visible = false;
            UserInfo.EditPermissions.Visible = false;
            UserInfo.EditUser_Name.Focus();

            UserInfo.EditUser_Name.ReadOnly = false;

            EditWhat = (int)enEditWhat.UserName;

            UserInfo.Save.Visible = true;
            
        }



        private bool Verifies_UserName_accuracy_Info_FromUI()
        {
            bool TheDataIsClean = true;

            if (UserInfo.EditUser_Name.Text == UserName)
            {

                MessageBox.Show("Please choose a different username, This is already the current username ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

         

         
                if (string.IsNullOrWhiteSpace(UserInfo.EditUser_Name.Text))
            {
                MessageBox.Show("Invalid UserName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cls_Users.If_UserName_Exist(UserInfo.EditUser_Name.Text))
            {
                MessageBox.Show("This username is alread exists in the system, choose a different username. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return TheDataIsClean;
        }

        private void SaveClick()
        {
            if(EditWhat != (int)enEditWhat.Non)
            {
                if (EditWhat == (int)enEditWhat.Permission)
                {
                    user_Information_Class UpdatePermission = new user_Information_Class();
                    if (UserID != -1)
                    {
                        UpdatePermission.user_ID = UserID;

                        if(UserInfo.cmbEditPermission.SelectedIndex == 0)
                        {
                            UpdatePermission.is_Admin = false;
                        }
                        else if (UserInfo.cmbEditPermission.SelectedIndex == 1)
                        {
                            UpdatePermission.is_Admin = true;
                        }
                        else
                        {
                            MessageBox.Show(" An errore occurred while attempting to get information", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (cls__Users.Update_User_Permission(UpdatePermission))
                        {
                            UserInfo.cmbEditPermission.Visible = false;
                            

                            if (UpdatePermission.is_Admin == true)
                            {
                                MessageBox.Show($"Note: You can no longer manage this account because you both have the same role and permissions .", "User Promoted successfully", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }

                            else
                            {
                                MessageBox.Show($"This user has been successfully promoted.", "User Promoted successfully", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            }



                            //
                           UserInfo.Visible = false;

                                UsersList.Clear();

                                List<Person_Information_class> GetNew = cls__Users.Get_Users_List();

                            if (GetNew != null)
                                {

                                UsersList = GetNew;


                                }

                                UsersTable.CurrentLineInfo = 0;
                            UsersTable.CurrentPage = 1;

                                FullTableInformation();

                            //
                            

                        }
                        else
                        {
                            MessageBox.Show(" An errore occurred while save in database", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }
                    else
                    {
                        MessageBox.Show(" An errore occurred while attempting to get information", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                   
                }
                else if(EditWhat == (int)enEditWhat.UserName)
                {
                    if(Verifies_UserName_accuracy_Info_FromUI())
                    {
                        user_Information_Class UpdateUserName = new user_Information_Class();

                        if (CurrentUserLogin.CurrentUserID == UserID)
                        {
                            UpdateUserName.user_ID = UserID;

                            UpdateUserName.userName = UserInfo.EditUser_Name.Text;

                            if (cls__Users.Update_User_Name(UpdateUserName))
                            {
                                CurrentUserLogin.CurrentUserName = UpdateUserName.userName;
                                MessageBox.Show($"The username has been successfully updated.", "Username update successfully", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                UserInfo.Visible = false;

                                UsersList.Clear();

                                List<Person_Information_class> GetNew = cls__Users.Get_Users_List();

                                if (GetNew != null)
                                {

                                    UsersList = GetNew;


                                }

                                UsersTable.CurrentLineInfo = 0;
                                UsersTable.CurrentPage = 1;

                                FullTableInformation();
                            }
                            else
                            {
                                MessageBox.Show(" An errore occurred while save in database", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        else
                        {
                            MessageBox.Show(" An errore occurred while attempting to get information", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }
                }
            }
        }

        //


        //Add New user

        us_PersonInformationCard AddNewUser;
        Person_Information_class NewInformation;
        cls_People Get_PersonInfo;
        private int PersonID = -1;
        private bool Verifies_New_User_Info_FromUI(user_Information_Class Info)
        {
            bool TheDataIsClean = true;

            if (cls_Users.If_ThisPersonIsUser(Info.people_ID))
            {
                MessageBox.Show("This Person is alread User. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }


            if (string.IsNullOrWhiteSpace(Info.userName))
            {
                MessageBox.Show("Invalid UserName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cls_Users.If_UserName_Exist(Info.userName))
            {
                MessageBox.Show("This username is alread exists in the system, choose a different username. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }


            if (string.IsNullOrWhiteSpace(Info.userPassword))
            {
                MessageBox.Show("Invalid Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(Info.userPassword.Length < 8) 
                {
                MessageBox.Show("Invalid Password, Password must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            return TheDataIsClean;
        }


        private void CallAddUser()
        {

            AddNewUser = new us_PersonInformationCard();
            NewInformation = new Person_Information_class();
            Get_PersonInfo = new cls_People();
            AddUser.Enabled = false;

            AddNewUser.guna2CirclePictureBox6.BackgroundImage = (Drive_License_System_UI.Properties.Resources.t);

            AddNewUser.guna2CirclePictureBox5.BackgroundImage = (Drive_License_System_UI.Properties.Resources.Picsart_26_06_16_14_07_02_6191);

            AddNewUser.phonenumber.Visible = false;
            AddNewUser.Email.Visible = false;
            AddNewUser.EditUser_Name.Visible = true;

            AddNewUser.EditUser_Name.ReadOnly = false;


            AddNewUser.lblcontact.Text = "Username";
            AddNewUser.pnlEmail.Text = "Permission";

            AddNewUser.guna2CirclePictureBox7.BackgroundImage = (Drive_License_System_UI.Properties.Resources.b1);
            AddNewUser.address.Visible = false;
            AddNewUser.Password.Visible = true;
            AddNewUser.lblAddress.Text = "Password";
            AddNewUser.txbSearch.Visible = true;
            AddNewUser.guna2HtmlLabel6.Visible = true;

            AddNewUser.cmbEditPermission.Items.Clear();

            AddNewUser.cmbEditPermission.Items.Add("Standard User");
            AddNewUser.cmbEditPermission.Items.Add("Super Admin");
            AddNewUser.cmbEditPermission.Visible = true;



            UsersTable.ButtonLine1ActionOptimiseTable.Visible = false;
            UsersTable.ButtonLine2ActionOptimiseTable.Visible = false;
            UsersTable.ButtonLine3ActionOptimiseTable.Visible = false;
            UsersTable.ButtonLine4ActionOptimiseTable.Visible = false;
            UsersTable.ButtonLine5ActionOptimiseTable.Visible = false;
            UsersTable.ButtonLine6ActionOptimiseTable.Visible = false;
            UsersTable.ButtonLine7ActionOptimiseTable.Visible = false;
            UsersTable.ButtonLine8ActionOptimiseTable.Visible = false;
            UsersTable.ButtonLine9ActionOptimiseTable.Visible = false;
            UsersTable.ButtonLine10ActionOptimiseTable.Visible = false;


            AddNewUser.contactslbl.Text = "USER";


            AddNewUser.SaveClick += SaveUserInfo;
            AddNewUser.CloseClick += Close_AddUserCard;
            AddNewUser.ShearchTextChange += txbSearch_TextChanged;

            AddNewUser.lblCardPersonTitle.Text = "Add New User";

            AddNewUser.btnClose.Visible = true;

            UserInfo.Visible = false;
            AddNewUser.Save.Visible = false;


            AddNewUser.Dock = DockStyle.Left;
            pnlscreen.Controls.Add(AddNewUser);

        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            CallAddUser();
        }

        private void Close_AddUserCard()
        {
            AddUser.Enabled = true;
            AddNewUser.Save.Visible = false;


            UserInfo.txbSearch.Visible = false;
            UserInfo.guna2HtmlLabel6.Visible = false;

            UsersTable.ButtonLine1ActionOptimiseTable.Visible = true;
            UsersTable.ButtonLine2ActionOptimiseTable.Visible = true;
            UsersTable.ButtonLine3ActionOptimiseTable.Visible = true;
            UsersTable.ButtonLine4ActionOptimiseTable.Visible = true;
            UsersTable.ButtonLine5ActionOptimiseTable.Visible = true;
            UsersTable.ButtonLine6ActionOptimiseTable.Visible = true;
            UsersTable.ButtonLine7ActionOptimiseTable.Visible = true;
            UsersTable.ButtonLine8ActionOptimiseTable.Visible = true;
            UsersTable.ButtonLine9ActionOptimiseTable.Visible = true;
            UsersTable.ButtonLine10ActionOptimiseTable.Visible = true;

            AddNewUser.Visible = false;
            UserInfo.Visible = true;

            UserInfo.btnClose.Visible = false;
            FullPersonalCardInfo();
        }
        private void SaveUserInfo()
        {
            if (PersonID != -1)
            {

                user_Information_Class AddNew = new user_Information_Class();

                AddNew.userName = AddNewUser.EditUser_Name.Text;
                AddNew.people_ID = PersonID;


                if (AddNewUser.cmbEditPermission.SelectedIndex == 0)
                {
                    AddNew.is_Admin = false;
                }
                else if (AddNewUser.cmbEditPermission.SelectedIndex == 1)
                {
                    AddNew.is_Admin = true;
                }
                else
                {
                    MessageBox.Show("Please grant permission to this user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AddNew.userPassword = AddNewUser.Password.Text;


                if (Verifies_New_User_Info_FromUI(AddNew))
                {
                    cls_Users AddNewUserInformation = new cls_Users();
                   
                    if (AddNewUserInformation.AddNewUser(AddNew))
                    {
                        MessageBox.Show($"The user has been successfully added.", "User added successfully", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Close_AddUserCard();
                        UsersList.Clear();

                        List<Person_Information_class> GetNew = cls__Users.Get_Users_List();

                        if (GetNew != null)
                        {

                            UsersList = GetNew;


                        }

                        UsersTable.CurrentLineInfo = 0;
                        UsersTable.CurrentPage = 1;

                        FullTableInformation();
                    }
                    else
                    {
                        MessageBox.Show(" An errore occurred while save in database", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }



                }
            }
            else
            {
                MessageBox.Show(" An errore occurred while attempting to get information", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void txbSearch_TextChanged()
        {
            NewInformation = Get_PersonInfo.Get_Person_By_NationalID(AddNewUser.txbSearch.Text);

            if (NewInformation.National_ID == AddNewUser.txbSearch.Text)
            {

                FullInformationCard();
                AddNewUser.Save.Visible = true;


            }

            else
            {


                AddNewUser.Save.Visible = false;


            }
        }

        private void FullInformationCard()
        {



            AddNewUser.PersonalPhoto.Image = Image.FromFile(NewInformation.Personal_Photo);

            AddNewUser.FullName.Text = NewInformation.FirstName + " " + NewInformation.SecondName + " " + NewInformation.ThirdName + " " + NewInformation.LastName;
            AddNewUser.personalName.Text = NewInformation.FirstName + " " + NewInformation.LastName;

            AddNewUser.NationalID.Text = NewInformation.National_ID;
            AddNewUser.DateofBirth.Text = NewInformation.Date_Of_Birth.Year.ToString() + "/" + NewInformation.Date_Of_Birth.Month.ToString() + "/" + NewInformation.Date_Of_Birth.Day.ToString();
            AddNewUser.nationality.Text = NewInformation.country_name;

            if (NewInformation.Gender == "M" || NewInformation.Gender == "m")
            {
                AddNewUser.GenderPicBox.BackgroundImage = (Drive_License_System_UI.Properties.Resources.Picsart_26_06_16_11);

                AddNewUser. Gender.Text = "Male";
            }
            else
            {
                AddNewUser. Gender.Text = "Female";
                AddNewUser.GenderPicBox.BackgroundImage = (Drive_License_System_UI.Properties.Resources.Picsart_26_06_16_14);

            }

            PersonID = NewInformation.Person_ID;





        }





        //




        //

        private void Us_Users_Load(object sender, EventArgs e)
        {
            cls__Users = new cls_Users();
            UsersTable = new us_Optimised_Table();
            CurrentPageList = new List<Person_Information_class>();
            UserInfo = new us_PersonInformationCard();
            UsersList = new List<Person_Information_class>();



            UsersList = cls__Users.Get_Users_List();


            UsersTable.NextPageButtonClicked += PersonsTable_NextPageButtonClicked;
            UsersTable.PreviousPageButtonClicked += PersonsTable_PreviousPageButtonClicked;
            UsersTable.ShearchTextChange += PersonsTable_ShearchTextChange;
            UsersTable.SelectedIndexChanged += SelectedIndexChanged;
            UsersTable.ActionShowMoreDetilePerson_Click += ActionShowMoreDetilePerson_Click;
            UserInfo.EditPermisssionClick += EditPermisssionClick;
            UserInfo.EditUserNameClick += EditUserNameClick;
            UserInfo.SaveClick += SaveClick;
            UserInfo.Dock = DockStyle.Left;
            UsersTable.Dock = DockStyle.Right;
          



            OptimiseTableToPersensTableForm();
            FullTableInformation();
            FullPersonalCardInfo();


          


            pnlscreen.Controls.Add(UserInfo);
            pnlscreen.Controls.Add(UsersTable);

        }

        private void pnlscreen_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
