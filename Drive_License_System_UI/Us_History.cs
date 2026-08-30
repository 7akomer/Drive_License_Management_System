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


namespace Drive_License_System_UI
{
    public partial class Us_History : UserControl
    {
        public Us_History()
        {
            InitializeComponent();
        }


        //Table Full Settings

        enum FilterBy
        {
            NationalID = 1,
            FirstName = 2,
            Non = 3
        }


        private us_Optimised_Table HistoryTable;
        private cls_Orders cls_History;
        private List<orders_Information_Class> HistoryList;
        private List<orders_Information_Class> CurrentPageList;

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
        private void OptimiseTableToOrdersTableForm()
        {
            HistoryTable.lplTitleEntityOptimiseTableLisensee.Text = "PERSON INFO";
            HistoryTable.picOptimiseTableIcon.BackgroundImage = (Drive_License_System_UI.Properties.Resources.Picsart_26_06_16_14_07_02_6192);
            HistoryTable.lblOptimiseTableTitle.Text = "HISTORY";
            HistoryTable.LabelLicenseNoRowOptimiseTable.Text = "CREATED DATE";
            HistoryTable.releasedateRowOptimiseTable.Text = "ORDER ID";


            HistoryTable.EditRow1.Visible = false;
            HistoryTable.EditRow2.Visible = false;
            HistoryTable.EditRow3.Visible = false;
            HistoryTable.EditRow4.Visible = false;
            HistoryTable.EditRow5.Visible = false;
            HistoryTable.EditRow6.Visible = false;
            HistoryTable.EditRow7.Visible = false;
            HistoryTable.EditRow8.Visible = false;
            HistoryTable.EditRow9.Visible = false;
            HistoryTable.EditRow10.Visible = false;

            HistoryTable.DeleteRow1.Visible = false;
            HistoryTable.DeleteRow2.Visible = false;
            HistoryTable.DeleteRow3.Visible = false;
            HistoryTable.DeleteRow4.Visible = false;
            HistoryTable.DeleteRow5.Visible = false;
            HistoryTable.DeleteRow6.Visible = false;
            HistoryTable.DeleteRow7.Visible = false;
            HistoryTable.DeleteRow8.Visible = false;
            HistoryTable.DeleteRow9.Visible = false;
            HistoryTable.DeleteRow10.Visible = false;




            HistoryTable.cxbOptimiseTableFilter.Items.Clear();

            HistoryTable.cxbOptimiseTableFilter.Items.Add("By National ID");
            HistoryTable.cxbOptimiseTableFilter.Items.Add("By First Name");




        }

        private void AddLineToTable(int PersonNumber, int LineNumber)
        {
            HistoryTable.panelLine[LineNumber].Visible = true;
            try
            {
                HistoryTable.PicColumn[LineNumber].Image = Image.FromFile(HistoryList[PersonNumber].Personal_Photo);
            }
            catch
            {

            }
            HistoryTable.LableColumn1[LineNumber].Text = ReturnTableFullName(HistoryList[PersonNumber].First_name, HistoryList[PersonNumber].Last_name);
            HistoryTable.LableColumn2[LineNumber].Text = HistoryList[PersonNumber].orderDate.Year.ToString() + "/" + HistoryList[PersonNumber].orderDate.Month.ToString() + "/" + HistoryList[PersonNumber].orderDate.Day.ToString();
            HistoryTable.LableColumn3[LineNumber].Text = HistoryList[PersonNumber].order_ID.ToString();



            if (HistoryList[PersonNumber].order_status_Name == "new")
            {
                HistoryTable.LableColumn4[LineNumber].ForeColor = Color.LimeGreen;


                HistoryTable.LableColumn4[LineNumber].Text = "New";
                HistoryTable.PanelColumn4[LineNumber].FillColor = Color.FromArgb(0, 64, 0);
            }
            else if((HistoryList[PersonNumber].order_status_Name == "cancelled"))
            {
                HistoryTable.LableColumn4[LineNumber].ForeColor = Color.Silver;
                HistoryTable.LableColumn4[LineNumber].Text = "Cancelled";
                HistoryTable.PanelColumn4[LineNumber].FillColor = Color.FromArgb(64, 64, 64);
            }

            else if((HistoryList[PersonNumber].order_status_Name == "completed"))
            {
                HistoryTable.LableColumn4[LineNumber].ForeColor = Color.Silver; //FromArgb(3B82F6);
                HistoryTable.LableColumn4[LineNumber].Text = "Completed";
                HistoryTable.PanelColumn4[LineNumber].FillColor = Color.MidnightBlue; // FromArgb(59, 130, 246);
            }

            HistoryTable.LableColumn4[LineNumber].Location = new Point(
           (HistoryTable.PanelColumn4[LineNumber].Width - HistoryTable.LableColumn4[LineNumber].Width) / 2,
           (HistoryTable.PanelColumn4[LineNumber].Height - HistoryTable.LableColumn4[LineNumber].Height) / 2);



            CurrentPageList.Add(HistoryList[PersonNumber]);
        }

