using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System__Models
{
    public class category_Information_Class
    {
        public int category_ID { get; set; }
        public string category_Name { get; set; }

        public decimal Price { get; set; }

        public int Required_Age { get; set; }


        public int service_ID { get; set; }

        public string description { get; set; }

        public int Validity { get; set; }
    }
}
