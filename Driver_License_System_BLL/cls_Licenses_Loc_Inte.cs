using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver_License_System_DAL;
using Driver_License_System__Models;
using System.Security.Cryptography.X509Certificates;

namespace Driver_License_System_BLL
{
    public class cls_Licenses_Loc_Inte
    {

        public List<drive_license_Information_Class> GetLicensesList()
        {

            List<drive_license_Information_Class> NewList = new List<drive_license_Information_Class>();

            drive_license_management NewManagement = new drive_license_management();

            bool is_Valid = false;

            NewList = NewManagement.Get_Drive_License_List(ref is_Valid);

            if (is_Valid) {
            
                return NewList;
            
            }





            return null;
        }

        public List<drive_license_Information_Class> GetExpiryLicensesList()
        {

            List<drive_license_Information_Class> NewList = new List<drive_license_Information_Class>();

            drive_license_management NewManagement = new drive_license_management();

            bool is_Valid = false;

            NewList = NewManagement.Get_Expiry_Licenses_List(ref is_Valid);

            if (is_Valid)
            {

                return NewList;

            }





            return null;
        }


        public List<drive_license_Information_Class> GetTop7ExpiryLicenses()
        {

            List<drive_license_Information_Class> NewList = new List<drive_license_Information_Class>();

            drive_license_management NewManagement = new drive_license_management();

            bool is_Valid = false;

            NewList = NewManagement.Get_Top7_Expiry_Licenses(ref is_Valid);

            if (is_Valid)
            {

                return NewList;

            }





            return null;
        }

        public List<drive_license_Information_Class> FilterByNationalID(string NationalID)
        {
            List<drive_license_Information_Class> NewList = new List<drive_license_Information_Class>();

            drive_license_management NewManagement = new drive_license_management();

            bool is_Valid = false;

            NewList = NewManagement.Find_By_NationalID(NationalID,ref is_Valid);

            if (is_Valid)
            {

                return NewList;

            }





            return null;
        }

        public List<drive_license_Information_Class> Filter_ExpiryLicenses_ByNationalID(string NationalID)
        {
            List<drive_license_Information_Class> NewList = new List<drive_license_Information_Class>();

            drive_license_management NewManagement = new drive_license_management();

            bool is_Valid = false;

            NewList = NewManagement.Find_ExpiryLicense_By_NationalID(NationalID, ref is_Valid);

            if (is_Valid)
            {

                return NewList;

            }





            return null;
        }

        public List<drive_license_Information_Class> FilterByFirstName(string firstName)
        {
            List<drive_license_Information_Class> NewList = new List<drive_license_Information_Class>();

            drive_license_management NewManagement = new drive_license_management();

            bool is_Valid = false;

            NewList = NewManagement.Find_By_FirstName(firstName, ref is_Valid);

            if (is_Valid)
            {

                return NewList;

            }





            return null;
        }

        public List<drive_license_Information_Class> Filter_ExpiryLicenses_ByFirstName(string firstName)
        {
            List<drive_license_Information_Class> NewList = new List<drive_license_Information_Class>();

            drive_license_management NewManagement = new drive_license_management();

            bool is_Valid = false;

            NewList = NewManagement.Find_ExpiryLicenses_By_FirstName(firstName, ref is_Valid);

            if (is_Valid)
            {

                return NewList;

            }





            return null;
        }



        public List<international_drive_license_Information_Class> GetInternationalLicensesList()
        {

            List<international_drive_license_Information_Class> NewList = new List<international_drive_license_Information_Class>();

            international_drive_license_management NewManagement = new international_drive_license_management();

            bool is_Valid = false;

            NewList = NewManagement.Get_International_Drive_License_List(ref is_Valid);

            if (is_Valid)
            {

                return NewList;

            }





            return null;
        }


        public List<international_drive_license_Information_Class> FilterInternationaLicenseByNationalID(string NationalID)
        {
            List<international_drive_license_Information_Class> NewList = new List<international_drive_license_Information_Class>();

            international_drive_license_management NewManagement = new international_drive_license_management();

            bool is_Valid = false;

            NewList = NewManagement.Find_By_NationalID(NationalID, ref is_Valid);

            if (is_Valid)
            {

                return NewList;

            }





            return null;
        }


        public List<international_drive_license_Information_Class> FilterInternationaLicenseByFirstName(string FirstName)
        {
            List<international_drive_license_Information_Class> NewList = new List<international_drive_license_Information_Class>();

            international_drive_license_management NewManagement = new international_drive_license_management();

            bool is_Valid = false;

            NewList = NewManagement.Find_By_FirstName(FirstName, ref is_Valid);

            if (is_Valid)
            {

                return NewList;

            }





            return null;
        }



        public drive_license_Information_Class Get_License_Info_By_LicenseID(int LicenseID)
        {
            drive_license_management NewManagement = new drive_license_management();

            drive_license_Information_Class NewInfo = new drive_license_Information_Class();

            bool is_Valid = false;


            NewInfo = NewManagement.Get_License_By_LicenseID(LicenseID, ref is_Valid);


      
            if (is_Valid)
            {

                return NewInfo;

            }





            return null;
        }


