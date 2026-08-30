using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver_License_System__Models;

namespace Driver_License_System_DAL
{
    public class people_management
    {
        public people_management()
        {

        }





        private static string connectionString = get_connectionString.connectionString;

        public bool Add_Person(Person_Information_class new_person)
        {

            bool is_valid = false;

            SqlConnection connection = new SqlConnection(connectionString);


            string query = @"insert into peoples values (@nationality_ID,@first_name,@second_name,@third_name,@last_name,@date_of_birth,@email,@phone_number,@_address,@personal_photo,@national_ID,@Gender)";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@nationality_ID", new_person.Nationality_ID);
            command.Parameters.AddWithValue("@first_name", new_person.FirstName);
            command.Parameters.AddWithValue("@second_name", new_person.SecondName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@third_name", new_person.ThirdName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@last_name", new_person.LastName);
            command.Parameters.AddWithValue("@date_of_birth", new_person.Date_Of_Birth);
            command.Parameters.AddWithValue("@email", new_person.Email);
            command.Parameters.AddWithValue("@phone_number", new_person.PhoneNumber);
            command.Parameters.AddWithValue("@_address", new_person.Address ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@personal_photo", new_person.Personal_Photo);
            command.Parameters.AddWithValue("@national_ID", new_person.National_ID);
            command.Parameters.AddWithValue("@Gender", new_person.Gender);

            try
            {
                connection.Open();

                int rowAffected = command.ExecuteNonQuery();


                if (rowAffected > 0)
                {
                    // Console.WriteLine("Person added successfully.");
                    is_valid = true;
                }
                else
                {
                    // Console.WriteLine("Failed to add the person.");
                    is_valid = false;
                }


            }
           

            finally { connection.Close(); }


            return is_valid;

        }

        public bool Update_Person(Person_Information_class update_person)
        {

            bool is_valid = false;


            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"update peoples set nationality_ID = @nationality_ID,
                               first_name = @first_name,second_name = @second_name,third_name = @third_name,
                                last_name = @last_name,date_of_birth = @date_of_birth,email = @email ,phone_number = @phone_number,
                                 _address = @address,personal_photo = @personal_photo,national_ID = @national_ID ,Gender = @Gender
                                     where people_ID = @people_ID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@people_ID", update_person.Person_ID);
            command.Parameters.AddWithValue("@nationality_ID", update_person.Nationality_ID);
            command.Parameters.AddWithValue("@first_name", update_person.FirstName);
            command.Parameters.AddWithValue("@second_name", update_person.SecondName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@third_name", update_person.ThirdName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@last_name", update_person.LastName);
            command.Parameters.AddWithValue("@date_of_birth", update_person.Date_Of_Birth);
            command.Parameters.AddWithValue("@email", update_person.Email);
            command.Parameters.AddWithValue("@phone_number", update_person.PhoneNumber);
            command.Parameters.AddWithValue("@address", update_person.Address ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@national_ID", update_person.National_ID);
            command.Parameters.AddWithValue("@personal_photo", update_person.Personal_Photo);
            command.Parameters.AddWithValue("@Gender", update_person.Gender);


            try
            {

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    is_valid = true;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            finally { connection.Close(); }

            return is_valid;
        }

        public bool Delete_Person(int people_ID)
        {
            bool is_valid = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"delete from peoples where people_ID = @people_ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@people_ID", people_ID);


            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    is_valid = true;
                }
            }
           

            finally { connection.Close(); }

            return is_valid;


        }

        private List<Person_Information_class> Find_People_Access(string information, string column_name, ref bool is_valid)
        {

            List<Person_Information_class> people_list = new List<Person_Information_class>();



            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from People_Information where {column_name} like @column";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@column", $"%{information}%");

            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Person_Information_class person = new Person_Information_class();
                    person.Person_ID = (int)reader["people_ID"];
                    person.National_ID = (string)reader["national_ID"];
                    person.LastName = (string)reader["last_name"];
                    person.FirstName = (string)reader["first_name"];
                    person.SecondName = reader["second_name"] as string;
                    person.ThirdName = reader["third_name"] as string;
                    person.Date_Of_Birth = (DateTime)reader["date_of_birth"];
                    person.Email = (string)reader["email"];
                    person.PhoneNumber = (string)reader["phone_number"];
                    person.Address = reader["_address"] as string;
                    person.Personal_Photo = (string)reader["personal_photo"];
                    person.country_name = (string)reader["country_name"];
                    person.Personal_Photo = (string)reader["personal_photo"];
                    person.Gender = (string)reader["Gender"];

                    people_list.Add(person);

