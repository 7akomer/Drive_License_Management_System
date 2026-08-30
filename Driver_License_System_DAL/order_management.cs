using Driver_License_System__Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System_DAL
{
  
        public class order_management
        {

            private static string connectionString = get_connectionString.connectionString;

            public List<orders_Information_Class> Get_Orders_List(ref bool is_Valid)
            {
                is_Valid = false;

                List<orders_Information_Class> Get_Information = new List<orders_Information_Class>();


                SqlConnection connection = new SqlConnection(connectionString);

                string query = $"select * from order_info ";

                SqlCommand command = new SqlCommand(query, connection);


                try

                {

                    connection.Open();


                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        orders_Information_Class order_Info = new orders_Information_Class();
                        order_Info.order_ID = (int)reader["order_ID"];
                        order_Info.people_ID = (int)reader["people_ID"];
                        order_Info.Application_fee_paid = (decimal)reader["application_fee_paid"];
                        order_Info.orderDate = (DateTime)reader["order_date"];
                        order_Info.service_Name = (string)reader["_service_name"];
                        order_Info.order_status_Name = (string)reader["_status"];
                        order_Info.First_name = (string)reader["first_name"];
                        order_Info.Last_name = (string)reader["last_name"];
                        order_Info.Personal_Photo = (string)reader["personal_photo"];
                        order_Info.National_ID = (string)reader["national_id"];
                    order_Info.Second_name = reader["second_name"] as string;
                    order_Info.Third_name = reader["third_name"] as string;
                    order_Info.Phone_Nember = (string)reader["phone_number"];



                    Get_Information.Add(order_Info);

                        is_Valid = true;

                    }

                }

               

                finally { connection.Close(); }




                return Get_Information;
            }


        public List<orders_Information_Class> Get_Orders_TotalFees_List()
        {

            List<orders_Information_Class> Get_Information = new List<orders_Information_Class>();


            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select application_fee_paid from order_info ";

            SqlCommand command = new SqlCommand(query, connection);


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orders_Information_Class order_Info = new orders_Information_Class();
                  
                    order_Info.Application_fee_paid = (decimal)reader["application_fee_paid"];
                   

                    Get_Information.Add(order_Info);


                }

            }



            finally { connection.Close(); }




            return Get_Information;
        }

        

        public List<orders_Information_Class> Get_Orders_TotalFees_Yasterday_List()
        {

            List<orders_Information_Class> Get_Information = new List<orders_Information_Class>();

            

            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select application_fee_paid from order_info where order_date = @OrderDate ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderDate", DateTime.Now.AddDays(-1));


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orders_Information_Class order_Info = new orders_Information_Class();

                    order_Info.Application_fee_paid = (decimal)reader["application_fee_paid"];


                    Get_Information.Add(order_Info);


                }

            }



            finally { connection.Close(); }




            return Get_Information;
        }


        public List<orders_Information_Class> Get_Orders_TotalFees_Today_List()
        {

            List<orders_Information_Class> Get_Information = new List<orders_Information_Class>();



            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select application_fee_paid from order_info where order_date = @OrderDate ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderDate", DateTime.Today);


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orders_Information_Class order_Info = new orders_Information_Class();

                    order_Info.Application_fee_paid = (decimal)reader["application_fee_paid"];


                    Get_Information.Add(order_Info);


                }

            }



            finally { connection.Close(); }




            return Get_Information;
        }




        public List<orders_Information_Class> Get_NewLicense_Application_List(string ServiceName,string Status,ref bool is_Valid)
        {

            List<orders_Information_Class> Get_Information = new List<orders_Information_Class>();
            is_Valid = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from order_info where _service_name = @_service_name and _status = @status ";



            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@_service_name", ServiceName);
            command.Parameters.AddWithValue("@status", Status);


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orders_Information_Class order_Info = new orders_Information_Class();
                    order_Info.order_ID = (int)reader["order_ID"];
                    order_Info.people_ID = (int)reader["people_ID"];
                    order_Info.Application_fee_paid = (decimal)reader["application_fee_paid"];
                    order_Info.orderDate = (DateTime)reader["order_date"];
                    order_Info.service_Name = (string)reader["_service_name"];
                    order_Info.order_status_Name = (string)reader["_status"];
                    order_Info.First_name = (string)reader["first_name"];
                    order_Info.Last_name = (string)reader["last_name"];
                    order_Info.Personal_Photo = (string)reader["personal_photo"];
                    order_Info.National_ID = (string)reader["national_id"];
                    order_Info.Second_name = reader["second_name"] as string;
                    order_Info.Third_name = reader["third_name"] as string;
                    order_Info.Phone_Nember = (string)reader["phone_number"];



                    Get_Information.Add(order_Info);
                    is_Valid = true;


                }

            }



            finally { connection.Close(); }




            return Get_Information;
        }

        public List<orders_Information_Class> Find_Person_Orders_By_NationalID(string nationalID, ref bool is_Valid)
            {
                is_Valid = false;

                List<orders_Information_Class> Get_Information = new List<orders_Information_Class>();


                SqlConnection connection = new SqlConnection(connectionString);

                string query = $"select * from order_info where national_ID like @nationalID";

                SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@nationalID", $"%{nationalID}%");



            try

            {

                    connection.Open();


                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        orders_Information_Class order_Info = new orders_Information_Class();
                        order_Info.order_ID = (int)reader["order_ID"];
                        order_Info.people_ID = (int)reader["people_ID"];
                        order_Info.Application_fee_paid = (decimal)reader["application_fee_paid"];
                        order_Info.orderDate = (DateTime)reader["order_date"];
                        order_Info.service_Name = (string)reader["_service_name"];
                        order_Info.order_status_Name = (string)reader["_status"];
                        order_Info.First_name = (string)reader["first_name"];
                        order_Info.Last_name = (string)reader["last_name"];
                        order_Info.Personal_Photo = (string)reader["personal_photo"];
                        order_Info.National_ID = (string)reader["national_id"];
                    order_Info.Second_name = reader["second_name"] as string;
                    order_Info.Third_name = reader["third_name"] as string;
                    order_Info.Phone_Nember = (string)reader["phone_number"];

                    Get_Information.Add(order_Info);

                        is_Valid = true;

                    }

                }

               
                finally { connection.Close(); }




                return Get_Information;
            }


        public List<orders_Information_Class> Find_Person_Orders_By_FirstName(string FirstName, ref bool is_Valid)
        {
            is_Valid = false;

            List<orders_Information_Class> Get_Information = new List<orders_Information_Class>();


            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"select * from order_info where first_name like @first_name";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@first_name", $"%{FirstName}%");



            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    orders_Information_Class order_Info = new orders_Information_Class();
                    order_Info.order_ID = (int)reader["order_ID"];
                    order_Info.people_ID = (int)reader["people_ID"];
                    order_Info.Application_fee_paid = (decimal)reader["application_fee_paid"];
                    order_Info.orderDate = (DateTime)reader["order_date"];
                    order_Info.service_Name = (string)reader["_service_name"];
                    order_Info.order_status_Name = (string)reader["_status"];
                    order_Info.First_name = (string)reader["first_name"];
                    order_Info.Last_name = (string)reader["last_name"];
                    order_Info.Personal_Photo = (string)reader["personal_photo"];
                    order_Info.National_ID = (string)reader["national_id"];
                    order_Info.Second_name = reader["second_name"] as string;
                    order_Info.Third_name = reader["third_name"] as string;
                    order_Info.Phone_Nember = (string)reader["phone_number"];

                    Get_Information.Add(order_Info);

                    is_Valid = true;

                }

            }

           

            finally { connection.Close(); }




            return Get_Information;
        }


        public  int GetNumberOfLicensesPending()
        {
            int count = 0;

            SqlConnection connection = new SqlConnection(connectionString);

            string quiry = "select count(*) from orders where order_status_ID = @order_status_ID";

            SqlCommand command = new SqlCommand(quiry, connection);
            command.Parameters.AddWithValue("@order_status_ID", (int)orders_Information_Class.order_status.New);

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

        public  int GetNumberOfLicensesPending_Today()
        {
            int count = 0;

            SqlConnection connection = new SqlConnection(connectionString);

            string quiry = "select count(*) from orders where order_status_ID = @order_status_ID and order_date = @order_date";

            SqlCommand command = new SqlCommand(quiry, connection);
            command.Parameters.AddWithValue("@order_status_ID", (int)orders_Information_Class.order_status.New);
            command.Parameters.AddWithValue("@order_date", DateTime.Today);

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

        public  int GetNumberOfLicensesPending_Yasterday()
        {
            int count = 0;

            SqlConnection connection = new SqlConnection(connectionString);

            string quiry = "select count(*) from orders where order_status_ID = @order_status_ID and order_date = @order_date";

            SqlCommand command = new SqlCommand(quiry, connection);
            command.Parameters.AddWithValue("@order_status_ID", (int)orders_Information_Class.order_status.New);
            command.Parameters.AddWithValue("@order_date", DateTime.Today.AddDays(-1));

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

        public bool Add_Order(orders_Information_Class new_Order)
            {

                bool is_valid = false;

                SqlConnection connection = new SqlConnection(connectionString);

                string query = $"insert into orders (order_date,Application_fee_paid,people_ID,service_ID,order_status_ID) values (@order_date,@Application_fee_paid,@people_ID,@service_ID,@order_status_ID)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ ", new_Order.orderDate);
                command.Parameters.AddWithValue("@Application_fee_paid", new_Order.Application_fee_paid);
                command.Parameters.AddWithValue("@people_ID", new_Order.people_ID);
                command.Parameters.AddWithValue("@service_ID", new_Order.service_ID);
                command.Parameters.AddWithValue("@order_status_ID", new_Order.order_status_ID);


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
                        // Console.WriteLine("Failed to add the person.");
                        is_valid = false;
                    }



                }


            catch
            {

            }

                finally { connection.Close(); }


                return is_valid;
            }

        public int Add_Order_And_Return_ID(orders_Information_Class new_Order)
        {

            int NewID = -1;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"insert into orders (order_date,Application_fee_paid,people_ID,service_ID,order_status_ID)
values (@order_date,@Application_fee_paid,@people_ID,@service_ID,@order_status_ID) ; 
 select cast (SCOPE_IDENTITY() AS INT);";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@order_date", new_Order.orderDate);
            command.Parameters.AddWithValue("@Application_fee_paid", new_Order.Application_fee_paid);
            command.Parameters.AddWithValue("@people_ID", new_Order.people_ID);
            command.Parameters.AddWithValue("@service_ID", new_Order.service_ID);
            command.Parameters.AddWithValue("@order_status_ID", new_Order.order_status_ID);


            try
            {
                connection.Open();

               NewID  = Convert.ToInt32(command.ExecuteScalar());

            }


            finally { connection.Close(); }


            return NewID;
        }




        public bool Update_Order_Status(int OrderID, orders_Information_Class.order_status status)
            {
                bool is_valid = false;


                SqlConnection connection = new SqlConnection(connectionString);

                string query = @"update orders set order_status_ID = @order_status_ID
                                     where order_ID = @order_ID";

                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@order_status_ID", (int)status);
                command.Parameters.AddWithValue("@order_ID", OrderID);

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

            public bool Delete_Order(int OrderID)
            {
                bool is_valid = false;
                SqlConnection connection = new SqlConnection(connectionString);
                string query = @"delete from orders where order_ID = @order_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@order_ID", OrderID);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
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

        public bool If_This_OrderInfo_Exist(orderInformation_Information_Class Info,int Order_Status_ID)
        {
            bool is_Exist = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"select 1 from OrderInformationExist where people_ID = @people_ID and service_ID = @service_ID and category_ID = @category_ID and order_status_ID = @order_status_ID ";
            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@people_ID", Info.People_ID);
            command.Parameters.AddWithValue("@service_ID", Info.Service_ID);
            command.Parameters.AddWithValue("@category_ID", Info.Category_ID);
            command.Parameters.AddWithValue("@order_status_ID", Order_Status_ID);
            try
            {
                connection.Open();
                object count = command.ExecuteScalar();


                if (count != null)
                {
                    is_Exist = true;
                }
                else
                {
                    is_Exist = false;
                }
            }
           
            finally { connection.Close(); }

            return is_Exist;
        }


        public bool If_This_Order_Exist(orders_Information_Class OrderInfo)
        {
            bool is_Exist = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"select 1 from orders where people_ID = @people_ID and service_ID = @service_ID and order_status_ID = @order_status_ID ";
            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@people_ID", OrderInfo.people_ID);
            command.Parameters.AddWithValue("@service_ID", OrderInfo.service_ID);
            command.Parameters.AddWithValue("@order_status_ID", OrderInfo.order_status_ID);

            try
            {
                connection.Open();
                object count = command.ExecuteScalar();


                if (count != null)
                {
                    is_Exist = true;
                }
                else
                {
                    is_Exist = false;
                }
            }

            finally { connection.Close(); }

            return is_Exist;
        }

        public bool Update_Order_Fees(int OrderID, decimal NewFees)
        {
            bool is_valid = false;


            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"update orders set application_fee_paid = @application_fee_paid
                                     where order_ID = @order_ID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@application_fee_paid", NewFees);
            command.Parameters.AddWithValue("@order_ID", OrderID);

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

