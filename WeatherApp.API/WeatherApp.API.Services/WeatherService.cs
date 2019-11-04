using System;
using WeatherApp.API.DataModel.Weather;
using WeatherApp.API.Services.Interfaces;

namespace WeatherApp.API.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IConfigurationService _configurationService;
        private readonly CommunicationService _communicationService;
        private readonly string appID;

        public WeatherService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;

            var weatherApiBaseAdress = _configurationService
                .GetFromAppSettings("weatherApiBaseAdress");

            appID = _configurationService.GetFromAppSettings("weatherApiAppID");

            _communicationService = new CommunicationService(weatherApiBaseAdress);
        }

        public WeatherApiResponse GetWeather(WeatherRequest request)
        {
            var weatherApiResponse = new WeatherApiResponse
            {
                ErrorMessage = string.Empty
            };

            var response = _communicationService
                .Get<WeatherApiResponse>(
                $"forecast?q={request.CityName}" +
                $"&units=metric" +
                $"&APPID={appID}");

            if (response.Exception != null)
            {
                weatherApiResponse.ErrorMessage = response.Exception.InnerException.Message;
            }
            else
            {
                weatherApiResponse = response.Result;
            }

            return weatherApiResponse;
        }
    }
}
