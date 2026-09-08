using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver_License_System__Models;
using Driver_License_System_DAL;

namespace Driver_License_System_BLL
{
    public class cls_Categorys
    {

        public List<category_Information_Class> Get_Categorys_List()
        {


            category_management New_Management = new category_management();
            List<category_Information_Class> New_Information = new List<category_Information_Class>();

            bool is_Valid = false;

            New_Information = New_Management.Get_Category_List(ref is_Valid);

            if (is_Valid)
            {
                return New_Information;
            }



            return null;
        }

        public bool Update_Category(category_Information_Class NewInfo)
        {


            category_management new_Management = new category_management();

           if( new_Management.Update_Category(NewInfo))
            {
                return true;
            }


            return false;
        }

        public category_Information_Class Get_Category_PriceAndRequiredAge_By_ID(int ID)
        {
            category_Information_Class GetInfo = new category_Information_Class();
            category_management new_Management = new category_management();
            bool is_Valid = false;

            GetInfo = new_Management.Get_Category_PriceAndRequiredAge_By_ID(ID,ref is_Valid);

            if (is_Valid)
            {
                return GetInfo;
            }

            return null;
        }

        public List<string> Get_List_Of_Categorys_Name()
        {
            List<string> list = new List<string>();
            category_management NewManagement = new category_management();

            list = NewManagement.Get_List_Of_Categorys_Name();
            if(list.Count > 0)
            {
                return list;
            }
            return null;
        }

        public static int Get_Category_Validity_By_CategoryID(int CategoryID)
        {

            return category_management.Get_Category_Validity_By_ID(CategoryID);
        }

    }
}
