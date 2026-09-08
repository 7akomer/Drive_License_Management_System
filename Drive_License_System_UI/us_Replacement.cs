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
    public partial class us_Replacement : UserControl
    {
        public us_Replacement()
        {
            InitializeComponent();
        }


        // Application Replacement Lost  License  ID = '4' In DataBase;
        private byte LostLicenseServiceID = 4;
        //

        // Application Replacement Damaged  License  ID = '5' In DataBase;

        private byte DamageLicenseServiceID = 5;

        //

        cls_Orders NewApplication;
        cls_Licenses_Loc_Inte ExistVerify;
        cls_People Get_PersonInfo;
        Person_Information_class NewInformation;

        DateTime ThisPersonDateOfBirth;
        private Decimal LostServicePrice = -1;
        private Decimal DamagedServicePrice = -1;

        private int PersonID = -1;
        private int LocalLicenseID = -1;
        private DateTime EndDate;
        private bool LicenseActive = false;

        enum ReplacementType
        {
            LostReplacement = 1,
            DamagedReplacement = 2,
                Non = 3
        }

        private byte ServiceType = (byte)ReplacementType.Non;

        private void btnDamaged_Click(object sender, EventArgs e)
        {
            ServiceType = (byte)ReplacementType.DamagedReplacement;

          
          
                Fees.Text = DamagedServicePrice.ToString() + " $";

            
        }

        private void btnLost_Click(object sender, EventArgs e)
        {
            ServiceType = (byte)ReplacementType.LostReplacement;
            Fees.Text = LostServicePrice.ToString() + " $";

        }



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
            LostServicePrice = GetServicePrice.GetServicePrice(LostLicenseServiceID).service_price;
            DamagedServicePrice = GetServicePrice.GetServicePrice(DamageLicenseServiceID).service_price;

            LocalLicenseID = NewLicenseInformation.Drive_License_ID;
            LicenseID.Text = LocalLicenseID.ToString();
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






            pnlPersonInfo.Visible = true;

        }


        private void txbSearch_TextChanged(object sender, EventArgs e)
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
                btnDamaged.Enabled = true;
                btnLost.Enabled = true;

                FullInformationCard(NewLicenseInfo);


                cls_LicenseDetain IfThisLicenseHold = new cls_LicenseDetain();
                if (!IfThisLicenseHold.Is_Reserved(LicenseID))
                {
                ErrorMessage.Visible = false;
                    btnIssue.Enabled = true;
                }
                else
                {
                    ErrorMessage.Text = "This license is Hold";
                     ErrorMessage.Visible = true;
                    btnIssue.Enabled = false;

                }

                if(LicenseActive)
                {
                      ErrorMessage.Visible = false;
                    btnIssue.Enabled = true;
                }
                else
                {
                    ErrorMessage.Text = "This license is inactive";

                    ErrorMessage.Visible = true;
                    btnIssue.Enabled = false;
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
                btnDamaged.Enabled = false;
                btnLost.Enabled = false;



            }
        }


        private void btnIssue_Click_1(object sender, EventArgs e)
        {

            if (LicenseActive)
            {

                if (PersonID != -1)
                {
                    orders_Information_Class NewOrder = new orders_Information_Class();





                    NewOrder.Application_fee_paid = LostServicePrice;
                    NewOrder.people_ID = PersonID;
                    if (ServiceType == (int)ReplacementType.LostReplacement)
                    {
                        NewOrder.service_ID = LostLicenseServiceID;
                    }
                    else if (ServiceType == (int)ReplacementType.DamagedReplacement)
                    {
                        NewOrder.service_ID = DamageLicenseServiceID;
                    }
                    else
                    {
                        MessageBox.Show("Error , Please .............. ","Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //
                        return;
                    }
                    NewOrder.order_status_ID = (int)orders_Information_Class.order_status.completed;



                    int OrderID = -1;
                    int NewID = -1;
                    if (NewApplication.AddNewOrder(NewOrder, ref OrderID))
                    {
                        cls_Licenses_Loc_Inte ReplacementLicense = new cls_Licenses_Loc_Inte();
                        drive_license_Information_Class AddNewLicense = new drive_license_Information_Class();

                        if (LocalLicenseID != -1)
                        {
                            AddNewLicense.Drive_License_ID = LocalLicenseID;
                            AddNewLicense.End_Date = EndDate;
                            if (ReplacementLicense.ReplacementLocalLicense(LocalLicenseID, ServiceType,ref NewID))
                            {
                                MessageBox.Show("The License has been successfully Replace, Go to the licenses screen for show new license .", "The operation was successful", MessageBoxButtons.OK);
                                txbSearch.Text = NewID.ToString();
                               // txbSearch_TextChanged(this,null);
                            }
                            else
                            {
                                NewApplication.UpdateOrderStatus(OrderID, orders_Information_Class.order_status.cancelled);
                                NewApplication.UpdateOrderFees(OrderID, 0);

                                //لا يدفع العميل اي مبلغ في هذه الحالة

                                MessageBox.Show("Error 5, an errore occurred while attempting to Replace license , The order is cancelled", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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


      




        private void us_Replacement_Load(object sender, EventArgs e)
        {

            NewApplication = new cls_Orders();
            ExistVerify = new cls_Licenses_Loc_Inte();
            Get_PersonInfo = new cls_People();
            NewInformation = new Person_Information_class();
        }

       
    }
}
