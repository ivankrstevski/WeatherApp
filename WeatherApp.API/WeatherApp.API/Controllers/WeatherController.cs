using System.Web.Http;
using WeatherApp.API.BusinessLogic.Interfaces;
using WeatherApp.API.BusinessModel.Weather;

namespace WeatherApp.API.Controllers
{
    [Authorize]
    public class WeatherController : ApiController
    {
        private readonly IWeatherBusinessLogic _weatherBusinessLogic;

        public WeatherController(IWeatherBusinessLogic weatherBusinessLogic)
        {
            _weatherBusinessLogic = weatherBusinessLogic;
        }

        public IHttpActionResult Get([FromUri] WeatherRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result  = _weatherBusinessLogic
                .GetWeather(request);

            return Ok(result);
        }
    }
}