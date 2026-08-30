using Driver_License_System__Models;
using Driver_License_System_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System_BLL
{
    public class cls_Orders
    {
        public List<orders_Information_Class> Get_History_List()
        {
            List<orders_Information_Class> NewInfo = new List<orders_Information_Class>();
            order_management NewList = new order_management();
            bool is_Valid = false;

            NewInfo = NewList.Get_Orders_List(ref is_Valid);

            if (is_Valid)
            {
                return NewInfo;
            }


            return null;
        }

     




        public List<orders_Information_Class> Get_Filterd_History_ByNationalID(string NationalID)
        {

            bool is_Valid = false;
            List<orders_Information_Class> NewInfo = new List<orders_Information_Class>();
            order_management NewList = new order_management();

            NewInfo = NewList.Find_Person_Orders_By_NationalID(NationalID, ref is_Valid);

            if (is_Valid)
            {
                return NewInfo;
            }


            return null;


        }


        public List<orders_Information_Class> Get_Filterd_History_ByFirstName(string FirstName)
        {

            bool is_Valid = false;
            List<orders_Information_Class> NewInfo = new List<orders_Information_Class>();
            order_management NewList = new order_management();

            NewInfo = NewList.Find_Person_Orders_By_FirstName(FirstName, ref is_Valid);

            if (is_Valid)
            {
                return NewInfo;
            }


            return null;


        }


        public bool AddNewOrder(orders_Information_Class AddThisOrder,ref int OrderID)

        {

            order_management NewOrder = new order_management();

            AddThisOrder.orderDate = DateTime.Now;

            OrderID = NewOrder.Add_Order_And_Return_ID(AddThisOrder);

            if(OrderID != -1)
            {
                return true;
            }

            return false;
        }



       

        public bool Add_NewOrder_NewLicense_Service(orders_Information_Class NewInformation, orderInformation_Information_Class NewOrderInformation)
        {
            order_management NewOrder = new order_management();
            orderInformation_management AddNewOrderInformationManagement = new orderInformation_management();


            NewInformation.orderDate = DateTime.Now;
            NewInformation.order_status_ID = 1;



            int ThisOrderID = NewOrder.Add_Order_And_Return_ID(NewInformation);
            int NewOrderInformationID = -1;

            if (ThisOrderID > 0)
            {
                NewOrderInformation.Order_ID = ThisOrderID;

                if (AddNewOrderInformationManagement.Add_OrderInformation(NewOrderInformation,ref NewOrderInformationID))
                     {

                    cls_Appointement AddNewAppointement = new cls_Appointement();

                   if(AddNewAppointement.AddAppointement(NewOrderInformationID))
                    {
                        return true;
                    }
                   else
                    {
                        NewOrder.Update_Order_Status(ThisOrderID, orders_Information_Class.order_status.cancelled);
                        UpdateOrderFees(ThisOrderID, 0);

                    }

                   
                }
                else
                {
                    NewOrder.Update_Order_Status(ThisOrderID, orders_Information_Class.order_status.cancelled);
                    UpdateOrderFees(ThisOrderID, 0);

                }

            }
            return false;
        }
    
        public void UpdateOrderStatus(int OrderID,orders_Information_Class.order_status status)
        {
            order_management NewManagement = new order_management();

            NewManagement.Update_Order_Status(OrderID, status);

        }

        public void UpdateOrderFees(int OrderID,decimal NewFees)
        {
            order_management NewManagement = new order_management();
            NewManagement.Update_Order_Fees(OrderID, NewFees);


        }

        public bool If_This_Order_Info_Exist(orderInformation_Information_Class NewInfo,int Order_Status_ID)
        {
            order_management NewManagement = new order_management();

            return NewManagement.If_This_OrderInfo_Exist(NewInfo, Order_Status_ID);

        }

        public bool If_This_Order_Exist(orders_Information_Class NewInfo)
        {
            order_management NewManagement = new order_management();

            NewInfo.order_status_ID = 1;
            if( NewManagement.If_This_Order_Exist(NewInfo))
            {
                return true;
            }

            NewInfo.order_status_ID = 3;

            if (NewManagement.If_This_Order_Exist(NewInfo))
            {
                return true;
            }

            return false;


        }

    }
}

