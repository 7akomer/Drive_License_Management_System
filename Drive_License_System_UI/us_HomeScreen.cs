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
            lblDonutTotal.Left = ehDonut.Left + (ehDonut.Width / 2) - (lblDonutTotal.Width / 2);
            lblDonutTotal.Top = ehDonut.Top + (ehDonut.Height / 2) - (lblDonutTotal.Height / 2);
            lblDonutTotal.BringToFront();

            lblDonutLabel.Left = ehDonut.Left + (ehDonut.Width / 2) - (lblDonutLabel.Width / 2);
            lblDonutLabel.Top = ehDonut.Top + (ehDonut.Height / 2) - (lblDonutLabel.Height / 2) - 20;
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
            sercle_License_Overview(45, 25, 30);


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
    }
}
