using Driver_License_System__Models;
using Driver_License_System_BLL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Drive_License_System_UI
{
    public partial class Us_License_Categories : UserControl
    {

        public Guna2HtmlLabel[] Titels;
        public Guna2HtmlLabel[] SubTitels;
        public Guna2TextBox[] MinAges;
        public Guna2TextBox[] Validitys;
        public Guna2TextBox[] Prices;

        cls_Categorys NewManagement;
        List<category_Information_Class> NewInformation;
        category_Information_Class NewCategoryInformation;
        public Us_License_Categories()
        {
            InitializeComponent();

            Titels = new Guna2HtmlLabel[]
           {
          lblTitleClassA, lblTitleClassB, lblTitleClassC, lblTitleClassD, lblTitleClassE, lblTitleClassF,lblTitleClassG

      };

            SubTitels = new Guna2HtmlLabel[]
            {
               Class1Description, Class2Description, Class3Description, Class4Description, Class5Description, Class6Description,Class7Description
            };


            MinAges = new Guna2TextBox[]
            {
                ClassAMinAge,ClassBMinAge, ClassCMinAge, ClassDMinAge,ClassEMinAge,ClassFMinAge,ClassGMinAge
            };

            Validitys = new Guna2TextBox[]
            {
                ClassAValidity, ClassBValidity, ClassCValidity, ClassDValidity, ClassEValidity, ClassFValidity, ClassGValidity
            };

            Prices = new Guna2TextBox[] {

                ClassAPrice,ClassBPrice,ClassCPrice,ClassDPrice, ClassEPrice, ClassFPrice,ClassGPrice
            };

        }

      
        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnltop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FullCategorysInformation()
        {
         
            NewInformation = NewManagement.Get_Categorys_List();

            if (NewInformation != null && NewInformation.Count > 0)
            {
                pnlClassA.Visible = true;
                pnlClassB.Visible = true;
                pnlClassC.Visible = true;
                pnlClassD.Visible = true;
                pnlClassE.Visible = true;
                pnlClassF.Visible = true;
                pnlClassG.Visible = true;

                int This_Category = 0;

                for (int i = 0; i < NewInformation.Count;i++)
                {

                    Titels[This_Category].Text = NewInformation[i].category_Name;
                    SubTitels[This_Category].Text = NewInformation[i].description;
                    MinAges[This_Category].Text = NewInformation[i].Required_Age.ToString();
                    Validitys[This_Category].Text = NewInformation[i].Validity.ToString();
                    Prices[This_Category].Text = NewInformation[i].Price.ToString();

                    This_Category++;
                }


                    }
            else
            {
                pnlClassA.Visible = false;
                pnlClassB.Visible = false;
                pnlClassC.Visible = false;
                pnlClassD.Visible = false;
                pnlClassE.Visible = false;
                pnlClassF.Visible = false;
                pnlClassG.Visible = false;
            }
        }

        //Edit Click Settings
        private void EditClassA_Click(object sender, EventArgs e)
        {
            ClassAPrice.Focus();

            ClassAMinAge.ReadOnly = false;
            ClassBMinAge.ReadOnly = true;
            ClassCMinAge.ReadOnly = true;
            ClassDMinAge.ReadOnly = true;
            ClassEMinAge.ReadOnly = true;
            ClassFMinAge.ReadOnly = true;
            ClassGMinAge.ReadOnly = true;

            ClassAValidity.ReadOnly = false;
            ClassBValidity.ReadOnly = true;
            ClassCValidity.ReadOnly = true;
            ClassDValidity.ReadOnly = true;
            ClassEValidity.ReadOnly = true;
            ClassFValidity.ReadOnly = true;
            ClassGValidity.ReadOnly = true;


            ClassAPrice.ReadOnly = false;
            ClassBPrice.ReadOnly = true;
            ClassCPrice.ReadOnly = true;
            ClassDPrice.ReadOnly = true;
            ClassEPrice.ReadOnly = true;
            ClassFPrice.ReadOnly = true;
            ClassGPrice.ReadOnly = true;

            ClassASave.Visible = true;
            ClassBSave.Visible = false;
            ClassCSave.Visible = false;
            ClassDSave.Visible = false;
            ClassESave.Visible = false;
            ClassFSave.Visible = false;
            ClassGSave.Visible = false;


        }

        private void EditClassB_Click(object sender, EventArgs e)
        {
            ClassBPrice.Focus();

            ClassAMinAge.ReadOnly = true;
            ClassBMinAge.ReadOnly = false;
            ClassCMinAge.ReadOnly = true;
            ClassDMinAge.ReadOnly = true;
            ClassEMinAge.ReadOnly = true;
            ClassFMinAge.ReadOnly = true;
            ClassGMinAge.ReadOnly = true;

            ClassAValidity.ReadOnly = true;
            ClassBValidity.ReadOnly = false;
            ClassCValidity.ReadOnly = true;
            ClassDValidity.ReadOnly = true;
            ClassEValidity.ReadOnly = true;
            ClassFValidity.ReadOnly = true;
            ClassGValidity.ReadOnly = true;


            ClassAPrice.ReadOnly = true;
            ClassBPrice.ReadOnly = false;
            ClassCPrice.ReadOnly = true;
            ClassDPrice.ReadOnly = true;
            ClassEPrice.ReadOnly = true;
            ClassFPrice.ReadOnly = true;
            ClassGPrice.ReadOnly = true;

            ClassASave.Visible = false;
            ClassBSave.Visible = true;
            ClassCSave.Visible = false;
            ClassDSave.Visible = false;
            ClassESave.Visible = false;
            ClassFSave.Visible = false;
            ClassGSave.Visible = false;
        }

        private void EditClassC_Click(object sender, EventArgs e)
        {
            ClassCPrice.Focus();

            ClassAMinAge.ReadOnly = true;
            ClassBMinAge.ReadOnly = true;
            ClassCMinAge.ReadOnly = false;
            ClassDMinAge.ReadOnly = true;
            ClassEMinAge.ReadOnly = true;
            ClassFMinAge.ReadOnly = true;
            ClassGMinAge.ReadOnly = true;

            ClassAValidity.ReadOnly = true;
            ClassBValidity.ReadOnly = true;
            ClassCValidity.ReadOnly = false;
            ClassDValidity.ReadOnly = true;
            ClassEValidity.ReadOnly = true;
            ClassFValidity.ReadOnly = true;
            ClassGValidity.ReadOnly = true;


            ClassAPrice.ReadOnly = true;
            ClassBPrice.ReadOnly = true;
            ClassCPrice.ReadOnly = false;
            ClassDPrice.ReadOnly = true;
            ClassEPrice.ReadOnly = true;
            ClassFPrice.ReadOnly = true;
            ClassGPrice.ReadOnly = true;

            ClassASave.Visible = false;
            ClassBSave.Visible = false;
            ClassCSave.Visible = true;
            ClassDSave.Visible = false;
            ClassESave.Visible = false;
            ClassFSave.Visible = false;
            ClassGSave.Visible = false;

        }

        private void EditClassD_Click(object sender, EventArgs e)
        {
            ClassDPrice.Focus();

            ClassAMinAge.ReadOnly = true;
            ClassBMinAge.ReadOnly = true;
            ClassCMinAge.ReadOnly = true;
            ClassDMinAge.ReadOnly = false;
            ClassEMinAge.ReadOnly = true;
            ClassFMinAge.ReadOnly = true;
            ClassGMinAge.ReadOnly = true;

            ClassAValidity.ReadOnly = true;
            ClassBValidity.ReadOnly = true;
            ClassCValidity.ReadOnly = true;
            ClassDValidity.ReadOnly = false;
            ClassEValidity.ReadOnly = true;
            ClassFValidity.ReadOnly = true;
            ClassGValidity.ReadOnly = true;


            ClassAPrice.ReadOnly = true;
            ClassBPrice.ReadOnly = true;
            ClassCPrice.ReadOnly = true;
            ClassDPrice.ReadOnly = false;
            ClassEPrice.ReadOnly = true;
            ClassFPrice.ReadOnly = true;
            ClassGPrice.ReadOnly = true;

            ClassASave.Visible = false;
            ClassBSave.Visible = false;
            ClassCSave.Visible = false;
            ClassDSave.Visible = true;
            ClassESave.Visible = false;
            ClassFSave.Visible = false;
            ClassGSave.Visible = false;

        }

        private void EditClassE_Click(object sender, EventArgs e)
        {
            ClassEPrice.Focus();

            ClassAMinAge.ReadOnly = true;
            ClassBMinAge.ReadOnly = true;
            ClassCMinAge.ReadOnly = true;
            ClassDMinAge.ReadOnly = true;
            ClassEMinAge.ReadOnly = false;
            ClassFMinAge.ReadOnly = true;
            ClassGMinAge.ReadOnly = true;

            ClassAValidity.ReadOnly = true;
            ClassBValidity.ReadOnly = true;
            ClassCValidity.ReadOnly = true;
            ClassDValidity.ReadOnly = true;
            ClassEValidity.ReadOnly = false;
            ClassFValidity.ReadOnly = true;
            ClassGValidity.ReadOnly = true;


            ClassAPrice.ReadOnly = true;
            ClassBPrice.ReadOnly = true;
            ClassCPrice.ReadOnly = true;
            ClassDPrice.ReadOnly = true;
            ClassEPrice.ReadOnly = false;
            ClassFPrice.ReadOnly = true;
            ClassGPrice.ReadOnly = true;

            ClassASave.Visible = false;
            ClassBSave.Visible = false;
            ClassCSave.Visible = false;
            ClassDSave.Visible = false;
            ClassESave.Visible = true;
            ClassFSave.Visible = false;
            ClassGSave.Visible = false;

        }

        private void EditClassF_Click(object sender, EventArgs e)
        {
            ClassFPrice.Focus();

            ClassAMinAge.ReadOnly = true;
            ClassBMinAge.ReadOnly = true;
            ClassCMinAge.ReadOnly = true;
            ClassDMinAge.ReadOnly = true;
            ClassEMinAge.ReadOnly = true;
            ClassFMinAge.ReadOnly = false;
            ClassGMinAge.ReadOnly = true;

            ClassAValidity.ReadOnly = true;
            ClassBValidity.ReadOnly = true;
            ClassCValidity.ReadOnly = true;
            ClassDValidity.ReadOnly = true;
            ClassEValidity.ReadOnly = true;
            ClassFValidity.ReadOnly = false;
            ClassGValidity.ReadOnly = true;


            ClassAPrice.ReadOnly = true;
            ClassBPrice.ReadOnly = true;
            ClassCPrice.ReadOnly = true;
            ClassDPrice.ReadOnly = true;
            ClassEPrice.ReadOnly = true;
            ClassFPrice.ReadOnly = false;
            ClassGPrice.ReadOnly = true;

            ClassASave.Visible = false;
            ClassBSave.Visible = false;
            ClassCSave.Visible = false;
            ClassDSave.Visible = false;
            ClassESave.Visible = false;
            ClassFSave.Visible = true;
            ClassGSave.Visible = false;

        }

        private void EditClassG_Click(object sender, EventArgs e)
        {
            ClassGPrice.Focus();

            ClassAMinAge.ReadOnly = true;
            ClassBMinAge.ReadOnly = true;
            ClassCMinAge.ReadOnly = true;
            ClassDMinAge.ReadOnly = true;
            ClassEMinAge.ReadOnly = true;
            ClassFMinAge.ReadOnly = true;
            ClassGMinAge.ReadOnly = false;

            ClassAValidity.ReadOnly = true;
            ClassBValidity.ReadOnly = true;
            ClassCValidity.ReadOnly = true;
            ClassDValidity.ReadOnly = true;
            ClassEValidity.ReadOnly = true;
            ClassFValidity.ReadOnly = true;
            ClassGValidity.ReadOnly = false;


            ClassAPrice.ReadOnly = true;
            ClassBPrice.ReadOnly = true;
            ClassCPrice.ReadOnly = true;
            ClassDPrice.ReadOnly = true;
            ClassEPrice.ReadOnly = true;
            ClassFPrice.ReadOnly = true;
            ClassGPrice.ReadOnly = false;

            ClassASave.Visible = false;
            ClassBSave.Visible = false;
            ClassCSave.Visible = false;
            ClassDSave.Visible = false;
            ClassESave.Visible = false;
            ClassFSave.Visible = false;
            ClassGSave.Visible = true;

        }

        //


        //Save settings

        private bool Verifies_accuracy_Info_FromUI()
        {
            bool TheDataIsClean = true;




            if (string.IsNullOrWhiteSpace(NewCategoryInformation.Validity.ToString()) || NewCategoryInformation.Validity < 0)
            {
                MessageBox.Show("Invalid validity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(NewCategoryInformation.Required_Age.ToString()) || NewCategoryInformation.Required_Age < 0)
            {
                MessageBox.Show("Invalid Required Age", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(NewCategoryInformation.Price.ToString()) || NewCategoryInformation.Price < 0)
            {
                MessageBox.Show("Invalid Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return TheDataIsClean;
        }

        private void ClassASave_Click(object sender, EventArgs e)
        {
            int Validity;
            int MinAge;
            decimal Price;

            NewCategoryInformation.category_ID = 1;
            if(int.TryParse(ClassAValidity.Text, out Validity))
            {
                NewCategoryInformation.Validity = Validity;
            }
            else
            {
                NewCategoryInformation.Validity = -1;
            }

            if (int.TryParse(ClassAMinAge.Text, out MinAge))
            {
                NewCategoryInformation.Required_Age = MinAge;
            }
            else
            {
                NewCategoryInformation.Required_Age = -1;
            }


            if (decimal.TryParse(ClassAPrice.Text, out Price))
            {
                NewCategoryInformation.Price = Price;
            }
            else
            {
                NewCategoryInformation.Price = -1;
            }


            if(!Verifies_accuracy_Info_FromUI())
            {
                return;
            }


            if (NewManagement.Update_Category(NewCategoryInformation))
            {
                MessageBox.Show("Update seccessful");

                ClassASave.Visible = false;
                ClassAMinAge.ReadOnly = true;
                ClassAPrice.ReadOnly = true;
                ClassAValidity.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Update Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void ClassBSave_Click(object sender, EventArgs e)
        {
            int Validity;
            int MinAge;
            decimal Price;

            NewCategoryInformation.category_ID = 2;
            if (int.TryParse(ClassBValidity.Text, out Validity))
            {
                NewCategoryInformation.Validity = Validity;
            }
            else
            {
                NewCategoryInformation.Validity = -1;
            }

            if (int.TryParse(ClassBMinAge.Text, out MinAge))
            {
                NewCategoryInformation.Required_Age = MinAge;
            }
            else
            {
                NewCategoryInformation.Required_Age = -1;
            }


            if (decimal.TryParse(ClassBPrice.Text, out Price))
            {
                NewCategoryInformation.Price = Price;
            }
            else
            {
                NewCategoryInformation.Price = -1;
            }


            if (!Verifies_accuracy_Info_FromUI())
            {
                return;
            }


            if (NewManagement.Update_Category(NewCategoryInformation))
            {
                MessageBox.Show("Update seccessful");
               

                ClassBSave.Visible = false;
                ClassBMinAge.ReadOnly = true;
                ClassBPrice.ReadOnly = true;
                ClassBValidity.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Update Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        

        }

        private void ClassCSave_Click(object sender, EventArgs e)
        {
            int Validity;
            int MinAge;
            decimal Price;

            NewCategoryInformation.category_ID = 3;
            if (int.TryParse(ClassCValidity.Text, out Validity))
            {
                NewCategoryInformation.Validity = Validity;
            }
            else
            {
                NewCategoryInformation.Validity = -1;
            }

            if (int.TryParse(ClassCMinAge.Text, out MinAge))
            {
                NewCategoryInformation.Required_Age = MinAge;
            }
            else
            {
                NewCategoryInformation.Required_Age = -1;
            }


            if (decimal.TryParse(ClassCPrice.Text, out Price))
            {
                NewCategoryInformation.Price = Price;
            }
            else
            {
                NewCategoryInformation.Price = -1;
            }


            if (!Verifies_accuracy_Info_FromUI())
            {
                return;
            }


            if (NewManagement.Update_Category(NewCategoryInformation))
            {
                MessageBox.Show("Update seccessful");

                ClassCSave.Visible = false;
                ClassCMinAge.ReadOnly = true;
                ClassCPrice.ReadOnly = true;
                ClassCValidity.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Update Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ClassDSave_Click(object sender, EventArgs e)
        {
            int Validity;
            int MinAge;
            decimal Price;

            NewCategoryInformation.category_ID = 4;
            if (int.TryParse(ClassDValidity.Text, out Validity))
            {
                NewCategoryInformation.Validity = Validity;
            }
            else
            {
                NewCategoryInformation.Validity = -1;
            }

            if (int.TryParse(ClassDMinAge.Text, out MinAge))
            {
                NewCategoryInformation.Required_Age = MinAge;
            }
            else
            {
                NewCategoryInformation.Required_Age = -1;
            }


            if (decimal.TryParse(ClassDPrice.Text, out Price))
            {
                NewCategoryInformation.Price = Price;
            }
            else
            {
                NewCategoryInformation.Price = -1;
            }


            if (!Verifies_accuracy_Info_FromUI())
            {
                return;
            }


            if (NewManagement.Update_Category(NewCategoryInformation))
            {
                MessageBox.Show("Update seccessful");

                ClassDSave.Visible = false;
                ClassDMinAge.ReadOnly = true;
                ClassDPrice.ReadOnly = true;
                ClassDValidity.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Update Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ClassESave_Click(object sender, EventArgs e)
        {
            int Validity;
            int MinAge;
            decimal Price;

            NewCategoryInformation.category_ID = 5;
            if (int.TryParse(ClassEValidity.Text, out Validity))
            {
                NewCategoryInformation.Validity = Validity;
            }
            else
            {
                NewCategoryInformation.Validity = -1;
            }

            if (int.TryParse(ClassEMinAge.Text, out MinAge))
            {
                NewCategoryInformation.Required_Age = MinAge;
            }
            else
            {
                NewCategoryInformation.Required_Age = -1;
            }


            if (decimal.TryParse(ClassEPrice.Text, out Price))
            {
                NewCategoryInformation.Price = Price;
            }
            else
            {
                NewCategoryInformation.Price = -1;
            }


            if (!Verifies_accuracy_Info_FromUI())
            {
                return;
            }


            if (NewManagement.Update_Category(NewCategoryInformation))
            {
                MessageBox.Show("Update seccessful");

                ClassESave.Visible = false;
                ClassEMinAge.ReadOnly = true;
                ClassEPrice.ReadOnly = true;
                ClassEValidity.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Update Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ClassFSave_Click(object sender, EventArgs e)
        {
            int Validity;
            int MinAge;
            decimal Price;

            NewCategoryInformation.category_ID = 6;
            if (int.TryParse(ClassFValidity.Text, out Validity))
            {
                NewCategoryInformation.Validity = Validity;
            }
            else
            {
                NewCategoryInformation.Validity = -1;
            }

            if (int.TryParse(ClassFMinAge.Text, out MinAge))
            {
                NewCategoryInformation.Required_Age = MinAge;
            }
            else
            {
                NewCategoryInformation.Required_Age = -1;
            }


            if (decimal.TryParse(ClassFPrice.Text, out Price))
            {
                NewCategoryInformation.Price = Price;
            }
            else
            {
                NewCategoryInformation.Price = -1;
            }


            if (!Verifies_accuracy_Info_FromUI())
            {
                return;
            }


            if (NewManagement.Update_Category(NewCategoryInformation))
            {
                MessageBox.Show("Update seccessful");

                ClassFSave.Visible = false;
                ClassFMinAge.ReadOnly = true;
                ClassFPrice.ReadOnly = true;
                ClassFValidity.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Update Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ClassGSave_Click(object sender, EventArgs e)
        {
            int Validity;
            int MinAge;
            decimal Price;

            NewCategoryInformation.category_ID = 7;
            if (int.TryParse(ClassGValidity.Text, out Validity))
            {
                NewCategoryInformation.Validity = Validity;
            }
            else
            {
                NewCategoryInformation.Validity = -1;
            }

            if (int.TryParse(ClassGMinAge.Text, out MinAge))
            {
                NewCategoryInformation.Required_Age = MinAge;
            }
            else
            {
                NewCategoryInformation.Required_Age = -1;
            }


            if (decimal.TryParse(ClassGPrice.Text, out Price))
            {
                NewCategoryInformation.Price = Price;
            }
            else
            {
                NewCategoryInformation.Price = -1;
            }


            if (!Verifies_accuracy_Info_FromUI())
            {
                return;
            }


            if (NewManagement.Update_Category(NewCategoryInformation))
            {
                MessageBox.Show("Update seccessful");

                ClassGSave.Visible = false;
                ClassGMinAge.ReadOnly = true;
                ClassGPrice.ReadOnly = true;
                ClassGValidity.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Update Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
         //

        private void Us_License_Categories_Load(object sender, EventArgs e)
        {
            NewManagement = new cls_Categorys();
            NewInformation = new List<category_Information_Class>();
            NewCategoryInformation = new category_Information_Class();

            FullCategorysInformation();
        }

        private void pnl4_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }

}
