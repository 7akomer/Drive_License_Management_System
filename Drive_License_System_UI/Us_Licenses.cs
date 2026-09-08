using Driver_License_System__Models;
using Driver_License_System_BLL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drive_License_System_UI
{
    public partial class Us_Licenses : UserControl
    {
        public Us_Licenses()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();
        }

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


            localLicenseTable.lblOptimiseTableTitle.Text = "Local Licenses";
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

            if (NewFilter_Loal == FilterBy_Local.NationalID)
            {

                LocalLicensesList.Clear();
                string NationalID = localLicenseTable.txbOptimiseTableSearch.Text;

                List<drive_license_Information_Class> GetNew = cls_LocalAndInternationalLicenses.FilterByNationalID(NationalID);
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

                List<drive_license_Information_Class> GetNew = cls_LocalAndInternationalLicenses.FilterByFirstName(FirstName);
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
        private void FullLocalLicenseCardInfo()
        {
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

            if (!DetainStatus.Is_Reserved(LocalLicense_CurrentPageList[ThisInternationalLicense].Drive_License_ID))
            {
                LocalInformationCard.lblDetentionstatus.ForeColor = Color.LimeGreen;

                
                LocalInformationCard.lblDetentionstatus.Text = "No";
                LocalInformationCard.pnlDetentionstatus.FillColor = Color.FromArgb(0, 64, 0);
            }
            else
            {
                LocalInformationCard.lblDetentionstatus.ForeColor = Color.FromArgb(255, 120, 120);
                LocalInformationCard.lblDetentionstatus.Text = "Yes";
                LocalInformationCard.pnlDetentionstatus.FillColor = Color.FromArgb(75, 30, 50);
            }

            //if det  yes/no





            LocalInformationCard.pnlfull.Visible = true;


        }


     
        private void ActionShowMoreDetileLicense_Click_Local()
        {

             InternationalLicenseTable.Visible = false;
            LocalInformationCard.Dock = DockStyle.Right;
            FullLocalLicenseCardInfo();
            pnlscreen.Controls.Add(LocalInformationCard);

        }

        private void ExitLicenseInformationCard_Local()
        {
            LocalInformationCard.Visible = false;
            InternationalLicenseTable.Visible = true;

        }

        //



        //International License Table Full Settings

        enum FilterBy
        {
            NationalID = 1,
            FirstName = 2,
            Non = 3
        }


        private us_Optimised_Table InternationalLicenseTable;
        private List<international_drive_license_Information_Class> InternationalLicensesList;
        private List<international_drive_license_Information_Class> InternationalLicense_CurrentPageList;




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
        private void OptimiseTableToInternationalLicenseTableForm()
        {
         

            InternationalLicenseTable.EditRow1.Visible = false;
            InternationalLicenseTable.EditRow2.Visible = false;
            InternationalLicenseTable.EditRow3.Visible = false;
            InternationalLicenseTable.EditRow4.Visible = false;
            InternationalLicenseTable.EditRow5.Visible = false;
            InternationalLicenseTable.EditRow6.Visible = false;
            InternationalLicenseTable.EditRow7.Visible = false;
            InternationalLicenseTable.EditRow8.Visible = false;
            InternationalLicenseTable.EditRow9.Visible = false;
            InternationalLicenseTable.EditRow10.Visible = false;

            InternationalLicenseTable.DeleteRow1.Visible = false;
            InternationalLicenseTable.DeleteRow2.Visible = false;
            InternationalLicenseTable.DeleteRow3.Visible = false;
            InternationalLicenseTable.DeleteRow4.Visible = false;
            InternationalLicenseTable.DeleteRow5.Visible = false;
            InternationalLicenseTable.DeleteRow6.Visible = false;
            InternationalLicenseTable.DeleteRow7.Visible = false;
            InternationalLicenseTable.DeleteRow8.Visible = false;
            InternationalLicenseTable.DeleteRow9.Visible = false;
            InternationalLicenseTable.DeleteRow10.Visible = false;




            InternationalLicenseTable.cxbOptimiseTableFilter.Items.Clear();

            InternationalLicenseTable.cxbOptimiseTableFilter.Items.Add("By National ID");
            InternationalLicenseTable.cxbOptimiseTableFilter.Items.Add("By First Name");




        }

        private void AddLineToTable(int PersonNumber, int LineNumber)
        {
            InternationalLicenseTable.panelLine[LineNumber].Visible = true;
            try
            {
                InternationalLicenseTable.PicColumn[LineNumber].Image = Image.FromFile(InternationalLicensesList[PersonNumber].Personal_Photo);
            }
            catch
            {

            }
            InternationalLicenseTable.LableColumn1[LineNumber].Text = ReturnTableFullName(InternationalLicensesList[PersonNumber].First_Name, InternationalLicensesList[PersonNumber].Last_Name);
            InternationalLicenseTable.LableColumn2[LineNumber].Text = InternationalLicensesList[PersonNumber].International_Drive_License_ID.ToString();
            InternationalLicenseTable.LableColumn3[LineNumber].Text = InternationalLicensesList[PersonNumber].Relese_Date.Year.ToString() + "/" + InternationalLicensesList[PersonNumber].Relese_Date.Month.ToString() + "/" + InternationalLicensesList[PersonNumber].Relese_Date.Day.ToString();



            if (InternationalLicensesList[PersonNumber].Is_Active == true)
            {
                InternationalLicenseTable.LableColumn4[LineNumber].ForeColor = Color.LimeGreen;


                InternationalLicenseTable.LableColumn4[LineNumber].Text = "● Active";
                InternationalLicenseTable.PanelColumn4[LineNumber].FillColor = Color.FromArgb(0, 64, 0);
            }
            else
            {
                InternationalLicenseTable.LableColumn4[LineNumber].ForeColor = Color.Silver;
                InternationalLicenseTable.LableColumn4[LineNumber].Text = "● Inactive";
                InternationalLicenseTable.PanelColumn4[LineNumber].FillColor = Color.FromArgb(64, 64, 64);
            }


            InternationalLicenseTable.LableColumn4[LineNumber].Location = new Point(
           (InternationalLicenseTable.PanelColumn4[LineNumber].Width - InternationalLicenseTable.LableColumn4[LineNumber].Width) / 2,
           (InternationalLicenseTable.PanelColumn4[LineNumber].Height - InternationalLicenseTable.LableColumn4[LineNumber].Height) / 2);



            InternationalLicense_CurrentPageList.Add(InternationalLicensesList[PersonNumber]);
        }

        private void FullTableInformation()
        {
            InternationalLicense_CurrentPageList.Clear();

            if (InternationalLicensesList != null && InternationalLicensesList.Count > 0)
            {

                InternationalLicenseTable.TotalPages = (int)Math.Ceiling((double)InternationalLicensesList.Count / 10);


                for (int i = 9; i >= 0; i--)
                {
                    InternationalLicenseTable.panelLine[i].Visible = false;
                }



                {



                    if (InternationalLicenseTable.TotalPages == InternationalLicenseTable.CurrentPage)

                    {
                        if (InternationalLicensesList.Count % 10 != 0)

                            InternationalLicenseTable.NumberOfRowsInThis = InternationalLicensesList.Count % 10;

                        else
                        {
                            InternationalLicenseTable.NumberOfRowsInThis = 10;

                        }
                    }
                    else
                    {
                        InternationalLicenseTable.NumberOfRowsInThis = 10;

                    }

                    InternationalLicenseTable.txtCountOptimiseTable.Text = "Showing 1 - " + InternationalLicenseTable.NumberOfRowsInThis + " of " + InternationalLicensesList.Count + " Licenses";
                    InternationalLicenseTable.ShowListCountOptimiseTable.Text = InternationalLicenseTable.CurrentPage + " of " + InternationalLicenseTable.TotalPages;
                    for (int i = 0; i < InternationalLicenseTable.NumberOfRowsInThis; i++)
                    {
                        AddLineToTable(InternationalLicenseTable.CurrentLineInfo, i);

                        InternationalLicenseTable.CurrentLineInfo++;


                    }


                }
            }
            else
            {
                InternationalLicenseTable.txtCountOptimiseTable.Text = "There is no one matching this search";
                InternationalLicenseTable.ShowListCountOptimiseTable.Text = "0 page";
             //   OrderInformationCard.pnlfull.Visible = false;



                for (int i = 9; i >= 0; i--)
                {
                    InternationalLicenseTable.panelLine[i].Visible = false;

                }
            }


        }

        private void InternationalLicenseTable_NextPageButtonClicked()
        {

            if (InternationalLicenseTable.CurrentPage < InternationalLicenseTable.TotalPages)
            {
                InternationalLicenseTable.CurrentPage++;

                FullTableInformation();


            }
        }

        private void InternationalLicenseTable_PreviousPageButtonClicked()
        {
            if (InternationalLicenseTable.CurrentPage > 1)
            {
                InternationalLicenseTable.CurrentPage--;
                InternationalLicenseTable.CurrentLineInfo = InternationalLicenseTable.CurrentLineInfo - (10 + InternationalLicenseTable.NumberOfRowsInThis);

                FullTableInformation();
            }
        }

        private void InternationalLicenseTable_ShearchTextChange(object sender, EventArgs e)
        {

            if (NewFilter == FilterBy.NationalID)
            {

                InternationalLicensesList.Clear();
                string NationalID = InternationalLicenseTable.txbOptimiseTableSearch.Text;

                List<international_drive_license_Information_Class> GetNew = cls_LocalAndInternationalLicenses.FilterInternationaLicenseByNationalID(NationalID);
                if (GetNew != null)
                {

                    InternationalLicensesList = GetNew;


                }

                InternationalLicenseTable.CurrentLineInfo = 0;
                InternationalLicenseTable.CurrentPage = 1;

                FullTableInformation();

            }

            else if (NewFilter == FilterBy.FirstName)
            {

                InternationalLicensesList.Clear();

                string FirstName = InternationalLicenseTable.txbOptimiseTableSearch.Text;

                List<international_drive_license_Information_Class> GetNew = cls_LocalAndInternationalLicenses.FilterInternationaLicenseByFirstName(FirstName);
                if (GetNew != null)
                {

                    InternationalLicensesList = GetNew;


                }

                InternationalLicenseTable.CurrentLineInfo = 0;
                InternationalLicenseTable.CurrentPage = 1;

                FullTableInformation();

            }

            else if (NewFilter == FilterBy.Non)
            {

            }




        }

        private void SelectedIndexChanged()
        {
            if (InternationalLicenseTable.cxbOptimiseTableFilter.Text == "By National ID")
            {
                NewFilter = FilterBy.NationalID;
            }
            else if (InternationalLicenseTable.cxbOptimiseTableFilter.Text == "By First Name")
            {
                NewFilter = FilterBy.FirstName;
            }
            else
            {
                NewFilter = FilterBy.Non;
            }
        }


        //

        // Full International License Card
        us_LicenseInformationCard InternationalInformationCard;
        private void FullInternationalLicenseCardInfo()
        {
            InternationalInformationCard.Visible = true;
            int ThisInternationalLicense = InternationalLicenseTable.CurrentActionLinePersonDetile - 1;
           cls_LicenseDetain DetainStatus = new cls_LicenseDetain();

                try
                {
                    InternationalInformationCard.personalPhoto.Image = Image.FromFile(InternationalLicense_CurrentPageList[ThisInternationalLicense].Personal_Photo);
                }
                catch
                {

                }
                InternationalInformationCard.personalName.Text = InternationalLicense_CurrentPageList[ThisInternationalLicense].First_Name + " " + InternationalLicense_CurrentPageList[ThisInternationalLicense].Last_Name;
                InternationalInformationCard.LicenseID.Text = InternationalLicense_CurrentPageList[ThisInternationalLicense].International_Drive_License_ID.ToString();


                InternationalInformationCard.DriverID.Text = InternationalLicense_CurrentPageList[ThisInternationalLicense].Drive_License_ID.ToString();

                InternationalInformationCard.categoryName.Text = InternationalLicense_CurrentPageList[ThisInternationalLicense].Category_Name;



            InternationalInformationCard.IssuanceDate.Text = InternationalLicense_CurrentPageList[ThisInternationalLicense].Relese_Date.Year.ToString()+ "/" +InternationalLicense_CurrentPageList[ThisInternationalLicense].Relese_Date.Month.ToString() + "/" + InternationalLicense_CurrentPageList[ThisInternationalLicense].Relese_Date.Day.ToString() ;

                InternationalInformationCard.ExpiryDate.Text = InternationalLicense_CurrentPageList[ThisInternationalLicense].End_Date.Year.ToString() + "/" + InternationalLicense_CurrentPageList[ThisInternationalLicense].End_Date.Month.ToString() + "/" + InternationalLicense_CurrentPageList[ThisInternationalLicense].End_Date.Day.ToString();


                if (InternationalLicense_CurrentPageList[ThisInternationalLicense].Is_Active == true)
                {
                    InternationalInformationCard.lblDriveLicenseCardStute.ForeColor = Color.LimeGreen;


                    InternationalInformationCard.lblDriveLicenseCardStute.Text = "● Active";
                    InternationalInformationCard.pnlDriveLicenseCardStute.FillColor = Color.FromArgb(0, 64, 0);
                }
                else
                {
                    InternationalInformationCard.lblDriveLicenseCardStute.ForeColor = Color.Silver;
                    InternationalInformationCard.lblDriveLicenseCardStute.Text = "● Inactive";
                    InternationalInformationCard.pnlDriveLicenseCardStute.FillColor = Color.FromArgb(64, 64, 64);
                }


            if (!DetainStatus.Is_Reserved(InternationalLicense_CurrentPageList[ThisInternationalLicense].Drive_License_ID))
            {
                InternationalInformationCard.lblDetentionstatus.ForeColor = Color.LimeGreen;

                
                InternationalInformationCard.lblDetentionstatus.Text = "No";
                InternationalInformationCard.pnlDetentionstatus.FillColor = Color.FromArgb(0, 64, 0);
            }
            else
            {
                InternationalInformationCard.lblDetentionstatus.ForeColor = Color.FromArgb(255, 120, 120);
                InternationalInformationCard.lblDetentionstatus.Text = "Yes";
                InternationalInformationCard.pnlDetentionstatus.FillColor = Color.FromArgb(75, 30, 50);
            }


            //if det  yes/no





            InternationalInformationCard.pnlfull.Visible = true;


        }

        private void ReformLicenseCardToInternationalLicenseCard()
        {
            InternationalInformationCard.lblCardPersonTitle.Text = "International License Card";
            InternationalInformationCard.lblDriverID.Text = "Local License ID";
            InternationalInformationCard.pnlNote.Visible = false;
            InternationalInformationCard.Note.Visible = false;
            InternationalInformationCard.line.Visible = false;
            InternationalInformationCard.NoteText.Visible = false;


        }

        private void ActionShowMoreDetileLicense_Click()
        {

            localLicenseTable.Visible = false;
            InternationalInformationCard.Dock = DockStyle.Left;
            ReformLicenseCardToInternationalLicenseCard();
            FullInternationalLicenseCardInfo();
            pnlscreen.Controls.Add(InternationalInformationCard);

        }

        private void ExitLicenseInformationCard()
        {
            InternationalInformationCard.Visible = false;
            localLicenseTable.Visible = true;

        }

        //



        private void tblLicenses_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlscreen_Paint(object sender, PaintEventArgs e)
        {

        }



        private void Us_Licenses_Load(object sender, EventArgs e)
        {

            cls_LocalAndInternationalLicenses = new cls_Licenses_Loc_Inte();

            // International Licenses Settings

            
            InternationalLicenseTable = new us_Optimised_Table();
            InternationalLicense_CurrentPageList = new List<international_drive_license_Information_Class>();
            InternationalLicensesList = new List<international_drive_license_Information_Class>();
            InternationalInformationCard = new us_LicenseInformationCard();


            InternationalLicensesList = cls_LocalAndInternationalLicenses.GetInternationalLicensesList();

            InternationalLicenseTable.Dock = DockStyle.Right;


            this.InternationalLicenseTable.NextPageButtonClicked += InternationalLicenseTable_NextPageButtonClicked;
            this.InternationalLicenseTable.PreviousPageButtonClicked += InternationalLicenseTable_PreviousPageButtonClicked;
            this.InternationalLicenseTable.ShearchTextChange += InternationalLicenseTable_ShearchTextChange;
            this.InternationalLicenseTable.SelectedIndexChanged += SelectedIndexChanged;
            this.InternationalLicenseTable.ActionShowMoreDetilePerson_Click += ActionShowMoreDetileLicense_Click;
            this.InternationalInformationCard.ExitLicenseInformationCard += ExitLicenseInformationCard;

            OptimiseTableToInternationalLicenseTableForm();
            FullTableInformation();


            pnlscreen.Controls.Add(InternationalLicenseTable);

            //




            // Local Licenses Settings


            localLicenseTable = new us_Optimised_Table();
            LocalLicense_CurrentPageList = new List<drive_license_Information_Class>();
            LocalLicensesList = new List<drive_license_Information_Class>();
            LocalInformationCard = new us_LicenseInformationCard();


            LocalLicensesList = cls_LocalAndInternationalLicenses.GetLicensesList();

            localLicenseTable.Dock = DockStyle.Left;


            this.localLicenseTable.NextPageButtonClicked += LocalLicenseTable_NextPageButtonClicked;
            this.localLicenseTable.PreviousPageButtonClicked += LocalLicenseTable_PreviousPageButtonClicked;
            this.localLicenseTable.ShearchTextChange += LocalLicenseTable_ShearchTextChange;
            this.localLicenseTable.SelectedIndexChanged += SelectedIndexChanged_Local;
            this.localLicenseTable.ActionShowMoreDetilePerson_Click += ActionShowMoreDetileLicense_Click_Local;
            this.LocalInformationCard.ExitLicenseInformationCard += ExitLicenseInformationCard_Local;

            OptimiseTableToLocalLicenseTableForm();
            FullTableInformation_Local();


            pnlscreen.Controls.Add(localLicenseTable);

            //

        }

        private void LabelLicenseNoRowLocalLicense_Click(object sender, EventArgs e)
        {

        }

        private void cxbLocalLicenseFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
