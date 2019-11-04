using Microsoft.Owin;
using Owin;
using System.Web.Http;
using WeatherApp.API.DI.Providers;

[assembly: OwinStartup(typeof(WeatherApp.API.Startup))]
namespace WeatherApp.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();

            ConfigureOauth.Configure(app);

            WebApiConfig.Register(httpConfig);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseWebApi(httpConfig);
        }
    }
}