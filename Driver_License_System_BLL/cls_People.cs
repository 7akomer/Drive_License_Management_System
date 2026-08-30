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
    public class cls_People
    {

      
        private enum WhatExistInfo
        {
            NationalID,
                PhoneNumber,
                Email,
                None


        }

        public int currentExistingInfo = (int)WhatExistInfo.None;


        public List<Person_Information_class> Get_People_List(ref bool isValid)
        {
            isValid = false;
            people_management AddManagement = new people_management();

            List<Person_Information_class> peopleList = AddManagement.Get_People_List(ref isValid);

            return peopleList;
        }

        public List<Person_Information_class> Get_Filtered_People_List(string searchText, Person_Information_class.Find_By_What FilterBy, ref bool isValid)
        {
            isValid = false;
            people_management AddManagement = new people_management();
            List<Person_Information_class> filteredPeopleList = AddManagement.Find_People_s(searchText, FilterBy, ref isValid);
            return filteredPeopleList;
        }

        public bool Update_Person_Information(Person_Information_class New_person_Info,ref bool isValid)
        {
           
                bool ErroreExiste = false;
            people_management UpdatePersonInformation = new people_management();

              if(  UpdatePersonInformation.CheakThisInfoExist(New_person_Info.National_ID, Person_Information_class.Find_By_What.By_National_ID, ref  isValid,New_person_Info.Person_ID))
            {
                ErroreExiste = true;
                currentExistingInfo = (int)WhatExistInfo.NationalID;
                return ErroreExiste;
            }
            else if (UpdatePersonInformation.CheakThisInfoExist(New_person_Info.PhoneNumber, Person_Information_class.Find_By_What.By_PhoneNumber, ref isValid, New_person_Info.Person_ID))
            {
                ErroreExiste = true;
                currentExistingInfo = (int)WhatExistInfo.PhoneNumber;
            }

            else if (UpdatePersonInformation.CheakThisInfoExist(New_person_Info.Email, Person_Information_class.Find_By_What.By_Email, ref isValid, New_person_Info.Person_ID))
            {
                ErroreExiste = true;
                currentExistingInfo = (int)WhatExistInfo.Email;
            }

            else
            {
                ErroreExiste = false;

                if (UpdatePersonInformation.Update_Person(New_person_Info))
                {
                    isValid = true;
                }
                else
                { isValid = false; }

            }

            
            

                return ErroreExiste;
            
        }


        public bool Add_New_Person(Person_Information_class New_person,ref bool isValid)
        {


            bool ErroreExiste = false;
            people_management NewPersonInfo = new people_management();

            if (NewPersonInfo.CheakThisInfoExist(New_person.National_ID, Person_Information_class.Find_By_What.By_National_ID, ref isValid,0))
            {
                ErroreExiste = true;
                currentExistingInfo = (int)WhatExistInfo.NationalID;
                return ErroreExiste;
            }
            else if (NewPersonInfo.CheakThisInfoExist(New_person.PhoneNumber, Person_Information_class.Find_By_What.By_PhoneNumber, ref isValid,0))
            {
                ErroreExiste = true;
                currentExistingInfo = (int)WhatExistInfo.PhoneNumber;
            }

            else if (NewPersonInfo.CheakThisInfoExist(New_person.Email, Person_Information_class.Find_By_What.By_Email, ref isValid,0))
            {
                ErroreExiste = true;
                currentExistingInfo = (int)WhatExistInfo.Email;
            }

            else
            {
                ErroreExiste = false;

                if (NewPersonInfo.Add_Person(New_person))
                {
                    isValid = true;
                }
                else
                { isValid = false; }


            }


            return ErroreExiste;



            
        }

        public Person_Information_class Get_Person_By_NationalID(string NationalID)
        {
            people_management NewManagement = new people_management();
            Person_Information_class PersonInfo = new Person_Information_class();

            PersonInfo =  NewManagement.Get_Person_By_NationalID (NationalID);

            return PersonInfo;
        }
    }
}
