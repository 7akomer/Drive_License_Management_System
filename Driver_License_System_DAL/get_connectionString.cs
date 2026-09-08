using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Driver_License_System_DAL
{
    internal class get_connectionString
    {
        public get_connectionString() { }


        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
    }
}
