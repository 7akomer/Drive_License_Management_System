using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Driver_License_System_BLL;
using Driver_License_System__Models;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Deployment.Application;

namespace Drive_License_System_UI
{
    public partial class Us_Persens : UserControl
    {
        public Us_Persens()
        {
            InitializeComponent();
        }


        //Table Full Settings

        private us_Optimised_Table PersonsTable;
        private cls_People cls_People;
        private List<Person_Information_class> peopleList;
        private List<Person_Information_class> CurrentPageList;
        private Person_Information_class.Find_By_What CurrentFilter;


        private void SelectCurrentFilter()
        {
            switch (PersonsTable.cxbOptimiseTableFilter.SelectedIndex)
            {
                case 0:
                    CurrentFilter = Person_Information_class.Find_By_What.By_National_ID;
                    break;

                case 1:
                    CurrentFilter = Person_Information_class.Find_By_What.By_FirstName;
                    break;

                case 2:
                    CurrentFilter = Person_Information_class.Find_By_What.By_SecondName;
                    break;

                case 3:
                    CurrentFilter = Person_Information_class.Find_By_What.By_TirdName;
                    break;

                case 4:
                    CurrentFilter = Person_Information_class.Find_By_What.By_LastName;
                    break;

                case 5:
                    CurrentFilter = Person_Information_class.Find_By_What.By_PhoneNumber;
                    break;

                case 6:
                    CurrentFilter = Person_Information_class.Find_By_What.By_Email;
                    break;

                case 7:
                    CurrentFilter = Person_Information_class.Find_By_What.By_BirthDate;
                    break;

                case 8:
                    CurrentFilter = Person_Information_class.Find_By_What.By_Country;
                    break;

                case 9:
                    CurrentFilter = Person_Information_class.Find_By_What.By_Address;
                    break;

                case 10:
                    CurrentFilter = Person_Information_class.Find_By_What.By_PeopleID;
                    break;



            }
        }
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
            PersonsTable.lplTitleEntityOptimiseTableLisensee.Text = "PERSON";
            PersonsTable.picOptimiseTableIcon.BackgroundImage = (Drive_License_System_UI.Properties.Resources.Picsart_26_06_16_14_07_02_6192);
            PersonsTable.lblOptimiseTableTitle.Text = "PERSONS";
            PersonsTable.releasedateRowOptimiseTable.Text = "BIRTH DAY";
            PersonsTable.StatusRowOptimiseTable.Text = "DR ELIGIBLE";
            PersonsTable.LabelLicenseNoRowOptimiseTable.Text = "NATIONAL ID";


            PersonsTable.cxbOptimiseTableFilter.Items.Clear();
            PersonsTable.cxbOptimiseTableFilter.Items.Add("By National_ID");
            PersonsTable.cxbOptimiseTableFilter.Items.Add("By First Name");
            PersonsTable.cxbOptimiseTableFilter.Items.Add("By Second Name");
            PersonsTable.cxbOptimiseTableFilter.Items.Add("By Third Name");
            PersonsTable.cxbOptimiseTableFilter.Items.Add("By Last Name");
            PersonsTable.cxbOptimiseTableFilter.Items.Add("By Phone ");
            PersonsTable.cxbOptimiseTableFilter.Items.Add("By Email ");
            PersonsTable.cxbOptimiseTableFilter.Items.Add("By BirthDate");
            PersonsTable.cxbOptimiseTableFilter.Items.Add("By country");
            PersonsTable.cxbOptimiseTableFilter.Items.Add("By Address ");
            PersonsTable.cxbOptimiseTableFilter.Items.Add("By Person ID");

            PersonalInfo.EditUser_Name.Visible = true;

            PersonsTable.cxbOptimiseTableFilter.SelectedIndex = 1;
            CurrentFilter = Person_Information_class.Find_By_What.By_FirstName;

            PersonalInfo.Edit.Visible = true;
            PersonsTable.DeleteRow1.Visible = false;
            PersonsTable.DeleteRow2.Visible = false;
            PersonsTable.DeleteRow3.Visible = false;
            PersonsTable.DeleteRow4.Visible = false;
            PersonsTable.DeleteRow5.Visible = false;
            PersonsTable.DeleteRow6.Visible = false;
            PersonsTable.DeleteRow7.Visible = false;
            PersonsTable.DeleteRow8.Visible = false;
            PersonsTable.DeleteRow9.Visible = false;
            PersonsTable.DeleteRow10.Visible = false;




        }

