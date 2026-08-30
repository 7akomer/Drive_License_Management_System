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
    public partial class us_RetakTest : UserControl
    {
        public us_RetakTest()
        {
            InitializeComponent();
        }


        // Re-examination servie ID in datebase = 2;

        byte ServiceID = 2;

        //Table Full Settings

        enum FilterBy
        {
            Vision = 1,
            Theory = 2,
            Practical = 3,
            Non = 4
        }


        private us_Optimised_Table FailedPersonsTable;
        private cls_Appointement cls_Appointement;
        private List<appointment_Information_Class> AppointementList;
        private List<appointment_Information_Class> CurrentPageList;

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
        private void OptimiseTableToOAppointementTableForm()
        {
            FailedPersonsTable.lplTitleEntityOptimiseTableLisensee.Text = "PERSON INFO";
            FailedPersonsTable.picOptimiseTableIcon.BackgroundImage = (Drive_License_System_UI.Properties.Resources.s);
            FailedPersonsTable.lblOptimiseTableTitle.Text = "FAILED PERSONS";
            FailedPersonsTable.LabelLicenseNoRowOptimiseTable.Text = "APPOINTEMENT ID";
            FailedPersonsTable.releasedateRowOptimiseTable.Text = "ORDER DATE";


            FailedPersonsTable.StatusRowOptimiseTable.Text = "TEST TYPE";
            FailedPersonsTable.txbOptimiseTableSearch.Visible = false;

            FailedPersonInformationCard.guna2HtmlLabel5.Text = "Test Type";
            FailedPersonInformationCard.picPersonalPotoCard.BackgroundImage = (Drive_License_System_UI.Properties.Resources.Picsart_26_06_02_01_55_32_565);
            FailedPersonInformationCard.pnlCategory.Visible = true;
            FailedPersonInformationCard.lblNationalID.Text = "Order ID";
            FailedPersonInformationCard.SecondTitle.Text = "APPOINTEMENT INFO";
            FailedPersonInformationCard.guna2HtmlLabel9.Text = "Appointement ID";
            FailedPersonInformationCard.lblCardOrderTitle.Text = "Retake Test";
            FailedPersonInformationCard.btnScheduling.Text = "Retake";
            FailedPersonInformationCard.btnScheduling.Visible = true;
            FailedPersonInformationCard.TakeDate.MinDate = DateTime.Now;
            FailedPersonInformationCard.TakeDate.Visible = true;


            FailedPersonsTable.EditRow1.Visible = false;
            FailedPersonsTable.EditRow2.Visible = false;
            FailedPersonsTable.EditRow3.Visible = false;
            FailedPersonsTable.EditRow4.Visible = false;
            FailedPersonsTable.EditRow5.Visible = false;
            FailedPersonsTable.EditRow6.Visible = false;
            FailedPersonsTable.EditRow7.Visible = false;
            FailedPersonsTable.EditRow8.Visible = false;
            FailedPersonsTable.EditRow9.Visible = false;
            FailedPersonsTable.EditRow10.Visible = false;

            FailedPersonsTable.DeleteRow1.Visible = false;
            FailedPersonsTable.DeleteRow2.Visible = false;
            FailedPersonsTable.DeleteRow3.Visible = false;
            FailedPersonsTable.DeleteRow4.Visible = false;
            FailedPersonsTable.DeleteRow5.Visible = false;
            FailedPersonsTable.DeleteRow6.Visible = false;
            FailedPersonsTable.DeleteRow7.Visible = false;
            FailedPersonsTable.DeleteRow8.Visible = false;
            FailedPersonsTable.DeleteRow9.Visible = false;
            FailedPersonsTable.DeleteRow10.Visible = false;




            FailedPersonsTable.cxbOptimiseTableFilter.Items.Clear();

            FailedPersonsTable.cxbOptimiseTableFilter.Items.Add("By Vision Test");
            FailedPersonsTable.cxbOptimiseTableFilter.Items.Add("By Theory Test");
            FailedPersonsTable.cxbOptimiseTableFilter.Items.Add("By Pratical Test");
            FailedPersonsTable.cxbOptimiseTableFilter.Items.Add("Non");





        }

        private void AddLineToTable(int PersonNumber, int LineNumber)
        {
            FailedPersonsTable.panelLine[LineNumber].Visible = true;
            try
            {
                FailedPersonsTable.PicColumn[LineNumber].Image = Image.FromFile(AppointementList[PersonNumber].Personal_Photo);
            }
            catch
            {

            }
            FailedPersonsTable.LableColumn1[LineNumber].Text = ReturnTableFullName(AppointementList[PersonNumber].First_name, AppointementList[PersonNumber].Last_name);
            FailedPersonsTable.LableColumn2[LineNumber].Text = AppointementList[PersonNumber].appointment_ID.ToString();
            FailedPersonsTable.LableColumn3[LineNumber].Text = AppointementList[PersonNumber].orderDate.Year.ToString() + "/" + AppointementList[PersonNumber].orderDate.Month.ToString() + "/" + AppointementList[PersonNumber].orderDate.Day.ToString();


            if (AppointementList[PersonNumber].test_ID == 1)
            {
                FailedPersonsTable.LableColumn4[LineNumber].ForeColor = Color.White;


                FailedPersonsTable.LableColumn4[LineNumber].Text = "Vision";

                FailedPersonsTable.PanelColumn4[LineNumber].FillColor = Color.DimGray;
            }
            else if (AppointementList[PersonNumber].test_ID == 2)
            {
                FailedPersonsTable.LableColumn4[LineNumber].ForeColor = Color.White;
                FailedPersonsTable.LableColumn4[LineNumber].Text = "Theory";
                FailedPersonsTable.PanelColumn4[LineNumber].FillColor = Color.SkyBlue;
            }

            else if (AppointementList[PersonNumber].test_ID == 3)
            {
                FailedPersonsTable.LableColumn4[LineNumber].ForeColor = Color.White; //FromArgb(3B82F6);
                FailedPersonsTable.LableColumn4[LineNumber].Text = "Practical";
                FailedPersonsTable.PanelColumn4[LineNumber].FillColor = Color.DodgerBlue; // FromArgb(59, 130, 246);
            }

            FailedPersonsTable.LableColumn4[LineNumber].Location = new Point(
           (FailedPersonsTable.PanelColumn4[LineNumber].Width - FailedPersonsTable.LableColumn4[LineNumber].Width) / 2,
           (FailedPersonsTable.PanelColumn4[LineNumber].Height - FailedPersonsTable.LableColumn4[LineNumber].Height) / 2);



            CurrentPageList.Add(AppointementList[PersonNumber]);
        }

        private void FullTableInformation()
        {
            CurrentPageList.Clear();

            if (AppointementList != null && AppointementList.Count > 0)
            {

                FailedPersonsTable.TotalPages = (int)Math.Ceiling((double)AppointementList.Count / 10);


                for (int i = 9; i >= 0; i--)
                {
                    FailedPersonsTable.panelLine[i].Visible = false;
                }



                {



                    if (FailedPersonsTable.TotalPages == FailedPersonsTable.CurrentPage)

                    {
                        if (AppointementList.Count % 10 != 0)

                            FailedPersonsTable.NumberOfRowsInThis = AppointementList.Count % 10;

                        else
                        {
                            FailedPersonsTable.NumberOfRowsInThis = 10;

                        }
                    }
                    else
                    {
                        FailedPersonsTable.NumberOfRowsInThis = 10;

                    }

                    FailedPersonsTable.txtCountOptimiseTable.Text = "Showing 1 - " + FailedPersonsTable.NumberOfRowsInThis + " of " + AppointementList.Count + " Items";
                    FailedPersonsTable.ShowListCountOptimiseTable.Text = FailedPersonsTable.CurrentPage + " of " + FailedPersonsTable.TotalPages;
                    for (int i = 0; i < FailedPersonsTable.NumberOfRowsInThis; i++)
                    {
                        AddLineToTable(FailedPersonsTable.CurrentLineInfo, i);

                        FailedPersonsTable.CurrentLineInfo++;


                    }


                }
            }
            else
            {
                FailedPersonsTable.txtCountOptimiseTable.Text = "There is no one matching this search";
                FailedPersonsTable.ShowListCountOptimiseTable.Text = "0 page";
                FailedPersonInformationCard.pnlfull.Visible = false;



                for (int i = 9; i >= 0; i--)
                {
                    FailedPersonsTable.panelLine[i].Visible = false;

                }
            }


        }

        private void AppointementsTable_NextPageButtonClicked()
        {

            if (FailedPersonsTable.CurrentPage < FailedPersonsTable.TotalPages)
            {
                FailedPersonsTable.CurrentPage++;

                FullTableInformation();


            }
        }

        private void AppointementsTable_PreviousPageButtonClicked()
        {
            if (FailedPersonsTable.CurrentPage > 1)
            {
                FailedPersonsTable.CurrentPage--;
                FailedPersonsTable.CurrentLineInfo = FailedPersonsTable.CurrentLineInfo - (10 + FailedPersonsTable.NumberOfRowsInThis);

                FullTableInformation();
            }
        }

        private void OrdersTable_ShearchTextChange(object sender, EventArgs e)
        {




        }

        private void SelectedIndexChanged()
        {
            if (FailedPersonsTable.cxbOptimiseTableFilter.Text == "By Vision Test")
            {
                NewFilter = FilterBy.Vision;
            }
            else if (FailedPersonsTable.cxbOptimiseTableFilter.Text == "By Theory Test")
            {
                NewFilter = FilterBy.Theory;
            }
            else if (FailedPersonsTable.cxbOptimiseTableFilter.Text == "By Pratical Test")
            {
                NewFilter = FilterBy.Practical;

            }
            else
            {
                NewFilter = FilterBy.Non;
            }


            if (NewFilter == FilterBy.Vision)
            {

                AppointementList.Clear();

                List<appointment_Information_Class> GetNew = cls_Appointement.Get_FailedPersonsFilterByTestID((int)appointment_Information_Class.Test.Eye_test);
                if (GetNew != null)
                {

                    AppointementList = GetNew;


                }

                FailedPersonsTable.CurrentLineInfo = 0;
                FailedPersonsTable.CurrentPage = 1;

                FullTableInformation();

            }

            else if (NewFilter == FilterBy.Theory)
            {

                AppointementList.Clear();

                List<appointment_Information_Class> GetNew = cls_Appointement.Get_FailedPersonsFilterByTestID((int)appointment_Information_Class.Test.Theoretical_test);
                if (GetNew != null)
                {

                    AppointementList = GetNew;


                }

                FailedPersonsTable.CurrentLineInfo = 0;
                FailedPersonsTable.CurrentPage = 1;

                FullTableInformation();

            }

            else if (NewFilter == FilterBy.Practical)
            {
                AppointementList.Clear();

                List<appointment_Information_Class> GetNew = cls_Appointement.Get_FailedPersonsFilterByTestID((int)appointment_Information_Class.Test.Practical_driving_test);

                if (GetNew != null)
                {

                    AppointementList = GetNew;


                }

                FailedPersonsTable.CurrentLineInfo = 0;
                FailedPersonsTable.CurrentPage = 1;

                FullTableInformation();
            }

            else if (NewFilter == FilterBy.Non)
            {
                AppointementList.Clear();

                List<appointment_Information_Class> GetNew = cls_Appointement.Get_Failed_Persons_List();

                if (GetNew != null)
                {

                    AppointementList = GetNew;


                }

                FailedPersonsTable.CurrentLineInfo = 0;
                FailedPersonsTable.CurrentPage = 1;

                FullTableInformation();
            }

        }

        private void ActionShowMoreDetileDriver_Click()
        {

            FullAppointementCardInfo();
        }

        //



        //Appointement Card Full Settings

        us_HistoryCard FailedPersonInformationCard;

        private int AppointementID = -1;
        

        private void FullAppointementCardInfo()
        {
            FailedPersonInformationCard.Visible = true;
            int ThisAppointement = FailedPersonsTable.CurrentActionLinePersonDetile - 1;

            cls_Services GetServicePrice = new cls_Services();
            
            



            if (CurrentPageList.Count > 0)
            {

                try
                {
                    FailedPersonInformationCard.Personal_Photo.Image = Image.FromFile(CurrentPageList[ThisAppointement].Personal_Photo);
                }
                catch
                {

                }
                FailedPersonInformationCard.personalName.Text = CurrentPageList[ThisAppointement].First_name + " " + CurrentPageList[ThisAppointement].Last_name;
                FailedPersonInformationCard.FullName.Text = CurrentPageList[ThisAppointement].First_name + " .. " + CurrentPageList[ThisAppointement].Last_name;

                AppointementID = CurrentPageList[ThisAppointement].appointment_ID;
                FailedPersonInformationCard.OrderID.Text = AppointementID.ToString();

                FailedPersonInformationCard.NationalID.Text = CurrentPageList[ThisAppointement].order_ID.ToString();
                FailedPersonInformationCard.Person_ID.Text = CurrentPageList[ThisAppointement].people_ID.ToString();

                FailedPersonInformationCard.OrderState.Text = CurrentPageList[ThisAppointement].TestName;

                FailedPersonInformationCard.OrderDate.Text = CurrentPageList[ThisAppointement].orderDate.Day.ToString() + "/" + CurrentPageList[ThisAppointement].orderDate.Month.ToString() + "/" + CurrentPageList[ThisAppointement].orderDate.Year.ToString();

                FailedPersonInformationCard.FeePaid.Text = (CurrentPageList[ThisAppointement].Test_Fees + GetServicePrice.GetServicePrice(ServiceID).service_price).ToString() + "$";

                FailedPersonInformationCard.ServiceName.Text = CurrentPageList[ThisAppointement].service_Name;

                FailedPersonInformationCard.Phone_Number.Text = CurrentPageList[ThisAppointement].Phone_Nember;

                FailedPersonInformationCard.Category.Text = CurrentPageList[ThisAppointement].Category_Name;




                FailedPersonInformationCard.pnlfull.Visible = true;


            }
            else
            {
                FailedPersonInformationCard.pnlfull.Visible = false;
            }
        }

        private void RetakBtnClick()
        {
            DialogResult result = MessageBox.Show("Are you sure about Retak this test for this date?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (AppointementID != -1)
                {
                    if (cls_Appointement.schedulingTest(AppointementID, FailedPersonInformationCard.TakeDate.Value))
                    {
                        FailedPersonInformationCard.Visible = false;

                        MessageBox.Show("The test has been successfully scheduled. Please inform the concerned person to attend at the sheduled time", " Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        NewFilter = FilterBy.Non;
                        SelectedIndexChanged();
                    }
                    else
                    {
                        MessageBox.Show("An unexpected error occurred. Please contact tha administrator to resolve this issue", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("An error occurred while retrieving the data. Please try again", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        //

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Us_Applications.GoBackToApplicaionCenter();
        }


        private void us_RetakTest_Load(object sender, EventArgs e)
        {
            FailedPersonsTable = new us_Optimised_Table();
            FailedPersonInformationCard = new us_HistoryCard();
            CurrentPageList = new List<appointment_Information_Class>();
            cls_Appointement = new cls_Appointement();





            FailedPersonInformationCard.Dock = DockStyle.Left;
            FailedPersonsTable.Dock = DockStyle.Right;


            FailedPersonInformationCard.SchedulingClick += RetakBtnClick;


            AppointementList = cls_Appointement.Get_Failed_Persons_List();

            this.FailedPersonsTable.NextPageButtonClicked += AppointementsTable_NextPageButtonClicked;
            this.FailedPersonsTable.PreviousPageButtonClicked += AppointementsTable_PreviousPageButtonClicked;
            this.FailedPersonsTable.ShearchTextChange += OrdersTable_ShearchTextChange;
            this.FailedPersonsTable.SelectedIndexChanged += SelectedIndexChanged;
            this.FailedPersonsTable.ActionShowMoreDetilePerson_Click += ActionShowMoreDetileDriver_Click;

            OptimiseTableToOAppointementTableForm();
            FullTableInformation();
            FullAppointementCardInfo();


            pnlscreen.Controls.Add(FailedPersonInformationCard);
            pnlscreen.Controls.Add(FailedPersonsTable);

        }


        private void pnlscreen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
