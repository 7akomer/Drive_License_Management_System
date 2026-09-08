using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_License_System__Models
{
    public class home_Information_Class
    {
        public decimal TotalFees { get; set; }
        public Decimal DefFromLastDayFees { get; set; } 


        public int TotalApplication {  get; set; }

        public int DefTotalApplicationFromLastDay {  get; set; }

        public bool IfTodayFeesWin { get; set; }
        public bool IfTodayCountApplicationWin { get; set; }


        public int LicensesPendingCount { get; set; }

        public int LicensesPendingFromLastDay { get; set; }

        public bool IfLicensesPendingWin { get; set; }

        public int TotaleLicensesIssud {  get; set; }

        public bool IfTotaleLicensesIssudWin { get; set; }


        public int DefTotalLicensesFromLastDay { get; set; }

        public int Pending {  get; set; }
        public int Expiry { get; set; }

        public int Active { get; set; }


    }
}
