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
    public partial class us_ManageAppInApplicationSenter : UserControl
    {
        public us_ManageAppInApplicationSenter()
        {
            InitializeComponent();
        }


        //Table Full Settings

        enum FilterBy
        {
            Vision = 1,
            Theory = 2,
            Practical = 3,
              Non = 4
        }


        private us_Optimised_Table AppointementTable;
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
            AppointementTable.lplTitleEntityOptimiseTableLisensee.Text = "PERSON INFO";
            AppointementTable.picOptimiseTableIcon.BackgroundImage = (Drive_License_System_UI.Properties.Resources.Picsart_26_06_16_14_07_02_6193);
            AppointementTable.lblOptimiseTableTitle.Text = "APPOINTEMENTS";
            AppointementTable.LabelLicenseNoRowOptimiseTable.Text = "APPOINTEMENT ID";
            AppointementTable.releasedateRowOptimiseTable.Text = "ORDER DATE";


            AppointementTable.StatusRowOptimiseTable.Text = "TEST TYPE";
            AppointementTable.txbOptimiseTableSearch.Visible = false;

            AppointementInformationCard.guna2HtmlLabel5.Text = "Test Type";
            AppointementInformationCard.picPersonalPotoCard.BackgroundImage =    (Drive_License_System_UI.Properties.Resources.Picsart_26_06_02_01_55_32_565);
            AppointementInformationCard.pnlCategory.Visible = true;
            AppointementInformationCard.lblNationalID.Text = "Order ID";
            AppointementInformationCard.SecondTitle.Text = "APPOINTEMENT INFO";
            AppointementInformationCard.guna2HtmlLabel9.Text = "Appointement ID";
            AppointementInformationCard.lblCardOrderTitle.Text = "Scheduling a Test";

            AppointementInformationCard.btnScheduling.Visible = true;
            AppointementInformationCard.TakeDate.MinDate = DateTime.Now;
            AppointementInformationCard.TakeDate.Visible = true;


            AppointementTable.EditRow1.Visible = false;
            AppointementTable.EditRow2.Visible = false;
            AppointementTable.EditRow3.Visible = false;
            AppointementTable.EditRow4.Visible = false;
            AppointementTable.EditRow5.Visible = false;
            AppointementTable.EditRow6.Visible = false;
            AppointementTable.EditRow7.Visible = false;
            AppointementTable.EditRow8.Visible = false;
            AppointementTable.EditRow9.Visible = false;
            AppointementTable.EditRow10.Visible = false;

            AppointementTable.DeleteRow1.Visible = false;
            AppointementTable.DeleteRow2.Visible = false;
            AppointementTable.DeleteRow3.Visible = false;
            AppointementTable.DeleteRow4.Visible = false;
            AppointementTable.DeleteRow5.Visible = false;
            AppointementTable.DeleteRow6.Visible = false;
            AppointementTable.DeleteRow7.Visible = false;
            AppointementTable.DeleteRow8.Visible = false;
            AppointementTable.DeleteRow9.Visible = false;
            AppointementTable.DeleteRow10.Visible = false;




            AppointementTable.cxbOptimiseTableFilter.Items.Clear();

            AppointementTable.cxbOptimiseTableFilter.Items.Add("By Vision Test");
            AppointementTable.cxbOptimiseTableFilter.Items.Add("By Theory Test");
            AppointementTable.cxbOptimiseTableFilter.Items.Add("By Pratical Test");
            AppointementTable.cxbOptimiseTableFilter.Items.Add("Non");





        }

        private void AddLineToTable(int PersonNumber, int LineNumber)
        {
            AppointementTable.panelLine[LineNumber].Visible = true;
            try
            {
                AppointementTable.PicColumn[LineNumber].Image = Image.FromFile(AppointementList[PersonNumber].Personal_Photo);
            }
            catch
            {

            }
            AppointementTable.LableColumn1[LineNumber].Text = ReturnTableFullName(AppointementList[PersonNumber].First_name, AppointementList[PersonNumber].Last_name);
            AppointementTable.LableColumn2[LineNumber].Text = AppointementList[PersonNumber].appointment_ID.ToString();
            AppointementTable.LableColumn3[LineNumber].Text = AppointementList[PersonNumber].orderDate.Year.ToString()+"/"+ AppointementList[PersonNumber].orderDate.Month.ToString() + "/" + AppointementList[PersonNumber].orderDate.Day.ToString();


            if (AppointementList[PersonNumber].test_ID == 1)
            {
                AppointementTable.LableColumn4[LineNumber].ForeColor = Color.White;


                AppointementTable.LableColumn4[LineNumber].Text = "Vision";
                
                AppointementTable.PanelColumn4[LineNumber].FillColor = Color.DimGray;
            }
            else if (AppointementList[PersonNumber].test_ID == 2)
            {
                AppointementTable.LableColumn4[LineNumber].ForeColor = Color.White;
                AppointementTable.LableColumn4[LineNumber].Text = "Theory";
                AppointementTable.PanelColumn4[LineNumber].FillColor = Color.SkyBlue;
            }

            else if (AppointementList[PersonNumber].test_ID == 3)
            {
                AppointementTable.LableColumn4[LineNumber].ForeColor = Color.White; //FromArgb(3B82F6);
                AppointementTable.LableColumn4[LineNumber].Text = "Practical";
                AppointementTable.PanelColumn4[LineNumber].FillColor = Color.DodgerBlue; // FromArgb(59, 130, 246);
            }

            AppointementTable.LableColumn4[LineNumber].Location = new Point(
           (AppointementTable.PanelColumn4[LineNumber].Width - AppointementTable.LableColumn4[LineNumber].Width) / 2,
           (AppointementTable.PanelColumn4[LineNumber].Height - AppointementTable.LableColumn4[LineNumber].Height) / 2);



            CurrentPageList.Add(AppointementList[PersonNumber]);
        }

        private void FullTableInformation()
        {
            CurrentPageList.Clear();

            if (AppointementList != null && AppointementList.Count > 0)
            {

                AppointementTable.TotalPages = (int)Math.Ceiling((double)AppointementList.Count / 10);


                for (int i = 9; i >= 0; i--)
                {
                    AppointementTable.panelLine[i].Visible = false;
                }



                {



                    if (AppointementTable.TotalPages == AppointementTable.CurrentPage)

                    {
                        if (AppointementList.Count % 10 != 0)

                            AppointementTable.NumberOfRowsInThis = AppointementList.Count % 10;

                        else
                        {
                            AppointementTable.NumberOfRowsInThis = 10;

                        }
                    }
                    else
                    {
                        AppointementTable.NumberOfRowsInThis = 10;

                    }

                    AppointementTable.txtCountOptimiseTable.Text = "Showing 1 - " + AppointementTable.NumberOfRowsInThis + " of " + AppointementList.Count + " Items";
                    AppointementTable.ShowListCountOptimiseTable.Text = AppointementTable.CurrentPage + " of " + AppointementTable.TotalPages;
                    for (int i = 0; i < AppointementTable.NumberOfRowsInThis; i++)
                    {
                        AddLineToTable(AppointementTable.CurrentLineInfo, i);

                        AppointementTable.CurrentLineInfo++;


                    }


                }
            }
            else
            {
                AppointementTable.txtCountOptimiseTable.Text = "There is no one matching this search";
                AppointementTable.ShowListCountOptimiseTable.Text = "0 page";
                AppointementInformationCard.pnlfull.Visible = false;



                for (int i = 9; i >= 0; i--)
                {
                    AppointementTable.panelLine[i].Visible = false;

                }
            }


        }

        private void AppointementsTable_NextPageButtonClicked()
        {

            if (AppointementTable.CurrentPage < AppointementTable.TotalPages)
            {
                AppointementTable.CurrentPage++;

                FullTableInformation();


            }
        }

        private void AppointementsTable_PreviousPageButtonClicked()
        {
            if (AppointementTable.CurrentPage > 1)
            {
                AppointementTable.CurrentPage--;
                AppointementTable.CurrentLineInfo = AppointementTable.CurrentLineInfo - (10 + AppointementTable.NumberOfRowsInThis);

                FullTableInformation();
            }
        }

        private void OrdersTable_ShearchTextChange(object sender, EventArgs e)
        {




        }

        private void SelectedIndexChanged()
        {
            if (AppointementTable.cxbOptimiseTableFilter.Text == "By Vision Test")
            {
                NewFilter = FilterBy.Vision;
            }
            else if (AppointementTable.cxbOptimiseTableFilter.Text == "By Theory Test")
            {
                NewFilter = FilterBy.Theory;
            }
            else if (AppointementTable.cxbOptimiseTableFilter.Text == "By Pratical Test")
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

                List<appointment_Information_Class> GetNew = cls_Appointement.Get_Appointement_No_Date_List_FilterByTestID((int)appointment_Information_Class.Test.Eye_test);
                if (GetNew != null)
                {

                    AppointementList = GetNew;


                }

                AppointementTable.CurrentLineInfo = 0;
                AppointementTable.CurrentPage = 1;

                FullTableInformation();

            }

            else if (NewFilter == FilterBy.Theory)
            {

                AppointementList.Clear();

                List<appointment_Information_Class> GetNew = cls_Appointement.Get_Appointement_No_Date_List_FilterByTestID((int)appointment_Information_Class.Test.Theoretical_test);
                if (GetNew != null)
                {

                    AppointementList = GetNew;


                }

                AppointementTable.CurrentLineInfo = 0;
                AppointementTable.CurrentPage = 1;

                FullTableInformation();

            }

            else if (NewFilter == FilterBy.Practical)
            {
                AppointementList.Clear();

                List<appointment_Information_Class> GetNew = cls_Appointement.Get_Appointement_No_Date_List_FilterByTestID((int)appointment_Information_Class.Test.Practical_driving_test);

                if (GetNew != null)
                {

                    AppointementList = GetNew;


                }

                AppointementTable.CurrentLineInfo = 0;
                AppointementTable.CurrentPage = 1;

                FullTableInformation();
            }

            else if (NewFilter == FilterBy.Non)
            {
                AppointementList.Clear();

                List<appointment_Information_Class> GetNew = cls_Appointement.Get_Appointement_No_Date_List();

                if (GetNew != null)
                {

                    AppointementList = GetNew;


                }

                AppointementTable.CurrentLineInfo = 0;
                AppointementTable.CurrentPage = 1;

                FullTableInformation();
            }

        }

        private void ActionShowMoreDetileDriver_Click()
        {

            FullAppointementCardInfo();
        }

        //



        //Appointement Card Full Settings

        us_HistoryCard AppointementInformationCard;

        private int AppointementID = -1;
        
        private void FullAppointementCardInfo()
        {
            AppointementInformationCard.Visible = true;
            int ThisAppointement = AppointementTable.CurrentActionLinePersonDetile - 1;

            if (CurrentPageList.Count > 0)
            {

                try
                {
                    AppointementInformationCard.Personal_Photo.Image = Image.FromFile(CurrentPageList[ThisAppointement].Personal_Photo);
                }
                catch
                {

                }
                AppointementInformationCard.personalName.Text = CurrentPageList[ThisAppointement].First_name + " " + CurrentPageList[ThisAppointement].Last_name;
                AppointementInformationCard.FullName.Text = CurrentPageList[ThisAppointement].First_name + " " + CurrentPageList[ThisAppointement].Last_name;

                AppointementID = CurrentPageList[ThisAppointement].appointment_ID;
                AppointementInformationCard.OrderID.Text = AppointementID.ToString();

                AppointementInformationCard.NationalID.Text = CurrentPageList[ThisAppointement].order_ID.ToString();
                AppointementInformationCard.Person_ID.Text = CurrentPageList[ThisAppointement].people_ID.ToString();

                AppointementInformationCard.OrderState.Text = CurrentPageList[ThisAppointement].TestName;

                AppointementInformationCard.OrderDate.Text = CurrentPageList[ThisAppointement].orderDate.Day.ToString() + "/" + CurrentPageList[ThisAppointement].orderDate.Month.ToString() + "/" + CurrentPageList[ThisAppointement].orderDate.Year.ToString();

                AppointementInformationCard.FeePaid.Text = CurrentPageList[ThisAppointement].Test_Fees.ToString() + "$";

                AppointementInformationCard.ServiceName.Text = CurrentPageList[ThisAppointement].service_Name;

                AppointementInformationCard.Phone_Number.Text = CurrentPageList[ThisAppointement].Phone_Nember;

                AppointementInformationCard.Category.Text = CurrentPageList[ThisAppointement].Category_Name;




                AppointementInformationCard.pnlfull.Visible = true;


            }
            else
            {
                AppointementInformationCard.pnlfull.Visible = false;
            }
        }

        private void SchedulingClick()
        {
            DialogResult result = MessageBox.Show("Are you sure about scheduling this test for this date?","Confirmation Message",MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (AppointementID != -1)
                {
                    if (cls_Appointement.schedulingTest(AppointementID, AppointementInformationCard.TakeDate.Value))
                    {
                        AppointementInformationCard.Visible = false;

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
            Us_Applications us_Applications = new Us_Applications();
            us_Applications.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(us_Applications);
            this.Parent.Controls.Remove(this);
        }

        private void us_ManageAppInApplicationSenter_Load(object sender, EventArgs e)
        {
            AppointementTable = new us_Optimised_Table();
            AppointementInformationCard = new us_HistoryCard();
            CurrentPageList = new List<appointment_Information_Class>();
            cls_Appointement = new cls_Appointement();





            AppointementInformationCard.Dock = DockStyle.Left;
            AppointementTable.Dock = DockStyle.Right;


            AppointementInformationCard.SchedulingClick += SchedulingClick;


            AppointementList = cls_Appointement.Get_Appointement_No_Date_List();

            this.AppointementTable.NextPageButtonClicked += AppointementsTable_NextPageButtonClicked;
            this.AppointementTable.PreviousPageButtonClicked += AppointementsTable_PreviousPageButtonClicked;
            this.AppointementTable.ShearchTextChange += OrdersTable_ShearchTextChange;
            this.AppointementTable.SelectedIndexChanged += SelectedIndexChanged;
            this.AppointementTable.ActionShowMoreDetilePerson_Click += ActionShowMoreDetileDriver_Click;

            OptimiseTableToOAppointementTableForm();
            FullTableInformation();
            FullAppointementCardInfo();


            pnlscreen.Controls.Add(AppointementInformationCard);
            pnlscreen.Controls.Add(AppointementTable);





        }

        private void pnlscreen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
