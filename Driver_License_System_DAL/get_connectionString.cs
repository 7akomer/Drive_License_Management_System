using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Driver_License_System_DAL
{
    internal class get_connectionString
    {
        public get_connectionString() { }
        public static string connectionString = "server=.;Database=drive_license;user id=sa;password=123456;TrustServerCertificate=true;";
    }
}
