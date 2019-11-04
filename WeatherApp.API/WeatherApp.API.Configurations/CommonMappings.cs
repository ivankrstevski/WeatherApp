using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.API.Configurations.Interfaces;
using WeatherApp.API.DataModel;
using WeatherApp.API.DataModel.Identity;
using WeatherApp.API.DataModel.Weather;

namespace WeatherApp.API.Configurations
{
    public class CommonMappings : IAutoMapperConfigurator
    {
        public void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<BusinessModel.Weather.WeatherRequest, WeatherRequest>();
                config.CreateMap<BusinessModel.Weather.WeatherApiResponse, WeatherApiResponse>();
                config.CreateMap<BusinessModel.Identity.AppUser, AppUser>();
            });
        }
    }
}