        private void FullTableInformation()
        {
            CurrentPageList.Clear();

            if (HistoryList != null && HistoryList.Count > 0)
            {

                HistoryTable.TotalPages = (int)Math.Ceiling((double)HistoryList.Count / 10);


                for (int i = 9; i >= 0; i--)
                {
                    HistoryTable.panelLine[i].Visible = false;
                }



                {



                    if (HistoryTable.TotalPages == HistoryTable.CurrentPage)

                    {
                        if(HistoryList.Count % 10 != 0)

                        HistoryTable.NumberOfRowsInThis = HistoryList.Count % 10;

                        else
                        {
                            HistoryTable.NumberOfRowsInThis = 10;

                        }
                    }
                    else
                    {
                        HistoryTable.NumberOfRowsInThis = 10;

                    }

                    HistoryTable.txtCountOptimiseTable.Text = "Showing 1 - " + HistoryTable.NumberOfRowsInThis + " of " + HistoryList.Count + " Items";
                    HistoryTable.ShowListCountOptimiseTable.Text = HistoryTable.CurrentPage + " of " + HistoryTable.TotalPages;
                    for (int i = 0; i < HistoryTable.NumberOfRowsInThis; i++)
                    {
                        AddLineToTable(HistoryTable.CurrentLineInfo, i);

                        HistoryTable.CurrentLineInfo++;


                    }


                }
            }
            else
            {
                HistoryTable.txtCountOptimiseTable.Text = "There is no one matching this search";
                HistoryTable.ShowListCountOptimiseTable.Text = "0 page";
                OrderInformationCard.pnlfull.Visible = false;



                for (int i = 9; i >= 0; i--)
                {
                    HistoryTable.panelLine[i].Visible = false;

                }
            }


        }

        private void OrdersTable_NextPageButtonClicked()
        {

            if (HistoryTable.CurrentPage < HistoryTable.TotalPages)
            {
                HistoryTable.CurrentPage++;

                FullTableInformation();


            }
        }

        private void OrdersTable_PreviousPageButtonClicked()
        {
            if (HistoryTable.CurrentPage > 1)
            {
                HistoryTable.CurrentPage--;
                HistoryTable.CurrentLineInfo = HistoryTable.CurrentLineInfo - (10 + HistoryTable.NumberOfRowsInThis);

                FullTableInformation();
            }
        }

        private void OrdersTable_ShearchTextChange(object sender, EventArgs e)
        {

            if (NewFilter == FilterBy.NationalID)
            {
              
                    HistoryList.Clear();

                   List<orders_Information_Class> GetNew = cls_History.Get_Filterd_History_ByNationalID(HistoryTable.txbOptimiseTableSearch.Text);
                    if (GetNew != null)
                    {

                        HistoryList = GetNew;


                    }

                HistoryTable.CurrentLineInfo = 0;
                HistoryTable.CurrentPage = 1;

                FullTableInformation();

            }

            else if (NewFilter == FilterBy.FirstName)
            {

                HistoryList.Clear();

                List<orders_Information_Class> GetNew = cls_History.Get_Filterd_History_ByFirstName(HistoryTable.txbOptimiseTableSearch.Text);
                if (GetNew != null)
                {

                    HistoryList = GetNew;


                }

                HistoryTable.CurrentLineInfo = 0;
                HistoryTable.CurrentPage = 1;

                FullTableInformation();

            }

            else if(NewFilter == FilterBy.Non)
            {

            }




        }

