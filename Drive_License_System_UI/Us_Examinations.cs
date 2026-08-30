using Driver_License_System__Models;
using Driver_License_System_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drive_License_System_UI
{
    public partial class Us_Examinations : UserControl
    {
        public Us_Examinations()
        {
            InitializeComponent();
        }


        enum FilterBy
        {
            Vision = 1,
            Theory = 2,
            Practical = 3,
            Non = 4
        }


        private us_Optimised_Table SchedulingTestsTable;
        private cls_Appointement cls_Appointement;
        private List<appointment_Information_Class> SchedulingTestsList;
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
        private void OptimiseTableToSchedulingTestsForm()
        {
            SchedulingTestsTable.lplTitleEntityOptimiseTableLisensee.Text = "PERSON INFO";
            SchedulingTestsTable.picOptimiseTableIcon.BackgroundImage = (Drive_License_System_UI.Properties.Resources.s);
            SchedulingTestsTable.lblOptimiseTableTitle.Text = "SCHEDULING EXAM";
            SchedulingTestsTable.LabelLicenseNoRowOptimiseTable.Text = "APPOINTEMENT ID";
            SchedulingTestsTable.releasedateRowOptimiseTable.Text = "APPOINTEMENT DATE";


            SchedulingTestsTable.StatusRowOptimiseTable.Text = "TEST TYPE";
            SchedulingTestsTable.txbOptimiseTableSearch.Visible = false;

      


            SchedulingTestsTable.EditRow1.Visible = false;
            SchedulingTestsTable.EditRow2.Visible = false;
            SchedulingTestsTable.EditRow3.Visible = false;
            SchedulingTestsTable.EditRow4.Visible = false;
            SchedulingTestsTable.EditRow5.Visible = false;
            SchedulingTestsTable.EditRow6.Visible = false;
            SchedulingTestsTable.EditRow7.Visible = false;
            SchedulingTestsTable.EditRow8.Visible = false;
            SchedulingTestsTable.EditRow9.Visible = false;
            SchedulingTestsTable.EditRow10.Visible = false;

            SchedulingTestsTable.DeleteRow1.Visible = false;
            SchedulingTestsTable.DeleteRow2.Visible = false;
            SchedulingTestsTable.DeleteRow3.Visible = false;
            SchedulingTestsTable.DeleteRow4.Visible = false;
            SchedulingTestsTable.DeleteRow5.Visible = false;
            SchedulingTestsTable.DeleteRow6.Visible = false;
            SchedulingTestsTable.DeleteRow7.Visible = false;
            SchedulingTestsTable.DeleteRow8.Visible = false;
            SchedulingTestsTable.DeleteRow9.Visible = false;
            SchedulingTestsTable.DeleteRow10.Visible = false;




            SchedulingTestsTable.cxbOptimiseTableFilter.Items.Clear();

            SchedulingTestsTable.cxbOptimiseTableFilter.Items.Add("By Vision Test");
            SchedulingTestsTable.cxbOptimiseTableFilter.Items.Add("By Theory Test");
            SchedulingTestsTable.cxbOptimiseTableFilter.Items.Add("By Pratical Test");
            SchedulingTestsTable.cxbOptimiseTableFilter.Items.Add("Non");





        }

        private void AddLineToTable(int PersonNumber, int LineNumber)
        {
            SchedulingTestsTable.panelLine[LineNumber].Visible = true;
            try
            {
                SchedulingTestsTable.PicColumn[LineNumber].Image = Image.FromFile(SchedulingTestsList[PersonNumber].Personal_Photo);
            }
            catch
            {

            }
            SchedulingTestsTable.LableColumn1[LineNumber].Text = ReturnTableFullName(SchedulingTestsList[PersonNumber].First_name, SchedulingTestsList[PersonNumber].Last_name);
            SchedulingTestsTable.LableColumn2[LineNumber].Text = SchedulingTestsList[PersonNumber].appointment_ID.ToString();
            SchedulingTestsTable.LableColumn3[LineNumber].Text = SchedulingTestsList[PersonNumber].AppoinementDate.Year.ToString() + "/" + SchedulingTestsList[PersonNumber].AppoinementDate.Month.ToString() + "/" + SchedulingTestsList[PersonNumber].AppoinementDate.Day.ToString();

            if (SchedulingTestsList[PersonNumber].test_ID == 1)
            {
                SchedulingTestsTable.LableColumn4[LineNumber].ForeColor = Color.White;


                SchedulingTestsTable.LableColumn4[LineNumber].Text = "Vision";

                SchedulingTestsTable.PanelColumn4[LineNumber].FillColor = Color.DimGray;
            }
            else if (SchedulingTestsList[PersonNumber].test_ID == 2)
            {
                SchedulingTestsTable.LableColumn4[LineNumber].ForeColor = Color.White;
                SchedulingTestsTable.LableColumn4[LineNumber].Text = "Theory";
                SchedulingTestsTable.PanelColumn4[LineNumber].FillColor = Color.SkyBlue;
            }

            else if (SchedulingTestsList[PersonNumber].test_ID == 3)
            {
                SchedulingTestsTable.LableColumn4[LineNumber].ForeColor = Color.White; //FromArgb(3B82F6);
                SchedulingTestsTable.LableColumn4[LineNumber].Text = "Practical";
                SchedulingTestsTable.PanelColumn4[LineNumber].FillColor = Color.DodgerBlue; // FromArgb(59, 130, 246);
            }

            SchedulingTestsTable.LableColumn4[LineNumber].Location = new Point(
           (SchedulingTestsTable.PanelColumn4[LineNumber].Width - SchedulingTestsTable.LableColumn4[LineNumber].Width) / 2,
           (SchedulingTestsTable.PanelColumn4[LineNumber].Height - SchedulingTestsTable.LableColumn4[LineNumber].Height) / 2);



            CurrentPageList.Add(SchedulingTestsList[PersonNumber]);
        }

        private void FullTableInformation()
        {
            CurrentPageList.Clear();

            if (SchedulingTestsList != null && SchedulingTestsList.Count > 0)
            {

                SchedulingTestsTable.TotalPages = (int)Math.Ceiling((double)SchedulingTestsList.Count / 10);


                for (int i = 9; i >= 0; i--)
                {
                    SchedulingTestsTable.panelLine[i].Visible = false;
                }



                {



                    if (SchedulingTestsTable.TotalPages == SchedulingTestsTable.CurrentPage)

                    {
                        if (SchedulingTestsList.Count % 10 != 0)

                            SchedulingTestsTable.NumberOfRowsInThis = SchedulingTestsList.Count % 10;

                        else
                        {
                            SchedulingTestsTable.NumberOfRowsInThis = 10;

                        }
                    }
                    else
                    {
                        SchedulingTestsTable.NumberOfRowsInThis = 10;

                    }

                    SchedulingTestsTable.txtCountOptimiseTable.Text = "Showing 1 - " + SchedulingTestsTable.NumberOfRowsInThis + " of " + SchedulingTestsList.Count + " Items";
                    SchedulingTestsTable.ShowListCountOptimiseTable.Text = SchedulingTestsTable.CurrentPage + " of " + SchedulingTestsTable.TotalPages;
                    for (int i = 0; i < SchedulingTestsTable.NumberOfRowsInThis; i++)
                    {
                        AddLineToTable(SchedulingTestsTable.CurrentLineInfo, i);

                        SchedulingTestsTable.CurrentLineInfo++;


                    }


                }
            }
            else
            {
                SchedulingTestsTable.txtCountOptimiseTable.Text = "There is no one matching this search";
                SchedulingTestsTable.ShowListCountOptimiseTable.Text = "0 page";
                TestInformationCard.pnlfull.Visible = false;



                for (int i = 9; i >= 0; i--)
                {
                    SchedulingTestsTable.panelLine[i].Visible = false;

                }
            }


        }

        private void AppointementsTable_NextPageButtonClicked()
        {

            if (SchedulingTestsTable.CurrentPage < SchedulingTestsTable.TotalPages)
            {
                SchedulingTestsTable.CurrentPage++;

                FullTableInformation();


            }
        }

        private void AppointementsTable_PreviousPageButtonClicked()
        {
            if (SchedulingTestsTable.CurrentPage > 1)
            {
                SchedulingTestsTable.CurrentPage--;
                SchedulingTestsTable.CurrentLineInfo = SchedulingTestsTable.CurrentLineInfo - (10 + SchedulingTestsTable.NumberOfRowsInThis);

                FullTableInformation();
            }
        }

        private void OrdersTable_ShearchTextChange(object sender, EventArgs e)
        {




        }

        private void SelectedIndexChanged()
        {
            if (SchedulingTestsTable.cxbOptimiseTableFilter.Text == "By Vision Test")
            {
                NewFilter = FilterBy.Vision;
            }
            else if (SchedulingTestsTable.cxbOptimiseTableFilter.Text == "By Theory Test")
            {
                NewFilter = FilterBy.Theory;
            }
            else if (SchedulingTestsTable.cxbOptimiseTableFilter.Text == "By Pratical Test")
            {
                NewFilter = FilterBy.Practical;

            }
            else
            {
                NewFilter = FilterBy.Non;
            }


            if (NewFilter == FilterBy.Vision)
            {

                SchedulingTestsList.Clear();

                List<appointment_Information_Class> GetNew = cls_Appointement.Get_Scheduling_Exam_List_FilterByTestType((int)appointment_Information_Class.Test.Eye_test);
                if (GetNew != null)
                {

                    SchedulingTestsList = GetNew;


                }

                SchedulingTestsTable.CurrentLineInfo = 0;
                SchedulingTestsTable.CurrentPage = 1;

                FullTableInformation();

            }

            else if (NewFilter == FilterBy.Theory)
            {

                SchedulingTestsList.Clear();

                List<appointment_Information_Class> GetNew = cls_Appointement.Get_Scheduling_Exam_List_FilterByTestType((int)appointment_Information_Class.Test.Theoretical_test);
                if (GetNew != null)
                {

                    SchedulingTestsList = GetNew;


                }

                SchedulingTestsTable.CurrentLineInfo = 0;
                SchedulingTestsTable.CurrentPage = 1;

                FullTableInformation();

            }

            else if (NewFilter == FilterBy.Practical)
            {
                SchedulingTestsList.Clear();

                List<appointment_Information_Class> GetNew = cls_Appointement.Get_Scheduling_Exam_List_FilterByTestType((int)appointment_Information_Class.Test.Practical_driving_test);

                if (GetNew != null)
                {

                    SchedulingTestsList = GetNew;


                }

                SchedulingTestsTable.CurrentLineInfo = 0;
                SchedulingTestsTable.CurrentPage = 1;

                FullTableInformation();
            }

            else if (NewFilter == FilterBy.Non)
            {
                SchedulingTestsList.Clear();

                List<appointment_Information_Class> GetNew = cls_Appointement.Get_Scheduling_Exam_List();

                if (GetNew != null)
                {

                    SchedulingTestsList = GetNew;


                }

                SchedulingTestsTable.CurrentLineInfo = 0;
                SchedulingTestsTable.CurrentPage = 1;

                FullTableInformation();
            }

        }

        private void ActionShowMoreDetileDriver_Click()
        {

            FullAppointementCardInfo();
        }

        //



        //Appointement Card Full Settings

        us_TakeTast TestInformationCard;

        private int AppointementID = -1;
        private int ThisPersonID = -1;
        private DateTime ThisAppointementDate;
        private int TestTypeID = -1;
        private String OldNote = "";
        private int OrderID = -1;


        private void FullAppointementCardInfo()
        {
            TestInformationCard.Visible = true;
            int ThisAppointement = SchedulingTestsTable.CurrentActionLinePersonDetile - 1;

            cls_Services GetServicePrice = new cls_Services();


            


            if (CurrentPageList.Count > 0)
            {

                try
                {
                    TestInformationCard.PersonPhoto.Image = Image.FromFile(CurrentPageList[ThisAppointement].Personal_Photo);
                }
                catch
                {

                }
                TestInformationCard.personalName.Text = CurrentPageList[ThisAppointement].First_name + " " + CurrentPageList[ThisAppointement].Last_name;

                AppointementID = CurrentPageList[ThisAppointement].appointment_ID;
                TestInformationCard.AppointementID.Text = AppointementID.ToString();
                TestInformationCard.Category.Text = CurrentPageList[ThisAppointement].Category_Name;
                TestInformationCard.Date.Text = CurrentPageList[ThisAppointement].AppoinementDate.Day.ToString() + "/" + CurrentPageList[ThisAppointement].AppoinementDate.Month.ToString() + "/" + CurrentPageList[ThisAppointement].AppoinementDate.Year.ToString();

                TestTypeID = CurrentPageList[ThisAppointement].test_ID;
                OldNote = CurrentPageList[ThisAppointement].notes;
                OrderID = CurrentPageList[ThisAppointement].order_ID;


                if (CurrentPageList[ThisAppointement].test_ID == (int)appointment_Information_Class.Test.Eye_test)
                {

                    TestInformationCard.picTestType.BackgroundImage = (Drive_License_System_UI.Properties.Resources._200);
                    TestInformationCard.TestTybe.Text = "Vision Test";
                    TestInformationCard.ProgressTest.Value = 100 / 3;
                    TestInformationCard.ProgressTest.Text = "1/3";
                }
                else if (CurrentPageList[ThisAppointement].test_ID == (int)appointment_Information_Class.Test.Theoretical_test)
                {
                    TestInformationCard.picTestType.BackgroundImage = (Drive_License_System_UI.Properties.Resources.v);
                    TestInformationCard.TestTybe.Text = "Theort Test";
                    TestInformationCard.ProgressTest.Value = 120 / 2;
                    TestInformationCard.ProgressTest.Text = "2/3";
                
            }
                else if(CurrentPageList[ThisAppointement].test_ID == (int)appointment_Information_Class.Test.Practical_driving_test)
                {
                    TestInformationCard.picTestType.BackgroundImage = (Drive_License_System_UI.Properties.Resources.file_00000000406871f4a8297107077afca93);
                    TestInformationCard.TestTybe.Text = "Practical Test";
                TestInformationCard.ProgressTest.Value = 100;
                TestInformationCard.ProgressTest.Text = "3/3";
            

        }

                ThisAppointementDate = CurrentPageList[ThisAppointement].AppoinementDate;

                ThisPersonID = CurrentPageList[ThisAppointement].people_ID;

                if(ThisAppointementDate <= DateTime.Today)
                {
                    TestInformationCard.IfGetDate.Text = "YES";
                }
                else
                {
                    TestInformationCard.IfGetDate.Text = "NO";

                }








                TestInformationCard.pnlfull.Visible = true;


            }
            else
            {
                TestInformationCard.pnlfull.Visible = false;
            }
        }

        private void SaveBtnClick()
        {
            int ResultID = -1;

            if (TestInformationCard.btnFill.Checked == true)
            {
                ResultID = (int)appointment_Information_Class.Results.Fail;
            }
            else if(TestInformationCard.btnPass.Checked == true)
            {
                ResultID = (int)appointment_Information_Class.Results.Pass;

            }
            else
            {
                MessageBox.Show("Please enter the test result and try again.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure about Save this Result for this Test?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                if (AppointementID != -1 && OrderID != -1 && ThisPersonID != -1 && ResultID != -1 && TestTypeID != -1)
                {

                    int NewLicenseID = -1;
                    if (cls_Appointement.SaveTestResult(AppointementID,ResultID,TestTypeID, OldNote,OrderID, TestInformationCard.Note.Text, ThisPersonID,ref NewLicenseID))
                    {
                        TestInformationCard.Visible = false;

                        if (NewLicenseID != -1)
                        {
                            MessageBox.Show($"The test result has been successfully Saved. The new license has been successfully added, License ID:  {NewLicenseID} .", " Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                        else
                        {
                            MessageBox.Show("The test result has been successfully Saved. ", " Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        NewFilter = FilterBy.Non;
                        SelectedIndexChanged();
                    }
                    else
                    {
                        MessageBox.Show("An unexpected error occurred. Please contact tha administrator to resolve ", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("An error occurred while retrieving the data. Please try again", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        //



        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Us_Examinations_Load(object sender, EventArgs e)
        {
            SchedulingTestsTable = new us_Optimised_Table();
            TestInformationCard = new us_TakeTast();
            CurrentPageList = new List<appointment_Information_Class>();
            cls_Appointement = new cls_Appointement();





            TestInformationCard.Dock = DockStyle.Left;
            SchedulingTestsTable.Dock = DockStyle.Right;


            TestInformationCard.BtnSaveClick += SaveBtnClick;


            SchedulingTestsList = cls_Appointement.Get_Scheduling_Exam_List();

            this.SchedulingTestsTable.NextPageButtonClicked += AppointementsTable_NextPageButtonClicked;
            this.SchedulingTestsTable.PreviousPageButtonClicked += AppointementsTable_PreviousPageButtonClicked;
            this.SchedulingTestsTable.ShearchTextChange += OrdersTable_ShearchTextChange;
            this.SchedulingTestsTable.SelectedIndexChanged += SelectedIndexChanged;
            this.SchedulingTestsTable.ActionShowMoreDetilePerson_Click += ActionShowMoreDetileDriver_Click;

            OptimiseTableToSchedulingTestsForm();
            FullTableInformation();
            FullAppointementCardInfo();


            pnlscreen.Controls.Add(TestInformationCard);
            pnlscreen.Controls.Add(SchedulingTestsTable);

        }

        private void pnlscreen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
