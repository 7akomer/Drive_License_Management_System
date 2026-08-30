using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver_License_System__Models;


namespace Driver_License_System_DAL
{
    public class appointment_management
    {
       


            private static string connectionString = get_connectionString.connectionString;


            public List<appointment_Information_Class> Get_Appointments_List_No_Dating()
            {

                List<appointment_Information_Class> Get_Information = new List<appointment_Information_Class>();


                SqlConnection connection = new SqlConnection(connectionString);


                string query = @"SELECT peoples.people_ID, peoples.first_name, peoples.last_name, peoples.phone_number,
peoples.personal_photo, orders.order_ID, orders.order_date, _services._service_name,
categorys.category_name, appointments.appointment_ID,      
appointments.appointment_date, testes.test_ID, testes.test_name, testes.test_price, 
appointments.result_ID FROM     peoples INNER JOIN  orders ON peoples.people_ID = orders.people_ID INNER JOIN  
orders_information ON peoples.people_ID = orders_information.people_ID AND orders.order_ID = orders_information.order_ID 
INNER JOIN    _services ON orders.service_ID = _services.service_ID AND orders_information.service_ID = _services.service_ID 
INNER JOIN  categorys ON orders_information.category_ID = categorys.category_ID AND _services.service_ID = categorys.service_ID
INNER JOIN appointments ON orders_information.order_information_ID = appointments.order_information_ID INNER JOIN
testes ON appointments.test_ID = testes.test_ID where appointments.result_ID = 3 and appointments.appointment_date = '2006/04/19' ";


                SqlCommand command = new SqlCommand(query, connection);


                try

                {

                    connection.Open();


                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        appointment_Information_Class appointment_Info = new appointment_Information_Class();

                        appointment_Info.appointment_ID = (int)reader["appointment_ID"];
                        appointment_Info.AppoinementDate = (DateTime)reader["appointment_date"];
                        appointment_Info.result_ID = (int)reader["result_ID"];
                        appointment_Info.test_ID = (int)reader["test_ID"];
                    appointment_Info.people_ID = (int)reader["people_ID"];
                    appointment_Info.First_name = (string)reader["first_name"];
                    appointment_Info.Last_name = (string)reader["last_name"];
                    appointment_Info.Phone_Nember = (string)reader["phone_number"];
                    appointment_Info.Personal_Photo = (string)reader["personal_photo"];
                    appointment_Info.order_ID = (int)reader["order_ID"];
                    appointment_Info.orderDate = (DateTime)reader["order_date"];
                    appointment_Info.service_Name = (string)reader["_service_name"];
                    appointment_Info.Category_Name = (string)reader["category_name"];
                    appointment_Info.Personal_Photo = (string)reader["personal_photo"];
                    appointment_Info.TestName = (string)reader["test_name"];
                    appointment_Info.Test_Fees = (Decimal)reader["test_price"];












                    Get_Information.Add(appointment_Info);


                    }

                }

             
                finally { connection.Close(); }




                return Get_Information;
            }

        public List<appointment_Information_Class> Get_ListOfFailedPersons(int FiledPersonsResultID )
        {

            List<appointment_Information_Class> Get_Information = new List<appointment_Information_Class>();


            SqlConnection connection = new SqlConnection(connectionString);


            string query = @"SELECT peoples.people_ID, peoples.first_name, peoples.last_name, peoples.phone_number,
peoples.personal_photo, orders.order_ID, orders.order_date, _services._service_name,
categorys.category_name, appointments.appointment_ID,      
appointments.appointment_date, testes.test_ID, testes.test_name, testes.test_price, 
appointments.result_ID FROM     peoples INNER JOIN  orders ON peoples.people_ID = orders.people_ID INNER JOIN  
orders_information ON peoples.people_ID = orders_information.people_ID AND orders.order_ID = orders_information.order_ID 
INNER JOIN    _services ON orders.service_ID = _services.service_ID AND orders_information.service_ID = _services.service_ID 
INNER JOIN  categorys ON orders_information.category_ID = categorys.category_ID AND _services.service_ID = categorys.service_ID
INNER JOIN appointments ON orders_information.order_information_ID = appointments.order_information_ID INNER JOIN
testes ON appointments.test_ID = testes.test_ID where appointments.result_ID = @ResultID ";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ResultID", FiledPersonsResultID);

            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    appointment_Information_Class appointment_Info = new appointment_Information_Class();