        private void SelectedIndexChanged()
        {
            if (HistoryTable.cxbOptimiseTableFilter.Text == "By National ID")
            {
                NewFilter = FilterBy.NationalID;
            }
            else if (HistoryTable.cxbOptimiseTableFilter.Text == "By First Name")
            {
                NewFilter = FilterBy.FirstName;
            }
            else
            {
                NewFilter = FilterBy.Non;
            }
        }

        private void ActionShowMoreDetileDriver_Click()
        {

            FullOrderCardInfo();
        }

        //



        //History Card Full Settings

        us_HistoryCard OrderInformationCard;
        private void FullOrderCardInfo()
        {
            OrderInformationCard.Visible = true;
            int ThisOrder = HistoryTable.CurrentActionLinePersonDetile - 1;
            if (CurrentPageList.Count > 0)
            {

                try
                {
                    OrderInformationCard.Personal_Photo.Image = Image.FromFile(CurrentPageList[ThisOrder].Personal_Photo);
                }
                catch
                {

                }
                OrderInformationCard.personalName.Text = CurrentPageList[ThisOrder].First_name+" "+ CurrentPageList[ThisOrder].Last_name;
                OrderInformationCard.FullName.Text = CurrentPageList[ThisOrder].First_name + " " + CurrentPageList[ThisOrder].Second_name + " "+ CurrentPageList[ThisOrder].Third_name+" "+ CurrentPageList[ThisOrder].Last_name;


                OrderInformationCard.OrderID.Text = CurrentPageList[ThisOrder].order_ID.ToString();

                OrderInformationCard.NationalID.Text = CurrentPageList[ThisOrder].National_ID;
                OrderInformationCard.Person_ID.Text = CurrentPageList[ThisOrder].people_ID.ToString();

                OrderInformationCard.OrderState.Text = CurrentPageList[ThisOrder].order_status_Name;

                OrderInformationCard.OrderDate.Text = CurrentPageList[ThisOrder].orderDate.Day.ToString() +"/"+ CurrentPageList[ThisOrder].orderDate.Month.ToString()+"/"+ CurrentPageList[ThisOrder].orderDate.Year.ToString();

                OrderInformationCard.FeePaid.Text = CurrentPageList[ThisOrder].Application_fee_paid.ToString()+"$";

                OrderInformationCard.ServiceName.Text = CurrentPageList[ThisOrder].service_Name;

                OrderInformationCard.Phone_Number.Text = CurrentPageList[ThisOrder].Phone_Nember;



                OrderInformationCard.pnlfull.Visible = true;


            }
            else
            {
                OrderInformationCard.pnlfull.Visible = false;
            }
        }
        //







        private void Us_History_Load(object sender, EventArgs e)
        {
            HistoryTable = new us_Optimised_Table();
            OrderInformationCard = new us_HistoryCard();
            CurrentPageList = new List<orders_Information_Class>();
            cls_History = new cls_Orders();





            OrderInformationCard.Dock = DockStyle.Left;
            HistoryTable.Dock = DockStyle.Right;





            HistoryList = cls_History.Get_History_List();

            this.HistoryTable.NextPageButtonClicked += OrdersTable_NextPageButtonClicked;
            this.HistoryTable.PreviousPageButtonClicked += OrdersTable_PreviousPageButtonClicked;
            this.HistoryTable.ShearchTextChange += OrdersTable_ShearchTextChange;
            this.HistoryTable.SelectedIndexChanged += SelectedIndexChanged;
            this.HistoryTable.ActionShowMoreDetilePerson_Click += ActionShowMoreDetileDriver_Click;

            OptimiseTableToOrdersTableForm();
            FullTableInformation();
            FullOrderCardInfo();


            pnlscreen.Controls.Add(OrderInformationCard);
            pnlscreen.Controls.Add(HistoryTable);


         




        }

        private void pnlscreen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlscreen_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
