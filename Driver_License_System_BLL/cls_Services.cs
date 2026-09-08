using Driver_License_System_DAL;
using Driver_License_System__Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System_BLL
{
    public class cls_Services
    {
       public  List<Services_Information_Class> GetServicesList()
        {
            List<Services_Information_Class> NewInformation = new List<Services_Information_Class>();

            services_management NewManagement = new services_management();

            bool is_Valid = false;

            NewInformation = NewManagement.Get_Services_List(ref is_Valid);

            if (is_Valid)
            {
                return NewInformation;
            }

            return null;
        }


        public bool UpdateService(Services_Information_Class service_Information)
        {
            services_management NewManagement = new services_management();

            if (NewManagement.Update_Service(service_Information))
            {
                return true;
            }

            return false;

        }


        public Services_Information_Class GetServicePrice(int ServiceID) 
            {

            Services_Information_Class NewInformation = new Services_Information_Class();
            services_management NewManagement = new services_management();

            bool is_Valid = false;

            NewInformation = NewManagement.Get_Service_Price_By_ID(ServiceID,ref is_Valid);

            if (is_Valid)
            {
                return NewInformation;
            }

            return null;
        }
    }
}