        public static int GetNumberOfLicensesThisDriverHas(int DriverID)
        {
            return drive_license_management.GetNumberOfLicensesThisDriverhas(DriverID);
        }


        public bool AddNewInternationalLicense(international_drive_license_Information_Class NewLicense)
        {
            international_drive_license_management NewManagement = new international_drive_license_management();

            NewLicense.Relese_Date = DateTime.Now;

            return NewManagement.Add_International_Drive_License(NewLicense);
        }

        public bool ReplacementLocalLicense(int LicenseID, byte ReplacementType,ref int NewLicenseID)
        {
            drive_license_Information_Class LicenseInformation = new drive_license_Information_Class();
            drive_license_management LicenseManagement = new drive_license_management();
            international_drive_license_Information_Class SendNewLicenseID = new international_drive_license_Information_Class();
            international_drive_license_management UpdateLicense = new international_drive_license_management();
            bool is_Valid = false;
            LicenseInformation = LicenseManagement.Get_License_Info_From_Licenses_By_LicenseID(LicenseID, ref is_Valid);

            if (is_Valid)
            {
                if (ReplacementType == 1)
                {
                    LicenseInformation.Comment += $"   This license is Replacement for Lost one, The old id = {LicenseID} ,..";
                }
                else if (ReplacementType == 2)
                {
                    LicenseInformation.Comment += $"   This license is Replacement for damaged one, The old id = {LicenseID} ,.. ";

                }
                else
                {
                    return false;
                }

                //نقوم بالغاء تفعيل هده الرخصة للتمكن من اضافة واحدة اخرى بنفس المعلومات
                LicenseManagement.deActivate_Drive_License(LicenseID);
                //

                 NewLicenseID = -1;
                if (LicenseManagement.Add_Drive_License(LicenseInformation,ref NewLicenseID))
                {
                    if (UpdateLicense.Is_Exist(LicenseID))
                    {
                        UpdateLicense.Update_International_Drive_License_To_NewLocalLicenseID(LicenseID, NewLicenseID);
                    }
                    LicenseManagement.Delete_Drive_License(LicenseID);
                    return true;
                }
                else
                {
                    //نعيد تفعيل الرخصة القديمة في حال حدوث خطا اثناء محاولة الاستبدال
                    LicenseManagement.Activate_Drive_License(LicenseID);
                    //

                    return false;
                }
            }
            else
            { 
            return false;
        }

            
          
        }


        public bool RenewalLocalLicense(int LicenseID, string  NewNote, ref int NewLicenseID)
        {
            drive_license_Information_Class LicenseInformation = new drive_license_Information_Class();
            drive_license_management LicenseManagement = new drive_license_management();
            international_drive_license_Information_Class SendNewLicenseID = new international_drive_license_Information_Class();
            international_drive_license_management InternationalLicenseManage = new international_drive_license_management();
            bool is_Valid = false;
            LicenseInformation = LicenseManagement.Get_License_Info_From_Licenses_By_LicenseID(LicenseID, ref is_Valid);

            if (is_Valid)
            {
               

                //نقوم بالغاء تفعيل هده الرخصة للتمكن من اضافة واحدة اخرى بنفس المعلومات
                LicenseManagement.deActivate_Drive_License(LicenseID);
                //

                NewLicenseID = -1;

                LicenseInformation.Comment = NewNote;
                LicenseInformation.Relese_Date = DateTime.Now;
                LicenseInformation.End_Date = DateTime.Now.AddYears(category_management.Get_Category_Validity_By_ID(LicenseInformation.Category_ID));

                if (LicenseManagement.Add_Drive_License(LicenseInformation, ref NewLicenseID))
                {
                    if (InternationalLicenseManage.Is_Exist(LicenseID))
                    {
                        InternationalLicenseManage.Delete_International_Drive_License(LicenseID);
                    }
                    LicenseManagement.Delete_Drive_License(LicenseID);
                    return true;
                }
                else
                {
                    //نعيد تفعيل الرخصة القديمة في حال حدوث خطا اثناء محاولة التجديد
                    LicenseManagement.Activate_Drive_License(LicenseID);
                    //

                    return false;
                }
            }
            else
            {
                return false;
            }



        }
        public bool AddNewLocalLicense(drive_license_Information_Class LicenseInformation,ref int  NewLicenseID)
        {
            drive_license_management LicenseManagement = new drive_license_management();

            if (LicenseManagement.Add_Drive_License(LicenseInformation, ref NewLicenseID))
            {
                return true;
            }

            return false;
            }


        public static bool RefreshExpiryLicenses()
        {
            drive_license_management.Refresh_The_Expiry_International_Licenses();


            return drive_license_management.Refresh_The_Expiry_Local_Licenses();
        }

    }
}