        private void AddLineToTable(int PersonNumber, int LineNumber)
        {
            bool is_Eligible = false;
            PersonsTable.panelLine[LineNumber].Visible = true;
            try
            {
                PersonsTable.PicColumn[LineNumber].Image = Image.FromFile(peopleList[PersonNumber].Personal_Photo);
            } catch
            {

            }
            PersonsTable.LableColumn1[LineNumber].Text = ReturnTableFullName(peopleList[PersonNumber].FirstName, peopleList[PersonNumber].LastName);
            PersonsTable.LableColumn2[LineNumber].Text = peopleList[PersonNumber].National_ID;
            PersonsTable.LableColumn3[LineNumber].Text = peopleList[PersonNumber].Date_Of_Birth.Year.ToString() + "/" + peopleList[PersonNumber].Date_Of_Birth.Month.ToString() + "/" + peopleList[PersonNumber].Date_Of_Birth.Day.ToString();

            is_Eligible = peopleList[PersonNumber].Date_Of_Birth <= DateTime.Today.AddYears(-18);


            if (is_Eligible)
            {
                PersonsTable.LableColumn4[LineNumber].ForeColor = Color.LimeGreen;


                PersonsTable.LableColumn4[LineNumber].Text = "Yes";
                //Persens.state1textOptimiseTable.Location = new Point (5,5);
                PersonsTable.PanelColumn4[LineNumber].FillColor = Color.FromArgb(0, 64, 0);
            }
            else
            {
                PersonsTable.LableColumn4[LineNumber].ForeColor = Color.FromArgb(255, 120, 120);
                PersonsTable.LableColumn4[LineNumber].Text = "No";
                PersonsTable.PanelColumn4[LineNumber].FillColor = Color.FromArgb(75, 30, 50);
            }

            PersonsTable.LableColumn4[LineNumber].Location = new Point(
           (PersonsTable.PanelColumn4[LineNumber].Width - PersonsTable.LableColumn4[LineNumber].Width) / 2,
           (PersonsTable.PanelColumn4[LineNumber].Height - PersonsTable.LableColumn4[LineNumber].Height) / 2);

            CurrentPageList.Add(peopleList[PersonNumber]);
        }

        private void FullTableInformation()
        {
            CurrentPageList.Clear();

            if (peopleList != null && peopleList.Count > 0)
            {

                PersonsTable.TotalPages = (int)Math.Ceiling((double)peopleList.Count / 10);


                for (int i = 9; i >= 0; i--)
                {
                    PersonsTable.panelLine[i].Visible = false;
                }



                {



                    if (PersonsTable.TotalPages == PersonsTable.CurrentPage)

                    {
                        PersonsTable.NumberOfRowsInThis = peopleList.Count % 10;
                    }
                    else
                    {
                        PersonsTable.NumberOfRowsInThis = 10;

                    }

                    PersonsTable.txtCountOptimiseTable.Text = "Showing 1 - " + PersonsTable.NumberOfRowsInThis + " of " + peopleList.Count + " persons";
                    PersonsTable.ShowListCountOptimiseTable.Text = PersonsTable.CurrentPage + " of " + PersonsTable.TotalPages;
                    for (int i = 0; i < PersonsTable.NumberOfRowsInThis; i++)
                    {
                        AddLineToTable(PersonsTable.CurrentLineInfo, i);

                        PersonsTable.CurrentLineInfo++;


                    }


                }
            }
            else
            {
                PersonsTable.txtCountOptimiseTable.Text = "There is no one matching this search";
                PersonsTable.ShowListCountOptimiseTable.Text = "0 page";
                PersonalInfo.pnlfull.Visible = false;



                for (int i = 9; i >= 0; i--)
                {
                    PersonsTable.panelLine[i].Visible = false;

                }
            }


        }

