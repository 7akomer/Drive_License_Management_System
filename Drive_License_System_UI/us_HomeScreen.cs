using Driver_License_System__Models;
using Driver_License_System_BLL;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using WpfCharts = LiveCharts.Wpf;


namespace Drive_License_System_UI
{
    public partial class Us_welcom_s : UserControl
    {
        public Us_welcom_s()
        {
            InitializeComponent();
        }

        private int Active = 0;
        private int Pending = 0;
        private int Expired = 0;
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


        private void FullHomeMoreInformation()
        {

          

            cls_HomeScreen GetHomeInformation = new cls_HomeScreen();

            home_Information_Class NewInfo = new home_Information_Class();

            NewInfo = GetHomeInformation.GetNewHomeInformation();


            lblValueApplications.Text = NewInfo.TotalApplication.ToString();
            lblValueLicenses.Text  = NewInfo.TotaleLicensesIssud.ToString();
            lblValuePending.Text = NewInfo.LicensesPendingCount.ToString();
            lblTodayRevenue_Value.Text = NewInfo.TotalFees.ToString() + " $";

            Active = NewInfo.Active;
            Pending = NewInfo.Pending;
            Expired = NewInfo.Expiry;
            lblConutTotal.Text = lblValueLicenses.Text;

            if (NewInfo.IfTotaleLicensesIssudWin)
            {
                lblChangeLicenses.ForeColor = System.Drawing. Color.FromArgb(52, 211, 153);
                lblChangeLicenses.Text = "↑ " + NewInfo.DefTotalLicensesFromLastDay.ToString();
            }
            else
            {
                lblChangeLicenses.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113);
                lblChangeLicenses.Text = "↓ " + NewInfo.DefTotalLicensesFromLastDay.ToString();

            }



            if (NewInfo.IfLicensesPendingWin)
            {
                lblChangePending.ForeColor = System.Drawing.Color.FromArgb(52, 211, 153);
                lblChangePending.Text = "↑ " + NewInfo.LicensesPendingFromLastDay.ToString();
            }
            else
            {
                lblChangePending.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113);
                lblChangePending.Text = "↓ " + NewInfo.LicensesPendingFromLastDay.ToString();

            }



