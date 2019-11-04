using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using WeatherApp.API.Services.Interfaces;

namespace WeatherApp.API.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public string GetFromAppSettings(string key)
        {
            var item = WebConfigurationManager.AppSettings[key];

            return item;
        }
    }
}