        private void PersonsTable_NextPageButtonClicked()
        {

            if (PersonsTable.CurrentPage < PersonsTable.TotalPages)
            {
                PersonsTable.CurrentPage++;

                FullTableInformation();


            }
        }

        private void PersonsTable_PreviousPageButtonClicked()
        {
            if (PersonsTable.CurrentPage > 1)
            {
                PersonsTable.CurrentPage--;
                PersonsTable.CurrentLineInfo = PersonsTable.CurrentLineInfo - (10 + PersonsTable.NumberOfRowsInThis);

                FullTableInformation();
            }
        }

        private void PersonsTable_ShearchTextChange(object sender, EventArgs e)
        {
            bool is_Valid = false;
            peopleList = cls_People.Get_Filtered_People_List(PersonsTable.txbOptimiseTableSearch.Text, CurrentFilter, ref is_Valid);

            PersonsTable.CurrentLineInfo = 0;
            PersonsTable.CurrentPage = 1;
            FullTableInformation();
        }

        private void SelectedIndexChanged()
        {
            SelectCurrentFilter();
        }

        private void ActionShowMoreDetilePerson_Click()
        {

            FullPersonalCardInfo();
        }

        //

        //Personal Card Full Settings

        us_PersonInformationCard PersonalInfo;
        private void FullPersonalCardInfo()
        {
            EditInformation.Visible = false;
            PersonalInfo.Visible = true;
            int ThisPerson = PersonsTable.CurrentActionLinePersonDetile - 1;
            if (CurrentPageList.Count > 0)
            {

                try
                {
                    PersonalInfo.PersonalPhoto.Image = Image.FromFile(CurrentPageList[ThisPerson].Personal_Photo);
                }
                catch
                {

                }
                PersonalInfo.personalName.Text = CurrentPageList[ThisPerson].FirstName + " " + CurrentPageList[ThisPerson].LastName;

                PersonalInfo.FullName.Text = CurrentPageList[ThisPerson].FirstName + " " + CurrentPageList[ThisPerson].SecondName + " " + CurrentPageList[ThisPerson].ThirdName + " " + CurrentPageList[ThisPerson].LastName;

                PersonalInfo.NationalID.Text = CurrentPageList[ThisPerson].National_ID;

                PersonalInfo.nationality.Text = CurrentPageList[ThisPerson].country_name;

                PersonalInfo.DateofBirth.Text = CurrentPageList[ThisPerson].Date_Of_Birth.Year.ToString() + "/" + CurrentPageList[ThisPerson].Date_Of_Birth.Month.ToString() + "/" + CurrentPageList[ThisPerson].Date_Of_Birth.Day.ToString();


                if (CurrentPageList[ThisPerson].Gender == "M" || CurrentPageList[ThisPerson].Gender == "m")
                {
                    PersonalInfo.GenderPicBox.BackgroundImage = (Drive_License_System_UI.Properties.Resources.Picsart_26_06_16_11);


                    PersonalInfo.Gender.Text = "Male";
                }
                else
                {
                    PersonalInfo.Gender.Text = "Female";
                    PersonalInfo.GenderPicBox.BackgroundImage = (Drive_License_System_UI.Properties.Resources.Picsart_26_06_16_14);

                }

                PersonalInfo.EditUser_Name.Text = CurrentPageList[ThisPerson].PhoneNumber;

                PersonalInfo.Email.Text = CurrentPageList[ThisPerson].Email;

                PersonalInfo.address.Text = CurrentPageList[ThisPerson].Address;

                PersonalInfo.pnlfull.Visible = true;


            }
            else
            {
                PersonalInfo.pnlfull.Visible = false;
            }
        }
        //


        //EditPersonlInformationCard

        us__EditPersonalInformation EditInformation;

        private string CurrentPhotoEpdate = "";


