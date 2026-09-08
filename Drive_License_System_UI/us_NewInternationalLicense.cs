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

namespace Drive_License_System_UI
{
    public partial class us_NewInternationalLicense : UserControl
    {
        public us_NewInternationalLicense()
        {
            InitializeComponent();
        }

        // Application New International License issuance ID = '7' In DataBase;
        private byte ServiceID = 7;
        //
      

        cls_Orders NewApplication;
        cls_Licenses_Loc_Inte ExistVerify;
        cls_People Get_PersonInfo;
        Person_Information_class NewInformation;

        DateTime ThisPersonDateOfBirth;
        private Decimal ServicePrice = -1;
        private int PersonID = -1;
        private int LocalLicenseID = -1;
        private DateTime EndDate;
        private bool LicenseActive = false;




    
        

        private void FullInformationCard(drive_license_Information_Class NewLicenseInformation)
        {


            cls_Services GetServicePrice = new cls_Services();
            ThisPersonDateOfBirth = NewInformation.Date_Of_Birth;


            LicenseTitle.Text = "Personal Information";
            PersonalPhoto.Image = Image.FromFile(NewInformation.Personal_Photo);
            FullName.Text = NewInformation.FirstName + " " + NewInformation.SecondName + " " + NewInformation.ThirdName + " " + NewInformation.LastName;
            NationalID.Text = NewInformation.National_ID;
            DateofBirth.Text = NewInformation.Date_Of_Birth.Year.ToString() + "/" + NewInformation.Date_Of_Birth.Month.ToString() + "/" + NewInformation.Date_Of_Birth.Day.ToString();
            nationality.Text = NewInformation.country_name;
            PersonID = NewInformation.Person_ID;

            if (NewInformation.Gender == "M" || NewInformation.Gender == "m")
            {
                Gender.Text = "Male";
            }
            else
            {
                Gender.Text = "Female";
            }


            phonenumber.Text = NewInformation.PhoneNumber;
            Email.Text = NewInformation.Email;
            ServicePrice = GetServicePrice.GetServicePrice(ServiceID).service_price;

            LocalLicenseID = NewLicenseInformation.Drive_License_ID;
            License_ID.Text = LocalLicenseID.ToString();
            categoryName.Text = NewLicenseInformation.Category_Name.ToString();
            DriverID.Text = NewLicenseInformation.Driver_ID.ToString();
            IssuanceDate.Text = NewLicenseInformation.Relese_Date.Year.ToString() + "/" + NewLicenseInformation.Relese_Date.Month.ToString() + "/" + NewLicenseInformation.Relese_Date.Day.ToString();

            EndDate = NewLicenseInformation.End_Date;
            ExpiryDate.Text = NewLicenseInformation.End_Date.Year.ToString() + "/" + NewLicenseInformation.End_Date.Month.ToString() + "/" + NewLicenseInformation.End_Date.Day.ToString();


            if (NewLicenseInformation.Is_Active)
            {
               lblStatus.ForeColor = Color.LimeGreen;


                lblStatus.Text = "● Active";
                pnlStatus.FillColor = Color.FromArgb(0, 64, 0);
                LicenseActive = true;
            }
            else 
            {
                lblStatus.ForeColor = Color.Silver;
                lblStatus.Text = "● Inactive";
                pnlStatus.FillColor = Color.FromArgb(64, 64, 64);
                LicenseActive = false;

            }


            lblStatus.Location = new Point(
           (pnlStatus.Width - lblStatus.Width) / 2,
           (pnlStatus.Height - lblStatus.Height) / 2);

            pnlStatus.Visible = true;




            Fees.Text = ServicePrice.ToString() + " $";


            pnlPersonInfo.Visible = true;

        }

