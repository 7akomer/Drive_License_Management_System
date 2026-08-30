using Driver_License_System__Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Driver_License_System_DAL;
using System.Runtime.InteropServices;

namespace Driver_License_System_BLL
{
    public class cls_Appointement
    {

        DateTime PrivateTime = new DateTime(2006, 04, 19);

        public List<appointment_Information_Class> Get_Appointement_No_Date_List()
        {

            appointment_management NewList = new appointment_management();



            return NewList.Get_Appointments_List_No_Dating();
            
        }

        public List<appointment_Information_Class> Get_Appointement_No_Date_List_FilterByTestID(int Test_ID)
        {

            appointment_management NewList = new appointment_management();



            return NewList.Get_Appointments_List_No_Dating_FilterdByTestID(Test_ID);

        }

        public List<appointment_Information_Class> Get_Failed_Persons_List()
        {

            appointment_management NewList = new appointment_management();



            return NewList.Get_ListOfFailedPersons((int)appointment_Information_Class.Results.Fail);

        }

        public List<appointment_Information_Class> Get_FailedPersonsFilterByTestID(int Test_ID)
        {

            appointment_management NewList = new appointment_management();



            return NewList.Get_FailedPersonsList_FilterdByTestID(Test_ID,(int)appointment_Information_Class.Results.Fail);

        }

        public List<appointment_Information_Class> Get_Scheduling_Exam_List()
        {

            appointment_management NewList = new appointment_management();



            return NewList.Get_List_Of_scheduling_Tests();

        }

        public List<appointment_Information_Class> Get_Scheduling_Exam_List_FilterByTestType(int Test_ID)
        {

            appointment_management NewList = new appointment_management();



            return NewList.Get_Shceduling_Test_List_FilterBy_TestType(Test_ID);

        }



        public bool schedulingTest(int AppointementID,DateTime AppointementDate)
        {

            appointment_management NewManagement = new appointment_management();

            if(NewManagement.Update_AppointmentDate(AppointementID,AppointementDate,(int)appointment_Information_Class.Results.Pending))
            {
                return true;
            }

            return false;
        }

        public bool SaveTestResult(int AppointementID,int ResultID,int TestTypeID,string OldNote,int OrderID,string NewNote,int PersonID,ref int NewLicenseID)
        {
            appointment_management NewManagement = new appointment_management();

            if (ResultID == (int)appointment_Information_Class.Results.Pass)
            {
                appointment_Information_Class NewInfo = new appointment_Information_Class();


                NewInfo.appointment_ID = AppointementID;
                NewInfo.notes = OldNote+" ,"+NewNote;
                
                if(TestTypeID == (int)appointment_Information_Class.Test.Eye_test)
                {
                    NewInfo.test_ID = (int)appointment_Information_Class.Test.Theoretical_test;
                    NewInfo.result_ID = (int)appointment_Information_Class.Results.Pending;
                    NewInfo.AppoinementDate = PrivateTime;
                    NewManagement.Update_Appointment_For_Pass(NewInfo);
                    return true;
                }
                else if(TestTypeID == (int)appointment_Information_Class.Test.Theoretical_test)
                {
                    NewInfo.test_ID = (int)appointment_Information_Class.Test.Practical_driving_test;
                    NewInfo.result_ID = (int)appointment_Information_Class.Results.Pending;
                    NewInfo.AppoinementDate = PrivateTime;
                    NewManagement.Update_Appointment_For_Pass(NewInfo);
                    return true;


                }
                else if(TestTypeID == (int)appointment_Information_Class.Test.Practical_driving_test)
                {
                    //في هذه الحالة يتم اصدار رخصة السياقة لهذا السائق

                    int DriverID = -1;

                    NewInfo.result_ID = (int)appointment_Information_Class.Results.Pass;

                    if(NewManagement.Update_Appointment_For_Complet_all_Exam(NewInfo))
                    {
                        cls_Drivers DriverManagement = new cls_Drivers();
                        drive_license_Information_Class NewLicense = new drive_license_Information_Class();
                        cls_Licenses_Loc_Inte AddNewLicenseManagement = new cls_Licenses_Loc_Inte();
                        cls_Orders NewStatus = new cls_Orders();

                        if(DriverManagement.IfThisPersonIsDriver(PersonID))
                        {
                            DriverID = DriverManagement.ReturnDriverID(PersonID);
                        }
                        else
                        {
                            DriverID = DriverManagement.AddNewDriver(PersonID);
                        }

                        NewLicense.Driver_ID = DriverID;
                        NewLicense.Relese_Date = DateTime.Now;
                        NewLicense.Comment = NewInfo.notes;
                        NewLicense.Category_ID = orderInformation_management.Get_CategoryID_By_OrderID(OrderID);
                        NewLicense.End_Date = DateTime.Now.AddYears(cls_Categorys.Get_Category_Validity_By_CategoryID(NewLicense.Category_ID));

                        AddNewLicenseManagement.AddNewLocalLicense(NewLicense, ref NewLicenseID);
                        NewStatus.UpdateOrderStatus(OrderID, orders_Information_Class.order_status.completed);
                        return true;

                    }


                }

                else { return false; }

               if( NewManagement.Update_Appointment_For_Pass(NewInfo))
                {

                }


            }


            else if(ResultID == (int)appointment_Information_Class.Results.Fail)
            {

               if(NewManagement.Update_Appointment_For_Failed(AppointementID, (int)appointment_Information_Class.Results.Fail))
                {
                    return true;
                }
                return false;
                
            }
            else
            {
                return false;
            }

            return false;
        }

        public bool AddAppointement(int OrderInformatioID )
        {

            appointment_Information_Class NewInfo = new appointment_Information_Class();

            NewInfo.AppoinementDate = PrivateTime;
            NewInfo.result_ID = (int)appointment_Information_Class.Results.Pending;
            NewInfo.notes = null;
            NewInfo.test_ID = (int)appointment_Information_Class.Test.Eye_test;
            NewInfo.order_information_ID = OrderInformatioID;

            appointment_management NewManagement = new appointment_management();
            return NewManagement.Add_Appointment(NewInfo);

        }


    }
}