            if (NewInfo.IfTodayCountApplicationWin)
            {
                lblChangeApplications.ForeColor = System.Drawing.Color.FromArgb(52, 211, 153);
                lblChangeApplications.Text = "↑ " + NewInfo.DefTotalApplicationFromLastDay.ToString();
            }
            else
            {
                lblChangeApplications.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113);
                lblChangeApplications.Text = "↓ " + NewInfo.DefTotalApplicationFromLastDay.ToString();

            }



            if (NewInfo.IfTodayFeesWin)
            {
                lblChangeTodayRevenue.ForeColor = System.Drawing.Color.FromArgb(52, 211, 153);
                lblChangeTodayRevenue.Text = "↑ " + NewInfo.DefFromLastDayFees.ToString();
            }
            else
            {
                lblChangeTodayRevenue.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113);
                lblChangeTodayRevenue.Text = "↓ " + NewInfo.DefFromLastDayFees.ToString();

            }


        }
        private int Get_Differnce_in_Days_From_Now(DateTime Date)
        {

            int NumberOfDays = (DateTime.Now - Date).Days;




            return NumberOfDays;
        }
        private void FullTableSettings()
        {
            cls_Licenses_Loc_Inte GetTop7ExpiryLicenses = new cls_Licenses_Loc_Inte();
            List<drive_license_Information_Class>NewInformation = new List<drive_license_Information_Class>();

            NewInformation = GetTop7ExpiryLicenses.GetTop7ExpiryLicenses();

            if (NewInformation != null ) {

                if(NewInformation.Count() > 0 )
                {
                    picLinePhoto1.Image = Image.FromFile(NewInformation[0].Personal_Photo);
                    LabelLine1Name.Text = ReturnTableFullName(NewInformation[0].First_Name, NewInformation[0].Last_Name);
                    LabelLine1licenseNo.Text = NewInformation[0].Drive_License_ID.ToString();
                    LabelLine1ExpiryDate.Text = NewInformation[0].End_Date.Year.ToString()+"/"+ NewInformation[0].End_Date.Month.ToString()+"/"+ NewInformation[0].End_Date.Day.ToString();




                    LabelLine1DaysOverdue.Text = Get_Differnce_in_Days_From_Now(NewInformation[0].End_Date).ToString() + " deys";




                    LabelLine1DaysOverdue.Location = new Point(
                   (PanelLine1DaysOverdue.Width - LabelLine1DaysOverdue.Width) / 2,
                   (PanelLine1DaysOverdue.Height - LabelLine1DaysOverdue.Height) / 2);
                    pnlLine1.Visible = true;


                }
                if (NewInformation.Count() > 1)
                {


                    picLinePhoto2.Image = Image.FromFile(NewInformation[1].Personal_Photo);
                    LabelLine2Name.Text = ReturnTableFullName(NewInformation[1].First_Name, NewInformation[1].Last_Name);
                    LabelLine2licenseNo.Text = NewInformation[1].Drive_License_ID.ToString();
                    LabelLine2ExpiryDate.Text = NewInformation[1].End_Date.Year.ToString() + "/" + NewInformation[1].End_Date.Month.ToString() + "/" + NewInformation[1].End_Date.Day.ToString();




                    LabelLine2DaysOverdue.Text = Get_Differnce_in_Days_From_Now(NewInformation[1].End_Date).ToString() + " deys";




                    LabelLine2DaysOverdue.Location = new Point(
                   (PanelLine2DaysOverdue.Width - LabelLine2DaysOverdue.Width) / 2,
                   (PanelLine2DaysOverdue.Height - LabelLine2DaysOverdue.Height) / 2);
                    pnlLine2.Visible = true;


                }

                if (NewInformation.Count() > 2)
                {

                    picLinePhoto3.Image = Image.FromFile(NewInformation[2].Personal_Photo);
                    LabelLine3Name.Text = ReturnTableFullName(NewInformation[2].First_Name, NewInformation[2].Last_Name);
                    LabelLine3licenseNo.Text = NewInformation[2].Drive_License_ID.ToString();
                    LabelLine3ExpiryDate.Text = NewInformation[2].End_Date.Year.ToString() + "/" + NewInformation[2].End_Date.Month.ToString() + "/" + NewInformation[2].End_Date.Day.ToString();




                    LabelLine3DaysOverdue.Text = Get_Differnce_in_Days_From_Now(NewInformation[2].End_Date).ToString() + " days";




                    LabelLine3DaysOverdue.Location = new Point(
                   (PanelLine3DaysOverdue.Width - LabelLine3DaysOverdue.Width) / 2,
                   (PanelLine3DaysOverdue.Height - LabelLine3DaysOverdue.Height) / 2);
                    pnlLine3.Visible = true;


                }

                if (NewInformation.Count() > 3)
                {

                    picLinePhoto4.Image = Image.FromFile(NewInformation[3].Personal_Photo);
                    LabelLine4Name.Text = ReturnTableFullName(NewInformation[3].First_Name, NewInformation[3].Last_Name);
                    LabelLine4licenseNo.Text = NewInformation[3].Drive_License_ID.ToString();
                    LabelLine4ExpiryDate.Text = NewInformation[3].End_Date.Year.ToString() + "/" + NewInformation[3].End_Date.Month.ToString() + "/" + NewInformation[3].End_Date.Day.ToString();




                    LabelLine4DaysOverdue.Text = Get_Differnce_in_Days_From_Now(NewInformation[3].End_Date).ToString() + " deys";




                    LabelLine4DaysOverdue.Location = new Point(
                   (PanelLine4DaysOverdue.Width - LabelLine4DaysOverdue.Width) / 2,
                   (PanelLine4DaysOverdue.Height - LabelLine4DaysOverdue.Height) / 2);
                    pnlLine4.Visible = true;

                }

                if (NewInformation.Count() > 4)
                {
                    picLinePhoto5.Image = Image.FromFile(NewInformation[4].Personal_Photo);
                    LabelLine5Name.Text = ReturnTableFullName(NewInformation[4].First_Name, NewInformation[4].Last_Name);
                    LabelLine5licenseNo.Text = NewInformation[4].Drive_License_ID.ToString();
                    LabelLine5ExpiryDate.Text = NewInformation[4].End_Date.Year.ToString() + "/" + NewInformation[4].End_Date.Month.ToString() + "/" + NewInformation[4].End_Date.Day.ToString();




                    LabelLine5DaysOverdue.Text = Get_Differnce_in_Days_From_Now(NewInformation[4].End_Date).ToString() + " deys";




                    LabelLine5DaysOverdue.Location = new Point(
                   (PanelLine5DaysOverdue.Width - LabelLine5DaysOverdue.Width) / 2,
                   (PanelLine5DaysOverdue.Height - LabelLine5DaysOverdue.Height) / 2);
                    pnlLine5.Visible = true;

                }

                if (NewInformation.Count() > 5)
                {
                    picLinePhoto6.Image = Image.FromFile(NewInformation[5].Personal_Photo);
                    LabelLine6Name.Text = ReturnTableFullName(NewInformation[5].First_Name, NewInformation[5].Last_Name);
                    LabelLine6licenseNo.Text = NewInformation[5].Drive_License_ID.ToString();
                    LabelLine6ExpiryDate.Text = NewInformation[5].End_Date.Year.ToString() + "/" + NewInformation[5].End_Date.Month.ToString() + "/" + NewInformation[5].End_Date.Day.ToString();




                    LabelLine6DaysOverdue.Text = Get_Differnce_in_Days_From_Now(NewInformation[5].End_Date).ToString() + " deys";




                    LabelLine6DaysOverdue.Location = new Point(
                   (PanelLine6DaysOverdue.Width - LabelLine6DaysOverdue.Width) / 2,
                   (PanelLine6DaysOverdue.Height - LabelLine6DaysOverdue.Height) / 2);
                    pnlLine6.Visible = true;

                }

                if (NewInformation.Count() > 6)
                {
                    picLinePhoto7.Image = Image.FromFile(NewInformation[6].Personal_Photo);
                    LabelLine7Name.Text = ReturnTableFullName(NewInformation[6].First_Name, NewInformation[6].Last_Name);
                    LabelLine7licenseNo.Text = NewInformation[6].Drive_License_ID.ToString();
                    LabelLine7ExpiryDate.Text = NewInformation[6].End_Date.Year.ToString() + "/" + NewInformation[6].End_Date.Month.ToString() + "/" + NewInformation[6].End_Date.Day.ToString();




                    LabelLine7DaysOverdue.Text = Get_Differnce_in_Days_From_Now(NewInformation[6].End_Date).ToString() + " deys";




                    LabelLine7DaysOverdue.Location = new Point(
                   (PanelLine7DaysOverdue.Width - LabelLine7DaysOverdue.Width) / 2,
                   (PanelLine7DaysOverdue.Height - LabelLine7DaysOverdue.Height) / 2);
                    pnlLine7.Visible = true;


                }


            }



            


        }

        private void sercle_License_Overview(int Active, int Pending, int Expired)
        {
            var pieChart = new LiveCharts.Wpf.PieChart();
            ehDonut.Child = pieChart;
            var pie = (LiveCharts.Wpf.PieChart)ehDonut.Child;

            pie.InnerRadius = 70;

            pie.Series = new SeriesCollection
    {
        new LiveCharts.Wpf.PieSeries
        {
            Title = "Active",
            Values = new ChartValues<int> { Active },
            Fill = new SolidColorBrush(
                System.Windows.Media.Color.FromRgb(88, 86, 214)),
            Stroke = System.Windows.Media.Brushes.Transparent,
            StrokeThickness = 0
        },
        new LiveCharts.Wpf.PieSeries
        {
            Title = "Pending",
            Values = new ChartValues<int> { Pending },
            Fill = new SolidColorBrush(
                System.Windows.Media.Color.FromRgb(168, 85, 247)),
            Stroke = System.Windows.Media.Brushes.Transparent,
            StrokeThickness = 0
        },
        new LiveCharts.Wpf.PieSeries
        {
            Title = "Expired",
            Values = new ChartValues<int> { Expired },
            Fill = new SolidColorBrush(
                System.Windows.Media.Color.FromRgb(34, 211, 238)),
            Stroke = System.Windows.Media.Brushes.Transparent,
            StrokeThickness = 0
        }
    };

            pie.LegendLocation = LegendLocation.None;
            pie.Hoverable = true;
            pie.DataTooltip = new LiveCharts.Wpf.DefaultTooltip();

            // بعد تحميل الدائرة
            lblConutTotal.Left = ehDonut.Left + (ehDonut.Width / 2) - (lblConutTotal.Width / 2);
            lblConutTotal.Top = ehDonut.Top + (ehDonut.Height / 2) - (lblConutTotal.Height / 2);
            lblConutTotal.BringToFront();

            lblDonutLabel.Left = ehDonut.Left + (ehDonut.Width / 2) - (lblDonutLabel.Width / 2);
            lblDonutLabel.Top = ehDonut.Top + (ehDonut.Height / 2) - (lblDonutLabel.Height / 2) - 30;
            lblDonutLabel.BringToFront();

        }
        private void ArrangeStatCards()
        {
            int totalWidth = flpStats.Width - 40;
            int cardCount = 4;
            int spacing = 10;
            int cardWidth = (totalWidth - (spacing * (cardCount - 1))) / cardCount;

            foreach (Control card in flpStats.Controls)
            {
                card.Width = cardWidth;
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PiclTitleApplications_Click(object sender, EventArgs e)
        {

        }

        private void pnlWelcome_s_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Us_welcom_s_Load(object sender, EventArgs e)
        {
            ArrangeStatCards();
            FullHomeMoreInformation();
            sercle_License_Overview(Active, Pending, Expired);

            welcomLabel1.Text = "Welcome back, " + CurrentUserLogin.CurrentUserName;

            FullTableSettings();


        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblChangeApplications__Click(object sender, EventArgs e)
        {

        }

        private void piclTitleLicenses_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void guna2Panel2_MouseEnter(object sender, EventArgs e)
        {
            pnlQuickActionApp.FillColor = System.Drawing.Color.FromArgb(18, 42, 111);
        }

        private void pnlQuickActionApp_MouseLeave(object sender, EventArgs e)
        {
            pnlQuickActionApp.FillColor = System.Drawing.Color.FromArgb(10, 27, 77);
        }

        private void pnlQuickActionIssueL_MouseEnter(object sender, EventArgs e)
        {
            pnlQuickActionIssueL.FillColor = System.Drawing.Color.FromArgb(90, 70, 180);

        }

        private void pnlQuickActionIssueL_MouseLeave(object sender, EventArgs e)
        {
            pnlQuickActionIssueL.FillColor = System.Drawing.Color.FromArgb(10, 27, 77);
        }

        private void pnlQuickActionScheduleEx_MouseEnter(object sender, EventArgs e)
        {
            pnlQuickActionScheduleEx.FillColor = System.Drawing.Color.FromArgb(180, 80, 200);

        }

        private void pnlQuickActionScheduleEx_MouseLeave(object sender, EventArgs e)
        {
            pnlQuickActionScheduleEx.FillColor = System.Drawing.Color.FromArgb(10, 27, 77);
        }

        private void pnlQuickActionCollectP_MouseEnter(object sender, EventArgs e)
        {
            pnlQuickActionCollectP.FillColor = System.Drawing.Color.FromArgb(20, 140, 140);

        }

        private void pnlQuickActionCollectP_MouseLeave(object sender, EventArgs e)
        {
            pnlQuickActionCollectP.FillColor = System.Drawing.Color.FromArgb(10, 27, 77);

        }

        private void Us_welcom_s_Resize(object sender, EventArgs e)
        {
            ArrangeStatCards();
        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void flpStats_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnViewAllExpired_Click(object sender, EventArgs e)
        {
            Drive_License_App_Start drive_License_App_Start = (Drive_License_App_Start)this.FindForm();
            drive_License_App_Start.OverirGestionPermisClickBtnRenew();
        }

        private void pnlQuickActionApp_Click(object sender, EventArgs e)
        {
            Drive_License_App_Start drive_License_App_Start = (Drive_License_App_Start)this.FindForm();
            drive_License_App_Start.OverirGestionPermisClickBtnApplication();
        }

        private void pnlQuickActionIssueL_Click(object sender, EventArgs e)
        {
            Drive_License_App_Start drive_License_App_Start = (Drive_License_App_Start)this.FindForm();
            drive_License_App_Start.OverirGestionPermisClickBtnApplication();

          

            
        }

        private void pnlQuickActionScheduleEx_Click(object sender, EventArgs e)
        {
            Drive_License_App_Start drive_License_App_Start = (Drive_License_App_Start)this.FindForm();
            drive_License_App_Start.OverirGestionPermisClickBtnExam();
        }

        private void pnlQuickActionCollectP_Click(object sender, EventArgs e)
        {
            Drive_License_App_Start drive_License_App_Start = (Drive_License_App_Start)this.FindForm();
            drive_License_App_Start.OverirGestionPermisClickBtnServices_Exam();
        }

        private void ButtonLine1Action_Click(object sender, EventArgs e)
        {
            Drive_License_App_Start drive_License_App_Start = (Drive_License_App_Start)this.FindForm();
            drive_License_App_Start.OverirGestionPermisClickBtnRenew();
        }

        private void ButtonLine2Action_Click(object sender, EventArgs e)
        {
            Drive_License_App_Start drive_License_App_Start = (Drive_License_App_Start)this.FindForm();
            drive_License_App_Start.OverirGestionPermisClickBtnRenew();
        }

        private void ButtonLine3Action_Click(object sender, EventArgs e)
        {
            Drive_License_App_Start drive_License_App_Start = (Drive_License_App_Start)this.FindForm();
            drive_License_App_Start.OverirGestionPermisClickBtnRenew();
        }

        private void ButtonLine4Action_Click(object sender, EventArgs e)
        {
            Drive_License_App_Start drive_License_App_Start = (Drive_License_App_Start)this.FindForm();
            drive_License_App_Start.OverirGestionPermisClickBtnRenew();
        }

        private void ButtonLine5Action_Click(object sender, EventArgs e)
        {
            Drive_License_App_Start drive_License_App_Start = (Drive_License_App_Start)this.FindForm();
            drive_License_App_Start.OverirGestionPermisClickBtnRenew();
        }

        private void ButtonLine6Action_Click(object sender, EventArgs e)
        {
            Drive_License_App_Start drive_License_App_Start = (Drive_License_App_Start)this.FindForm();
            drive_License_App_Start.OverirGestionPermisClickBtnRenew();
        }

        private void ButtonLine7Action_Click(object sender, EventArgs e)
        {
            Drive_License_App_Start drive_License_App_Start = (Drive_License_App_Start)this.FindForm();
            drive_License_App_Start.OverirGestionPermisClickBtnRenew();
        }
    }
}