        private void txbSearch_TextChanged_1(object sender, EventArgs e)
        {

            int LicenseID = -1;


            if (int.TryParse(txbSearch.Text, out LicenseID))
            {

            }
            else
            {
                LicenseID = -1;
                return;
            }

            cls_Licenses_Loc_Inte GetLicenseInformation = new cls_Licenses_Loc_Inte();
            drive_license_Information_Class NewLicenseInfo = new drive_license_Information_Class();


            NewLicenseInfo = GetLicenseInformation.Get_License_Info_By_LicenseID(LicenseID);

            if (NewLicenseInfo != null && NewLicenseInfo.Drive_License_ID == LicenseID)
            {

                NewInformation = Get_PersonInfo.Get_Person_By_NationalID(NewLicenseInfo.National_ID);


                CouldntFindMessage.Visible = false;

                FullInformationCard(NewLicenseInfo);

                cls_LicenseDetain IfThisLicenseHold = new cls_LicenseDetain();
                if (!IfThisLicenseHold.Is_Reserved(LicenseID))
                {
                    ErrorMessage.Visible = false;
                    btnIssue.Enabled = true;
                }
                else
                {
                    ErrorMessage.Visible = true;
                    btnIssue.Enabled = false;
                    return;

                }

                if (LicenseActive)
                {
                    ErrorMessage.Text = "It appears that this license is currently on hold, please ensure the hold is released so that an international license can be issued.";
                    ErrorMessage.Visible = false;
                    btnIssue.Enabled = true;
                }
                else
                {
                    ErrorMessage.Text = "This license is inactive";

                    ErrorMessage.Visible = true;
                    btnIssue.Enabled = false;

                    return;
                }





            }

            else
            {
                LicenseTitle.Text = "Please choose a license";
                CouldntFindMessage.Visible = true;

                pnlPersonInfo.Visible = false;
                btnIssue.Enabled = false;
                ErrorMessage.Visible = false;
                pnlStatus.Visible = false;



            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (LicenseActive)
            {
                if (ServicePrice != -1 && PersonID != -1)
                {
                    orders_Information_Class NewOrder = new orders_Information_Class();

                    //اضافة شرط عدم اضافة طلب في حالة تكراره



                    NewOrder.Application_fee_paid = ServicePrice;
                    NewOrder.people_ID = PersonID;
                    NewOrder.service_ID = ServiceID;
                    NewOrder.order_status_ID = (int)orders_Information_Class.order_status.completed;


                    if (NewApplication.If_This_Order_Exist(NewOrder))
                    {
                        MessageBox.Show("Error 1, This person already has a request for International license", "Administrative rejection", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }
                    else
                    {
                        int OrderID = -1;

                        if (NewApplication.AddNewOrder(NewOrder, ref OrderID))
                        {
                            cls_Licenses_Loc_Inte AddNewInternationalLicense = new cls_Licenses_Loc_Inte();
                            international_drive_license_Information_Class AddNewLicense = new international_drive_license_Information_Class();

                            if (LocalLicenseID != -1)
                            {
                                AddNewLicense.Drive_License_ID = LocalLicenseID;
                                AddNewLicense.End_Date = EndDate;
                                if (AddNewInternationalLicense.AddNewInternationalLicense(AddNewLicense))
                                {
                                    MessageBox.Show("The License has been successfully issue .", "The operation was successful", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    NewApplication.UpdateOrderStatus(OrderID, orders_Information_Class.order_status.cancelled);
                                    NewApplication.UpdateOrderFees(OrderID, 0);

                                    //لا يدفع العميل اي مبلغ في هذه الحالة

                                    MessageBox.Show("Error 5, an errore occurred while attempting to issue license , The order is cancelled", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                            }
                            else
                            {
                                NewApplication.UpdateOrderStatus(OrderID, orders_Information_Class.order_status.cancelled);

                                //لا يدفع العميل اي مبلغ في هذه الحالة

                                NewApplication.UpdateOrderFees(OrderID, 0);

                                MessageBox.Show("Error 2, an errore occurred while attempting to get information, The order is cancelled", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }

                        else
                        {
                            MessageBox.Show("Error 3, an errore occurred while attempting to Create Order, The order is cancelled", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }

                }
                else
                {
                    MessageBox.Show("Error 4, an errore occurred while attempting to get information,Filed Get Information", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else

            {
                MessageBox.Show("Error 6, This license is inactive ", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

       
      

        private void us_NewInternationalLicense_Load(object sender, EventArgs e)
        {
            NewApplication = new cls_Orders();
            ExistVerify = new cls_Licenses_Loc_Inte();
            Get_PersonInfo = new cls_People();
            NewInformation = new Person_Information_class();

        }

       
    }
}
