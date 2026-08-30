using Driver_License_System__Models;
using Driver_License_System_BLL;
using Guna.UI2.WinForms;
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
    public partial class Us_Services_Exam : UserControl
    {

        public Guna2TextBox[] Services;
        public Guna2TextBox[] Exam;

        public Us_Services_Exam()
        {
            InitializeComponent();

            Services = new Guna2TextBox[] {

            LicenseIssuancePrice,ReexaminationServicePrice,RenewalServicePrice,LicenseReplacementPrice,DamagedReplacementPrice,LicenseReleasePrice,InternationalLicensePrice
        };

            Exam = new Guna2TextBox[] {

                VisionTestPrice,TheoryTestPrice,PracticalTestPrice
        };

        }


        cls_Services NewServiceManagement;
        cls_Exam NewExamManagement;
        List<Services_Information_Class> NewServiceListInformation;
        Services_Information_Class NewServiceInformation;
        test_Information_Class NewExamInformation;
        List<test_Information_Class> NewExamListInformation;


        //Service Edit
        private void guna2CirclePictureBox5_Click(object sender, EventArgs e)
        {
            LicenseIssuancePrice.Focus();
            LicenseIssuancePrice.ReadOnly = false;

            LicenseReplacementPrice.ReadOnly = true;
            RenewalServicePrice.ReadOnly = true;
            DamagedReplacementPrice.ReadOnly = true;
            LicenseReleasePrice.ReadOnly = true;
            InternationalLicensePrice.ReadOnly = true;
            ReexaminationServicePrice.ReadOnly = true;

            VisionTestPrice.ReadOnly = true;
            PracticalTestPrice.ReadOnly = true;
            TheoryTestPrice.ReadOnly = true;

            Save1.Visible = true;
            Save2.Visible = false;
            Save3.Visible = false;
            Save4.Visible = false;
            Save5.Visible = false;
            Save6.Visible = false;
            Save7.Visible = false;
            Save21.Visible = false;
            Save22.Visible = false;
            Save23.Visible = false;






        }

        private void Edit2_Click(object sender, EventArgs e)
        {
            ReexaminationServicePrice.Focus();
            LicenseIssuancePrice.ReadOnly = true;

            LicenseReplacementPrice.ReadOnly = true;
            RenewalServicePrice.ReadOnly = true;
            DamagedReplacementPrice.ReadOnly = true;
            LicenseReleasePrice.ReadOnly = true;
            InternationalLicensePrice.ReadOnly = true;
            ReexaminationServicePrice.ReadOnly = false;

            VisionTestPrice.ReadOnly = true;
            PracticalTestPrice.ReadOnly = true;
            TheoryTestPrice.ReadOnly = true;

            Save1.Visible = false;
            Save2.Visible = true;
            Save3.Visible = false;
            Save4.Visible = false;
            Save5.Visible = false;
            Save6.Visible = false;
            Save7.Visible = false;
            Save21.Visible = false;
            Save22.Visible = false;
            Save23.Visible = false;

        }

        private void Edit3_Click(object sender, EventArgs e)
        {
            RenewalServicePrice.Focus();
            LicenseIssuancePrice.ReadOnly = true;

            LicenseReplacementPrice.ReadOnly = true;
            RenewalServicePrice.ReadOnly = false;
            DamagedReplacementPrice.ReadOnly = true;
            LicenseReleasePrice.ReadOnly = true;
            InternationalLicensePrice.ReadOnly = true;
            ReexaminationServicePrice.ReadOnly = true;

            VisionTestPrice.ReadOnly = true;
            PracticalTestPrice.ReadOnly = true;
            TheoryTestPrice.ReadOnly = true;

            Save1.Visible = false;
            Save2.Visible = false;
            Save3.Visible = true;
            Save4.Visible = false;
            Save5.Visible = false;
            Save6.Visible = false;
            Save7.Visible = false;
            Save21.Visible = false;
            Save22.Visible = false;
            Save23.Visible = false;

        }

        private void Edit4_Click(object sender, EventArgs e)
        {
            LicenseReplacementPrice.Focus();
            LicenseIssuancePrice.ReadOnly = true;

            LicenseReplacementPrice.ReadOnly = false;
            RenewalServicePrice.ReadOnly = true;
            DamagedReplacementPrice.ReadOnly = true;
            LicenseReleasePrice.ReadOnly = true;
            InternationalLicensePrice.ReadOnly = true;
            ReexaminationServicePrice.ReadOnly = true;

            VisionTestPrice.ReadOnly = true;
            PracticalTestPrice.ReadOnly = true;
            TheoryTestPrice.ReadOnly = true;

            Save1.Visible = false;
            Save2.Visible = false;
            Save3.Visible = false;
            Save4.Visible = true;
            Save5.Visible = false;
            Save6.Visible = false;
            Save7.Visible = false;
            Save21.Visible = false;
            Save22.Visible = false;
            Save23.Visible = false;

        }

        private void Edit5_Click(object sender, EventArgs e)
        {
            DamagedReplacementPrice.Focus();
            LicenseIssuancePrice.ReadOnly = true;

            LicenseReplacementPrice.ReadOnly = true;
            RenewalServicePrice.ReadOnly = true;
            DamagedReplacementPrice.ReadOnly = false;
            LicenseReleasePrice.ReadOnly = true;
            InternationalLicensePrice.ReadOnly = true;
            ReexaminationServicePrice.ReadOnly = true;

            VisionTestPrice.ReadOnly = true;
            PracticalTestPrice.ReadOnly = true;
            TheoryTestPrice.ReadOnly = true;

            Save1.Visible = false;
            Save2.Visible = false;
            Save3.Visible = false;
            Save4.Visible = false;
            Save5.Visible = true;
            Save6.Visible = false;
            Save7.Visible = false;
            Save21.Visible = false;
            Save22.Visible = false;
            Save23.Visible = false;

        }

        private void Edit6_Click(object sender, EventArgs e)
        {
            LicenseReleasePrice.Focus();
            LicenseIssuancePrice.ReadOnly = true;

            LicenseReplacementPrice.ReadOnly = true;
            RenewalServicePrice.ReadOnly = true;
            DamagedReplacementPrice.ReadOnly = true;
            LicenseReleasePrice.ReadOnly = false;
            InternationalLicensePrice.ReadOnly = true;
            ReexaminationServicePrice.ReadOnly = true;

            VisionTestPrice.ReadOnly = true;
            PracticalTestPrice.ReadOnly = true;
            TheoryTestPrice.ReadOnly = true;

            Save1.Visible = false;
            Save2.Visible = false;
            Save3.Visible = false;
            Save4.Visible = false;
            Save5.Visible = false;
            Save6.Visible = true;
            Save7.Visible = false;
            Save21.Visible = false;
            Save22.Visible = false;
            Save23.Visible = false;

        }

        private void Edit7_Click(object sender, EventArgs e)
        {
            InternationalLicensePrice.Focus();
            LicenseIssuancePrice.ReadOnly = true;

            LicenseReplacementPrice.ReadOnly = true;
            RenewalServicePrice.ReadOnly = true;
            DamagedReplacementPrice.ReadOnly = true;
            LicenseReleasePrice.ReadOnly = true;
            InternationalLicensePrice.ReadOnly = false;
            ReexaminationServicePrice.ReadOnly = true;

            VisionTestPrice.ReadOnly = true;
            PracticalTestPrice.ReadOnly = true;
            TheoryTestPrice.ReadOnly = true;

            Save1.Visible = false;
            Save2.Visible = false;
            Save3.Visible = false;
            Save4.Visible = false;
            Save5.Visible = false;
            Save6.Visible = false;
            Save7.Visible = true;
            Save21.Visible = false;
            Save22.Visible = false;
            Save23.Visible = false;

        }

        //

        //Exam Edit


        private void Edit21_Click(object sender, EventArgs e)
        {
            VisionTestPrice.Focus();
            LicenseIssuancePrice.ReadOnly = true;

            LicenseReplacementPrice.ReadOnly = true;
            RenewalServicePrice.ReadOnly = true;
            DamagedReplacementPrice.ReadOnly = true;
            LicenseReleasePrice.ReadOnly = true;
            InternationalLicensePrice.ReadOnly = true;
            ReexaminationServicePrice.ReadOnly = true;

            VisionTestPrice.ReadOnly = false;
            PracticalTestPrice.ReadOnly = true;
            TheoryTestPrice.ReadOnly = true;

            Save1.Visible = false;
            Save2.Visible = false;
            Save3.Visible = false;
            Save4.Visible = false;
            Save5.Visible = false;
            Save6.Visible = false;
            Save7.Visible = false;
            Save21.Visible = true;
            Save22.Visible = false;
            Save23.Visible = false;

        }

        private void Edit22_Click(object sender, EventArgs e)
        {
            TheoryTestPrice.Focus();
            LicenseIssuancePrice.ReadOnly = true;

            LicenseReplacementPrice.ReadOnly = true;
            RenewalServicePrice.ReadOnly = true;
            DamagedReplacementPrice.ReadOnly = true;
            LicenseReleasePrice.ReadOnly = true;
            InternationalLicensePrice.ReadOnly = true;
            ReexaminationServicePrice.ReadOnly = true;

            VisionTestPrice.ReadOnly = true;
            PracticalTestPrice.ReadOnly = true;
            TheoryTestPrice.ReadOnly = false;

            Save1.Visible = false;
            Save2.Visible = false;
            Save3.Visible = false;
            Save4.Visible = false;
            Save5.Visible = false;
            Save6.Visible = false;
            Save7.Visible = false;
            Save21.Visible = false;
            Save22.Visible = true;
            Save23.Visible = false;
        }

        private void Edit23_Click(object sender, EventArgs e)
        {
            PracticalTestPrice.Focus();
            LicenseIssuancePrice.ReadOnly = true;

            LicenseReplacementPrice.ReadOnly = true;
            RenewalServicePrice.ReadOnly = true;
            DamagedReplacementPrice.ReadOnly = true;
            LicenseReleasePrice.ReadOnly = true;
            InternationalLicensePrice.ReadOnly = true;
            ReexaminationServicePrice.ReadOnly = true;

            VisionTestPrice.ReadOnly = true;
            PracticalTestPrice.ReadOnly = false;
            TheoryTestPrice.ReadOnly = true;

            Save1.Visible = false;
            Save2.Visible = false;
            Save3.Visible = false;
            Save4.Visible = false;
            Save5.Visible = false;
            Save6.Visible = false;
            Save7.Visible = false;
            Save21.Visible = false;
            Save22.Visible = false;
            Save23.Visible = true;

        }


        //



        // Save Service Information

        private bool Verifies_Service_accuracy_Info_FromUI()
        {
            bool TheDataIsClean = true;




            if (string.IsNullOrWhiteSpace(NewServiceInformation.service_price.ToString()) || NewServiceInformation.service_price < 0)
            {
                MessageBox.Show("Invalid Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return TheDataIsClean;
        }

        private void Save1_Click(object sender, EventArgs e)
        {
            decimal Price;

            NewServiceInformation.service_Id = 1;


            if (decimal.TryParse(LicenseIssuancePrice.Text, out Price))
            {
                NewServiceInformation.service_price = Price;
            }
            else
            {
                NewServiceInformation.service_price = -1;
            }


            if (!Verifies_Service_accuracy_Info_FromUI())
            {
                return;
            }


            if (NewServiceManagement.UpdateService(NewServiceInformation))
            {
                MessageBox.Show("Update seccessful");

                Save1.Visible = false;
                LicenseIssuancePrice.ReadOnly = true;
              
            }
            else
            {
                MessageBox.Show("Update Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Save2_Click(object sender, EventArgs e)
        {
            decimal Price;

            NewServiceInformation.service_Id = 2;


            if (decimal.TryParse(ReexaminationServicePrice.Text, out Price))
            {
                NewServiceInformation.service_price = Price;
            }
            else
            {
                NewServiceInformation.service_price = -1;
            }


            if (!Verifies_Service_accuracy_Info_FromUI())
            {
                return;
            }


            if (NewServiceManagement.UpdateService(NewServiceInformation))
            {
                MessageBox.Show("Update seccessful");

                Save2.Visible = false;
                ReexaminationServicePrice.ReadOnly = true;

            }
            else
            {
                MessageBox.Show("Update Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Save3_Click(object sender, EventArgs e)
        {
            decimal Price;

            NewServiceInformation.service_Id = 3;


            if (decimal.TryParse(RenewalServicePrice.Text, out Price))
            {
                NewServiceInformation.service_price = Price;
            }
            else
            {
                NewServiceInformation.service_price = -1;
            }


            if (!Verifies_Service_accuracy_Info_FromUI())
            {
                return;
            }


            if (NewServiceManagement.UpdateService(NewServiceInformation))
            {
                MessageBox.Show("Update seccessful");

                Save3.Visible = false;
                RenewalServicePrice.ReadOnly = true;

            }
            else
            {
                MessageBox.Show("Update Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Save4_Click(object sender, EventArgs e)
        {
            decimal Price;

            NewServiceInformation.service_Id = 4;


            if (decimal.TryParse(LicenseReplacementPrice.Text, out Price))
            {
                NewServiceInformation.service_price = Price;
            }
            else
            {
                NewServiceInformation.service_price = -1;
            }


            if (!Verifies_Service_accuracy_Info_FromUI())
            {
                return;
            }


            if (NewServiceManagement.UpdateService(NewServiceInformation))
            {
                MessageBox.Show("Update seccessful");

                Save4.Visible = false;
                LicenseReplacementPrice.ReadOnly = true;

            }
            else
            {
                MessageBox.Show("Update Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Save5_Click(object sender, EventArgs e)
        {
            decimal Price;

            NewServiceInformation.service_Id = 5;


            if (decimal.TryParse(DamagedReplacementPrice.Text, out Price))
            {
                NewServiceInformation.service_price = Price;
            }
            else
            {
                NewServiceInformation.service_price = -1;
            }


            if (!Verifies_Service_accuracy_Info_FromUI())
            {
                return;
            }


            if (NewServiceManagement.UpdateService(NewServiceInformation))
            {
                MessageBox.Show("Update seccessful");

                Save5.Visible = false;
                DamagedReplacementPrice.ReadOnly = true;

            }
            else
            {
                MessageBox.Show("Update Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Save6_Click(object sender, EventArgs e)
        {
            decimal Price;

            NewServiceInformation.service_Id = 6;


            if (decimal.TryParse(LicenseReleasePrice.Text, out Price))
            {
                NewServiceInformation.service_price = Price;
            }
            else
            {
                NewServiceInformation.service_price = -1;
            }


            if (!Verifies_Service_accuracy_Info_FromUI())
            {
                return;
            }


            if (NewServiceManagement.UpdateService(NewServiceInformation))
            {
                MessageBox.Show("Update seccessful");

                Save6.Visible = false;
                LicenseReleasePrice.ReadOnly = true;

            }
            else
            {
                MessageBox.Show("Update Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Save7_Click(object sender, EventArgs e)
        {
            decimal Price;

            NewServiceInformation.service_Id = 7;


            if (decimal.TryParse(InternationalLicensePrice.Text, out Price))
            {
                NewServiceInformation.service_price = Price;
            }
            else
            {
                NewServiceInformation.service_price = -1;
            }


            if (!Verifies_Service_accuracy_Info_FromUI())
            {
                return;
            }


            if (NewServiceManagement.UpdateService(NewServiceInformation))
            {
                MessageBox.Show("Update seccessful");

                Save7.Visible = false;
                InternationalLicensePrice.ReadOnly = true;

            }
            else
            {
                MessageBox.Show("Update Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }



        //


        //Save Exam Information 

        private bool Verifies_Exam_accuracy_Info_FromUI()
        {
            bool TheDataIsClean = true;




            if (string.IsNullOrWhiteSpace(NewExamInformation.Test_Price.ToString()) || NewExamInformation.Test_Price < 0)
            {
                MessageBox.Show("Invalid Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return TheDataIsClean;
        }

        private void Save21_Click(object sender, EventArgs e)
        {
            decimal Price;

            NewExamInformation.Test_ID = 1;


            if (decimal.TryParse(VisionTestPrice.Text, out Price))
            {
                NewExamInformation.Test_Price = Price;
            }
            else
            {
                NewExamInformation.Test_Price = -1;
            }


            if (!Verifies_Exam_accuracy_Info_FromUI())
            {
                return;
            }


            if (NewExamManagement.UpdateExam(NewExamInformation))
            {
                MessageBox.Show("Update seccessful");

                Save21.Visible = false;
                VisionTestPrice.ReadOnly = true;

            }
            else
            {
                MessageBox.Show("Update Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Save22_Click(object sender, EventArgs e)
        {
            decimal Price;

            NewExamInformation.Test_ID = 2;


            if (decimal.TryParse(TheoryTestPrice.Text, out Price))
            {
                NewExamInformation.Test_Price = Price;
            }
            else
            {
                NewExamInformation.Test_Price = -1;
            }


            if (!Verifies_Exam_accuracy_Info_FromUI())
            {
                return;
            }


            if (NewExamManagement.UpdateExam(NewExamInformation))
            {
                MessageBox.Show("Update seccessful");

                Save22.Visible = false;
                TheoryTestPrice.ReadOnly = true;

            }
            else
            {
                MessageBox.Show("Update Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Save23_Click(object sender, EventArgs e)
        {
            decimal Price;

            NewExamInformation.Test_ID = 3;


            if (decimal.TryParse(PracticalTestPrice.Text, out Price))
            {
                NewExamInformation.Test_Price = Price;
            }
            else
            {
                NewExamInformation.Test_Price = -1;
            }


            if (!Verifies_Exam_accuracy_Info_FromUI())
            {
                return;
            }


            if (NewExamManagement.UpdateExam(NewExamInformation))
            {
                MessageBox.Show("Update seccessful");

                Save23.Visible = false;
                PracticalTestPrice.ReadOnly = true;

            }
            else
            {
                MessageBox.Show("Update Filed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        //



        private void FullServicesInformation()
        {

            NewServiceListInformation = NewServiceManagement.GetServicesList();

            if (NewServiceListInformation != null && NewServiceListInformation.Count > 0)
            {
                flowLayoutPanel3.Visible = true;
                flowLayoutPanel1.Visible = true;
                flowLayoutPanel4.Visible = true;
               

                int This_Service = 0;

                for (int i = 0; i < NewServiceListInformation.Count; i++)
                {

                    Services[This_Service].Text = NewServiceListInformation[i].service_price.ToString();
                   
                    This_Service++;
                }


            }
            else
            {
                flowLayoutPanel3.Visible = false;
                flowLayoutPanel1.Visible = false;
                flowLayoutPanel4.Visible = false;
            }
        }

        private void FullExamInformation()
        {
            NewExamListInformation = NewExamManagement.GetExamList();

            if (NewExamListInformation != null && NewExamListInformation.Count > 0)
            {
                pnlShowExam.Visible = true;


                int This_Exam = 0;

                for (int i = 0; i < NewExamListInformation.Count; i++)
                {

                    Exam[This_Exam].Text = NewExamListInformation[i].Test_Price.ToString();

                    This_Exam++;
                }


            }
            else
            {
                pnlShowExam.Visible = false;

            }
        }

        private void Us_Services_Exam_Load(object sender, EventArgs e)
        {
            NewServiceManagement = new cls_Services();
            NewServiceListInformation = new List<Services_Information_Class>();
            NewServiceInformation = new Services_Information_Class();
            NewExamInformation = new test_Information_Class();
            NewExamListInformation = new List<test_Information_Class>();
            NewExamManagement = new cls_Exam();

            FullServicesInformation();
            FullExamInformation();


        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnltop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
