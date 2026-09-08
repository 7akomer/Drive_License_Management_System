using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System__Models
{
    public class orders_Information_Class
    {
        public enum order_status
        {
            New = 1,
            cancelled = 2,
            completed = 3,

        }
        public int order_ID { get; set; }

        public int people_ID { get; set; }

        public DateTime orderDate { get; set; }


        public Decimal Application_fee_paid { get; set; }

        public string service_Name { get; set; }

        public string order_status_Name { get; set; }

        public string First_name { get; set; }

        public string Last_name { get; set; }

        public string Personal_Photo { get; set; }

        public string National_ID { get; set; }

        public int service_ID { get; set; }

        public int order_status_ID { get; set; }

        public string Third_name { get; set; }

        public string Second_name { get; set; }

        public string Phone_Nember { get; set; }


    }
}
