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
    public partial class Us_Renewals : UserControl
    {
        public Us_Renewals()
        {
            InitializeComponent();
        }


        //Renewals Service ID = 3 int DataBase

        private byte ServiceID = 3;

        //


        private cls_Licenses_Loc_Inte cls_LocalAndInternationalLicenses;


        // Local License Table Full Settings

        enum FilterBy_Local

        {
            NationalID = 1,
            FirstName = 2,
            Non = 3
        }


        private us_Optimised_Table localLicenseTable;
        private List<drive_license_Information_Class> LocalLicensesList;
        private List<drive_license_Information_Class> LocalLicense_CurrentPageList;
        private cls_Orders NewApplication;


        FilterBy_Local NewFilter_Loal = FilterBy_Local.Non;



        private string ReturnTableFullName_Local(string FirstName, string LastName)
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
        private void OptimiseTableToLocalLicenseTableForm()
        {


            localLicenseTable.picOptimiseTableIcon.BackgroundImage = (Drive_License_System_UI.Properties.Resources._99);
            localLicenseTable.lblOptimiseTableTitle.Text = "Expired Licenses";
            localLicenseTable.releasedateRowOptimiseTable.Text = "EXPIRY DATE";
            localLicenseTable.StatusRowOptimiseTable.Text = "DAYS OVERDUE";

            localLicenseTable.EditRow1.Visible = false;
            localLicenseTable.EditRow2.Visible = false;
            localLicenseTable.EditRow3.Visible = false;
            localLicenseTable.EditRow4.Visible = false;
            localLicenseTable.EditRow5.Visible = false;
            localLicenseTable.EditRow6.Visible = false;
            localLicenseTable.EditRow7.Visible = false;
            localLicenseTable.EditRow8.Visible = false;
            localLicenseTable.EditRow9.Visible = false;
            localLicenseTable.EditRow10.Visible = false;

            localLicenseTable.DeleteRow1.Visible = false;
            localLicenseTable.DeleteRow2.Visible = false;
            localLicenseTable.DeleteRow3.Visible = false;
            localLicenseTable.DeleteRow4.Visible = false;
            localLicenseTable.DeleteRow5.Visible = false;
            localLicenseTable.DeleteRow6.Visible = false;
            localLicenseTable.DeleteRow7.Visible = false;
            localLicenseTable.DeleteRow8.Visible = false;
            localLicenseTable.DeleteRow9.Visible = false;
            localLicenseTable.DeleteRow10.Visible = false;

            LocalInformationCard.btnRenewal.Visible = true;
            LocalInformationCard.btnRenewal.Enabled = false;

            LocalInformationCard.lblTax.Text = "Price";
            LocalInformationCard.lblTax.Visible = true;
            LocalInformationCard.pnlTax.Visible = true;
            LocalInformationCard.Tax.Visible = true;
            LocalInformationCard.Tax.ReadOnly = true;
            LocalInformationCard.NoteText.Text = "NEW NOTE";
            LocalInformationCard.Note.Visible = false;
            LocalInformationCard.Reason.Visible = true;

            localLicenseTable.cxbOptimiseTableFilter.Items.Clear();

            localLicenseTable.cxbOptimiseTableFilter.Items.Add("By National ID");
            localLicenseTable.cxbOptimiseTableFilter.Items.Add("By First Name");


        }

        private int Get_Differnce_in_Days_From_Now(DateTime Date)
        {

            int NumberOfDays = (DateTime.Now - Date).Days;




            return NumberOfDays;
        }

        private void AddLineToTable_Local(int PersonNumber, int LineNumber)
        {
            localLicenseTable.panelLine[LineNumber].Visible = true;
            try
            {
                localLicenseTable.PicColumn[LineNumber].Image = Image.FromFile(LocalLicensesList[PersonNumber].Personal_Photo);
            }
            catch
            {

            }
            localLicenseTable.LableColumn1[LineNumber].Text = ReturnTableFullName_Local(LocalLicensesList[PersonNumber].First_Name, LocalLicensesList[PersonNumber].Last_Name);
            localLicenseTable.LableColumn2[LineNumber].Text = LocalLicensesList[PersonNumber].Drive_License_ID.ToString();
            localLicenseTable.LableColumn3[LineNumber].Text = LocalLicensesList[PersonNumber].End_Date.Year.ToString() + "/" + LocalLicensesList[PersonNumber].End_Date.Month.ToString() + "/" + LocalLicensesList[PersonNumber].End_Date.Day.ToString();



          
                localLicenseTable.LableColumn4[LineNumber].ForeColor = Color.FromArgb(255, 120, 120);
            localLicenseTable.PanelColumn4[LineNumber].FillColor = Color.FromArgb(75, 30, 50);


            localLicenseTable.LableColumn4[LineNumber].Text = Get_Differnce_in_Days_From_Now(LocalLicensesList[PersonNumber].End_Date).ToString() + " days";
            
           


            localLicenseTable.LableColumn4[LineNumber].Location = new Point(
           (localLicenseTable.PanelColumn4[LineNumber].Width - localLicenseTable.LableColumn4[LineNumber].Width) / 2,
           (localLicenseTable.PanelColumn4[LineNumber].Height - localLicenseTable.LableColumn4[LineNumber].Height) / 2);



            LocalLicense_CurrentPageList.Add(LocalLicensesList[PersonNumber]);
        }

        private void FullTableInformation_Local()
        {
            LocalLicense_CurrentPageList.Clear();

            try
            {

                if (LocalLicensesList != null && LocalLicensesList.Count > 0)
                {

                    localLicenseTable.TotalPages = (int)Math.Ceiling((double)LocalLicensesList.Count / 10);


                    for (int i = 9; i >= 0; i--)
                    {
                        localLicenseTable.panelLine[i].Visible = false;
                    }



                    {



                        if (localLicenseTable.TotalPages == localLicenseTable.CurrentPage)

                        {
                            if (LocalLicensesList.Count % 10 != 0)

                                localLicenseTable.NumberOfRowsInThis = LocalLicensesList.Count % 10;

                            else
                            {
                                localLicenseTable.NumberOfRowsInThis = 10;

                            }
                        }
                        else
                        {
                            localLicenseTable.NumberOfRowsInThis = 10;

                        }

                        localLicenseTable.txtCountOptimiseTable.Text = "Showing 1 - " + localLicenseTable.NumberOfRowsInThis + " of " + LocalLicensesList.Count + " Licenses";
                        localLicenseTable.ShowListCountOptimiseTable.Text = localLicenseTable.CurrentPage + " of " + localLicenseTable.TotalPages;
                        for (int i = 0; i < localLicenseTable.NumberOfRowsInThis; i++)
                        {
                            AddLineToTable_Local(localLicenseTable.CurrentLineInfo, i);

                            localLicenseTable.CurrentLineInfo++;


                        }


                    }
                }

                else
                {
                    localLicenseTable.txtCountOptimiseTable.Text = "There is no one matching this search";
                    localLicenseTable.ShowListCountOptimiseTable.Text = "0 page";
                    //   OrderInformationCard.pnlfull.Visible = false;



                    for (int i = 9; i >= 0; i--)
                    {
                        localLicenseTable.panelLine[i].Visible = false;

                    }
                }


            }
            catch
            {
                localLicenseTable.txtCountOptimiseTable.Text = "There is no one matching this search";
                localLicenseTable.ShowListCountOptimiseTable.Text = "0 page";
                //   OrderInformationCard.pnlfull.Visible = false;



                for (int i = 9; i >= 0; i--)
                {
                    localLicenseTable.panelLine[i].Visible = false;

                }
            }
        }


        private void LocalLicenseTable_NextPageButtonClicked()
        {

            if (localLicenseTable.CurrentPage < localLicenseTable.TotalPages)
            {
                localLicenseTable.CurrentPage++;

                FullTableInformation_Local();


            }
        }

        private void LocalLicenseTable_PreviousPageButtonClicked()
        {
            if (localLicenseTable.CurrentPage > 1)
            {
                localLicenseTable.CurrentPage--;
                localLicenseTable.CurrentLineInfo = localLicenseTable.CurrentLineInfo - (10 + localLicenseTable.NumberOfRowsInThis);

                FullTableInformation_Local();
            }
        }

        private void LocalLicenseTable_ShearchTextChange(object sender, EventArgs e)
        {
            if (LocalLicensesList != null)
            {
                if (NewFilter_Loal == FilterBy_Local.NationalID)
                {

                    LocalLicensesList.Clear();
                    string NationalID = localLicenseTable.txbOptimiseTableSearch.Text;

                    List<drive_license_Information_Class> GetNew = cls_LocalAndInternationalLicenses.Filter_ExpiryLicenses_ByNationalID(NationalID);
                    if (GetNew != null)
                    {

                        LocalLicensesList = GetNew;


                    }

                    localLicenseTable.CurrentLineInfo = 0;
                    localLicenseTable.CurrentPage = 1;

                    FullTableInformation_Local();

                }

                else if (NewFilter_Loal == FilterBy_Local.FirstName)
                {

                    LocalLicensesList.Clear();

                    string FirstName = localLicenseTable.txbOptimiseTableSearch.Text;

                    List<drive_license_Information_Class> GetNew = cls_LocalAndInternationalLicenses.Filter_ExpiryLicenses_ByFirstName(FirstName);
                    if (GetNew != null)
                    {

                        LocalLicensesList = GetNew;


                    }

                    localLicenseTable.CurrentLineInfo = 0;
                    localLicenseTable.CurrentPage = 1;

                    FullTableInformation_Local();

                }

                else if (NewFilter_Loal == FilterBy_Local.Non)
                {

                }


            }

        }

        private void SelectedIndexChanged_Local()
        {
            if (localLicenseTable.cxbOptimiseTableFilter.Text == "By National ID")
            {
                NewFilter_Loal = FilterBy_Local.NationalID;
            }
            else if (localLicenseTable.cxbOptimiseTableFilter.Text == "By First Name")
            {
                NewFilter_Loal = FilterBy_Local.FirstName;
            }
            else
            {
                NewFilter_Loal = FilterBy_Local.Non;
            }
        }


        //


        // Full Local  License Card
        us_LicenseInformationCard LocalInformationCard;

        private int PersonID = -1;
        private int LicenseID  = -1;
        private Decimal ServicePrice = -1;
        private void FullLocalLicenseCardInfo()
        {
            cls_Services GetServicePrice = new cls_Services();

            LocalInformationCard.Visible = true;
            int ThisInternationalLicense = localLicenseTable.CurrentActionLinePersonDetile - 1;

            cls_LicenseDetain DetainStatus = new cls_LicenseDetain();


            try
            {
                LocalInformationCard.personalPhoto.Image = Image.FromFile(LocalLicense_CurrentPageList[ThisInternationalLicense].Personal_Photo);
            }
            catch
            {

            }
            LocalInformationCard.personalName.Text = LocalLicense_CurrentPageList[ThisInternationalLicense].First_Name + " " + LocalLicense_CurrentPageList[ThisInternationalLicense].Last_Name;
            LocalInformationCard.LicenseID.Text = LocalLicense_CurrentPageList[ThisInternationalLicense].Drive_License_ID.ToString();
            LicenseID = LocalLicense_CurrentPageList[ThisInternationalLicense].Drive_License_ID;
            PersonID = LocalLicense_CurrentPageList[ThisInternationalLicense].person_ID;
            LocalInformationCard.DriverID.Text = LocalLicense_CurrentPageList[ThisInternationalLicense].Driver_ID.ToString();

            LocalInformationCard.categoryName.Text = LocalLicense_CurrentPageList[ThisInternationalLicense].Category_Name;



            LocalInformationCard.IssuanceDate.Text = LocalLicense_CurrentPageList[ThisInternationalLicense].Relese_Date.Year.ToString() + "/" + LocalLicense_CurrentPageList[ThisInternationalLicense].Relese_Date.Month.ToString() + "/" + LocalLicense_CurrentPageList[ThisInternationalLicense].Relese_Date.Day.ToString();

            LocalInformationCard.ExpiryDate.Text = LocalLicense_CurrentPageList[ThisInternationalLicense].End_Date.Year.ToString() + "/" + LocalLicense_CurrentPageList[ThisInternationalLicense].End_Date.Month.ToString() + "/" + LocalLicense_CurrentPageList[ThisInternationalLicense].End_Date.Day.ToString();

            LocalInformationCard.Reason.Text = LocalLicense_CurrentPageList[ThisInternationalLicense].Comment;

            if (LocalLicense_CurrentPageList[ThisInternationalLicense].Is_Active == true)
            {
                LocalInformationCard.lblDriveLicenseCardStute.ForeColor = Color.LimeGreen;


                LocalInformationCard.lblDriveLicenseCardStute.Text = "● Active";
                LocalInformationCard.pnlDriveLicenseCardStute.FillColor = Color.FromArgb(0, 64, 0);
            }
            else
            {
                LocalInformationCard.lblDriveLicenseCardStute.ForeColor = Color.Silver;
                LocalInformationCard.lblDriveLicenseCardStute.Text = "● Inactive";
                LocalInformationCard.pnlDriveLicenseCardStute.FillColor = Color.FromArgb(64, 64, 64);
            }

            if (!DetainStatus.Is_Reserved(LocalLicense_CurrentPageList[ThisInternationalLicense].Drive_License_ID))
            {
                LocalInformationCard.lblDetentionstatus.ForeColor = Color.LimeGreen;


                LocalInformationCard.lblDetentionstatus.Text = "No";
                LocalInformationCard.pnlDetentionstatus.FillColor = Color.FromArgb(0, 64, 0);
                LocalInformationCard.btnRenewal.Enabled = true;
                LocalInformationCard.Reason.ReadOnly = false;
                ServicePrice = GetServicePrice.GetServicePrice(ServiceID).service_price;
                LocalInformationCard.Tax.Text = ServicePrice.ToString() + "$";


            }
            else
            {
                LocalInformationCard.lblDetentionstatus.ForeColor = Color.FromArgb(255, 120, 120);
                LocalInformationCard.lblDetentionstatus.Text = "Yes";
                LocalInformationCard.pnlDetentionstatus.FillColor = Color.FromArgb(75, 30, 50);
                LocalInformationCard.btnRenewal.Enabled = false;
                LocalInformationCard.Reason.ReadOnly = true;
                LocalInformationCard.Tax.Text = "0 $";



            }

            //if det  yes/no




            LocalInformationCard.pnlfull.Visible = true;


        }



        private void ActionShowMoreDetileLicense_Click_Local()
        {

            LocalInformationCard.Dock = DockStyle.Left;
            FullLocalLicenseCardInfo();
            pnlscreen.Controls.Add(LocalInformationCard);

        }

        private void ExitLicenseInformationCard_Local()
        {
            LocalInformationCard.Visible = false;

        }


        private void btnRenewalLicenseClick()
        {

            DialogResult result = MessageBox.Show("Are you sure about Renewal this License ?, The international license linked to this license will be deleted, if applicable!", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                if (PersonID != -1 )
                {
                    orders_Information_Class NewOrder = new orders_Information_Class();





                    NewOrder.Application_fee_paid = ServicePrice;
                    NewOrder.people_ID = PersonID;
                              NewOrder.service_ID = ServiceID;
                                     NewOrder.order_status_ID = (int)orders_Information_Class.order_status.completed;



                    int OrderID = -1;
                    int NewLicenseID = -1;
                    if (NewApplication.AddNewOrder(NewOrder, ref OrderID))
                    {
                        cls_Licenses_Loc_Inte RenewalLicense = new cls_Licenses_Loc_Inte();
                        drive_license_Information_Class AddNewLicense = new drive_license_Information_Class();

                        if (LicenseID != -1)
                        {
                            AddNewLicense.Drive_License_ID = LicenseID;

                            string NewNote = LocalInformationCard.Reason.Text;

                            if (RenewalLicense.RenewalLocalLicense(LicenseID, NewNote, ref NewLicenseID))
                            {
                                ExitLicenseInformationCard_Local();
                               
                                MessageBox.Show($"The License has been successfully Renewal ,Order ID: {OrderID}, Go to the licenses screen for show new license, New License ID: {NewLicenseID} .", "The operation was successful", MessageBoxButtons.OK);
                                LocalLicensesList = cls_LocalAndInternationalLicenses.GetLicensesList();
                                NewFilter_Loal = FilterBy_Local.FirstName;
                                LocalLicenseTable_ShearchTextChange(this, null);

                            }
                            else
                            {
                                NewApplication.UpdateOrderStatus(OrderID, orders_Information_Class.order_status.cancelled);
                                NewApplication.UpdateOrderFees(OrderID, 0);

                                //لا يدفع العميل اي مبلغ في هذه الحالة

                                MessageBox.Show("Error 5, an errore occurred while attempting to Renewal license , The order is cancelled", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
        }
        //



        private void pnlscreen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Us_Renewals_Load(object sender, EventArgs e)
        {

            cls_Licenses_Loc_Inte.RefreshExpiryLicenses();

            cls_LocalAndInternationalLicenses = new cls_Licenses_Loc_Inte();

            // Local Licenses Settings


            localLicenseTable = new us_Optimised_Table();
            LocalLicense_CurrentPageList = new List<drive_license_Information_Class>();
            LocalLicensesList = new List<drive_license_Information_Class>();
            LocalInformationCard = new us_LicenseInformationCard();
             NewApplication = new cls_Orders();


            LocalLicensesList = cls_LocalAndInternationalLicenses.GetExpiryLicensesList();

            localLicenseTable.Dock = DockStyle.Right;


            this.localLicenseTable.NextPageButtonClicked += LocalLicenseTable_NextPageButtonClicked;
            this.localLicenseTable.PreviousPageButtonClicked += LocalLicenseTable_PreviousPageButtonClicked;
            this.localLicenseTable.ShearchTextChange += LocalLicenseTable_ShearchTextChange;
            this.localLicenseTable.SelectedIndexChanged += SelectedIndexChanged_Local;
            this.localLicenseTable.ActionShowMoreDetilePerson_Click += ActionShowMoreDetileLicense_Click_Local;
            this.LocalInformationCard.ExitLicenseInformationCard += ExitLicenseInformationCard_Local;
            this.LocalInformationCard.RenewalLicense += btnRenewalLicenseClick;

            OptimiseTableToLocalLicenseTableForm();
            FullTableInformation_Local();


            pnlscreen.Controls.Add(localLicenseTable);

            //
        }
    }
}
