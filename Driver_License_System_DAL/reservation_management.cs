using Driver_License_System__Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System_DAL
{
   
        public class reservation_management
        {

            private static string connectionString = get_connectionString.connectionString;



            public List<reservation_Informaton_Class> Get_License_Reservation_List(ref bool is_Valid)
            {
                is_Valid = false;

                List<reservation_Informaton_Class> Get_Information = new List<reservation_Informaton_Class>();


                SqlConnection connection = new SqlConnection(connectionString);

                string query = $"select * from reservation_information";

                SqlCommand command = new SqlCommand(query, connection);


                try

                {

                    connection.Open();


                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        reservation_Informaton_Class reserv_Info = new reservation_Informaton_Class();
                        reserv_Info.Drive_License_ID = (int)reader["drive_license_ID"];
                        reserv_Info.User_ID = (int)reader["userID"];
                        reserv_Info.Reservation_ID = (int)reader["reservation_ID"];
                        reserv_Info.Reason_For_Reservation = reader["reason_for_reseration"] as string;
                        reserv_Info.Reservation_Date = (DateTime)reader["reservation_date"];
                        reserv_Info.Category_Name = (string)reader["category_name"];
                        reserv_Info.Personal_Photo = (string)reader["personal_photo"];
                        reserv_Info.First_Name = (string)reader["first_name"];
                        reserv_Info.Last_Name = (string)reader["last_name"];
                        reserv_Info.Person_ID = (int)reader["people_ID"];
                        reserv_Info.Tax = (decimal)reader["tax"];


                        Get_Information.Add(reserv_Info);

                        is_Valid = true;

                    }

                }

               

                finally { connection.Close(); }




                return Get_Information;
            }

        public List<reservation_Informaton_Class> Get_Filter_By_FirstName_Reservation_List(string FirstName,ref bool is_Valid)
        {
            is_Valid = false;

            List<reservation_Informaton_Class> Get_Information = new List<reservation_Informaton_Class>();


            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from reservation_information where first_name like @first_name";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@first_name", $"%{FirstName}%");


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    reservation_Informaton_Class reserv_Info = new reservation_Informaton_Class();
                    reserv_Info.Drive_License_ID = (int)reader["drive_license_ID"];
                    reserv_Info.User_ID = (int)reader["userID"];
                    reserv_Info.Reservation_ID = (int)reader["reservation_ID"];
                    reserv_Info.Reason_For_Reservation = reader["reason_for_reseration"] as string;
                    reserv_Info.Reservation_Date = (DateTime)reader["reservation_date"];
                    reserv_Info.Category_Name = (string)reader["category_name"];
                    reserv_Info.Personal_Photo = (string)reader["personal_photo"];
                    reserv_Info.First_Name = (string)reader["first_name"];
                    reserv_Info.Last_Name = (string)reader["last_name"];
                    reserv_Info.Person_ID = (int)reader["people_ID"];
                    reserv_Info.Tax = (decimal)reader["tax"];


                    Get_Information.Add(reserv_Info);

                    is_Valid = true;

                }

            }

           

            finally { connection.Close(); }




            return Get_Information;
        }


        public List<reservation_Informaton_Class> Get_Filter_By_DetainID_Reservation_List(int DetainID, ref bool is_Valid)
        {
            is_Valid = false;

            List<reservation_Informaton_Class> Get_Information = new List<reservation_Informaton_Class>();


            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from reservation_information where reservation_ID like @reservation_ID";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@reservation_ID", $"%{DetainID}%");


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    reservation_Informaton_Class reserv_Info = new reservation_Informaton_Class();
                    reserv_Info.Drive_License_ID = (int)reader["drive_license_ID"];
                    reserv_Info.User_ID = (int)reader["userID"];
                    reserv_Info.Reservation_ID = (int)reader["reservation_ID"];
                    reserv_Info.Reason_For_Reservation = reader["reason_for_reseration"] as string;
                    reserv_Info.Reservation_Date = (DateTime)reader["reservation_date"];
                    reserv_Info.Category_Name = (string)reader["category_name"];
                    reserv_Info.Personal_Photo = (string)reader["personal_photo"];
                    reserv_Info.First_Name = (string)reader["first_name"];
                    reserv_Info.Last_Name = (string)reader["last_name"];
                    reserv_Info.Person_ID = (int)reader["people_ID"];
                    reserv_Info.Tax = (decimal)reader["tax"];


                    Get_Information.Add(reserv_Info);

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

        public bool Add_Reserve_Drive_License(reservation_Informaton_Class new_reserve)
            {

                bool is_valid = false;

                SqlConnection connection = new SqlConnection(connectionString);

                string query = @"insert into reservation_list (tax,reason_for_reseration,userID,drive_license_ID,reservation_date)
                            values (@tax,@reason_for_reseration,@userID,@drive_license_ID,@reservation_date)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@tax", new_reserve.Tax);
                command.Parameters.AddWithValue("@reason_for_reseration", new_reserve.Reason_For_Reservation);
                command.Parameters.AddWithValue("@userID", new_reserve.User_ID);
                command.Parameters.AddWithValue("@drive_license_ID", new_reserve.Drive_License_ID);
                command.Parameters.AddWithValue("@reservation_date", new_reserve.Reservation_Date);



                try
                {
                    connection.Open();

                    int rowAffected = Convert.ToInt32(command.ExecuteNonQuery());

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


            public bool License_Release(int Reserve_ID)
            {
                bool is_valid = false;
                SqlConnection connection = new SqlConnection(connectionString);
                string query = @"delete from reservation_list where reservation_ID = @reservation_ID";


                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@reservation_ID", Reserve_ID);
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


            public bool Is_Reserved(int Drive_License_ID)
            {
                bool is_reserved = false;
                SqlConnection connection = new SqlConnection(connectionString);
                string query = @"select 1 from reservation_list where drive_license_ID = @drive_license_ID";
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


        public static int GetNumberOfDetainLicensesThisPersonhas(int PersonID)
        {
            int count = 0;

            SqlConnection connection = new SqlConnection(connectionString);

            string quiry = "select count(*) from reservation_information where people_ID = @PersonID";

            SqlCommand command = new SqlCommand(quiry, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

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



    }
}

