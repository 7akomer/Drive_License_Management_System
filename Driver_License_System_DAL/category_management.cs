using Driver_License_System__Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System_DAL
{
    public class category_management
    {




        private static string connectionString = get_connectionString.connectionString;

        public List<category_Information_Class> Get_Category_List(ref bool is_Valid)
        {
            is_Valid = false;

            List<category_Information_Class> Get_Information = new List<category_Information_Class>();


            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from categorys";

            SqlCommand command = new SqlCommand(query, connection);


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    category_Information_Class category_Info = new category_Information_Class();
                    category_Info.service_ID = (int)reader["service_ID"];
                    category_Info.category_Name = (string)reader["category_name"];
                    category_Info.Price = (decimal)reader["price"];
                    category_Info.category_ID = (int)reader["category_ID"];
                    category_Info.Required_Age = (int)reader["required_age"];
                    category_Info.description = (string)reader["_description"];
                    category_Info.Validity = (int)reader["Validity"];

                    Get_Information.Add(category_Info);

                    is_Valid = true;

                }

            }

           
            finally { connection.Close(); }




            return Get_Information;
        }

        //public bool Add_Category(category_Information_Class new_category)
        //{

        //    bool is_valid = false;

        //    SqlConnection connection = new SqlConnection(connectionString);

        //    string query = $"insert into categorys values (@category_name,@price,@required_age,@service_ID,@_description)";

        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.AddWithValue("@category_name", new_category.category_Name);
        //    command.Parameters.AddWithValue("@price", new_category.Price);
        //    command.Parameters.AddWithValue("@required_age", new_category.Required_Age);
        //    command.Parameters.AddWithValue("@service_ID", new_category.service_ID);
        //    command.Parameters.AddWithValue("@_description", new_category.description);


        //    try
        //    {
        //        connection.Open();

        //        int rowAffected = command.ExecuteNonQuery();


        //        if (rowAffected > 0)
        //        {
        //            // Console.WriteLine("Person added successfully.");
        //            is_valid = true;
        //        }
        //        else
        //        {
        //            // Console.WriteLine("Failed to add the person.");
        //            is_valid = false;
        //        }



        //    }
        //    catch (Exception ex)
        //    {

        //        is_valid = false;
        //        //Console.WriteLine(ex.ToString());
        //    }

        //    finally { connection.Close(); }


        //    return is_valid;
        //}


        public bool Update_Category(category_Information_Class new_category)
        {
            bool is_valid = false;


            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"update categorys set price = @price,required_age = @recuired_age
                                  ,Validity = @Validity 
                                     where category_ID = @category_ID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@price", new_category.Price);
            command.Parameters.AddWithValue("@recuired_age", new_category.Required_Age);
            command.Parameters.AddWithValue("@Validity", new_category.Validity);
            command.Parameters.AddWithValue("@category_ID", new_category.category_ID);



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


        //public bool Delete_Category(int category_ID)
        //{
        //    bool is_valid = false;
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string query = @"delete from categorys where category_ID = @category_ID";

        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@category_ID", category_ID);


        //    try
        //    {
        //        connection.Open();
        //        int rowsAffected = command.ExecuteNonQuery();
        //        if (rowsAffected > 0)
        //        {
        //            is_valid = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Console.WriteLine(ex.ToString());
        //        is_valid = false;
        //    }

        //    finally { connection.Close(); }

        //    return is_valid;

        //}

        public category_Information_Class Get_Category_PriceAndRequiredAge_By_ID(int ID,ref bool Is_Valid)
        {


            Is_Valid = false ;
            SqlConnection connection = new SqlConnection(connectionString);
            category_Information_Class category_Info = new category_Information_Class();

            string query = $"select price ,required_age  from categorys  where category_ID = @CategoryID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CategoryID", ID);


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                  
                    category_Info.Price = (decimal)reader["price"];
                    category_Info.Required_Age = (int)reader["required_age"];
                   Is_Valid = true;

                }

            }

        

            finally { connection.Close(); }




            return category_Info;
        }


        public static int Get_Category_Validity_By_ID(int ID)
        {


            SqlConnection connection = new SqlConnection(connectionString);

            int Validity = -1;
            string query = $"select Validity  from categorys  where category_ID = @CategoryID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CategoryID", ID);


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Validity = (int)reader["Validity"];

                }

            }



            finally { connection.Close(); }




            return Validity;
        }

        public List<string> Get_List_Of_Categorys_Name()
        {


            SqlConnection connection = new SqlConnection(connectionString);
List<string> NewList = new List<string>();
            string query = $"select category_name  from categorys ";

            SqlCommand command = new SqlCommand(query, connection);


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                   NewList.Add((string)reader["category_name"]);

                }

            }



            finally { connection.Close(); }




            return NewList;
        }

    }
}
