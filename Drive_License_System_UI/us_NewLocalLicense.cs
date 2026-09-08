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


    public partial class us_NewLocalLicense : UserControl
    {


        // Application New Local License issuance ID = '1' In DataBase;
        private byte ServiceID = 1;
        //
        public us_NewLocalLicense()
        {
            InitializeComponent();
        }

        cls_Orders NewApplication;
        cls_Licenses_Loc_Inte ExistVerify;
        cls_People Get_PersonInfo;
        Person_Information_class NewInformation;
        cls_Categorys Get_Category_Info;

        DateTime ThisPersonDateOfBurth;
        private int ThisCategoryID = -1;
        private Decimal ServicePrice = -1;
        private Decimal TottlePrice = -1;
        private int PersonID = -1;




        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            NewInformation =  Get_PersonInfo.Get_Person_By_NationalID(txbSearch.Text);

            if(NewInformation.National_ID == txbSearch.Text)
            {
                CouldntFindMessage.Visible = false;

                FullInformationCard();
                Category.Enabled = true;
                btnCreateOrder.Enabled = true;

                if (ThisCategoryID != -1)
                {
                    ThisCategoryID = Category.SelectedIndex + 1;

                    if (!(DateTime.Now > ThisPersonDateOfBurth.AddYears(Get_Category_Info.Get_Category_PriceAndRequiredAge_By_ID(ThisCategoryID).Required_Age)))
                    {
                        lblThisPersonNotReachedMessage.Visible = true;
                        btnCreateOrder.Enabled = false;

                    }
                }
            }

            else
            {
                personTitle.Text = "Please choose a person";
                CouldntFindMessage.Visible = true;

                pnlPersonInfo.Visible = false;
                Category.Enabled = false;
                btnCreateOrder.Enabled = false;
                lblThisPersonNotReachedMessage.Visible = false;


            }
        }

        private void FullInformationCard()
        {
           
           
                cls_Services GetServicePrice = new cls_Services();
            ThisPersonDateOfBurth = NewInformation.Date_Of_Birth;


                personTitle.Text = "Personal Information";
                PersonalPhoto.Image = Image.FromFile(NewInformation.Personal_Photo);
                FullName.Text = NewInformation.FirstName + " " + NewInformation.SecondName + " " + NewInformation.ThirdName + " " + NewInformation.LastName;
                NationalID.Text = NewInformation.National_ID;
                DateofBirth.Text = NewInformation.Date_Of_Birth.Year.ToString()+"/"+NewInformation.Date_Of_Birth.Month.ToString()+"/" + NewInformation.Date_Of_Birth.Day.ToString();
                nationality.Text = NewInformation.country_name;
            PersonID = NewInformation.Person_ID;

                if(NewInformation.Gender == "M" || NewInformation.Gender == "m")
                {
                    Gender.Text = "Male";
                }
                else
                {
                    Gender.Text = "Female";
                }


                phonenumber.Text = NewInformation.PhoneNumber;
                Email.Text = NewInformation.Email;
                ApplicationDate.Text = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
            ServicePrice = GetServicePrice.GetServicePrice(ServiceID).service_price;
            ApplicationFees.Text = ServicePrice.ToString() + " $";


            pnlPersonInfo.Visible = true;

        }

        
        private void Category_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                    ThisCategoryID = Category.SelectedIndex+1;

            if (DateTime.Now > ThisPersonDateOfBurth.AddYears(Get_Category_Info.Get_Category_PriceAndRequiredAge_By_ID(ThisCategoryID).Required_Age))
                {
                CategoryFees.Text = Get_Category_Info.Get_Category_PriceAndRequiredAge_By_ID(ThisCategoryID).Price.ToString() + " $";
                if (ServicePrice != -1)
                {
                    TottlePrice = (ServicePrice + Get_Category_Info.Get_Category_PriceAndRequiredAge_By_ID(ThisCategoryID).Price);
                    Tottle.Text = TottlePrice.ToString();
                    btnCreateOrder.Enabled = true;
                    lblThisPersonNotReachedMessage.Visible = false;

                }


            }
            else
            {
                btnCreateOrder.Enabled = false;
                lblThisPersonNotReachedMessage.Visible = true;
            }





        }

        private void Full_What_Categorys_We_Have()
        {
            Category.Items.Clear();
            List<string> categories_Name = new List<string>();
            categories_Name = Get_Category_Info.Get_List_Of_Categorys_Name();
            if (categories_Name != null)
            {
                for (int i = 0; i < categories_Name.Count; i++)
                {
                    Category.Items.Add(categories_Name[i]);
                }
            }
            else
            {
                Category.Items.Add("There is no category now, Please Contact your admin");
            }
        }


        private void btnCreateOrder_Click(object sender, EventArgs e)
        {

            if (ThisCategoryID != -1 && ServicePrice != -1 && TottlePrice != -1 && PersonID != -1)
            {
                orders_Information_Class NewOrder = new orders_Information_Class();
                orderInformation_Information_Class NewOrderInformation = new orderInformation_Information_Class();

                //اضافة شرط عدم اضافة طلب في حالة تكراره



                NewOrder.Application_fee_paid = TottlePrice;
                NewOrder.people_ID = PersonID;
                NewOrder.service_ID = ServiceID;

                NewOrderInformation.People_ID = PersonID;
                NewOrderInformation.Service_ID = ServiceID;
                NewOrderInformation.Category_ID = ThisCategoryID;

                if (NewApplication.If_This_Order_Info_Exist(NewOrderInformation, 1) || NewApplication.If_This_Order_Info_Exist(NewOrderInformation, 3))
                {
                    MessageBox.Show("Sorry. This person already has a request for this category", "Administrative rejection", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                else
                {

                    if (NewApplication.Add_NewOrder_NewLicense_Service(NewOrder, NewOrderInformation))
                    {
                        MessageBox.Show("The Orde has been successfully added .", "The operation was successful", MessageBoxButtons.OK);
                    }

                    else
                    {
                        MessageBox.Show("Sorry. an errore occurred while attempting to Create Order, The order is cancelled", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

            }
            else
            {
                MessageBox.Show("Sorry. an errore occurred while attempting to Create Order,Filed Get Information", "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
          

        }

        private void us_NewLocalLicense_Load(object sender, EventArgs e)
        {
            NewApplication = new cls_Orders();
            ExistVerify = new cls_Licenses_Loc_Inte();
            Get_PersonInfo = new cls_People();
            NewInformation = new Person_Information_class();
            Get_Category_Info = new cls_Categorys();

            Full_What_Categorys_We_Have();
        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

        private void pnlPersonInfo_Paint(object sender, PaintEventArgs e)
        {

        }

   
    }
}
