﻿using Microsoft.Extensions.Configuration;
using System.IO;

namespace Data.Context
{
    public class DatabaseConnection
    {
        public static IConfiguration ConnectionConfiguration
        {
            get
            {
                IConfigurationRoot Configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                return Configuration;
            }
        }
    }
}
