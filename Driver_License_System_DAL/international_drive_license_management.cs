using Driver_License_System__Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System_DAL
{
    public class international_drive_license_management
    {
        private static string connectionString = get_connectionString.connectionString;

        public List<international_drive_license_Information_Class> Get_International_Drive_License_List(ref bool is_Valid)
        {
            is_Valid = false;

            List<international_drive_license_Information_Class> Get_Information = new List<international_drive_license_Information_Class>();

            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from license_info";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    international_drive_license_Information_Class license_Info = new international_drive_license_Information_Class();
                    license_Info.International_Drive_License_ID = (int)reader["license_ID"];
                    license_Info.Drive_License_ID = (int)reader["drive_license_ID"];
                    license_Info.Relese_Date = (DateTime)reader["relese_date"];
                    license_Info.End_Date = (DateTime)reader["end_date"];
                    license_Info.Category_Name = (string)reader["category_name"];

                    license_Info.person_ID = (int)reader["people_ID"];
                    license_Info.First_Name = (string)reader["first_name"];
                    license_Info.Last_Name = (string)reader["last_name"];
                    license_Info.Personal_Photo = (string)reader["personal_photo"];
                    license_Info.Is_Active = (bool)reader["is_active"];
                    license_Info.National_ID = (string)reader["national_id"];


                    Get_Information.Add(license_Info);

                    is_Valid = true;
                }
            }
            catch (Exception ex)
            {
                is_Valid = false;
                Console.WriteLine(ex);
            }
            finally { connection.Close(); }

            return Get_Information;
        }

        public List<international_drive_license_Information_Class> Find_By_NationalID(string National_ID, ref bool is_Valid)
        {
            is_Valid = false;

            international_drive_license_Information_Class license_Info = new international_drive_license_Information_Class();
            List<international_drive_license_Information_Class> NewList  = new List<international_drive_license_Information_Class> ();

            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from license_info where national_id like @national_ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@national_ID", $"%{National_ID}%");

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    license_Info.International_Drive_License_ID = (int)reader["Locallicense_ID"];
                    license_Info.Drive_License_ID = (int)reader["drive_license_ID"];
                    license_Info.Relese_Date = (DateTime)reader["relese_date"];
                    license_Info.End_Date = (DateTime)reader["end_date"];
                    license_Info.Category_Name = (string)reader["category_name"];

                    license_Info.person_ID = (int)reader["people_ID"];
                    license_Info.First_Name = (string)reader["first_name"];
                    license_Info.Last_Name = (string)reader["last_name"];
                    license_Info.Personal_Photo = (string)reader["personal_photo"];
                    license_Info.Is_Active = (bool)reader["is_active"];
                    license_Info.National_ID = (string)reader["national_id"];

                    NewList.Add(license_Info);

                    is_Valid = true;
                }
            }
            catch (Exception ex)
            {
                is_Valid = false;
                Console.WriteLine(ex);
            }
            finally { connection.Close(); }

            return NewList;
        }

        public List< international_drive_license_Information_Class> Find_By_FirstName(string firstName, ref bool is_Valid)
        {
            is_Valid = false;

            international_drive_license_Information_Class license_Info = new international_drive_license_Information_Class();
            List<international_drive_license_Information_Class> NewList = new List<international_drive_license_Information_Class> ();

            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from license_info where first_name like @first_name";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@first_name", $"%{firstName}%");

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    license_Info.International_Drive_License_ID = (int)reader["Locallicense_ID"];
                    license_Info.Drive_License_ID = (int)reader["drive_license_ID"];
                    license_Info.Relese_Date = (DateTime)reader["relese_date"];
                    license_Info.End_Date = (DateTime)reader["end_date"];
                    license_Info.Category_Name = (string)reader["category_name"];

                    license_Info.person_ID = (int)reader["people_ID"];
                    license_Info.First_Name = (string)reader["first_name"];
                    license_Info.Last_Name = (string)reader["last_name"];
                    license_Info.Personal_Photo = (string)reader["personal_photo"];
                    license_Info.Is_Active = (bool)reader["is_active"];
                    license_Info.National_ID = (string)reader["national_id"];


                    NewList.Add(license_Info);
                    is_Valid = true;
                }
            }
            catch (Exception ex)
            {
                is_Valid = false;
                Console.WriteLine(ex);
            }
            finally { connection.Close(); }

            return NewList;
        }

        public bool Add_International_Drive_License(international_drive_license_Information_Class new_International_Drive_License)
        {
            bool is_valid = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"insert into international_driving_license (relese_date,end_date,drive_license_ID) values (@relese_date,@end_date,@drive_license_ID)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@relese_date", new_International_Drive_License.Relese_Date);
            command.Parameters.AddWithValue("@end_date", new_International_Drive_License.End_Date);
            command.Parameters.AddWithValue("@drive_license_ID", new_International_Drive_License.Drive_License_ID);


            try
            {
                connection.Open();

                int rowAffected = command.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    is_valid = true;
                }
                else
                {
                    is_valid = false;
                }
            }
            catch (SqlException ex)
            {
                is_valid = false;
                Console.WriteLine(ex.ToString());
            }
            finally { connection.Close(); }

            return is_valid;
        }

        public bool Activate_International_Drive_License(int license_ID)
        {
            bool is_valid = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"update international_driving_license set is_active = 1 where Locallicense_ID = @Locallicense_ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Locallicense_ID", license_ID);
            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    is_valid = true;
                }
                else
                {
                    is_valid = false;
                }
            }
            catch (SqlException ex)
            {
                is_valid = false;
                Console.WriteLine(ex.ToString());
            }
            finally { connection.Close(); }
            return is_valid;


        }

        public bool deActivate_International_Drive_License(int license_ID)
        {
            bool is_valid = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"update international_driving_license set is_active = 0 where Locallicense_ID = @Locallicense_ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Locallicense_ID", license_ID);
            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    is_valid = true;
                }
                else
                {
                    is_valid = false;
                }
            }
            catch (SqlException ex)
            {
                is_valid = false;
                Console.WriteLine(ex.ToString());
            }
            finally { connection.Close(); }
            return is_valid;


        }


        public bool Delete_International_Drive_License(int Locallicense_ID)
        {
            bool is_valid = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"delete from international_driving_license where drive_license_ID = @Locallicense_ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Locallicense_ID", Locallicense_ID);
            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    is_valid = true;
                }
                else
                {
                    is_valid = false;
                }
            }
            catch (SqlException ex)
            {
                is_valid = false;
                Console.WriteLine(ex.ToString());
            }
            finally { connection.Close(); }
            return is_valid;

        }

        public bool Is_Exist(int Drive_License_ID)
        {
            bool is_reserved = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"select 1 from international_driving_license where drive_license_ID = @drive_license_ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@drive_license_ID", Drive_License_ID);
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


        public bool Update_International_Drive_License_To_NewLocalLicenseID(int OldLocalLicenseID,int NewLocalLicenseID)
        {

            bool is_valid = false;


            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"update international_driving_license set drive_license_ID = @drive_license_ID
                               
                                     where drive_license_ID = @Locallicense_ID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@Locallicense_ID", OldLocalLicenseID);
            command.Parameters.AddWithValue("@drive_license_ID", NewLocalLicenseID);
           
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




    }
}
