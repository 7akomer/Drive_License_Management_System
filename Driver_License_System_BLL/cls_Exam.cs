using Driver_License_System__Models;
using Driver_License_System_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System_BLL
{
    public class cls_Exam
    {
        public List<test_Information_Class> GetExamList()
        {
            List<test_Information_Class> NewInformation = new List<test_Information_Class>();

            test_management NewManagement = new test_management();

            bool is_Valid = false;

            NewInformation = NewManagement.Get_Tests_List(ref is_Valid);

            if (is_Valid)
            {
                return NewInformation;
            }

            return null;
        }


        public bool UpdateExam(test_Information_Class Test_Information)
        {
            test_management NewManagement = new test_management();

            if (NewManagement.Update_Test_Price(Test_Information))
            {
                return true;
            }

            return false;

        }
    }
}
