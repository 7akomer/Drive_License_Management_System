using Driver_License_System__Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System_DAL
{
    public class driver_management
    {




        private static string connectionString = get_connectionString.connectionString;



        public List<drivers_Information_Class> Get_Drivers_List(ref bool is_valid)
        {

            List<drivers_Information_Class> Get_List = new List<drivers_Information_Class>();

            //   st_Person_Information get_peopleID = new st_Person_Information();
            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"select * from driver_info";

            SqlCommand command = new SqlCommand(query, connection);



            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    drivers_Information_Class drivers_Info = new drivers_Information_Class();
                    drivers_Info.Driver_ID = (int)reader["driver_ID"];
                    drivers_Info.People_ID = (int)reader["people_ID"];
                    drivers_Info.first_name = (string)reader["first_name"];
                    drivers_Info.second_name = reader["second_name"] as string;
                    drivers_Info.third_name = reader["third_name"] as string;
                    drivers_Info.last_name = (string)reader["last_name"];
                    drivers_Info.Driver_Photo = (string)reader["personal_photo"];

                    Get_List.Add(drivers_Info);

                    is_valid = true;
                }
            }



            catch (Exception ex)
            {

                is_valid = false;

                // Console.WriteLine(ex.ToString());



            }



            finally { connection.Close(); }

            return Get_List;

        }

        public drivers_Information_Class Find_By_DriverID(string DriverID, ref bool is_valid)
        {

            drivers_Information_Class drivers_Info = new drivers_Information_Class();

            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"select * from driver_info where driver_ID = @driver_ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@driver_ID", DriverID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    drivers_Info.Driver_ID = (int)reader["driver_ID"];
                    drivers_Info.People_ID = (int)reader["people_ID"];
                    drivers_Info.first_name = (string)reader["first_name"];
                    drivers_Info.second_name = reader["second_name"] as string;
                    drivers_Info.third_name = reader["third_name"] as string;
                    drivers_Info.last_name = (string)reader["last_name"];
                    drivers_Info.Driver_Photo = (string)reader["personal_photo"];


                    is_valid = true;
                }
            }



            catch (Exception ex)
            {

                is_valid = false;

                // Console.WriteLine(ex.ToString());



            }



            finally { connection.Close(); }

            return drivers_Info;

        }


        public int GetDriverID(int PersonID)
        {


            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"select driver_ID from drivers where people_ID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            int DriverID = -1;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DriverID = (int)reader["driver_ID"];
                    

                }
            }



            finally { connection.Close(); }

            return DriverID;

        }


        public bool IFthisPersonIsDriver(int PersonID)
        {
            bool IsDriver = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"select 1 from drivers where people_ID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                object count = command.ExecuteScalar();
                if (count != null)
                {
                    IsDriver = true;
                }
                else
                {
                    IsDriver = false;
                }
            }

            finally { connection.Close(); }

            return IsDriver;
        }


        public int Add_Driver(int PeopleID)
        {

            int DriverID = -1;
            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"insert into drivers (people_ID) values (@people_ID); select cast (SCOPE_IDENTITY() AS INT);";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@people_ID", PeopleID);

            try
            {
                connection.Open();

                DriverID = Convert.ToInt32(command.ExecuteScalar());

            }

            finally { connection.Close(); }


            return DriverID;
        }

        public bool Delete_Driver(int Driver_ID)
        {
            bool is_valid = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"delete from drivers where driver_ID = @driver_ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@driver_ID", Driver_ID);
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
                is_valid = false;
                //  Console.WriteLine(ex.ToString());
            }
            finally { connection.Close(); }
            return is_valid;
        }






    }
}
