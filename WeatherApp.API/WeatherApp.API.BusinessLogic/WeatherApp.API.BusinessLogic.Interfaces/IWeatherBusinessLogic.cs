using System.Collections.Generic;
using WeatherApp.API.BusinessModel.Common;
using WeatherApp.API.BusinessModel.Weather;

namespace WeatherApp.API.BusinessLogic.Interfaces
{
    public interface IWeatherBusinessLogic
    {
        Result<List<WeatherItem>> GetWeather(WeatherRequest request);
    }
}
