using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Drive_License_System_UI
{
    public partial class us_Optimised_Table : UserControl
    {

        public Guna2CirclePictureBox[] PicColumn;
        public Guna2HtmlLabel[] LableColumn1;
        public Guna2HtmlLabel[] LableColumn2;
        public Guna2HtmlLabel[] LableColumn3;
        public Guna2HtmlLabel[] LableColumn4;
        public Guna2Panel[] PanelColumn4;
        public Guna2Panel[] panelLine;


        public event Action NextPageButtonClicked;
        public event Action PreviousPageButtonClicked;
        public event EventHandler ShearchTextChange;
        public event Action SelectedIndexChanged;
        public event Action ActionShowMoreDetilePerson_Click;
        public event Action ActionEditPersonInformation;

        public us_Optimised_Table()
        {
            InitializeComponent();

            LableColumn1 = new Guna2HtmlLabel[]
             {
            Name1OptimiseTable,
            Name2OptimiseTable,
            Name3OptimiseTable,
            Name4OptimiseTable,
            Name5OptimiseTable,
             Name6OptimiseTable,
              Name7OptimiseTable,
               Name8OptimiseTable,
              Name9OptimiseTable,
               Name10OptimiseTable,

        };


            LableColumn2 = new Guna2HtmlLabel[]
          {
                LicenseNo1OptimiseTable,
                LicenseNo2OptimiseTable,
LicenseNo3OptimiseTable,
LicenseNo4OptimiseTable,
LicenseNo5OptimiseTable,
LicenseNo6OptimiseTable,
LicenseNo7OptimiseTable,
LicenseNo8OptimiseTable,
LicenseNo9OptimiseTable,
LicenseNo10OptimiseTable,

            };


            LableColumn3 = new Guna2HtmlLabel[]
                {

                releasedate1OptimiseTable,
                releasedate2OptimiseTable,
                releasedate3OptimiseTable,
                releasedate4OptimiseTable,
                releasedate5OptimiseTable,
                releasedate6OptimiseTable,
                releasedate7OptimiseTable,
                releasedate8OptimiseTable,
                releasedate9OptimiseTable,
                releasedate10OptimiseTable,
            };


            PicColumn = new Guna2CirclePictureBox[]
            {
            personalPhoto1OptimiseTable,
            personalPhoto2OptimiseTable,
            personalPhoto3OptimiseTable,
            personalPhoto4OptimiseTable,
            personalPhoto5OptimiseTable,
            personalPhoto6OptimiseTable,
            personalPhoto7OptimiseTable,
            personalPhoto8OptimiseTable,
            personalPhoto9OptimiseTable,
            personalPhoto10OptimiseTable,
            };

            LableColumn4 = new Guna2HtmlLabel[]
              {
                  state1textOptimiseTable,
                  state2textOptimiseTable,
                  state3textOptimiseTable,
                  state4textOptimiseTable,
                  state5textOptimiseTable,
                  state6textOptimiseTable,
                  state7textOptimiseTable,
                  state8textOptimiseTable,
                  state9textOptimiseTable,
                  state10textOptimiseTable,


          };


            PanelColumn4 = new Guna2Panel[]
            {
                StatePnl1OptimiseTable,
                 StatePnl2OptimiseTable,
                 StatePnl3OptimiseTable,
                 StatePnl4OptimiseTable,
                 StatePnl5OptimiseTable,
                 StatePnl6OptimiseTable,
                 StatePnl7OptimiseTable,
                 StatePnl8OptimiseTable,
                 StatePnl9OptimiseTable,
                 StatePnl10OptimiseTable,
            };

            panelLine = new Guna2Panel[]
            {
                Row1OptimiseTable,
                Row2OptimiseTable,
                Row3OptimiseTable,
                Row4OptimiseTable,
                Row5OptimiseTable,
                Row6OptimiseTable,
                Row7OptimiseTable,
                Row8OptimiseTable,
                Row9OptimiseTable,
                Row10OptimiseTable,
            };





        }


        public int CurrentPage = 1;
        public int TotalPages = 1;
        public int NumberOfRowsInThis = 10;
        public int CurrentLineInfo = 0;
        public int CurrentActionLinePersonDetile = 1;

        private void txbOptimiseTableSearch_TextChanged(object sender, EventArgs e)
       {
            ShearchTextChange?.Invoke(this,EventArgs.Empty);
        }

        private void Row1OptimiseTable_Paint(object sender, PaintEventArgs e)
        {

        }




        public void us_Optimised_Table_Load(object sender, EventArgs e)
        {




        }

        private void btnNextOptimiseTable_Click(object sender, EventArgs e)
        {
           

            NextPageButtonClicked?.Invoke();
        }

        private void btnpreviousOptimiseTable_Click(object sender, EventArgs e)
        {
            PreviousPageButtonClicked?.Invoke();
        }

        private void cxbOptimiseTableFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndexChanged?.Invoke();
        }

        private void ButtonLine1ActionOptimiseTable_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 1;
            ActionShowMoreDetilePerson_Click?.Invoke();
       }

        private void ButtonLine2ActionOptimiseTable_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 2;

            ActionShowMoreDetilePerson_Click?.Invoke();
        }

        private void ButtonLine3ActionOptimiseTable_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 3;

            ActionShowMoreDetilePerson_Click?.Invoke();
        }

        private void ButtonLine4ActionOptimiseTable_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 4;

            ActionShowMoreDetilePerson_Click?.Invoke();
        }

        private void ButtonLine5ActionOptimiseTable_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 5;
            ActionShowMoreDetilePerson_Click?.Invoke();

        }

        private void ButtonLine6ActionOptimiseTable_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 6;

            ActionShowMoreDetilePerson_Click?.Invoke();
        }

        private void ButtonLine7ActionOptimiseTable_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 7;

            ActionShowMoreDetilePerson_Click?.Invoke();
        }

        private void ButtonLine8ActionOptimiseTable_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 8;

            ActionShowMoreDetilePerson_Click?.Invoke();
        }

        private void ButtonLine9ActionOptimiseTable_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 9;

            ActionShowMoreDetilePerson_Click?.Invoke();
        }

        private void ButtonLine10ActionOptimiseTable_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 10;

            ActionShowMoreDetilePerson_Click?.Invoke();
        }

        private void EditRow1_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 1;

            ActionEditPersonInformation?.Invoke();
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 2;

            ActionEditPersonInformation?.Invoke();

        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 3;

            ActionEditPersonInformation?.Invoke();

        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 4;

            ActionEditPersonInformation?.Invoke();

        }

        private void guna2CirclePictureBox5_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 5;

            ActionEditPersonInformation?.Invoke();

        }

        private void guna2CirclePictureBox6_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 6;

            ActionEditPersonInformation?.Invoke();

        }

        private void guna2CirclePictureBox7_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 7;

            ActionEditPersonInformation?.Invoke();

        }

        private void guna2CirclePictureBox8_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 8;

            ActionEditPersonInformation?.Invoke();

        }

        private void guna2CirclePictureBox9_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 9;

            ActionEditPersonInformation?.Invoke();

        }

        private void guna2CirclePictureBox10_Click(object sender, EventArgs e)
        {
            CurrentActionLinePersonDetile = 10;

            ActionEditPersonInformation?.Invoke();

        }

        private void lplTitleEntityOptimiseTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlOptimiseTableHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
