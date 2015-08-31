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
    public abstract class DataService<T>
    {
       protected SqlConnection conn;
       protected string dbconnection = ConfigurationManager.AppSettings.Get("connectionString");
       protected SqlCommand comm;
       protected SqlDataReader reader;
       protected List<T> ObjectList(SqlDataReader reader)
       {
           List<T> objectlist = new List<T>();
           List<PropertyInfo> properties = typeof(T).GetProperties().ToList();
           if (properties != null)
           {
               while (reader.Read())
               {
                   var item = Activator.CreateInstance<T>();
                   foreach (PropertyInfo property in properties)
                   {
                       if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                       {
                           Type convertTo = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                           var value = Convert.ChangeType(reader[property.Name], convertTo);
                           property.SetValue(item, value, null);
                       }
                   }
                   objectlist.Add(item);
               }
               return objectlist;
           }
           return null;
       }
       

    }
}
