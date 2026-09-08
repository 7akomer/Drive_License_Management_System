using Driver_License_System__Models;
using Driver_License_System_DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System_BLL
{
    public class cls_Users
    {

        enum AvilablePermission
        {
            StandardUser = 0,
            SuperAdmin = 1,
        }
        public List<Person_Information_class> Get_Users_List()
        {
            user_management NewManagement = new user_management();

            if (CurrentUserLogin.IsSuperAdmin == true)
            {
                return NewManagement.Get_Users_List(CurrentUserLogin.CurrentUserID);
            }
            else
            {
                List<Person_Information_class> NewInfo = new List<Person_Information_class>();

                NewInfo.Add(NewManagement.Get_Current_User_Information(CurrentUserLogin.CurrentUserID));

                    return NewInfo;
            }

            
        }

        public bool Update_User_Permission(user_Information_Class NewInfo)
        {
            user_management NewManagement = new user_management();


            return NewManagement.Update_user_Permission(NewInfo);
        }

        public bool Update_User_Name(user_Information_Class NewInfo)
        {
            user_management NewManagement = new user_management();

            

            return NewManagement.Update_userName(NewInfo);
        }



        public static user_Information_Class GetUserInfoByUserName(string userName)
        {
            return user_management.Get_user_By_userName(userName);
        }

        public static bool If_UserName_Exist(string UserName)
        {
            return user_management.If_UserName_Exist(UserName);
        }

        public bool AddNewUser(user_Information_Class NewUser)
        {
            user_management NewManagement = new user_management();

            if (CurrentUserLogin.IsSuperAdmin)
            {
                return NewManagement.Add_user(NewUser);

            }
            else
            {
                return false;

            }
        }


        public static bool If_ThisPersonIsUser(int PersonID)
        {
            return user_management.If_ThisPersonIsUser(PersonID);
        }

        public bool Authenticate_user(string UserName, string Password)
        {

            bool IsTheUser = false;

            if(Password.Length < 8)
            {
                return false;
            }
            else
            {
                user_management Authenticate_user = new user_management();
                user_Information_Class CurrentUserInfo = new user_Information_Class();

                if(Authenticate_user.Authenticate_user(UserName, Password)) 
                    {
                    IsTheUser = true;
                    CurrentUserInfo = user_management.Get_Current_user_By_userName(UserName);

                    CurrentUserLogin.CurrentUserID = CurrentUserInfo.user_ID;
                    CurrentUserLogin.CurrentUserName = CurrentUserInfo.userName;
                    CurrentUserLogin.IsSuperAdmin = CurrentUserInfo.is_Admin;
                    CurrentUserLogin.CurrentUserPhoto = CurrentUserInfo.UserPhoto;

                    }

            }

            return IsTheUser;
        }


        public bool Update_Password(user_Information_Class NewInfo)
        {

            user_management NewPassword = new user_management();
            NewInfo.userName = CurrentUserLogin.CurrentUserName;

            if (NewInfo.userPassword.Length < 8)
            {
                return false;
            }

            else
            {
                return NewPassword.Update_Password(NewInfo);
            }

        }


    }
}
