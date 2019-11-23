using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using System.Web.Http;
using Unity;
using WeatherApp.API.BusinessLogic;
using WeatherApp.API.BusinessLogic.Interfaces;
using WeatherApp.API.Configurations;
using WeatherApp.API.Configurations.Interfaces;
using WeatherApp.API.DataModel.Identity;
using WeatherApp.API.Repositories;
using WeatherApp.API.Repositories.Common;
using WeatherApp.API.Repositories.Interfaces;
using WeatherApp.API.Services;
using WeatherApp.API.Services.Interfaces;

namespace WeatherApp.API.DI
{
    public static class UnityAdapter
    {
        public static UnityResolver Resolve(HttpConfiguration config)
        {
            var container = new UnityContainer();

            container.RegisterType<HistoryContext, MySqlHistoryContext>();
            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType<IUserStore<AppUser>, UserStore<AppUser>>();

            // AutoMapper
            container.RegisterType<IAutoMapper, AutoMapperAdapter>();
            container.RegisterType<IAutoMapperConfigurator, CommonMappings>();
            var classes = container.Resolve<IEnumerable
                <IAutoMapperConfigurator>>();
            new AutoMapperConfigurator().Configure(classes);

            //Repositories
            container.RegisterType<IUserRepository, UserRepository>();

            // Services
            container.RegisterType<IWeatherService, WeatherService>();
            container.RegisterType<IConfigurationService, ConfigurationService>();
            container.RegisterType<IUserService, UserService>();

            // BusinessLogic
            container.RegisterType<IWeatherBusinessLogic, WeatherBusinessLogic>();
            container.RegisterType<IUserBusinessLogic, UserBusinessLogic>();

            var resolver = new UnityResolver(container);

            return resolver;
        }
    }
}
