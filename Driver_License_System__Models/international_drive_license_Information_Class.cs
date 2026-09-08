using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System__Models
{
    public class international_drive_license_Information_Class
    {
        public int International_Drive_License_ID { get; set; }

        public int Drive_License_ID { get; set; }

        public DateTime Relese_Date { get; set; }

        public DateTime End_Date { get; set; }

        public string Category_Name { get; set; }




        public int person_ID { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Personal_Photo { get; set; }

        public bool Is_Active { get; set; }

        public string National_ID
        {
            get; set;
        }
    }
}
