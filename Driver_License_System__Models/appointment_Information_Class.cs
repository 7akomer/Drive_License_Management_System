using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System__Models
{
    public class appointment_Information_Class
    {
        public enum Results
        {
            Fail = 1,
            Pass = 2,
            Pending = 3
        }

        public enum Test
        {
            Eye_test = 1,
            Theoretical_test = 2,
            Practical_driving_test = 3
        }
        public int appointment_ID { get; set; }

        public DateTime AppoinementDate { get; set; }

        public int result_ID { get; set; }

        public string notes { get; set; }

        public int test_ID { get; set; }

        public int order_information_ID { get; set; }

        public int order_ID { get; set; }

        public int people_ID { get; set; }

        public DateTime orderDate { get; set; }


        public Decimal Test_Fees { get; set; }

        public string service_Name { get; set; }


        public string First_name { get; set; }

        public string Last_name { get; set; }

        public string Personal_Photo { get; set; }

        public string Phone_Nember { get; set; }

        public string Category_Name { get; set; }

        public string TestName { get; set; }


    }
}
