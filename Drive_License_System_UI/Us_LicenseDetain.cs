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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Drive_License_System_UI
{
    public partial class Us_LicenseDetain : UserControl
    {

        //Release License Service ID = '6' In DataBase

        private byte ServiceID = 6;
        //
        public Us_LicenseDetain()
        {
            InitializeComponent();
        }

        private void pnlscreen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Us_LicenseDetain_Click(object sender, EventArgs e)
        {

        }



        private cls_LicenseDetain cls_LicenseDetain;


        //  License Table Full Settings

        enum FilterBy_Local

        {
            NationalID = 1,
            FirstName = 2,
            Non = 3
        }


        private us_Optimised_Table localLicenseTable;
        private List<drive_license_Information_Class> LocalLicensesList;
        private List<drive_license_Information_Class> LocalLicense_CurrentPageList;


        FilterBy_Local NewFilter_Local = FilterBy_Local.Non;



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




            localLicenseTable.cxbOptimiseTableFilter.Items.Clear();

            localLicenseTable.cxbOptimiseTableFilter.Items.Add("By National ID");
            localLicenseTable.cxbOptimiseTableFilter.Items.Add("By First Name");


            localLicenseTable.lblOptimiseTableTitle.Text = " Active Licenses ";
            localLicenseTable.picOptimiseTableIcon.BackgroundImage = Drive_License_System_UI.Properties.Resources._73;
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
            localLicenseTable.LableColumn3[LineNumber].Text = LocalLicensesList[PersonNumber].Relese_Date.Year.ToString() + "/" + LocalLicensesList[PersonNumber].Relese_Date.Month.ToString() + "/" + LocalLicensesList[PersonNumber].Relese_Date.Day.ToString();



            if (LocalLicensesList[PersonNumber].Is_Active == true)
            {
                localLicenseTable.LableColumn4[LineNumber].ForeColor = Color.LimeGreen;


                localLicenseTable.LableColumn4[LineNumber].Text = "● Active";
                localLicenseTable.PanelColumn4[LineNumber].FillColor = Color.FromArgb(0, 64, 0);
            }
            else
            {
                localLicenseTable.LableColumn4[LineNumber].ForeColor = Color.Silver;
                localLicenseTable.LableColumn4[LineNumber].Text = "● Inactive";
                localLicenseTable.PanelColumn4[LineNumber].FillColor = Color.FromArgb(64, 64, 64);
            }


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

                if (LocalLicensesList.Count > 0)
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

                        localLicenseTable.txtCountOptimiseTable.Text = "Showing 1 - " + localLicenseTable.NumberOfRowsInThis + " of " + LocalLicensesList.Count + " Items";
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

            if (NewFilter_Local == FilterBy_Local.NationalID)
            {

                LocalLicensesList.Clear();
                string NationalID = localLicenseTable.txbOptimiseTableSearch.Text;

                List<drive_license_Information_Class> GetNew = cls_LicenseDetain.Get_Filter_By_NationalID_Not_Reservd_And_Active_Licenses(NationalID);
                if (GetNew != null)
                {

                    LocalLicensesList = GetNew;


                }

                localLicenseTable.CurrentLineInfo = 0;
                localLicenseTable.CurrentPage = 1;

                FullTableInformation_Local();

            }

            else if (NewFilter_Local == FilterBy_Local.FirstName)
            {

                LocalLicensesList.Clear();

                string FirstName = localLicenseTable.txbOptimiseTableSearch.Text;

                List<drive_license_Information_Class> GetNew = cls_LicenseDetain.Get_Filter_By_FirstName_Not_Reservd_And_Active_Licenses(FirstName);
                if (GetNew != null)
                {

                    LocalLicensesList = GetNew;


                }

                localLicenseTable.CurrentLineInfo = 0;
                localLicenseTable.CurrentPage = 1;

                FullTableInformation_Local();

            }

            else if (NewFilter_Local == FilterBy_Local.Non)
            {

            }




        }

        private void SelectedIndexChanged_Local()
        {
            if (localLicenseTable.cxbOptimiseTableFilter.Text == "By National ID")
            {
                NewFilter_Local = FilterBy_Local.NationalID;
            }
            else if (localLicenseTable.cxbOptimiseTableFilter.Text == "By First Name")
            {
                NewFilter_Local = FilterBy_Local.FirstName;
            }
            else
            {
                NewFilter_Local = FilterBy_Local.Non;
            }
        }


        //


        // Full Local  License Card
        us_LicenseInformationCard LocalInformationCard;
        private int ThisLicenseID = -1;
        private void FullLocalLicenseCardInfo()
        {
            LocalInformationCard.Visible = true;
            LocalInformationCard.btnHeld.Visible = true;
            LocalInformationCard.Note.Visible = false;
            LocalInformationCard.Reason.Visible = true;
            LocalInformationCard.Reason.ReadOnly = false;
            LocalInformationCard.pnlTax.Visible = true;
            LocalInformationCard.lblTax.Visible = true;
            LocalInformationCard.Tax.ReadOnly = false;

            LocalInformationCard.lblCardPersonTitle.Text = "Drive License Card";
            LocalInformationCard.NoteText.Text = "The Reason";


            int ThisInternationalLicense = localLicenseTable.CurrentActionLinePersonDetile - 1;

           ThisLicenseID = LocalLicense_CurrentPageList[ThisInternationalLicense].Drive_License_ID;



            try
            {
                LocalInformationCard.personalPhoto.Image = Image.FromFile(LocalLicense_CurrentPageList[ThisInternationalLicense].Personal_Photo);
            }
            catch
            {

            }
            LocalInformationCard.personalName.Text = LocalLicense_CurrentPageList[ThisInternationalLicense].First_Name + " " + LocalLicense_CurrentPageList[ThisInternationalLicense].Last_Name;
            LocalInformationCard.LicenseID.Text = LocalLicense_CurrentPageList[ThisInternationalLicense].Drive_License_ID.ToString();


            LocalInformationCard.DriverID.Text = LocalLicense_CurrentPageList[ThisInternationalLicense].Driver_ID.ToString();

            LocalInformationCard.categoryName.Text = LocalLicense_CurrentPageList[ThisInternationalLicense].Category_Name;



            LocalInformationCard.IssuanceDate.Text = LocalLicense_CurrentPageList[ThisInternationalLicense].Relese_Date.Year.ToString() + "/" + LocalLicense_CurrentPageList[ThisInternationalLicense].Relese_Date.Month.ToString() + "/" + LocalLicense_CurrentPageList[ThisInternationalLicense].Relese_Date.Day.ToString();

            LocalInformationCard.ExpiryDate.Text = LocalLicense_CurrentPageList[ThisInternationalLicense].End_Date.Year.ToString() + "/" + LocalLicense_CurrentPageList[ThisInternationalLicense].End_Date.Month.ToString() + "/" + LocalLicense_CurrentPageList[ThisInternationalLicense].End_Date.Day.ToString();

            LocalInformationCard.Note.Text = LocalLicense_CurrentPageList[ThisInternationalLicense].Comment;

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

          
                LocalInformationCard.lblDetentionstatus.ForeColor = Color.LimeGreen;


                LocalInformationCard.lblDetentionstatus.Text = "No";
                LocalInformationCard.pnlDetentionstatus.FillColor = Color.FromArgb(0, 64, 0);
            

            //if det  yes/no





            LocalInformationCard.pnlfull.Visible = true;


        }



        private void ActionShowMoreDetileLicense_Click_Local()
        {

            LicenseDetainTable.Visible = false;
            LocalInformationCard.Dock = DockStyle.Right;
            FullLocalLicenseCardInfo();
            pnlscreen.Controls.Add(LocalInformationCard);

        }

        private void ExitLicenseInformationCard_Local()
        {
            LocalInformationCard.Visible = false;
            LicenseDetainTable.Visible = true;

        }


        private bool Verifies_Detain_accuracy_Info_FromUI()
        {
            bool TheDataIsClean = true;




            if (string.IsNullOrWhiteSpace(NewReserve.Tax.ToString()) || NewReserve.Tax < 0)
            {
                MessageBox.Show("Invalid Tax", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(NewReserve.Reason_For_Reservation))
            {
                MessageBox.Show("Please enter the reason", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (NewReserve.Drive_License_ID < 0)
            {
                MessageBox.Show("Detain Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return TheDataIsClean;
        }

        public void Held_This_License()
        {



            if (MessageBox.Show("Are you sure you want to held this license?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                decimal Tax;



                if (decimal.TryParse(LocalInformationCard.Tax.Text, out Tax))
                {
                    NewReserve.Tax = Tax;
                }
                else
                {
                    NewReserve.Tax = -1;
                }

                NewReserve.Reason_For_Reservation = LocalInformationCard.Reason.Text;
                NewReserve.Drive_License_ID = ThisLicenseID;

                if (!Verifies_Detain_accuracy_Info_FromUI())
                {
                    return;
                }

                if (cls_LicenseDetain.Add_Reserve_Drive_License(NewReserve))
                {

                    MessageBox.Show("The operation was completed successfully. The license now is detain");

                    ExitLicenseInformationCard_Local();

                    NewFilter_Local = FilterBy_Local.FirstName;

                    LocalLicenseTable_ShearchTextChange(this, EventArgs.Empty);

                    NewFilter_Local = FilterBy_Local.Non;

                    NewFilter = FilterBy.FirstName;

                    DetainLicenseTable_ShearchTextChange(this, EventArgs.Empty);

                    NewFilter = FilterBy.Non;



                }
                else
                {
                    MessageBox.Show("An error occurred while processing your request. Please try again");

                }

            } }

        //



        //Detain License Table Full Settings

        enum FilterBy
        {
            DetainID = 1,
            FirstName = 2,
            Non = 3
        }


        private us_Optimised_Table LicenseDetainTable;
        private List<reservation_Informaton_Class> LicenseDetainList;
        private List<reservation_Informaton_Class> DetainLicense_CurrentPageList;
        private reservation_Informaton_Class NewReserve;



        FilterBy NewFilter = FilterBy.Non;

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
        private void OptimiseTableToDetainLicenseTableForm()
        {


            LicenseDetainTable.EditRow1.Visible = false;
            LicenseDetainTable.EditRow2.Visible = false;
            LicenseDetainTable.EditRow3.Visible = false;
            LicenseDetainTable.EditRow4.Visible = false;
            LicenseDetainTable.EditRow5.Visible = false;
            LicenseDetainTable.EditRow6.Visible = false;
            LicenseDetainTable.EditRow7.Visible = false;
            LicenseDetainTable.EditRow8.Visible = false;
            LicenseDetainTable.EditRow9.Visible = false;
            LicenseDetainTable.EditRow10.Visible = false;

            LicenseDetainTable.DeleteRow1.Visible = false;
            LicenseDetainTable.DeleteRow2.Visible = false;
            LicenseDetainTable.DeleteRow3.Visible = false;
            LicenseDetainTable.DeleteRow4.Visible = false;
            LicenseDetainTable.DeleteRow5.Visible = false;
            LicenseDetainTable.DeleteRow6.Visible = false;
            LicenseDetainTable.DeleteRow7.Visible = false;
            LicenseDetainTable.DeleteRow8.Visible = false;
            LicenseDetainTable.DeleteRow9.Visible = false;
            LicenseDetainTable.DeleteRow10.Visible = false;



            LicenseDetainTable.lblOptimiseTableTitle.Text = "Confiscated Licenses";  
            LicenseDetainTable.LabelLicenseNoRowOptimiseTable.Text = "DETAIN ID";
            LicenseDetainTable.releasedateRowOptimiseTable.Text = "CONFISCATION DATE";
            LicenseDetainTable.picOptimiseTableIcon.BackgroundImage = Drive_License_System_UI.Properties.Resources.n;

            LicenseDetainTable.cxbOptimiseTableFilter.Items.Clear();

            LicenseDetainTable.cxbOptimiseTableFilter.Items.Add("By Detain ID");
            LicenseDetainTable.cxbOptimiseTableFilter.Items.Add("By First Name");




        }

        private void AddLineToTable(int PersonNumber, int LineNumber)
        {
            LicenseDetainTable.panelLine[LineNumber].Visible = true;
            try
            {
                LicenseDetainTable.PicColumn[LineNumber].Image = Image.FromFile(LicenseDetainList[PersonNumber].Personal_Photo);
            }
            catch
            {

            }
            LicenseDetainTable.LableColumn1[LineNumber].Text = ReturnTableFullName(LicenseDetainList[PersonNumber].First_Name, LicenseDetainList[PersonNumber].Last_Name);
            LicenseDetainTable.LableColumn2[LineNumber].Text = LicenseDetainList[PersonNumber].Reservation_ID.ToString();
            LicenseDetainTable.LableColumn3[LineNumber].Text = LicenseDetainList[PersonNumber].Reservation_Date.Year.ToString() + "/" + LicenseDetainList[PersonNumber].Reservation_Date.Month.ToString() + "/" + LicenseDetainList[PersonNumber].Reservation_Date.Day.ToString();


                LicenseDetainTable.LableColumn4[LineNumber].ForeColor = Color.Silver;
                LicenseDetainTable.LableColumn4[LineNumber].Text = "● Inactive";
                LicenseDetainTable.PanelColumn4[LineNumber].FillColor = Color.FromArgb(64, 64, 64);
            


            LicenseDetainTable.LableColumn4[LineNumber].Location = new Point(
           (LicenseDetainTable.PanelColumn4[LineNumber].Width - LicenseDetainTable.LableColumn4[LineNumber].Width) / 2,
           (LicenseDetainTable.PanelColumn4[LineNumber].Height - LicenseDetainTable.LableColumn4[LineNumber].Height) / 2);



            DetainLicense_CurrentPageList.Add(LicenseDetainList[PersonNumber]);
        }

        private void FullTableInformation()
        {
            DetainLicense_CurrentPageList.Clear();



            if (  LicenseDetainList != null && LicenseDetainList.Count > 0)
            {

                LicenseDetainTable.TotalPages = (int)Math.Ceiling((double)LicenseDetainList.Count / 10);


                for (int i = 9; i >= 0; i--)
                {
                    LicenseDetainTable.panelLine[i].Visible = false;
                }



                {



                    if (LicenseDetainTable.TotalPages == LicenseDetainTable.CurrentPage)

                    {
                        if (LicenseDetainList.Count % 10 != 0)

                            LicenseDetainTable.NumberOfRowsInThis = LicenseDetainList.Count % 10;

                        else
                        {
                            LicenseDetainTable.NumberOfRowsInThis = 10;

                        }
                    }
                    else
                    {
                        LicenseDetainTable.NumberOfRowsInThis = 10;

                    }

                    LicenseDetainTable.txtCountOptimiseTable.Text = "Showing 1 - " + LicenseDetainTable.NumberOfRowsInThis + " of " + LicenseDetainList.Count + " Items";
                    LicenseDetainTable.ShowListCountOptimiseTable.Text = LicenseDetainTable.CurrentPage + " of " + LicenseDetainTable.TotalPages;
                    for (int i = 0; i < LicenseDetainTable.NumberOfRowsInThis; i++)
                    {
                        AddLineToTable(LicenseDetainTable.CurrentLineInfo, i);

                        LicenseDetainTable.CurrentLineInfo++;


                    }


                }
            }
            else
            {
                LicenseDetainTable.txtCountOptimiseTable.Text = "There is no one matching this search";
                LicenseDetainTable.ShowListCountOptimiseTable.Text = "0 page";



                for (int i = 9; i >= 0; i--)
                {
                    LicenseDetainTable.panelLine[i].Visible = false;

                }
            }


        }

        private void DetainLicenseTable_NextPageButtonClicked()
        {

            if (LicenseDetainTable.CurrentPage < LicenseDetainTable.TotalPages)
            {
                LicenseDetainTable.CurrentPage++;

                FullTableInformation();


            }
        }

        private void DetainLicenseTable_PreviousPageButtonClicked()
        {
            if (LicenseDetainTable.CurrentPage > 1)
            {
                LicenseDetainTable.CurrentPage--;
                LicenseDetainTable.CurrentLineInfo = LicenseDetainTable.CurrentLineInfo - (10 + LicenseDetainTable.NumberOfRowsInThis);

                FullTableInformation();
            }
        }

        private void DetainLicenseTable_ShearchTextChange(object sender, EventArgs e)
        {


            if (LicenseDetainList != null && LicenseDetainList.Count > 0)
            {

                if (NewFilter == FilterBy.DetainID)
                {

                    LicenseDetainList.Clear();
                    int DetainID;

                    if (int.TryParse(LicenseDetainTable.txbOptimiseTableSearch.Text, out DetainID))
                    {
                    }
                    else
                    {
                        DetainID = -1;
                    }

                    List<reservation_Informaton_Class> GetNew = cls_LicenseDetain.Get_Filter_By_NationalID_Reservation_List(DetainID);


                    if (GetNew != null)
                    {

                        LicenseDetainList = GetNew;


                    }

                    LicenseDetainTable.CurrentLineInfo = 0;
                    LicenseDetainTable.CurrentPage = 1;

                    FullTableInformation();

                }

                else if (NewFilter == FilterBy.FirstName)
                {

                    LicenseDetainList.Clear();

                    string FirstName = LicenseDetainTable.txbOptimiseTableSearch.Text;

                    List<reservation_Informaton_Class> GetNew = cls_LicenseDetain.Get_Filter_By_FirstName_Reservation_List(FirstName);
                    if (GetNew != null)
                    {

                        LicenseDetainList = GetNew;


                    }

                    LicenseDetainTable.CurrentLineInfo = 0;
                    LicenseDetainTable.CurrentPage = 1;

                    FullTableInformation();

                }

                else if (NewFilter == FilterBy.Non)
                {

                }


            }

        }

        private void SelectedIndexChanged()
        {
            if (LicenseDetainTable.cxbOptimiseTableFilter.Text == "By Detain ID")
            {
                NewFilter = FilterBy.DetainID;
            }
            else if (LicenseDetainTable.cxbOptimiseTableFilter.Text == "By First Name")
            {
                NewFilter = FilterBy.FirstName;
            }
            else
            {
                NewFilter = FilterBy.Non;
            }
        }


        //

        // Full Release License Card
        us_LicenseDetainCard ReleaseLicenseCard;
        private int ThisDetainID = -1;
        private int ThisPersonID = -1;
        private Decimal ThisPaid = -1;
        private int This_License_ID = -1;
        private DateTime ExpiryDate;
        private void FullDetainLicenseCardInfo()
        {
            ReleaseLicenseCard.Visible = true;
            int ThisLicense = LicenseDetainTable.CurrentActionLinePersonDetile - 1;

            drive_license_Information_Class NewInfo = new drive_license_Information_Class();
            Services_Information_Class ThisService = new Services_Information_Class();
            NewInfo = cls_LicenseDetain.Get_License_Detain_Information(DetainLicense_CurrentPageList[ThisLicense].Drive_License_ID);

            This_License_ID = DetainLicense_CurrentPageList[ThisLicense].Drive_License_ID;
            ExpiryDate = NewInfo.End_Date;

            //This Service ID = 6;
            ThisService = cls_LicenseDetain.Get_Service_Detain_Price(ServiceID);

            
            try
            {
                ReleaseLicenseCard.personalPhoto.Image = Image.FromFile(DetainLicense_CurrentPageList[ThisLicense].Personal_Photo);
            }
            catch
            {

            }
            ReleaseLicenseCard.personalName.Text = DetainLicense_CurrentPageList[ThisLicense].First_Name + " " + DetainLicense_CurrentPageList[ThisLicense].Last_Name;
            ReleaseLicenseCard.LicenseID.Text = NewInfo.Drive_License_ID.ToString();


            ReleaseLicenseCard.DriverID.Text = NewInfo.Driver_ID.ToString();

            ReleaseLicenseCard.categoryName.Text = DetainLicense_CurrentPageList[ThisLicense].Category_Name;



            ReleaseLicenseCard.IssuanceDate.Text = NewInfo.Relese_Date.Year.ToString() + "/" + NewInfo.Relese_Date.Month.ToString() + "/" + NewInfo.Relese_Date.Day.ToString();

            ReleaseLicenseCard.ExpiryDate.Text = NewInfo.End_Date.Year.ToString() + "/" + NewInfo.End_Date.Month.ToString() + "/" + NewInfo.End_Date.Day.ToString();


            if (NewInfo.Is_Active == true)
            {
                ReleaseLicenseCard.lblDriveLicenseCardStute.ForeColor = Color.LimeGreen;


                ReleaseLicenseCard.lblDriveLicenseCardStute.Text = "● Active";
                ReleaseLicenseCard.pnlDriveLicenseCardStute.FillColor = Color.FromArgb(0, 64, 0);
            }
            else
            {
                ReleaseLicenseCard.lblDriveLicenseCardStute.ForeColor = Color.Silver;
                ReleaseLicenseCard.lblDriveLicenseCardStute.Text = "● Inactive";
                ReleaseLicenseCard.pnlDriveLicenseCardStute.FillColor = Color.FromArgb(64, 64, 64);
            }

            //if det  yes/no



            ReleaseLicenseCard.lblDetentionstatus.ForeColor = Color.FromArgb(255, 120, 120);
            ReleaseLicenseCard.lblDetentionstatus.Text = "Yes";
            ReleaseLicenseCard.pnlDetentionstatus.FillColor = Color.FromArgb(75, 30, 50);

            ReleaseLicenseCard.HeldID.Text = DetainLicense_CurrentPageList[ThisLicense].Reservation_ID.ToString();
            ThisDetainID = DetainLicense_CurrentPageList[ThisLicense].Reservation_ID;


            ReleaseLicenseCard.userID.Text = DetainLicense_CurrentPageList[ThisLicense].User_ID.ToString();
            ReleaseLicenseCard.HeldDate.Text = DetainLicense_CurrentPageList[ThisLicense].Reservation_Date.Year.ToString() + "/" + DetainLicense_CurrentPageList[ThisLicense].Reservation_Date.Month.ToString() + "/" + DetainLicense_CurrentPageList[ThisLicense].Reservation_Date.Day.ToString();


            //This Service ID = 6;

            ReleaseLicenseCard.ServiceName.Text = ThisService.service_Name;
            ReleaseLicenseCard.Service_Price.Text = ThisService.service_price.ToString() + " $";

            ReleaseLicenseCard.Tax.Text = DetainLicense_CurrentPageList[ThisLicense].Tax.ToString()+ " $";


            ReleaseLicenseCard.TotallPrice.Text = (DetainLicense_CurrentPageList[ThisLicense].Tax + ThisService.service_price).ToString()+" $" ;


            ReleaseLicenseCard.Reason.Text = DetainLicense_CurrentPageList[ThisLicense].Reason_For_Reservation;


            ThisPaid = (DetainLicense_CurrentPageList[ThisLicense].Tax + ThisService.service_price);
            ThisPersonID = DetainLicense_CurrentPageList[ThisLicense].Person_ID;




            ReleaseLicenseCard.pnlfull.Visible = true;


        }


        private void ActionShowMoreDetileLicense_Click()
        {

            localLicenseTable.Visible = false;
            ReleaseLicenseCard.Dock = DockStyle.Left;
            FullDetainLicenseCardInfo();
            pnlscreen.Controls.Add(ReleaseLicenseCard);

        }

        private void ExitLicenseReleaseCard()
        {
            ReleaseLicenseCard.Visible = false;
            localLicenseTable.Visible = true;

        }

        private void Release_License()
        {
            
            if (MessageBox.Show("Are you sure you want to release the hold on this license?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (cls_LicenseDetain.License_Release(ThisDetainID, This_License_ID, ExpiryDate))
            {
                    cls_LicenseDetain.AddNewReleaseOrder(ThisPersonID, ThisPaid, 3);
                    MessageBox.Show("The operation was completed successfully. The license is now available in the licenses table");

                    ExitLicenseReleaseCard();

                    NewFilter_Local = FilterBy_Local.FirstName;

                    LocalLicenseTable_ShearchTextChange(this, EventArgs.Empty);

                    NewFilter_Local = FilterBy_Local.Non;

                    NewFilter = FilterBy.FirstName;

                    DetainLicenseTable_ShearchTextChange(this, EventArgs.Empty);

                    NewFilter = FilterBy.Non;



                }


                else 
                {
                    cls_LicenseDetain.AddNewReleaseOrder(ThisPersonID, ThisPaid, 2);

                    MessageBox.Show("An error occurred while processing your request. Please try again");

                }

              

            }
        }

        //



        private void Us_LicenseDetain_Load(object sender, EventArgs e)
        {
            cls_LicenseDetain = new cls_LicenseDetain();

            // Detain Licenses Settings


            LicenseDetainTable = new us_Optimised_Table();
            DetainLicense_CurrentPageList = new List<reservation_Informaton_Class>();
            LicenseDetainList = new List<reservation_Informaton_Class>();
            ReleaseLicenseCard = new us_LicenseDetainCard();


            LicenseDetainList = cls_LicenseDetain.Get_License_Reservation_List();

            LicenseDetainTable.Dock = DockStyle.Right;


            this.LicenseDetainTable.NextPageButtonClicked += DetainLicenseTable_NextPageButtonClicked;
            this.LicenseDetainTable.PreviousPageButtonClicked += DetainLicenseTable_PreviousPageButtonClicked;
            this.LicenseDetainTable.ShearchTextChange += DetainLicenseTable_ShearchTextChange;
            this.LicenseDetainTable.SelectedIndexChanged += SelectedIndexChanged;
            this.LicenseDetainTable.ActionShowMoreDetilePerson_Click += ActionShowMoreDetileLicense_Click;
            this.ReleaseLicenseCard.ExitLicenseReleaseCard += ExitLicenseReleaseCard;
            this.ReleaseLicenseCard.ReleaseLicense += Release_License;
            OptimiseTableToDetainLicenseTableForm();
            FullTableInformation();


            pnlscreen.Controls.Add(LicenseDetainTable);

            //




            // Local Licenses Settings


            localLicenseTable = new us_Optimised_Table();
            LocalLicense_CurrentPageList = new List<drive_license_Information_Class>();
            LocalLicensesList = new List<drive_license_Information_Class>();
            LocalInformationCard = new us_LicenseInformationCard();
            NewReserve = new reservation_Informaton_Class();


            LocalLicensesList = cls_LicenseDetain.Get_Not_Reservd_And_Active_Licenses();

            localLicenseTable.Dock = DockStyle.Left;


            this.localLicenseTable.NextPageButtonClicked += LocalLicenseTable_NextPageButtonClicked;
            this.localLicenseTable.PreviousPageButtonClicked += LocalLicenseTable_PreviousPageButtonClicked;
            this.localLicenseTable.ShearchTextChange += LocalLicenseTable_ShearchTextChange;
            this.localLicenseTable.SelectedIndexChanged += SelectedIndexChanged_Local;
            this.localLicenseTable.ActionShowMoreDetilePerson_Click += ActionShowMoreDetileLicense_Click_Local;
            this.LocalInformationCard.ExitLicenseInformationCard += ExitLicenseInformationCard_Local;
            this.LocalInformationCard.HeldLicense += Held_This_License;

            OptimiseTableToLocalLicenseTableForm();
            FullTableInformation_Local();


            pnlscreen.Controls.Add(localLicenseTable);

            //
        }
    }
}
