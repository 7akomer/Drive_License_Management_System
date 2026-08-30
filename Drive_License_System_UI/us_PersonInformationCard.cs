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
    public partial class us_PersonInformationCard : UserControl
    {
        public us_PersonInformationCard()
        {
            InitializeComponent();
        }

        public event Action EditThisPersonIfo;
        public event Action EditUserNameClick;
        public event Action EditPermisssionClick;
        public event Action SaveClick;
        public event Action CloseClick;
        public event Action ShearchTextChange;

        private void pnlfull_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCardPersonTitle_Click(object sender, EventArgs e)
        {

        }

        private void Call_Click(object sender, EventArgs e)
        {

        }

        private void Edit_Click(object sender, EventArgs e)
        {
            EditThisPersonIfo?.Invoke();
        }

        private void Delete_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox8_Click(object sender, EventArgs e)
        {
            EditPermisssionClick.Invoke();
        }

        private void EditUserName_Click(object sender, EventArgs e)
        {
            EditUserNameClick.Invoke();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveClick.Invoke();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseClick.Invoke();
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            ShearchTextChange.Invoke();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
