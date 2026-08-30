using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System__Models
{
    public class Person_Information_class
    {
        public enum Find_By_What
        {
            By_PeopleID = 0, By_FirstName = 1, By_SecondName = 2, By_TirdName = 3, By_LastName = 4, By_PhoneNumber = 5, By_Email = 6, By_National_ID = 7, By_Country = 8, By_Address = 9, By_BirthDate = 10
        }
        public string National_ID { get; set; }
        public byte Nationality_ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public string Personal_Photo { get; set; }

        public string Gender {  get; set; }
        public string country_name { get; set; }

        public int Person_ID { get; set; }

        public string UserName { get; set; }

        public int UserID { get; set; }

        public bool Is_Supper_Admin {  get; set; }

        

    }
}
