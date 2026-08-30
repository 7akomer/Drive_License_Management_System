using Driver_License_System__Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System_DAL
{
    public class orderInformation_management
    {


        private static string connectionString = get_connectionString.connectionString;

        public List<orderInformation_Information_Class> Get_OrdersInformation_List(ref bool is_Valid)
        {
            is_Valid = false;

            List<orderInformation_Information_Class> Get_Information = new List<orderInformation_Information_Class>();


            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from orders_information";

            SqlCommand command = new SqlCommand(query, connection);


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orderInformation_Information_Class order_Info = new orderInformation_Information_Class();
                    order_Info.OrderInformation_ID = (int)reader["order_information_ID"];
                    order_Info.People_ID = (int)reader["people_ID"];
                    order_Info.Service_ID = (int)reader["service_ID"];
                    order_Info.Category_ID = reader["category_ID"] as int?;
                    order_Info.Order_ID = (int)reader["order_ID"];

                    Get_Information.Add(order_Info);

                    is_Valid = true;

                }

            }

         
            finally { connection.Close(); }




            return Get_Information;
        }

        public bool Add_OrderInformation(orderInformation_Information_Class new_OrderInformation,ref int NewOrderInformationID)
        {

            bool is_valid = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"insert into orders_information  (people_ID,order_ID,service_ID,category_ID) values (@people_ID,@order_ID,@service_ID,@category_ID) select cast (SCOPE_IDENTITY() AS INT);";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@people_ID", new_OrderInformation.People_ID);
            command.Parameters.AddWithValue("@order_ID", new_OrderInformation.Order_ID);
            command.Parameters.AddWithValue("@service_ID", new_OrderInformation.Service_ID);
            command.Parameters.AddWithValue("@category_ID", (object)new_OrderInformation.Category_ID ?? DBNull.Value);


            try
            {
                connection.Open();

                NewOrderInformationID = Convert.ToInt32(command.ExecuteScalar());


                if (NewOrderInformationID > 0)
                {
                    is_valid = true;
                }
                else
                {
                    is_valid = false;
                }



            }
          

            finally { connection.Close(); }


            return is_valid;
        }

        public bool Delete_OrderInformation(int OrderInformation_ID)
        {
            bool is_valid = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"delete from orders_information where order_information_ID = @order_information_ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@order_information_ID", OrderInformation_ID);
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

        public static int Get_CategoryID_By_OrderID(int OrderID)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            int CategoryID = -1;
            string query = $"select category_ID  from orders_information  where order_ID = @OrderID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderID", OrderID);


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    CategoryID = (int)reader["category_ID"];

                }

            }



            finally { connection.Close(); }




            return CategoryID;

        }
    }
}
