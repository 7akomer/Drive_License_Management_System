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
    public partial class us__EditPersonalInformation : UserControl
    {
        public us__EditPersonalInformation()
        {
            InitializeComponent();
        }

        public event Action Close_EditCard;
        public event Action SelectNewPhoto;
        public event Action SaveEditedInformation;
        public event Action AddNewPerson;
        public event Action Close_AddPersonCard;

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close_EditCard?.Invoke();
        }


        private void Edit_Click(object sender, EventArgs e)
        {
            SelectNewPhoto.Invoke();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveEditedInformation.Invoke();
        }

        private void EditNationalID_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddNewPerson.Invoke();
        }

        private void btnCloseAddCard_Click(object sender, EventArgs e)
        {
            Close_AddPersonCard.Invoke();
        }

        private void pnlfull_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
