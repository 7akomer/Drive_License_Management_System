using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System__Models
{
    public class reservation_Informaton_Class
    {
        public int Reservation_ID { get; set; }

        public int Drive_License_ID { get; set; }



        public Decimal Tax { get; set; }

        public string Reason_For_Reservation { get; set; }

        public DateTime Reservation_Date { get; set; }

        public int User_ID { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Personal_Photo { get; set; }

        public string Category_Name { get; set; }

        public int Person_ID { get; set; }
    }
}
