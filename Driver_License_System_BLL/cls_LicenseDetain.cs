using Driver_License_System__Models;
using Driver_License_System_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System_BLL
{
    public class cls_LicenseDetain
    {
        public List<reservation_Informaton_Class> Get_License_Reservation_List()
        {

            bool is_Valid = false;

            List<reservation_Informaton_Class> NewList = new List<reservation_Informaton_Class>();

            reservation_management NewManagement = new reservation_management();

            NewList = NewManagement.Get_License_Reservation_List(ref is_Valid);


            if (is_Valid)
            {
                return NewList;
            }

            return null;
        }

        public List<reservation_Informaton_Class> Get_Filter_By_FirstName_Reservation_List(string NationalID)
        {

            bool is_Valid = false;

            List<reservation_Informaton_Class> NewList = new List<reservation_Informaton_Class>();

            reservation_management NewManagement = new reservation_management();

            NewList = NewManagement.Get_Filter_By_FirstName_Reservation_List(NationalID, ref is_Valid);


            if (is_Valid)
            {
                return NewList;
            }

            return null;
        }

        public List<reservation_Informaton_Class> Get_Filter_By_NationalID_Reservation_List(int DetainID )
        {

            if (DetainID > 0)
            {
                bool is_Valid = false;

                List<reservation_Informaton_Class> NewList = new List<reservation_Informaton_Class>();

                reservation_management NewManagement = new reservation_management();

                NewList = NewManagement.Get_Filter_By_DetainID_Reservation_List(DetainID, ref is_Valid);


                if (is_Valid)
                {
                    return NewList;
                }

            }

            return null;
        }



        //
        public bool Add_Reserve_Drive_License(reservation_Informaton_Class NewInfo)
        {

            reservation_management NewManagement = new reservation_management();
            drive_license_management NewStatus = new drive_license_management();

            NewInfo.Reservation_Date = DateTime.Now;

            //
            NewInfo.User_ID = CurrentUserLogin.CurrentUserID;
            //

            if (NewManagement.Add_Reserve_Drive_License(NewInfo))
            {
                NewStatus.deActivate_Drive_License(NewInfo.Drive_License_ID);
                return true;
            }

            return false;
        }
        //

        public bool License_Release(int Reserve_ID,int LicenseID,DateTime ExpiryDate)
        {
            reservation_management NewManagement = new reservation_management();
            drive_license_management NewStatus = new drive_license_management();

            if (NewManagement.License_Release(Reserve_ID))
            {

                if (ExpiryDate > DateTime.Now)
                {
                    NewStatus.Activate_Drive_License(LicenseID);
                }

                return true;
            }
            return false;
        }


        public bool Is_Reserved(int LicenseID)
        {
            reservation_management NewManagement = new reservation_management();

            if (NewManagement.Is_Reserved(LicenseID))
            {
                return true;
            }
            return false;
        }


        public List<drive_license_Information_Class> Get_Not_Reservd_And_Active_Licenses()
        {
            cls_Licenses_Loc_Inte NewLicenses = new cls_Licenses_Loc_Inte();

            List<drive_license_Information_Class> NewList = new List<drive_license_Information_Class>();
            List<drive_license_Information_Class> FiltredList = new List<drive_license_Information_Class>();

            NewList = NewLicenses.GetLicensesList();


            for (int i = 0; i < NewList.Count(); i++)
            {
                if ((!Is_Reserved(NewList[i].Drive_License_ID)) && NewList[i].Is_Active == true)
                {
                    FiltredList.Add(NewList[i]);
                }

            }



            return FiltredList;
        }


        public List<drive_license_Information_Class> Get_Filter_By_FirstName_Not_Reservd_And_Active_Licenses(string FirstName)
        {
            cls_Licenses_Loc_Inte NewLicenses = new cls_Licenses_Loc_Inte();

            List<drive_license_Information_Class> NewList = new List<drive_license_Information_Class>();
            List<drive_license_Information_Class> FiltredList = new List<drive_license_Information_Class>();

            NewList = NewLicenses.FilterByFirstName(FirstName);

            if (NewList != null)
            {

                for (int i = 0; i < NewList.Count(); i++)
                {
                    if ((!Is_Reserved(NewList[i].Drive_License_ID )) && NewList[i].Is_Active == true)
                    {
                        FiltredList.Add(NewList[i]);
                    }

                }

            }

            return FiltredList;
        }

        public List<drive_license_Information_Class> Get_Filter_By_NationalID_Not_Reservd_And_Active_Licenses(string NationalID)
        {
            cls_Licenses_Loc_Inte NewLicenses = new cls_Licenses_Loc_Inte();

            List<drive_license_Information_Class> NewList = new List<drive_license_Information_Class>();
            List<drive_license_Information_Class> FiltredList = new List<drive_license_Information_Class>();

            NewList = NewLicenses.FilterByNationalID(NationalID);

            if (NewList != null)
            {
                for (int i = 0; i < NewList.Count(); i++)
                {
                    if ((!Is_Reserved(NewList[i].Drive_License_ID)) && NewList[i].Is_Active == true)
                    {
                        FiltredList.Add(NewList[i]);
                    }

                }
            }


            return FiltredList;
        }


        public drive_license_Information_Class Get_License_Detain_Information(int  LicenseID)
        {
           
                cls_Licenses_Loc_Inte NewLicenses = new cls_Licenses_Loc_Inte();

            return NewLicenses.Get_License_Info_By_LicenseID(LicenseID);

            

        }


        public Services_Information_Class Get_Service_Detain_Price(int ServiceID)
        {
            cls_Services GetPrice = new cls_Services();
            
            return GetPrice.GetServicePrice(ServiceID);
        }


        public void AddNewReleaseOrder(int PersonID,Decimal TotalPaid,int OrderStatusID)
        {
            order_management NewOrder = new order_management();
            orders_Information_Class NewInformation = new orders_Information_Class();

            NewInformation.Application_fee_paid = TotalPaid;
            NewInformation.people_ID = PersonID;
            NewInformation.orderDate = DateTime.Now;
            NewInformation.service_ID = 6;
            NewInformation.order_status_ID = OrderStatusID;

            NewOrder.Add_Order(NewInformation);

        }


        public static int GetNumberOfDetainLicensesThisPersonHas(int PersonID)
        {
            return reservation_management.GetNumberOfDetainLicensesThisPersonhas(PersonID);
        }
    }
}
