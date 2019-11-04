using WeatherApp.API.DataModel.Weather;

namespace WeatherApp.API.Services.Interfaces
{
    public interface IWeatherService
    {
        WeatherApiResponse GetWeather(WeatherRequest request);
    }
}
