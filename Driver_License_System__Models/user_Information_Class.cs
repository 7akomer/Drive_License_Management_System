using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System__Models
{
    public class user_Information_Class
    {
        public string userName { get; set; }
        public int people_ID { get; set; }

        public bool is_Admin { get; set; }
        public string userPassword { get; set; }

        public int user_ID { get; set; }

        public string UserPhoto {  get; set; }
    }
}
