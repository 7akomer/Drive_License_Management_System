using Driver_License_System__Models;
using Driver_License_System_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System_BLL
{
    public  class cls_HomeScreen
    {
        public home_Information_Class GetNewHomeInformation()
        {
            order_management NewManagement = new order_management();
            List <orders_Information_Class> NewFees = new List<orders_Information_Class>();
            List<orders_Information_Class> TodayFees = new List<orders_Information_Class>();
            List<orders_Information_Class> YasterdayFees = new List<orders_Information_Class>();


            home_Information_Class HomeManage = new home_Information_Class();



            NewFees = NewManagement.Get_Orders_TotalFees_List();
            TodayFees = NewManagement.Get_Orders_TotalFees_Today_List();
            YasterdayFees = NewManagement.Get_Orders_TotalFees_Yasterday_List();

            if (NewFees == null)
            {
                HomeManage.TotalApplication = 0;
                HomeManage.TotalFees = 0;
                HomeManage.DefFromLastDayFees = 0;
                HomeManage.IfTodayCountApplicationWin = true;
                HomeManage.IfTodayFeesWin = true;
                HomeManage.DefTotalApplicationFromLastDay = 0;
                HomeManage.IfTotaleLicensesIssudWin = true;
                HomeManage.TotaleLicensesIssud = 0;
                HomeManage.Active = 0;
                HomeManage.Expiry = 0;
                HomeManage.Pending = 0;
                HomeManage.LicensesPendingCount = 0;
                HomeManage.IfLicensesPendingWin = true;
                HomeManage.LicensesPendingFromLastDay = 0;
                HomeManage.DefTotalLicensesFromLastDay = 0;



                return HomeManage;
            }
            else
            {
                Decimal Total_Fees = 0;
                Decimal Today_Fees = 0;
                Decimal Yaster_dayFees = 0;

                HomeManage.TotalApplication = NewFees.Count();



                try
                {
                    for (int i = 0; i < NewFees.Count; i++)
                    {
                        Total_Fees += NewFees[i].Application_fee_paid;
                    }
                }
                catch

                {
                    Total_Fees = 0;
                }

                HomeManage.TotalFees = Total_Fees;


                try
                {

                    for (int i = 0; i < TodayFees.Count; i++)
                    {
                        Today_Fees += TodayFees[i].Application_fee_paid;
                    }
                }
                catch
                {
                    Today_Fees = 0;
                }


                try
                {
                    for (int i = 0; i < YasterdayFees.Count; i++)
                    {
                        Yaster_dayFees += YasterdayFees[i].Application_fee_paid;
                    }
                }
                catch
                {
                    Yaster_dayFees = 0;
                }

                if (Yaster_dayFees <= Today_Fees)
                {
                    HomeManage.DefFromLastDayFees = (Today_Fees - Yaster_dayFees) * 10;
                    HomeManage.IfTodayFeesWin = true;

                }
                else
                {
                    HomeManage.DefFromLastDayFees = (Yaster_dayFees - Today_Fees) * 10;
                    HomeManage.IfTodayFeesWin = false;
                }

                if(YasterdayFees.Count() <= TodayFees.Count())
                {
                    HomeManage.DefTotalApplicationFromLastDay = (TodayFees.Count() - YasterdayFees.Count()) * 10;

                    HomeManage.IfTodayCountApplicationWin = true;
                }
                else
                {
                    HomeManage.DefTotalApplicationFromLastDay = (YasterdayFees.Count()  - TodayFees.Count()) * 10;

                    HomeManage.IfTodayCountApplicationWin = false;
                }


            }



            HomeManage.LicensesPendingCount = NewManagement.GetNumberOfLicensesPending();

            int TodayPending = 0;
            int YasterdayPending = 0;

            TodayPending = NewManagement.GetNumberOfLicensesPending_Today();
            YasterdayPending = NewManagement.GetNumberOfLicensesPending_Yasterday();

            if(YasterdayPending <= TodayPending)
            {
                HomeManage.LicensesPendingFromLastDay = (TodayPending - YasterdayPending) *10;
                HomeManage.IfLicensesPendingWin = true;
            }
            else
            {
                HomeManage.LicensesPendingFromLastDay = (YasterdayPending  - TodayPending) * 10;

                HomeManage.IfLicensesPendingWin = false;

            }

            HomeManage.Expiry = drive_license_management.GetNumberOfExpiry_Licenses();
            HomeManage.Active = drive_license_management.GetNumberOfActive_Licenses();
            HomeManage.Pending = HomeManage.LicensesPendingCount;

            drive_license_management NewLicenseManagement = new drive_license_management();

            HomeManage.TotaleLicensesIssud = NewLicenseManagement.GetNumberOfIssue_Licenses();

            int TodayIssued = 0;
            int YasterdayIssued = 0;

            TodayIssued = NewLicenseManagement.GetNumberOfIssue_Licenses_Today();
            YasterdayIssued = NewLicenseManagement.GetNumberOfIssue_Licenses_Yasterday();

            if (YasterdayIssued <= TodayIssued)
            {
                HomeManage.DefTotalLicensesFromLastDay = (TodayIssued - YasterdayIssued) * 10;
                HomeManage.IfTotaleLicensesIssudWin = true;
            }
            else
            {
                HomeManage.DefTotalLicensesFromLastDay = (YasterdayIssued - TodayIssued) * 10;

                HomeManage.IfTotaleLicensesIssudWin = false;

            }






            return HomeManage;



        }



    }
}