        private void EditThisPersonIfo()
        {
            CallEditCard();
        }
        private void FullCurrentPersonInEditCard()
        {

            int ThisPerson = PersonsTable.CurrentActionLinePersonDetile - 1;

            PersonalInfo.Visible = false;
            EditInformation.Visible = true;

            if (CurrentPageList.Count > 0)
            {
                try
                {
                    EditInformation.EditPhoto.Image = Image.FromFile(CurrentPageList[ThisPerson].Personal_Photo);
                    CurrentPhotoEpdate = CurrentPageList[ThisPerson].Personal_Photo;
                }
                catch
                {

                }

                EditInformation.EditFirstName.Text = CurrentPageList[ThisPerson].FirstName;
                EditInformation.EditMiddleName.Text = CurrentPageList[ThisPerson].SecondName;
                EditInformation.EditThirdName.Text = CurrentPageList[ThisPerson].ThirdName;
                EditInformation.EditLastName.Text = CurrentPageList[ThisPerson].LastName;
                EditInformation.EditNationalID.Text = CurrentPageList[ThisPerson].National_ID;
                EditInformation.EditNationality.Text = CurrentPageList[ThisPerson].country_name;
                EditInformation.EditPhone.Text = CurrentPageList[ThisPerson].PhoneNumber;
                EditInformation.EditEmail.Text = CurrentPageList[ThisPerson].Email;
                EditInformation.EditAddress.Text = CurrentPageList[ThisPerson].Address;
                EditInformation.EditDateOfBirth.Value = CurrentPageList[ThisPerson].Date_Of_Birth;

                if (CurrentPageList[ThisPerson].Gender == "M" || CurrentPageList[ThisPerson].Gender == "m")
                {
                    EditInformation.EditGender.Text = "Male";

                }
                else
                {
                    EditInformation.EditGender.Text = "Female";

                }



            }
            else
            {
                PersonalInfo.pnlfull.Visible = false;
            }
        }

        private void CallEditCard()
        {


            FullCurrentPersonInEditCard();


        }

        private void ActionEditPersonInformation()
        {
            CallEditCard();
        }

        private void Close_EditCard()
        {
            PersonalInfo.Dock = DockStyle.Left;
            FullPersonalCardInfo();


        }

        private void SelectNewPhoto()
        {
            EditInformation.EditPhotoopenFileDialog.Filter = "Image Filter|*.jpg;*.jpej;*.png;*.bmp";

            if (EditInformation.EditPhotoopenFileDialog.ShowDialog() == DialogResult.OK)
            {
                CurrentPhotoEpdate = EditInformation.EditPhotoopenFileDialog.FileName;
                EditInformation.EditPhoto.Image = Image.FromFile(CurrentPhotoEpdate);
            }

        }


        private bool Verifies_accuracy_Info_FromUI(Person_Information_class Info)
        {
            bool TheDataIsClean = true;



            if (string.IsNullOrWhiteSpace(Info.FirstName))
            {
                EditInformation.errorProvider1.SetError(EditInformation.EditFirstName, "First Name");
                TheDataIsClean = false;
            }
            if (string.IsNullOrWhiteSpace(Info.LastName))
            {
                EditInformation.errorProvider1.SetError(EditInformation.EditLastName, "Last Name");
                TheDataIsClean = false;
            }
            if (string.IsNullOrWhiteSpace(Info.SecondName))
            {
                Info.SecondName = null;
            }
            if (string.IsNullOrWhiteSpace(Info.ThirdName))
            {
                Info.ThirdName = null;
            }

            if (string.IsNullOrWhiteSpace(Info.National_ID))
            {
                EditInformation.errorProvider1.SetError(EditInformation.EditNationalID, "National ID");
                TheDataIsClean = false;
            }
            if (string.IsNullOrWhiteSpace(EditInformation.EditNationality.Text))
            {
                EditInformation.errorProvider1.SetError(EditInformation.EditNationality, "Country");
                TheDataIsClean = false;
            }



            if (Info.Date_Of_Birth > DateTime.Now)
            {
                EditInformation.errorProvider1.SetError(EditInformation.EditDateOfBirth, "Invalid Date");
                TheDataIsClean = false;
            }


           

            if (string.IsNullOrWhiteSpace(Info.Gender))
            {
                EditInformation.errorProvider1.SetError(EditInformation.EditGender, "Gender");
                TheDataIsClean = false;
            }

            if (!IsValidPhone(Info.PhoneNumber))
            {
                EditInformation.errorProvider1.SetError(EditInformation.EditPhone, "Invalid Number");
                TheDataIsClean = false;
            }

            if (!IsValidEmail(Info.Email))
            {
                EditInformation.errorProvider1.SetError(EditInformation.EditEmail, "Invalid Email");
                TheDataIsClean = false;
            }

            if (string.IsNullOrWhiteSpace(Info.Address))
            {
                EditInformation.errorProvider1.SetError(EditInformation.EditAddress, "Address");
                TheDataIsClean = false;
            }

            return TheDataIsClean;
        }

