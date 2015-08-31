using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebApi
{
    public abstract class BaseDataService
    {
       protected SqlConnection conn;
       protected string dbconnection = ConfigurationManager.AppSettings.Get("connectionString");
       protected SqlCommand comm;
       protected SqlDataReader reader;
    }
}
