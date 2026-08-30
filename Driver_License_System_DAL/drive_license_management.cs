using Driver_License_System__Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System_DAL
{
    public class drive_license_management
    {

        private static string connectionString = get_connectionString.connectionString;

        public List<drive_license_Information_Class> Find_By_NationalID(string national_ID, ref bool is_Valid)
        {
            is_Valid = false;

            List< drive_license_Information_Class > NewManagement = new List<drive_license_Information_Class>();

            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from local_license_info where national_id like @national_ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@national_ID", $"%{national_ID}%");

            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    drive_license_Information_Class license_Info = new drive_license_Information_Class();

                    license_Info.Drive_License_ID = (int)reader["drive_license_ID"];
                    license_Info.Driver_ID = (int)reader["driver_ID"];
                    license_Info.Category_Name = (string)reader["category_name"];
                    license_Info.Comment = reader["comments"] as string;
                    license_Info.Relese_Date = (DateTime)reader["relese_date"];
                    license_Info.End_Date = (DateTime)reader["end_date"];
                    license_Info.person_ID = (int)reader["people_ID"];
                    license_Info.First_Name = (string)reader["first_name"];
                    license_Info.Last_Name = (string)reader["last_name"];
                    license_Info.Personal_Photo = (string)reader["personal_photo"];
                    license_Info.Is_Active = (bool)reader["is_active"];
                    license_Info.National_ID = (string)reader["national_id"];

                    NewManagement.Add(license_Info);

                    is_Valid = true;

                }


            }



            catch (Exception ex)
            {
                is_Valid = false;
                Console.WriteLine(ex);
            }

            finally { connection.Close(); }




            return NewManagement;
        }

        public static int GetNumberOfExpiry_Licenses()
        {
            int count = 0;

            SqlConnection connection = new SqlConnection(connectionString);

            string quiry = "select count(*) from drive_licenses where end_date < GETDATE() ";

            SqlCommand command = new SqlCommand(quiry, connection);

            try
            {
                connection.Open();

                count = (int)command.ExecuteScalar();
            }
            finally
            {
                connection.Close();
            }

            return count;
        }

        public int GetNumberOfIssue_Licenses_Today()
        {
            int count = 0;

            SqlConnection connection = new SqlConnection(connectionString);

            string quiry = "select count(*) from drive_licenses where  relese_date = @relese_date ";

            SqlCommand command = new SqlCommand(quiry, connection);
            command.Parameters.AddWithValue("@relese_date", DateTime.Today);

            try
            {
                connection.Open();

                count = (int)command.ExecuteScalar();
            }
            finally
            {
                connection.Close();
            }

            return count;
        }


        public int GetNumberOfIssue_Licenses_Yasterday()
        {
            int count = 0;

            SqlConnection connection = new SqlConnection(connectionString);

            string quiry = "select count(*) from drive_licenses where relese_date = @relese_date ";

            SqlCommand command = new SqlCommand(quiry, connection);
            command.Parameters.AddWithValue("@relese_date", DateTime.Today.AddDays(-1));

            try
            {
                connection.Open();

                count = (int)command.ExecuteScalar();
            }
            finally
            {
                connection.Close();
            }

            return count;
        }

        public int GetNumberOfIssue_Licenses()
        {
            int count = 0;

            SqlConnection connection = new SqlConnection(connectionString);

            string quiry = "select count(*) from drive_licenses ";

            SqlCommand command = new SqlCommand(quiry, connection);

            try
            {
                connection.Open();

                count = (int)command.ExecuteScalar();
            }
            finally
            {
                connection.Close();
            }

            return count;
        }


        public static int  GetNumberOfActive_Licenses()
        {
            int count = 0;

            SqlConnection connection = new SqlConnection(connectionString);

            string quiry = "select count(*) from drive_licenses where is_active = 1 ";

            SqlCommand command = new SqlCommand(quiry, connection);

            try
            {
                connection.Open();

                count = (int)command.ExecuteScalar();
            }
            finally
            {
                connection.Close();
            }

            return count;
        }




        public List<drive_license_Information_Class> Find_By_FirstName(string firstName, ref bool is_Valid)
        {
            is_Valid = false;

            List<drive_license_Information_Class> NewManagement = new List<drive_license_Information_Class>();

            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from local_license_info where first_name like @firstname";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@firstname", $"%{firstName}%");

            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    drive_license_Information_Class license_Info = new drive_license_Information_Class();

                    license_Info.Drive_License_ID = (int)reader["drive_license_ID"];
                    license_Info.Driver_ID = (int)reader["driver_ID"];
                    license_Info.Category_Name = (string)reader["category_name"];
                    license_Info.Comment = reader["comments"] as string;
                    license_Info.Relese_Date = (DateTime)reader["relese_date"];
                    license_Info.End_Date = (DateTime)reader["end_date"];
                    license_Info.person_ID = (int)reader["people_ID"];
                    license_Info.First_Name = (string)reader["first_name"];
                    license_Info.Last_Name = (string)reader["last_name"];
                    license_Info.Personal_Photo = (string)reader["personal_photo"];
                    license_Info.Is_Active = (bool)reader["is_active"];
                    license_Info.National_ID = (string)reader["national_id"];

                    NewManagement.Add(license_Info);

                    is_Valid = true;

                }


            }



            catch (Exception ex)
            {
                is_Valid = false;
                Console.WriteLine(ex);
            }

            finally { connection.Close(); }




            return NewManagement;
        }


        public List<drive_license_Information_Class> Get_Drive_License_List(ref bool is_Valid)
        {
            is_Valid = false;

            List<drive_license_Information_Class> Get_Information = new List<drive_license_Information_Class>();


            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from local_license_info";

            SqlCommand command = new SqlCommand(query, connection);


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    drive_license_Information_Class license_Info = new drive_license_Information_Class();
                    license_Info.Drive_License_ID = (int)reader["drive_license_ID"];
                    license_Info.Driver_ID = (int)reader["driver_ID"];
                    license_Info.Category_Name = (string)reader["category_name"];
                    license_Info.Comment = reader["comments"] as string;
                    license_Info.Relese_Date = (DateTime)reader["relese_date"];
                    license_Info.End_Date = (DateTime)reader["end_date"];
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


        public List<drive_license_Information_Class> Get_Expiry_Licenses_List(ref bool is_Valid)
        {
            is_Valid = false;

            List<drive_license_Information_Class> Get_Information = new List<drive_license_Information_Class>();


            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from local_license_info where end_date < GETDATE()";

            SqlCommand command = new SqlCommand(query, connection);


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    drive_license_Information_Class license_Info = new drive_license_Information_Class();
                    license_Info.Drive_License_ID = (int)reader["drive_license_ID"];
                    license_Info.Driver_ID = (int)reader["driver_ID"];
                    license_Info.Category_Name = (string)reader["category_name"];
                    license_Info.Comment = reader["comments"] as string;
                    license_Info.Relese_Date = (DateTime)reader["relese_date"];
                    license_Info.End_Date = (DateTime)reader["end_date"];
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

          

            finally { connection.Close(); }




            return Get_Information;
        }




        public List<drive_license_Information_Class> Get_Top7_Expiry_Licenses(ref bool is_Valid)
        {
            is_Valid = false;

            List<drive_license_Information_Class> Get_Information = new List<drive_license_Information_Class>();


            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select top 7 * from local_license_info where end_date < GETDATE()";

            SqlCommand command = new SqlCommand(query, connection);


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    drive_license_Information_Class license_Info = new drive_license_Information_Class();
                    license_Info.Drive_License_ID = (int)reader["drive_license_ID"];
                    license_Info.Driver_ID = (int)reader["driver_ID"];
                    license_Info.Category_Name = (string)reader["category_name"];
                    license_Info.Comment = reader["comments"] as string;
                    license_Info.Relese_Date = (DateTime)reader["relese_date"];
                    license_Info.End_Date = (DateTime)reader["end_date"];
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



            finally { connection.Close(); }




            return Get_Information;
        }


        public List<drive_license_Information_Class> Find_ExpiryLicenses_By_FirstName(string firstName, ref bool is_Valid)
        {
            is_Valid = false;

            List<drive_license_Information_Class> NewManagement = new List<drive_license_Information_Class>();

            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from local_license_info where first_name like @firstname and end_date < GETDATE()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@firstname", $"%{firstName}%");

            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    drive_license_Information_Class license_Info = new drive_license_Information_Class();

                    license_Info.Drive_License_ID = (int)reader["drive_license_ID"];
                    license_Info.Driver_ID = (int)reader["driver_ID"];
                    license_Info.Category_Name = (string)reader["category_name"];
                    license_Info.Comment = reader["comments"] as string;
                    license_Info.Relese_Date = (DateTime)reader["relese_date"];
                    license_Info.End_Date = (DateTime)reader["end_date"];
                    license_Info.person_ID = (int)reader["people_ID"];
                    license_Info.First_Name = (string)reader["first_name"];
                    license_Info.Last_Name = (string)reader["last_name"];
                    license_Info.Personal_Photo = (string)reader["personal_photo"];
                    license_Info.Is_Active = (bool)reader["is_active"];
                    license_Info.National_ID = (string)reader["national_id"];

                    NewManagement.Add(license_Info);

                    is_Valid = true;

                }


            }



            catch (Exception ex)
            {
                is_Valid = false;
                Console.WriteLine(ex);
            }

            finally { connection.Close(); }




            return NewManagement;
        }


        public List<drive_license_Information_Class> Find_ExpiryLicense_By_NationalID(string national_ID, ref bool is_Valid)
        {
            is_Valid = false;

            List<drive_license_Information_Class> NewManagement = new List<drive_license_Information_Class>();

            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from local_license_info where national_id like @national_ID and end_date < GETDATE()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@national_ID", $"%{national_ID}%");

            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    drive_license_Information_Class license_Info = new drive_license_Information_Class();

                    license_Info.Drive_License_ID = (int)reader["drive_license_ID"];
                    license_Info.Driver_ID = (int)reader["driver_ID"];
                    license_Info.Category_Name = (string)reader["category_name"];
                    license_Info.Comment = reader["comments"] as string;
                    license_Info.Relese_Date = (DateTime)reader["relese_date"];
                    license_Info.End_Date = (DateTime)reader["end_date"];
                    license_Info.person_ID = (int)reader["people_ID"];
                    license_Info.First_Name = (string)reader["first_name"];
                    license_Info.Last_Name = (string)reader["last_name"];
                    license_Info.Personal_Photo = (string)reader["personal_photo"];
                    license_Info.Is_Active = (bool)reader["is_active"];
                    license_Info.National_ID = (string)reader["national_id"];

                    NewManagement.Add(license_Info);

                    is_Valid = true;

                }


            }



            catch (Exception ex)
            {
                is_Valid = false;
                Console.WriteLine(ex);
            }

            finally { connection.Close(); }




            return NewManagement;
        }





        public bool Add_Drive_License(drive_license_Information_Class new_Drive_License,ref int NewID)
        {

            bool is_valid = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"insert into drive_licenses (driver_ID,category_ID,comments,relese_date,end_date) 
values (@driver_ID,@category_ID,@comments,@relese_date,@end_date);

select cast(@@IDENTITY AS INT);";
            

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@driver_ID", new_Drive_License.Driver_ID);
            command.Parameters.AddWithValue("@category_ID", new_Drive_License.Category_ID);
            command.Parameters.AddWithValue("@comments", (object)new_Drive_License.Comment ?? DBNull.Value);
            command.Parameters.AddWithValue("@relese_date", new_Drive_License.Relese_Date);
            command.Parameters.AddWithValue("@end_date", new_Drive_License.End_Date);


            try
            {


                connection.Open();

                object value = command.ExecuteScalar();
                NewID = Convert.ToInt32(value);

                is_valid = true;



            }



            finally { connection.Close(); }


            return is_valid;
        }


        public bool Delete_Drive_License(int Drive_License_ID)
        {
            bool is_valid = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"delete from drive_licenses where drive_license_ID = @drive_license_ID";


            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@drive_license_ID", Drive_License_ID);
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


        public bool Activate_Drive_License(int license_ID)
        {
            bool is_valid = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"update drive_licenses set is_active = 1 where drive_license_ID = @license_ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@license_ID", license_ID);
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

        public static bool Refresh_The_Expiry_Local_Licenses()
        {
            bool WeHaveExpiryLicense = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"update drive_licenses set is_active = 0 where end_date < GETDATE()";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    WeHaveExpiryLicense = true;
                }
                else
                {
                    WeHaveExpiryLicense = false;
                }

            }
           
            finally { connection.Close(); }

            return WeHaveExpiryLicense;


        }

        public static void Refresh_The_Expiry_International_Licenses()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"update international_driving_license set is_active = 0 where end_date < GETDATE()";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();

            }

            finally { connection.Close(); }


        }

        public bool deActivate_Drive_License(int license_ID)
        {
            bool is_valid = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"update drive_licenses set is_active = 0 where drive_license_ID = @license_ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@license_ID", license_ID);
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

        public bool Is_Exist(int Person_ID, ref bool is_Valid)
        {
            is_Valid = false;
            bool is_reserved = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"select 1 from drive_licenses where people_ID = @people_ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@people_ID", Person_ID);
            try
            {
                connection.Open();
                object count = command.ExecuteScalar();
                if (count != null)
                {
                    is_Valid = true;
                    is_reserved = true;
                }
                else
                {
                    is_Valid = true;
                    is_reserved = false;
                }
            }
            catch (Exception ex)
            {
                is_Valid = false;
                Console.WriteLine(ex.ToString());
            }
            finally { connection.Close(); }

            return is_reserved;
        }


        public drive_license_Information_Class Get_License_By_LicenseID(int LicenseID,ref bool is_Valid)
        {
            is_Valid = false;

            drive_license_Information_Class license_Info = new drive_license_Information_Class();


            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from local_license_info where drive_license_ID = @drive_license_ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@drive_license_ID", LicenseID);

            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    license_Info.Drive_License_ID = (int)reader["drive_license_ID"];
                    license_Info.Driver_ID = (int)reader["driver_ID"];
                    license_Info.Category_Name = (string)reader["category_name"];
                    license_Info.Comment = reader["comments"] as string;
                    license_Info.Relese_Date = (DateTime)reader["relese_date"];
                    license_Info.End_Date = (DateTime)reader["end_date"];
                    license_Info.person_ID = (int)reader["people_ID"];
                    license_Info.First_Name = (string)reader["first_name"];
                    license_Info.Last_Name = (string)reader["last_name"];
                    license_Info.Personal_Photo = (string)reader["personal_photo"];
                    license_Info.Is_Active = (bool)reader["is_active"];
                    license_Info.National_ID = (string)reader["national_id"];


                    is_Valid = true;

                }


            }





            catch (Exception ex)
            {
                is_Valid = false;
                Console.WriteLine(ex);
            }

            finally { connection.Close(); }




            return license_Info;
        }


        public static int GetNumberOfLicensesThisDriverhas(int driverID)
        {
            int count = 0;

            SqlConnection connection = new SqlConnection(connectionString);

            string quiry = "select count(*) from drive_licenses where driver_ID = @driverID";

            SqlCommand command = new SqlCommand(quiry,connection );

            command.Parameters.AddWithValue("@driverID", driverID);

            try
            {
                connection.Open();

                count = (int)command.ExecuteScalar();
            }
            finally
            {
                connection.Close();
            }

            return count;
        }


        public drive_license_Information_Class Get_License_Info_From_Licenses_By_LicenseID(int LicenseID, ref bool is_Valid)
        {
            is_Valid = false;

            drive_license_Information_Class license_Info = new drive_license_Information_Class();


            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from drive_licenses where drive_license_ID = @drive_license_ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@drive_license_ID", LicenseID);

            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    license_Info.Drive_License_ID = (int)reader["drive_license_ID"];
                    license_Info.Driver_ID = (int)reader["driver_ID"];
                    license_Info.Category_ID = (int)reader["category_ID"];
                    license_Info.Comment = reader["comments"] as string;
                    license_Info.Relese_Date = (DateTime)reader["relese_date"];
                    license_Info.End_Date = (DateTime)reader["end_date"];
                    license_Info.Is_Active = (bool)reader["is_active"];


                    is_Valid = true;

                }


            }


            finally { connection.Close(); }




            return license_Info;
        }


    }
}