                    is_valid = true;
                }


            }
           

            finally { connection.Close(); }



            return people_list;
        }


        public List<Person_Information_class> Find_People_s(string information, Person_Information_class.Find_By_What what, ref bool is_valid)
        {
            string column_name = "";

            switch (what)
            {
                case Person_Information_class.Find_By_What.By_PeopleID:
                    column_name = "people_ID";
                    break;

                case Person_Information_class.Find_By_What.By_FirstName:
                    column_name = "first_name";
                    break;

                case Person_Information_class.Find_By_What.By_SecondName:
                    column_name = "second_name";
                    break;

                case Person_Information_class.Find_By_What.By_TirdName:
                    column_name = "third_name";
                    break;

                case Person_Information_class.Find_By_What.By_LastName:
                    column_name = "last_name";
                    break;

                case Person_Information_class.Find_By_What.By_PhoneNumber:
                    column_name = "phone_number";
                    break;

                case Person_Information_class.Find_By_What.By_Email:
                    column_name = "email";
                    break;

                case Person_Information_class.Find_By_What.By_National_ID:
                    column_name = "national_ID";
                    break;

                case Person_Information_class.Find_By_What.By_Country:
                    column_name = "country_name";
                    break;

                case Person_Information_class.Find_By_What.By_Address:
                    column_name = "_address";
                    break;

                case Person_Information_class.Find_By_What.By_BirthDate:
                    column_name = "date_of_birth";
                    break;

                default:
                    throw new ArgumentException("Invalid search type.");
            }

            return Find_People_Access(information, column_name, ref is_valid);



        }

        public List<Person_Information_class> Get_People_List(ref bool is_valid)
        {
            List<Person_Information_class> people_list = new List<Person_Information_class>();
            is_valid = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from People_Information";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Person_Information_class person = new Person_Information_class();
                    person.Person_ID = (int)reader["people_ID"];
                    person.National_ID = (string)reader["national_ID"];
                    person.LastName = (string)reader["last_name"];
                    person.FirstName = (string)reader["first_name"];
                    person.SecondName = reader["second_name"] as string;
                    person.ThirdName = reader["third_name"] as string;
                    person.Date_Of_Birth = (DateTime)reader["date_of_birth"];
                    person.Email = (string)reader["email"];
                    person.PhoneNumber = (string)reader["phone_number"];
                    person.Address = reader["_address"] as string;
                    person.Personal_Photo = (string)reader["personal_photo"];
                    person.country_name = (string)reader["country_name"];
                    person.Gender = (string)reader["Gender"];

                    people_list.Add(person);
                    is_valid = true;
                }
            }
           
            finally
            {
                connection.Close();
            }
            return people_list;



        }


        public bool CheakThisInfoExist(string information, Person_Information_class.Find_By_What what, ref bool is_valid, int ThisPersonID)
        {
            string column_name = "";

            switch (what)
            {
                case Person_Information_class.Find_By_What.By_PeopleID:
                    column_name = "people_ID";
                    break;

                case Person_Information_class.Find_By_What.By_FirstName:
                    column_name = "first_name";
                    break;

                case Person_Information_class.Find_By_What.By_SecondName:
                    column_name = "second_name";
                    break;

                case Person_Information_class.Find_By_What.By_TirdName:
                    column_name = "third_name";
                    break;

                case Person_Information_class.Find_By_What.By_LastName:
                    column_name = "last_name";
                    break;

                case Person_Information_class.Find_By_What.By_PhoneNumber:
                    column_name = "phone_number";
                    break;

                case Person_Information_class.Find_By_What.By_Email:
                    column_name = "email";
                    break;

                case Person_Information_class.Find_By_What.By_National_ID:
                    column_name = "national_ID";
                    break;

                case Person_Information_class.Find_By_What.By_Country:
                    column_name = "country_name";
                    break;

                case Person_Information_class.Find_By_What.By_Address:
                    column_name = "_address";
                    break;

                case Person_Information_class.Find_By_What.By_BirthDate:
                    column_name = "date_of_birth";
                    break;

                default:
                    throw new ArgumentException("Invalid search type.");
            }

            return CheakExistAccess(information, column_name, ref is_valid, ThisPersonID);



        }

        private bool CheakExistAccess(string information, string column_name, ref bool is_valid, int ThisPersonID)
        {

            List<Person_Information_class> people_list = new List<Person_Information_class>();


            is_valid = false;
            bool is_Exist = false;
            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select 1 from People_Information  where {column_name} = @information and people_ID <> @personID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@information", information);
            command.Parameters.AddWithValue("@personID", ThisPersonID);


            try
            {
                connection.Open();
                object count = command.ExecuteScalar();
                if (count != null)
                {
                    is_valid = true;
                    is_Exist = true;
                }
                else
                {
                    is_valid = true;
                    is_Exist = false;
                }



            }
            catch (Exception ex)
            {
                is_valid = false;
                Console.WriteLine(ex.ToString());
            }


            finally { connection.Close(); }

            return is_Exist;


        } 


            public Person_Information_class Get_Person_By_NationalID(string NationalID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from People_Information where national_ID = @NationalID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalID", NationalID);

            Person_Information_class person = new Person_Information_class();

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    person.Person_ID = (int)reader["people_ID"];
                    person.National_ID = (string)reader["national_ID"];
                    person.LastName = (string)reader["last_name"];
                    person.FirstName = (string)reader["first_name"];
                    person.SecondName = reader["second_name"] as string;
                    person.ThirdName = reader["third_name"] as string;
                    person.Date_Of_Birth = (DateTime)reader["date_of_birth"];
                    person.Email = (string)reader["email"];
                    person.PhoneNumber = (string)reader["phone_number"];
                    person.Address = reader["_address"] as string;
                    person.Personal_Photo = (string)reader["personal_photo"];
                    person.country_name = (string)reader["country_name"];
                    person.Gender = (string)reader["Gender"];

                }
            }

            finally
            {
                connection.Close();
            }
            return person;



        }

    }
    } 