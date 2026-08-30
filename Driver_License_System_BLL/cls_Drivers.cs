using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver_License_System__Models;
using Driver_License_System_DAL;


namespace Driver_License_System_BLL
{
    public class cls_Drivers
    {
      public   List<drivers_Information_Class> Get_Drivers_list()
        {

            driver_management NewManagement = new driver_management();

            bool is_Valid = false;
            List<drivers_Information_Class> NewList = new List<drivers_Information_Class>();

            NewList = NewManagement.Get_Drivers_List(ref is_Valid);

            if (is_Valid)
            {
                return NewList;
            }


            return null;
        }

        public drivers_Information_Class Filter_By_DriverID(string driverID)
        {
            bool is_Valid = false;
            drivers_Information_Class Information = new drivers_Information_Class();

            driver_management Get_Information = new driver_management();

            Information = Get_Information.Find_By_DriverID(driverID,ref is_Valid);

            if(is_Valid)
            {
                return Information;
            }
            
            return null;

        }

        public bool IfThisPersonIsDriver(int PersonID)
        {
            driver_management Get_Information = new driver_management();


            return Get_Information.IFthisPersonIsDriver(PersonID);
        }

        public int ReturnDriverID(int PersonID)
        {
            driver_management Get_Information = new driver_management();

            return Get_Information.GetDriverID(PersonID);
        }

        public int AddNewDriver(int PersonID)
        {
            driver_management Get_Information = new driver_management();

            return Get_Information.Add_Driver(PersonID);
        }

    }
}
