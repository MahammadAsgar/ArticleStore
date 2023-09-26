﻿using Microsoft.Extensions.Configuration;

namespace ArticleStore.Application.Config
{
    public static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ArticleStore.API"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("BaseConnection");
            }
        }
    }
}