                    appointment_Info.appointment_ID = (int)reader["appointment_ID"];
                    appointment_Info.AppoinementDate = (DateTime)reader["appointment_date"];
                    appointment_Info.result_ID = (int)reader["result_ID"];
                    appointment_Info.test_ID = (int)reader["test_ID"];
                    appointment_Info.people_ID = (int)reader["people_ID"];
                    appointment_Info.First_name = (string)reader["first_name"];
                    appointment_Info.Last_name = (string)reader["last_name"];
                    appointment_Info.Phone_Nember = (string)reader["phone_number"];
                    appointment_Info.Personal_Photo = (string)reader["personal_photo"];
                    appointment_Info.order_ID = (int)reader["order_ID"];
                    appointment_Info.orderDate = (DateTime)reader["order_date"];
                    appointment_Info.service_Name = (string)reader["_service_name"];
                    appointment_Info.Category_Name = (string)reader["category_name"];
                    appointment_Info.Personal_Photo = (string)reader["personal_photo"];
                    appointment_Info.TestName = (string)reader["test_name"];
                    appointment_Info.Test_Fees = (Decimal)reader["test_price"];












                    Get_Information.Add(appointment_Info);


                }

            }


            finally { connection.Close(); }




            return Get_Information;
        }

     

        public List<appointment_Information_Class> Get_List_Of_scheduling_Tests()
        {

            List<appointment_Information_Class> Get_Information = new List<appointment_Information_Class>();


            SqlConnection connection = new SqlConnection(connectionString);


            string query = @"SELECT peoples.people_ID, peoples.first_name, peoples.last_name, peoples.phone_number,
peoples.personal_photo, orders.order_ID, orders.order_date, _services._service_name,
categorys.category_name, appointments.appointment_ID,      
appointments.appointment_date, testes.test_ID, testes.test_name, testes.test_price, 
appointments.result_ID FROM     peoples INNER JOIN  orders ON peoples.people_ID = orders.people_ID INNER JOIN  
orders_information ON peoples.people_ID = orders_information.people_ID AND orders.order_ID = orders_information.order_ID 
INNER JOIN    _services ON orders.service_ID = _services.service_ID AND orders_information.service_ID = _services.service_ID 
INNER JOIN  categorys ON orders_information.category_ID = categorys.category_ID AND _services.service_ID = categorys.service_ID
INNER JOIN appointments ON orders_information.order_information_ID = appointments.order_information_ID INNER JOIN
testes ON appointments.test_ID = testes.test_ID where appointments.result_ID = 3 and appointments.appointment_date != '2006/04/19' ";


            SqlCommand command = new SqlCommand(query, connection);


            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    appointment_Information_Class appointment_Info = new appointment_Information_Class();

                    appointment_Info.appointment_ID = (int)reader["appointment_ID"];
                    appointment_Info.AppoinementDate = (DateTime)reader["appointment_date"];
                    appointment_Info.result_ID = (int)reader["result_ID"];
                    appointment_Info.test_ID = (int)reader["test_ID"];
                    appointment_Info.people_ID = (int)reader["people_ID"];
                    appointment_Info.First_name = (string)reader["first_name"];
                    appointment_Info.Last_name = (string)reader["last_name"];
                    appointment_Info.Phone_Nember = (string)reader["phone_number"];
                    appointment_Info.Personal_Photo = (string)reader["personal_photo"];
                    appointment_Info.order_ID = (int)reader["order_ID"];
                    appointment_Info.orderDate = (DateTime)reader["order_date"];
                    appointment_Info.service_Name = (string)reader["_service_name"];
                    appointment_Info.Category_Name = (string)reader["category_name"];
                    appointment_Info.Personal_Photo = (string)reader["personal_photo"];
                    appointment_Info.TestName = (string)reader["test_name"];
                    appointment_Info.Test_Fees = (Decimal)reader["test_price"];












                    Get_Information.Add(appointment_Info);


                }

            }


            finally { connection.Close(); }




            return Get_Information;
        }

        public List<appointment_Information_Class> Get_Appointments_List_No_Dating_FilterdByTestID(int TestID)
        {

            List<appointment_Information_Class> Get_Information = new List<appointment_Information_Class>();


            SqlConnection connection = new SqlConnection(connectionString);


            string query = @"SELECT peoples.people_ID, peoples.first_name, peoples.last_name, peoples.phone_number,
peoples.personal_photo, orders.order_ID, orders.order_date, _services._service_name,
categorys.category_name, appointments.appointment_ID,      
appointments.appointment_date, testes.test_ID, testes.test_name, testes.test_price, 
appointments.result_ID FROM     peoples INNER JOIN  orders ON peoples.people_ID = orders.people_ID INNER JOIN  
orders_information ON peoples.people_ID = orders_information.people_ID AND orders.order_ID = orders_information.order_ID 
INNER JOIN    _services ON orders.service_ID = _services.service_ID AND orders_information.service_ID = _services.service_ID 
INNER JOIN  categorys ON orders_information.category_ID = categorys.category_ID AND _services.service_ID = categorys.service_ID
INNER JOIN appointments ON orders_information.order_information_ID = appointments.order_information_ID INNER JOIN
testes ON appointments.test_ID = testes.test_ID where appointments.result_ID = 3 and appointments.appointment_date = '2006/04/19' and testes.test_ID = @TestID  ";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);

            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    appointment_Information_Class appointment_Info = new appointment_Information_Class();

                    appointment_Info.appointment_ID = (int)reader["appointment_ID"];
                    appointment_Info.AppoinementDate = (DateTime)reader["appointment_date"];
                    appointment_Info.result_ID = (int)reader["result_ID"];
                    appointment_Info.test_ID = (int)reader["test_ID"];
                    appointment_Info.people_ID = (int)reader["people_ID"];
                    appointment_Info.First_name = (string)reader["first_name"];
                    appointment_Info.Last_name = (string)reader["last_name"];
                    appointment_Info.Phone_Nember = (string)reader["phone_number"];
                    appointment_Info.Personal_Photo = (string)reader["personal_photo"];
                    appointment_Info.order_ID = (int)reader["order_ID"];
                    appointment_Info.orderDate = (DateTime)reader["order_date"];
                    appointment_Info.service_Name = (string)reader["_service_name"];
                    appointment_Info.Category_Name = (string)reader["category_name"];
                    appointment_Info.Personal_Photo = (string)reader["personal_photo"];
                    appointment_Info.TestName = (string)reader["test_name"];
                    appointment_Info.Test_Fees = (Decimal)reader["test_price"];












                    Get_Information.Add(appointment_Info);


                }

            }

           

            finally { connection.Close(); }




            return Get_Information;
        }


        public List<appointment_Information_Class> Get_FailedPersonsList_FilterdByTestID(int TestID,int FiledPersonsResultID)
        {

            List<appointment_Information_Class> Get_Information = new List<appointment_Information_Class>();


            SqlConnection connection = new SqlConnection(connectionString);


            string query = @"SELECT peoples.people_ID, peoples.first_name, peoples.last_name, peoples.phone_number,
peoples.personal_photo, orders.order_ID, orders.order_date, _services._service_name,
categorys.category_name, appointments.appointment_ID,      
appointments.appointment_date, testes.test_ID, testes.test_name, testes.test_price, 
appointments.result_ID FROM     peoples INNER JOIN  orders ON peoples.people_ID = orders.people_ID INNER JOIN  
orders_information ON peoples.people_ID = orders_information.people_ID AND orders.order_ID = orders_information.order_ID 
INNER JOIN    _services ON orders.service_ID = _services.service_ID AND orders_information.service_ID = _services.service_ID 
INNER JOIN  categorys ON orders_information.category_ID = categorys.category_ID AND _services.service_ID = categorys.service_ID
INNER JOIN appointments ON orders_information.order_information_ID = appointments.order_information_ID INNER JOIN
testes ON appointments.test_ID = testes.test_ID where appointments.result_ID = @ResultID and testes.test_ID = @TestID  ";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);
            command.Parameters.AddWithValue("@ResultID", FiledPersonsResultID);

            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    appointment_Information_Class appointment_Info = new appointment_Information_Class();

                    appointment_Info.appointment_ID = (int)reader["appointment_ID"];
                    appointment_Info.AppoinementDate = (DateTime)reader["appointment_date"];
                    appointment_Info.result_ID = (int)reader["result_ID"];
                    appointment_Info.test_ID = (int)reader["test_ID"];
                    appointment_Info.people_ID = (int)reader["people_ID"];
                    appointment_Info.First_name = (string)reader["first_name"];
                    appointment_Info.Last_name = (string)reader["last_name"];
                    appointment_Info.Phone_Nember = (string)reader["phone_number"];
                    appointment_Info.Personal_Photo = (string)reader["personal_photo"];
                    appointment_Info.order_ID = (int)reader["order_ID"];
                    appointment_Info.orderDate = (DateTime)reader["order_date"];
                    appointment_Info.service_Name = (string)reader["_service_name"];
                    appointment_Info.Category_Name = (string)reader["category_name"];
                    appointment_Info.Personal_Photo = (string)reader["personal_photo"];
                    appointment_Info.TestName = (string)reader["test_name"];
                    appointment_Info.Test_Fees = (Decimal)reader["test_price"];












                    Get_Information.Add(appointment_Info);


                }

            }



            finally { connection.Close(); }




            return Get_Information;
        }

        public List<appointment_Information_Class> Get_Shceduling_Test_List_FilterBy_TestType(int TestID)
        {

            List<appointment_Information_Class> Get_Information = new List<appointment_Information_Class>();


            SqlConnection connection = new SqlConnection(connectionString);


            string query = @"SELECT peoples.people_ID, peoples.first_name, peoples.last_name, peoples.phone_number,
peoples.personal_photo, orders.order_ID, orders.order_date, _services._service_name,
categorys.category_name, appointments.appointment_ID,      
appointments.appointment_date, testes.test_ID, testes.test_name, testes.test_price, 
appointments.result_ID FROM     peoples INNER JOIN  orders ON peoples.people_ID = orders.people_ID INNER JOIN  
orders_information ON peoples.people_ID = orders_information.people_ID AND orders.order_ID = orders_information.order_ID 
INNER JOIN    _services ON orders.service_ID = _services.service_ID AND orders_information.service_ID = _services.service_ID 
INNER JOIN  categorys ON orders_information.category_ID = categorys.category_ID AND _services.service_ID = categorys.service_ID
INNER JOIN appointments ON orders_information.order_information_ID = appointments.order_information_ID INNER JOIN
testes ON appointments.test_ID = testes.test_ID where appointments.result_ID = 3 and appointments.appointment_date != '2006/04/19' and testes.test_ID = @TestID  ";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);

            try

            {

                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    appointment_Information_Class appointment_Info = new appointment_Information_Class();

                    appointment_Info.appointment_ID = (int)reader["appointment_ID"];
                    appointment_Info.AppoinementDate = (DateTime)reader["appointment_date"];
                    appointment_Info.result_ID = (int)reader["result_ID"];
                    appointment_Info.test_ID = (int)reader["test_ID"];
                    appointment_Info.people_ID = (int)reader["people_ID"];
                    appointment_Info.First_name = (string)reader["first_name"];
                    appointment_Info.Last_name = (string)reader["last_name"];
                    appointment_Info.Phone_Nember = (string)reader["phone_number"];
                    appointment_Info.Personal_Photo = (string)reader["personal_photo"];
                    appointment_Info.order_ID = (int)reader["order_ID"];
                    appointment_Info.orderDate = (DateTime)reader["order_date"];
                    appointment_Info.service_Name = (string)reader["_service_name"];
                    appointment_Info.Category_Name = (string)reader["category_name"];
                    appointment_Info.Personal_Photo = (string)reader["personal_photo"];
                    appointment_Info.TestName = (string)reader["test_name"];
                    appointment_Info.Test_Fees = (Decimal)reader["test_price"];












                    Get_Information.Add(appointment_Info);


                }

            }



            finally { connection.Close(); }




            return Get_Information;
        }


        //        public bool If_ThisOrder_Has_Appointement(int OrderID)
        //        {
        //            bool is_Exist = false;
        //            SqlConnection connection = new SqlConnection(connectionString);
        //            string query = @"SELECT orders.order_ID, orders_information.order_information_ID, appointments.appointment_ID
        //FROM     orders INNER JOIN
        //                  orders_information ON orders.order_ID = orders_information.order_ID INNER JOIN
        //                  appointments ON orders_information.order_information_ID = appointments.order_information_ID
        //				  where orders.order_ID = @OrderID ";

        //            SqlCommand command = new SqlCommand(query, connection);


        //            command.Parameters.AddWithValue("@OrderID", OrderID);


        //            try
        //            {
        //                connection.Open();
        //                object count = command.ExecuteScalar();


        //                if (count != null)
        //                {
        //                    is_Exist = true;
        //                }
        //                else
        //                {
        //                    is_Exist = false;
        //                }
        //            }

        //            finally { connection.Close(); }

        //            return is_Exist;
        //        }
        public bool Add_Appointment(appointment_Information_Class new_Appointment)
            {

                bool is_valid = false;

                SqlConnection connection = new SqlConnection(connectionString);

                string query = $"insert into appointments (appointment_date,result_ID,note,test_ID,order_information_ID) values (@appointment_date,@result_ID,@note,@test_ID,@order_information_ID)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@appointment_date", new_Appointment.AppoinementDate);
                command.Parameters.AddWithValue("@result_ID", new_Appointment.result_ID);
                command.Parameters.AddWithValue("@note", new_Appointment.notes ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@test_ID", new_Appointment.test_ID);
                command.Parameters.AddWithValue("@order_information_ID", new_Appointment.order_information_ID);
                
             
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
            

                finally { connection.Close(); }


                return is_valid;
            }


            public bool Update_Appointment_For_Complet_all_Exam(appointment_Information_Class update_Info)
            {
                bool is_valid = false;


                SqlConnection connection = new SqlConnection(connectionString);

                string query = @"update appointments set 
result_ID = @Result_ID,
                                                        note = @note
                                                       
                                 where appointment_ID = @appointment_ID";

                SqlCommand command = new SqlCommand(query, connection);


                command.Parameters.AddWithValue("@note", update_Info.notes);
                command.Parameters.AddWithValue("@appointment_ID", update_Info.appointment_ID);
            command.Parameters.AddWithValue("@Result_ID", update_Info.result_ID);

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

        public bool Update_Appointment_For_Pass(appointment_Information_Class update_Info)
        {
            bool is_valid = false;


            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"update appointments set appointment_date = @appointment_date,
                                                        test_ID = @test_ID,
result_ID = @Result_ID,
                                                        note = @note
                                                       
                                 where appointment_ID = @appointment_ID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@appointment_date", update_Info.AppoinementDate);
            command.Parameters.AddWithValue("@note", update_Info.notes);
            command.Parameters.AddWithValue("@test_ID", (int)update_Info.test_ID);
            command.Parameters.AddWithValue("@appointment_ID", update_Info.appointment_ID);
            command.Parameters.AddWithValue("@Result_ID", update_Info.result_ID);

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



        public bool Update_Appointment_For_Failed(int AppointementID,int ResultID)
        {
            bool is_valid = false;


            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"update appointments set 
                                                        
result_ID = @Result_ID
                                                       
                                 where appointment_ID = @appointment_ID";

            SqlCommand command = new SqlCommand(query, connection);


           
            command.Parameters.AddWithValue("@appointment_ID", AppointementID);
            command.Parameters.AddWithValue("@Result_ID", ResultID);

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



        public bool Update_AppointmentDate(int AppointementID,DateTime AppointementDate,int Result_ID)
        {
            bool is_valid = false;


            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"update appointments set appointment_date = @appointment_date,result_ID = @Result_ID
                                                 
                                 where appointment_ID = @appointment_ID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@appointment_date", AppointementDate);
            command.Parameters.AddWithValue("@appointment_ID", AppointementID);
            command.Parameters.AddWithValue("@Result_ID", Result_ID);


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


        public bool Update_Appointment(int AppointementID, DateTime AppointementDate, int Result_ID)
        {
            bool is_valid = false;


            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"update appointments set appointment_date = @appointment_date,result_ID = @Result_ID
                                                 
                                 where appointment_ID = @appointment_ID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@appointment_date", AppointementDate);
            command.Parameters.AddWithValue("@appointment_ID", AppointementID);
            command.Parameters.AddWithValue("@Result_ID", Result_ID);


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


        public bool Delete_Appointment(int appointment_ID)
            {
                bool is_valid = false;
                SqlConnection connection = new SqlConnection(connectionString);
                string query = @"delete from appointments where appointment_ID = @appointment_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@appointment_ID", appointment_ID);
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

        }
    
}