        private bool IsValidPhone(string phone)
        {

            return Regex.IsMatch(phone, @"^\+?\d{6,16}$");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void SaveEditedInformation()
        {

            int ThisPerson = PersonsTable.CurrentActionLinePersonDetile - 1;
            bool is_Valid = false;
            Person_Information_class UpdateInfo = new Person_Information_class();
            UpdateInfo.Person_ID = CurrentPageList[ThisPerson].Person_ID;
            UpdateInfo.FirstName = EditInformation.EditFirstName.Text;
            UpdateInfo.SecondName = EditInformation.EditMiddleName.Text;
            UpdateInfo.ThirdName = EditInformation.EditThirdName.Text;
            UpdateInfo.LastName = EditInformation.EditLastName.Text;
            UpdateInfo.National_ID = EditInformation.EditNationalID.Text;
            UpdateInfo.Nationality_ID = (byte)EditInformation.EditNationality.SelectedIndex;
            UpdateInfo.PhoneNumber = EditInformation.EditPhone.Text;
            UpdateInfo.Email = EditInformation.EditEmail.Text;
            UpdateInfo.Address = EditInformation.EditAddress.Text;
            UpdateInfo.Date_Of_Birth = EditInformation.EditDateOfBirth.Value;
            UpdateInfo.Personal_Photo = CurrentPhotoEpdate;


            if (EditInformation.EditGender.SelectedIndex == 0)
            {
                UpdateInfo.Gender = "M";
            }
            else
            {
                UpdateInfo.Gender = "F";

            }



            if (Verifies_accuracy_Info_FromUI(UpdateInfo))
            {


                if (cls_People.Update_Person_Information(UpdateInfo, ref is_Valid))
                {
                    if (is_Valid)
                    {

                        if (cls_People.currentExistingInfo == 0)
                        {
                            MessageBox.Show("Sorry. The National ID you are trying to enter already exists in the system", "Exist Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (cls_People.currentExistingInfo == 1)
                        {
                            MessageBox.Show("Sorry. The Phone Number you are trying to enter already exists in the system", "Exist Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else if (cls_People.currentExistingInfo == 2)
                        {
                            MessageBox.Show("Sorry. The Email you are trying to enter already exists in the system", "Exist Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }


                        else
                        {
                            MessageBox.Show("Sorry. an errore occurred while attempting to update this person's information", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Sorry.It appears that the database is rejecting one of the data entries. Please verify that the entered values ​​meet all the required conditions.", "DataBase Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }


                }
                else
                {
                    if (is_Valid)
                    {

                        MessageBox.Show("The person data has been successfully updated .", "The operation was successful", MessageBoxButtons.OK);
                        PersonsTable.cxbOptimiseTableFilter.Text = "By National_ID";

                        PersonsTable.txbOptimiseTableSearch.Text = EditInformation.EditNationalID.Text;
                        EditInformation.EditPhoto.Image = PersonalInfo.PersonalPhoto.Image;
                        PersonsTable.CurrentActionLinePersonDetile = 1;
                    }
                    else
                    {
                        MessageBox.Show("Sorry.It appears that the database is rejecting one of the data entries. Please verify that the entered values ​​meet all the required conditions.", "DataBase Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }







        }

        //


        //Add New Person
        us__EditPersonalInformation AddNewPerson;
        string CurrentPhotoAdded = "";

        private bool Verifies_New_Person_Info_FromUI(Person_Information_class Info)
        {
            bool TheDataIsClean = true;

            if (string.IsNullOrWhiteSpace(CurrentPhotoAdded))
            {
                AddNewPerson.errorProvider1.SetError(AddNewPerson.EditPhoto, "Select Photo");

                TheDataIsClean = false;
            }

            if (string.IsNullOrWhiteSpace(Info.FirstName))
            {
                AddNewPerson.errorProvider1.SetError(AddNewPerson.EditFirstName, "First Name");
                TheDataIsClean = false;
            }
            if (string.IsNullOrWhiteSpace(Info.LastName))
            {
                AddNewPerson.errorProvider1.SetError(AddNewPerson.EditLastName, "Last Name");
                TheDataIsClean = false;
            }
            if (string.IsNullOrWhiteSpace(Info.SecondName))
            {
                Info.SecondName = null;
            }
            if (string.IsNullOrWhiteSpace(Info.ThirdName))
            {
                Info.ThirdName = null;
            }

            if (string.IsNullOrWhiteSpace(Info.National_ID))
            {
                AddNewPerson.errorProvider1.SetError(AddNewPerson.EditNationalID, "National ID");
                TheDataIsClean = false;
            }
            if (string.IsNullOrWhiteSpace(AddNewPerson.EditNationality.Text))
            {
                AddNewPerson.errorProvider1.SetError(AddNewPerson.EditNationality, "Country");
                TheDataIsClean = false;
            }



            if (Info.Date_Of_Birth > DateTime.Now)
            {
                AddNewPerson.errorProvider1.SetError(AddNewPerson.EditDateOfBirth, "Invalid Date");
                TheDataIsClean = false;
            }
            if (!(Info.Date_Of_Birth <= DateTime.Today.AddYears(-18)))
            {
                EditInformation.errorProvider1.SetError(EditInformation.EditDateOfBirth, "The person has not reached the required age");
                MessageBox.Show("Sorry. The person has not reached the required age", "Eligible age", MessageBoxButtons.OK, MessageBoxIcon.Error);

                TheDataIsClean = false;
            }

            if (string.IsNullOrWhiteSpace(Info.Gender))
            {
                AddNewPerson.errorProvider1.SetError(AddNewPerson.EditGender, "Gender");
                TheDataIsClean = false;
            }

            if (!IsValidPhone(Info.PhoneNumber))
            {
                AddNewPerson.errorProvider1.SetError(AddNewPerson.EditPhone, "Invalid Number");
                TheDataIsClean = false;
            }

            if (!IsValidEmail(Info.Email))
            {
                AddNewPerson.errorProvider1.SetError(AddNewPerson.EditEmail, "Invalid Email");
                TheDataIsClean = false;
            }

            if (string.IsNullOrWhiteSpace(Info.Address))
            {
                AddNewPerson.errorProvider1.SetError(AddNewPerson.EditAddress, "Address");
                TheDataIsClean = false;
            }

            return TheDataIsClean;
        }

        private void Close_AddPersonCard()
        {
            AddPersen.Enabled = true;

            PersonsTable.EditRow1.Visible = true;
            PersonsTable.EditRow2.Visible = true;
            PersonsTable.EditRow3.Visible = true;
            PersonsTable.EditRow4.Visible = true;
            PersonsTable.EditRow5.Visible = true;
            PersonsTable.EditRow6.Visible = true;
            PersonsTable.EditRow7.Visible = true;
            PersonsTable.EditRow8.Visible = true;
            PersonsTable.EditRow9.Visible =     true;
            PersonsTable.EditRow10.Visible = true;

            PersonsTable.ButtonLine1ActionOptimiseTable.Visible = true;
            PersonsTable.ButtonLine2ActionOptimiseTable.Visible = true;
            PersonsTable.ButtonLine3ActionOptimiseTable.Visible = true;
            PersonsTable.ButtonLine4ActionOptimiseTable.Visible = true;
            PersonsTable.ButtonLine5ActionOptimiseTable.Visible = true;
            PersonsTable.ButtonLine6ActionOptimiseTable.Visible = true;
            PersonsTable.ButtonLine7ActionOptimiseTable.Visible = true;
            PersonsTable.ButtonLine8ActionOptimiseTable.Visible = true;
            PersonsTable.ButtonLine9ActionOptimiseTable.Visible = true;
            PersonsTable.ButtonLine10ActionOptimiseTable.Visible = true;

            AddNewPerson.Visible = false;
            PersonalInfo.Visible = true;
            EditInformation.Visible = false;
            FullPersonalCardInfo();
        }
        private void CallAddPersonCard()
        {

            AddPersen.Enabled = false;

            PersonsTable.EditRow1.Visible = false;
            PersonsTable.EditRow2.Visible = false;
            PersonsTable.EditRow3.Visible = false;
            PersonsTable.EditRow4.Visible = false;
            PersonsTable.EditRow5.Visible = false;
            PersonsTable.EditRow6.Visible = false;
            PersonsTable.EditRow7.Visible = false;
            PersonsTable.EditRow8.Visible = false;
            PersonsTable.EditRow9.Visible = false;
            PersonsTable.EditRow10.Visible = false;

            PersonsTable.ButtonLine1ActionOptimiseTable.Visible = false;
            PersonsTable.ButtonLine2ActionOptimiseTable.Visible = false;
            PersonsTable.ButtonLine3ActionOptimiseTable.Visible = false;
            PersonsTable.ButtonLine4ActionOptimiseTable.Visible = false;
            PersonsTable.ButtonLine5ActionOptimiseTable.Visible = false;
            PersonsTable.ButtonLine6ActionOptimiseTable.Visible = false;
            PersonsTable.ButtonLine7ActionOptimiseTable.Visible = false;
            PersonsTable.ButtonLine8ActionOptimiseTable.Visible = false;
            PersonsTable.ButtonLine9ActionOptimiseTable.Visible = false;
            PersonsTable.ButtonLine10ActionOptimiseTable.Visible = false;


            AddNewPerson = new us__EditPersonalInformation();
                AddNewPerson.AddNewPerson += SaveNewPersonInfo;
                AddNewPerson.SelectNewPhoto += SelectNewPersonalPhoto;
                AddNewPerson.Close_AddPersonCard += Close_AddPersonCard;

                AddNewPerson.lblCardPersonTitle.Text = "Add New Person";
                AddNewPerson.btnClose.Visible = false;
                AddNewPerson.btnCloseAddCard.Location = AddNewPerson.btnClose.Location;
                AddNewPerson.btnCloseAddCard.Visible = true;

                EditInformation.Visible = false;
                PersonalInfo.Visible = false;
                AddNewPerson.Save.Visible = false;
                AddNewPerson.BtnAddNewPerson.Location = AddNewPerson.Save.Location;
                AddNewPerson.BtnAddNewPerson.Visible = true;
                AddNewPerson.EditFirstName.BorderThickness = 1;
                AddNewPerson.EditMiddleName.BorderThickness = 1;
                AddNewPerson.EditThirdName.BorderThickness = 1;
                AddNewPerson.EditLastName.BorderThickness = 1;
                AddNewPerson.EditNationalID.BorderThickness = 1;
                AddNewPerson.EditEmail.BorderThickness = 1;
                AddNewPerson.EditAddress.BorderThickness = 1;
                AddNewPerson.EditPhone.BorderThickness = 1;


                AddNewPerson.Dock = DockStyle.Left;
                pnlscreen.Controls.Add(AddNewPerson);
          
        }

        private void SaveNewPersonInfo()
        {
            bool is_Valid = false;
            Person_Information_class NewPerson = new Person_Information_class();
            NewPerson.FirstName = AddNewPerson.EditFirstName.Text;
            NewPerson.SecondName = AddNewPerson.EditMiddleName.Text;
            NewPerson.ThirdName = AddNewPerson.EditThirdName.Text;
            NewPerson.LastName = AddNewPerson.EditLastName.Text;
            NewPerson.National_ID = AddNewPerson.EditNationalID.Text;
            NewPerson.Nationality_ID = (byte)AddNewPerson.EditNationality.SelectedIndex;
            NewPerson.PhoneNumber = AddNewPerson.EditPhone.Text;
            NewPerson.Email = AddNewPerson.EditEmail.Text;
            NewPerson.Address = AddNewPerson.EditAddress.Text;
            NewPerson.Date_Of_Birth = AddNewPerson.EditDateOfBirth.Value;
            NewPerson.Personal_Photo = CurrentPhotoAdded;


            if (AddNewPerson.EditGender.SelectedIndex == 0)
            {
                NewPerson.Gender = "M";
            }
            else
            {
                NewPerson.Gender = "F";

            }

            if (Verifies_New_Person_Info_FromUI(NewPerson))
            {


                if (cls_People.Add_New_Person(NewPerson, ref is_Valid))
                {
                    if (is_Valid)
                    {

                        if (cls_People.currentExistingInfo == 0)
                        {
                            MessageBox.Show("Sorry. The National ID you are trying to enter already exists in the system", "Exist Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (cls_People.currentExistingInfo == 1)
                        {
                            MessageBox.Show("Sorry. The Phone Number you are trying to enter already exists in the system", "Exist Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else if (cls_People.currentExistingInfo == 2)
                        {
                            MessageBox.Show("Sorry. The Email you are trying to enter already exists in the system", "Exist Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }


                        else
                        {
                            MessageBox.Show("Sorry. an errore occurred while attempting to add this person's information", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Sorry.It appears that the database is rejecting one of the data entries. Please verify that the entered values ​​meet all the required conditions.", "DataBase Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

                else
                {
                    if (is_Valid)
                    {

                        MessageBox.Show("The person data has been successfully added .", "The operation was successful", MessageBoxButtons.OK);
                        PersonsTable.cxbOptimiseTableFilter.Text = "By National_ID";

                        PersonsTable.txbOptimiseTableSearch.Text = NewPerson.National_ID;
                        PersonsTable.CurrentActionLinePersonDetile = 1;

                        AddNewPerson.Visible = false;
                        CallEditCard();
                    }
                    else
                    {
                        MessageBox.Show("Sorry.It appears that the database is rejecting one of the data entries. Please verify that the entered values ​​meet all the required conditions.", "DataBase Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }


           


            }

        }

    

        private void SelectNewPersonalPhoto()
        {
            AddNewPerson.EditPhotoopenFileDialog.Filter = "Image Filter|*.jpg;*.jpej;*.png;*.bmp";

            if (AddNewPerson.EditPhotoopenFileDialog.ShowDialog() == DialogResult.OK)
            {
                CurrentPhotoAdded = AddNewPerson.EditPhotoopenFileDialog.FileName;
                AddNewPerson.EditPhoto.Image = Image.FromFile(AddNewPerson.EditPhotoopenFileDialog.FileName);
            }

        }

        //

        private void Us_Persens_Load(object sender, EventArgs e)
        {
            cls_People = new cls_People();
            PersonsTable = new us_Optimised_Table();
            CurrentPageList = new List<Person_Information_class>();
             PersonalInfo = new us_PersonInformationCard();
            EditInformation = new us__EditPersonalInformation();
            peopleList = new List<Person_Information_class>();


            bool is_Valid = false;
            peopleList = cls_People.Get_People_List(ref is_Valid);

            PersonsTable.NextPageButtonClicked += PersonsTable_NextPageButtonClicked;
             PersonsTable.PreviousPageButtonClicked += PersonsTable_PreviousPageButtonClicked;
            PersonsTable.ShearchTextChange += PersonsTable_ShearchTextChange;
            PersonsTable.SelectedIndexChanged += SelectedIndexChanged;
            PersonsTable.ActionShowMoreDetilePerson_Click += ActionShowMoreDetilePerson_Click;
            PersonsTable.ActionEditPersonInformation += ActionEditPersonInformation;
            
            EditInformation.Close_EditCard += Close_EditCard;
            EditInformation.SelectNewPhoto += SelectNewPhoto;

            EditInformation.SaveEditedInformation += SaveEditedInformation;
            PersonalInfo.EditThisPersonIfo += EditThisPersonIfo;
            PersonalInfo.Dock = DockStyle.Left;
            PersonsTable.Dock = DockStyle.Right;
            EditInformation.Dock = DockStyle.Left;
            EditInformation.Visible = false;




            OptimiseTableToPersensTableForm();
            FullTableInformation();
            FullPersonalCardInfo();


            pnlscreen.Controls.Add(PersonalInfo);
            pnlscreen.Controls.Add(PersonsTable);
            pnlscreen.Controls.Add(EditInformation);
        


        }

        private void pnlscreen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddPersen_Click(object sender, EventArgs e)
        {
            CallAddPersonCard();
        }
    }
}
