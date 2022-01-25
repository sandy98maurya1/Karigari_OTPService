using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class ApplicationDbContext
    {
        public static string GetConnectionString(string name = "DefaultConnectionString")
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
            //return _configuration.GetSection("ConnectionStrings").GetSection("ProductContext").Value;
        }
    }
}
