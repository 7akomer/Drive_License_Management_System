using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System__Models
{
    public class orderInformation_Information_Class
    {
        public int OrderInformation_ID { get; set; }
        public int People_ID { get; set; }

        public int Order_ID { get; set; }

        public int Service_ID { get; set; }

        public int? Category_ID { get; set; }
    }
}
