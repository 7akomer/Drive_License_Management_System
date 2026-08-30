using Driver_License_System__Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System_DAL
{
    public class user_management

    {





        private static string connectionString = get_connectionString.connectionString;


      
        public bool Add_user(user_Information_Class new_user)
        {

            bool is_valid = false;
            string PassWord = HashPassword(new_user.userPassword);

            SqlConnection connection = new SqlConnection(connectionString);


            string query = @"insert into users values (@userName,@people_ID,@userPassword,@is_Admin)";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userName", new_user.userName);
            command.Parameters.AddWithValue("@userPassword", PassWord);
            command.Parameters.AddWithValue("@people_ID", new_user.people_ID);
            command.Parameters.AddWithValue("@is_Admin", new_user.is_Admin);


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

                is_valid = true;

            }
            catch (Exception ex)
            {

                is_valid = false;
                //Console.WriteLine(ex.ToString());
            }

            finally
            {
                connection.Close();
            }


            return is_valid;

        }




        public bool Update_userName(user_Information_Class update_userName)
        {

            bool is_valid = false;


            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"update users set userName = @userName
                                     where userID = @user_ID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@user_ID", update_userName.user_ID);
            command.Parameters.AddWithValue("@userName", update_userName.userName);

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

        public bool Update_user_Permission(user_Information_Class update_Permission)
        {

            bool is_valid = false;


            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"update users set is_Admin = @is_Admin
                                     where userID = @user_ID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@user_ID", update_Permission.user_ID);
            command.Parameters.AddWithValue("@is_Admin", update_Permission.is_Admin);

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




        public bool Delete_user(int userID)
        {
            bool is_valid = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"delete from users where userID = @userID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userID", userID);


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
                // Console.WriteLine(ex.ToString());
                is_valid = false;
            }

            finally { connection.Close(); }

            return is_valid;


        }




        public List<Person_Information_class> Get_Users_List(int WhoIsCurrentUser)
        {

            List<Person_Information_class> user_list = new List<Person_Information_class>();



            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"SELECT users.userID, users.userName, users.is_Admin, peoples.*, country_list.country_name FROM     country_list INNER JOIN   peoples ON country_list.country_ID = peoples.nationality_ID INNER JOIN     users ON peoples.people_ID = users.people_ID  where is_Admin = 0 or userID = @UserID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", WhoIsCurrentUser);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Person_Information_class user = new Person_Information_class();

                    user.UserName = (string)reader["userName"];
                    user.Person_ID = (int)reader["people_ID"];
                    user.Is_Supper_Admin = (bool)reader["is_Admin"];
                    user.National_ID = (string)reader["national_ID"];
                    user.LastName = (string)reader["last_name"];
                      user  .FirstName = (string)reader["first_name"];
                    user.SecondName = reader["second_name"] as string;
                    user.ThirdName = reader["third_name"] as string;
                    user.Date_Of_Birth = (DateTime)reader["date_of_birth"];
                    user.Personal_Photo = (string)reader["personal_photo"];
                    user.country_name = (string)reader["country_name"];
                    user.Gender = (string)reader["Gender"];
                    user.UserID = (int)reader["userID"];




                    user_list.Add(user);

                }


            }
          
            finally { connection.Close(); }


            return user_list;
        }

        public Person_Information_class Get_Current_User_Information(int WhoIsCurrentUser)
        {




            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"SELECT users.userID, users.userName, users.is_Admin, peoples.*, country_list.country_name FROM     country_list INNER JOIN   peoples ON country_list.country_ID = peoples.nationality_ID INNER JOIN     users ON peoples.people_ID = users.people_ID  where users.userID = @UserID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", WhoIsCurrentUser);

            Person_Information_class user = new Person_Information_class();

            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    user.UserName = (string)reader["userName"];
                    user.Person_ID = (int)reader["people_ID"];
                    user.Is_Supper_Admin = (bool)reader["is_Admin"];
                    user.National_ID = (string)reader["national_ID"];
                    user.LastName = (string)reader["last_name"];
                    user.FirstName = (string)reader["first_name"];
                    user.SecondName = reader["second_name"] as string;
                    user.ThirdName = reader["third_name"] as string;
                    user.Date_Of_Birth = (DateTime)reader["date_of_birth"];
                    user.Personal_Photo = (string)reader["personal_photo"];
                    user.country_name = (string)reader["country_name"];
                    user.Gender = (string)reader["Gender"];
                    user.UserID = (int)reader["userID"];





                }


            }

            finally { connection.Close(); }


            return user;
        }



        public static user_Information_Class Get_user_By_userName(string userName)
        {
            user_Information_Class user = new user_Information_Class();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"select userName,people_ID,is_Admin from users where userName = @userName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userName", userName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    user.userName = (string)reader["userName"];
                    user.people_ID = (int)reader["people_ID"];
                    user.is_Admin = (bool)reader["is_Admin"];

                }
            }
          
            finally { connection.Close(); }

            return user;

        }

        public static user_Information_Class Get_Current_user_By_userName(string userName)
        {
            user_Information_Class user = new user_Information_Class();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"SELECT users.userID, users.userName, users.is_Admin,peoples.people_ID, peoples.personal_photo
FROM     users INNER JOIN
                  peoples ON users.people_ID = peoples.people_ID

where users.userName = @userName";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userName", userName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    user.user_ID = (int)reader["userID"];
                    user.userName = (string)reader["userName"];
                    user.people_ID = (int)reader["people_ID"];
                    user.is_Admin = (bool)reader["is_Admin"];
                    user.UserPhoto = (string)reader["personal_photo"];
                }
            }

            finally { connection.Close(); }

            return user;

        }



        public bool Authenticate_user(string userName, string password)
        {
            bool is_valid = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"select userPassword from users where userName = @userName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@userName", userName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string storedHash = (string)reader["userPassword"];
                    is_valid = VerifyPassword(password, storedHash);
                }
            }
            catch (Exception ex)
            {
                is_valid = false;
                // Console.WriteLine(ex.ToString());
            }
            finally { connection.Close(); }
            return is_valid;
        }
        private string HashPassword(string password)
        {
            return PasswordHasher.HashPassword(password);
        }
        private bool VerifyPassword(string password, string storedHash)
        {
            return PasswordHasher.VerifyPassword(password, storedHash);
        }


        public bool Update_Password(user_Information_Class new_Info)

        {

            bool is_Valid = false;
            string New_Password = HashPassword(new_Info.userPassword);


            SqlConnection connection = new SqlConnection(connectionString);


            string query = $"update users set userPassword = @userPassword where userName = @userName";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@userPassword", New_Password);

            command.Parameters.AddWithValue("@userName", new_Info.userName);

            try
            {
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    is_Valid = true;
                }



            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                //Console.WriteLine("error logic")

            }



            finally { connection.Close(); }




            return is_Valid;
        }


        public static bool If_UserName_Exist(string UserName)
        {
            bool is_reserved = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"select 1 from users where userName  = @UserName";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            try
            {
                connection.Open();
                object count = command.ExecuteScalar();
                if (count != null)
                {
                    is_reserved = true;
                }
                else
                {
                    is_reserved = false;
                }
            }
         
            finally { connection.Close(); }

            return is_reserved;
        }

        public static bool If_ThisPersonIsUser(int PersonID)
        {
            bool is_reserved = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"select 1 from users where people_ID  = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                object count = command.ExecuteScalar();
                if (count != null)
                {
                    is_reserved = true;
                }
                else
                {
                    is_reserved = false;
                }
            }

            finally { connection.Close(); }

            return is_reserved;
        }

    }

}
