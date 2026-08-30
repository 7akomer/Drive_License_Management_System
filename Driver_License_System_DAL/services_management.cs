using Driver_License_System__Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System_DAL
{
    public class services_management
    {

        private static string connectionString = get_connectionString.connectionString;

        public List<Services_Information_Class> Get_Services_List(ref bool is_Valid)
        {
            is_Valid = false;

            List<Services_Information_Class> Get_Information = new List<Services_Information_Class>();


            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from _services";

            SqlCommand command = new SqlCommand(query, connection);


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Services_Information_Class service_Info = new Services_Information_Class();
                    service_Info.service_Id = (int)reader["service_ID"];
                   service_Info.service_Name = (string)reader["_service_name"];
                    service_Info.service_price = (decimal)reader["_service_price"];

                    Get_Information.Add(service_Info);

                    is_Valid = true;

                }

            }

            catch (Exception ex)
            {
                is_Valid = false;
                // Console.WriteLine(ex);
            }

            finally { connection.Close(); }




            return Get_Information;
        }

        public Services_Information_Class Get_Service_Price_By_ID(int ServiceID,ref bool is_Valid)
        {
            is_Valid = false;

            Services_Information_Class service_Info = new Services_Information_Class();


            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from _services where service_ID = @service_ID";



            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@service_ID", ServiceID);


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    service_Info.service_Id = (int)reader["service_ID"];
                    service_Info.service_Name = (string)reader["_service_name"];
                    service_Info.service_price = (decimal)reader["_service_price"];


                    is_Valid = true;

                }

            }

            catch (Exception ex)
            {
                is_Valid = false;
                // Console.WriteLine(ex);
            }

            finally { connection.Close(); }




            return service_Info;
        }

        /*  public bool Add_Service(service_Information_Class new_service)
          {

              bool is_valid = false;

              SqlConnection connection = new SqlConnection(connectionString);

              string query = $"insert into _services values (@_service_name,@_service_price)";

              SqlCommand command = new SqlCommand(query, connection);

              command.Parameters.AddWithValue("@_service_name", new_service.service_Name);
              command.Parameters.AddWithValue("@_service_price", new_service.service_price);


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
              catch (Exception ex)
              {

                  is_valid = false;
                  //Console.WriteLine(ex.ToString());
              }

              finally { connection.Close(); }


              return is_valid;
          }

          */


        public bool Update_Service(Services_Information_Class new_service)
        {
            bool is_valid = false;


            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"update _services set _service_price = @service_price
                                     where service_ID = @service_ID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@service_price", new_service.service_price);
            command.Parameters.AddWithValue("@service_ID", new_service.service_Id);

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


      /*  public bool Delete_Service(int service_ID)
        {
            bool is_valid = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"delete from _services where service_ID = @service_ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@service_ID", service_ID);


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
      */

    }
}
