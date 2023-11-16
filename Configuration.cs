using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocket
{
    public class Configuration
    {
        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json");

            IConfiguration configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("MyDatabase");

            return connectionString;
        }
    }
}
