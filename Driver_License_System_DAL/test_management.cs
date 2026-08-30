using Driver_License_System__Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System_DAL
{
    public class test_management
    {




        private static string connectionString = get_connectionString.connectionString;

        public List<test_Information_Class> Get_Tests_List(ref bool is_Valid)
        {
            is_Valid = false;

            List<test_Information_Class> Get_Information = new List<test_Information_Class>();

            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from testes";

            SqlCommand command = new SqlCommand(query, connection);


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    test_Information_Class test_Info = new test_Information_Class();
                    test_Info.Test_ID = (int)reader["test_ID"];
                    test_Info.Test_Name = (string)reader["test_name"];
                    test_Info.Test_Price = (decimal)reader["test_price"];

                    Get_Information.Add(test_Info);

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


      
        public bool Update_Test_Price(test_Information_Class new_price)
        {
            bool is_valid = false;


            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"update testes set test_price = @price where test_ID = @test_ID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@price", new_price.Test_Price);
            command.Parameters.AddWithValue("@test_ID", new_price.Test_ID);




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
            }

            finally { connection.Close(); }

            return is_valid;
        }





    }
}
