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
    public partial class Us_Drivers : UserControl
    {
        public Us_Drivers()
        {
            InitializeComponent();
        }

        //Table Full Settings

        private us_Optimised_Table DriversTable;
        private cls_Drivers cls_Drivers;
        private List<drivers_Information_Class> DriversList;
        private List<drivers_Information_Class> CurrentPageList;
        bool Filtered = false;

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
            DriversTable.lplTitleEntityOptimiseTableLisensee.Text = "DRIVER";
            DriversTable.picOptimiseTableIcon.BackgroundImage = (Drive_License_System_UI.Properties.Resources.Picsart_26_06_16_14_07_02_6192);
            DriversTable.lblOptimiseTableTitle.Text = "DRIVERS TABLE" +
                "";
            DriversTable.LabelLicenseNoRowOptimiseTable.Text = "DRIVER ID";
            DriversTable.releasedateRowOptimiseTable.Text = "PERSON ID";
            DriversTable.StatusRowOptimiseTable.Visible = false;
            DriversTable.StatePnl1OptimiseTable.Visible = false;
            DriversTable.state1textOptimiseTable.Visible = false;
            DriversTable.StatePnl2OptimiseTable.Visible = false;
            DriversTable.state2textOptimiseTable.Visible = false;

            DriversTable.StatePnl3OptimiseTable.Visible = false;
            DriversTable.state3textOptimiseTable.Visible = false;
            DriversTable.StatePnl4OptimiseTable.Visible = false;
            DriversTable.state4textOptimiseTable.Visible = false;
            DriversTable.StatePnl5OptimiseTable.Visible = false;
            DriversTable.state5textOptimiseTable.Visible = false;
            DriversTable.StatePnl6OptimiseTable.Visible = false;
            DriversTable.state6textOptimiseTable.Visible = false;
            DriversTable.StatePnl7OptimiseTable.Visible = false;
            DriversTable.state7textOptimiseTable.Visible = false;
            DriversTable.StatePnl8OptimiseTable.Visible = false;
            DriversTable.state8textOptimiseTable.Visible = false;
            DriversTable.StatePnl9OptimiseTable.Visible = false;
            DriversTable.state9textOptimiseTable.Visible = false;
            DriversTable.StatePnl10OptimiseTable.Visible = false;
            DriversTable.state10textOptimiseTable.Visible = false;

            DriversTable.EditRow1.Visible = false;
            DriversTable.EditRow2.Visible = false;
            DriversTable.EditRow3.Visible = false;
            DriversTable.EditRow4.Visible = false;
            DriversTable.EditRow5.Visible = false;
            DriversTable.EditRow6.Visible = false;
            DriversTable.EditRow7.Visible = false;
            DriversTable.EditRow8.Visible = false;
            DriversTable.EditRow9.Visible = false;
            DriversTable.EditRow10.Visible = false;

            DriversTable.DeleteRow1.Visible = false;
            DriversTable.DeleteRow2.Visible = false;
            DriversTable.DeleteRow3.Visible = false;
            DriversTable.DeleteRow4.Visible = false;
            DriversTable.DeleteRow5.Visible = false;
            DriversTable.DeleteRow6.Visible = false;
            DriversTable.DeleteRow7.Visible = false;
            DriversTable.DeleteRow8.Visible = false;
            DriversTable.DeleteRow9.Visible = false;
            DriversTable.DeleteRow10.Visible = false;




            DriversTable.cxbOptimiseTableFilter.Items.Clear();
           
            DriversTable.cxbOptimiseTableFilter.Items.Add("By Driver ID");



        }

        private void AddLineToTable(int PersonNumber, int LineNumber)
        {
            DriversTable.panelLine[LineNumber].Visible = true;
            try
            {
                DriversTable.PicColumn[LineNumber].Image = Image.FromFile(DriversList[PersonNumber].Driver_Photo);
            }
            catch
            {

            }
            DriversTable.LableColumn1[LineNumber].Text = ReturnTableFullName(DriversList[PersonNumber].first_name, DriversList[PersonNumber].last_name);
            DriversTable.LableColumn2[LineNumber].Text = DriversList[PersonNumber].Driver_ID.ToString();
            DriversTable.LableColumn3[LineNumber].Text = DriversList[PersonNumber].People_ID.ToString();


            CurrentPageList.Add(DriversList[PersonNumber]);
        }

        private void FullTableInformation()
        {
            CurrentPageList.Clear();

            if (DriversList != null && DriversList.Count > 0)
            {

                DriversTable.TotalPages = (int)Math.Ceiling((double)DriversList.Count / 10);


                for (int i = 9; i >= 0; i--)
                {
                    DriversTable.panelLine[i].Visible = false;
                }



                {



                    if (DriversTable.TotalPages == DriversTable.CurrentPage)

                    {
                        DriversTable.NumberOfRowsInThis = DriversList.Count % 10;
                    }
                    else
                    {
                        DriversTable.NumberOfRowsInThis = 10;

                    }

                    DriversTable.txtCountOptimiseTable.Text = "Showing 1 - " + DriversTable.NumberOfRowsInThis + " of " + DriversList.Count + " Drivers";
                    DriversTable.ShowListCountOptimiseTable.Text = DriversTable.CurrentPage + " of " + DriversTable.TotalPages;
                    for (int i = 0; i < DriversTable.NumberOfRowsInThis; i++)
                    {
                        AddLineToTable(DriversTable.CurrentLineInfo, i);

                        DriversTable.CurrentLineInfo++;


                    }


                }
            }
            else
            {
                DriversTable.txtCountOptimiseTable.Text = "There is no one matching this search";
                DriversTable.ShowListCountOptimiseTable.Text = "0 page";
                DriverInfoCard.pnlfull.Visible = false;



                for (int i = 9; i >= 0; i--)
                {
                    DriversTable.panelLine[i].Visible = false;

                }
            }


        }

        private void PersonsTable_NextPageButtonClicked()
        {

            if (DriversTable.CurrentPage < DriversTable.TotalPages)
            {
                DriversTable.CurrentPage++;

                FullTableInformation();


            }
        }

        private void PersonsTable_PreviousPageButtonClicked()
        {
            if (DriversTable.CurrentPage > 1)
            {
                DriversTable.CurrentPage--;
                DriversTable.CurrentLineInfo = DriversTable.CurrentLineInfo - (10 + DriversTable.NumberOfRowsInThis);

                FullTableInformation();
            }
        }

        private void DriversTable_ShearchTextChange(object sender, EventArgs e)
        {

            if (Filtered)
            {
                if(DriversTable.txbOptimiseTableSearch.Text != "")
                {
                DriversList.Clear();

                drivers_Information_Class GetNew = cls_Drivers.Filter_By_DriverID(DriversTable.txbOptimiseTableSearch.Text);
                    if (GetNew != null)
                    {

                        DriversList.Add(GetNew);

                      
                    }
                }
                else
                {
                    DriversList = cls_Drivers.Get_Drivers_list();
                }

                DriversTable.CurrentLineInfo = 0;
                DriversTable.CurrentPage = 1;

                FullTableInformation();
            }


        }

        private void SelectedIndexChanged()
        {
            if(DriversTable.cxbOptimiseTableFilter.Text == "By Driver ID")
            {
               Filtered = true;
            }
        }

        private void ActionShowMoreDetileDriver_Click()
        {

            FullDriverCardInfo();
        }

        //



        //DRIVERS Card Full Settings

        us_DriverInformationCard DriverInfoCard;
        private void FullDriverCardInfo()
        {
            DriverInfoCard.Visible = true;
            int ThisDriver = DriversTable.CurrentActionLinePersonDetile - 1;
            if (CurrentPageList.Count > 0)
            {

                try
                {
                    DriverInfoCard.PersonPhoto.Image = Image.FromFile(CurrentPageList[ThisDriver].Driver_Photo);
                }
                catch
                {

                }
                DriverInfoCard.personalName.Text = CurrentPageList[ThisDriver].first_name + " " + CurrentPageList[ThisDriver].second_name +" "+CurrentPageList[ThisDriver].third_name+" "+ CurrentPageList[ThisDriver].last_name;


                DriverInfoCard.DriverID.Text = CurrentPageList[ThisDriver].Driver_ID.ToString();

                DriverInfoCard.PersonID.Text = CurrentPageList[ThisDriver].People_ID.ToString();


                
               
              DriverInfoCard.TotalLicenses.Text = cls_Licenses_Loc_Inte.GetNumberOfLicensesThisDriverHas(CurrentPageList[ThisDriver].Driver_ID).ToString();
               
                DriverInfoCard.NemberofLicensesHeld.Text = cls_LicenseDetain.GetNumberOfDetainLicensesThisPersonHas(CurrentPageList[ThisDriver].People_ID).ToString();

               

                DriverInfoCard.pnlfull.Visible = true;


            }
            else
            {
                DriverInfoCard.pnlfull.Visible = false;
            }
        }
        //


        private void Us_Drivers_Load(object sender, EventArgs e)
        {
             DriversTable = new us_Optimised_Table();
            DriverInfoCard = new us_DriverInformationCard();
            CurrentPageList = new List<drivers_Information_Class>();
            cls_Drivers = new cls_Drivers();





            DriverInfoCard.Dock = DockStyle.Left;
            DriversTable.Dock = DockStyle.Right;
           


           

           
             DriversList = cls_Drivers.Get_Drivers_list();

            this.DriversTable.NextPageButtonClicked += PersonsTable_NextPageButtonClicked;
            this.DriversTable.PreviousPageButtonClicked += PersonsTable_PreviousPageButtonClicked;
            this.DriversTable.ShearchTextChange += DriversTable_ShearchTextChange;
            this.DriversTable.SelectedIndexChanged += SelectedIndexChanged;
            this.DriversTable.ActionShowMoreDetilePerson_Click += ActionShowMoreDetileDriver_Click;

            OptimiseTableToPersensTableForm();
            FullTableInformation();
            FullDriverCardInfo();


            pnlscreen.Controls.Add(DriverInfoCard);
            pnlscreen.Controls.Add(DriversTable);

        }

        private void pnlscreen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
