using System;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.API.BusinessLogic.Interfaces;
using WeatherApp.API.BusinessModel;
using WeatherApp.API.BusinessModel.Common;
using WeatherApp.API.BusinessModel.Weather;
using WeatherApp.API.Configurations.Interfaces;
using WeatherApp.API.Services.Interfaces;

namespace WeatherApp.API.BusinessLogic
{
    public class WeatherBusinessLogic : IWeatherBusinessLogic
    {
        public IWeatherService _weatherService;
        public IAutoMapper _autoMapper;

        public WeatherBusinessLogic(
            IWeatherService weatherService,
            IAutoMapper autoMapper)
        {
            _weatherService = weatherService;
            _autoMapper = autoMapper;
        }

        public Result<List<WeatherItem>> GetWeather(WeatherRequest request)
        {
            var result = new Result<List<WeatherItem>> {
                ErrorMessage = string.Empty
            };

            var defaultDate = default(DateTime);

            var dmReq = _autoMapper.Map<WeatherRequest, 
                DataModel.Weather.WeatherRequest>(request);

            var dmRes = _weatherService.GetWeather(dmReq);

            if (string.IsNullOrEmpty(dmRes.ErrorMessage))
            {
                result.Data = new List<WeatherItem>();

                var response = _autoMapper
                    .Map<DataModel.Weather.WeatherApiResponse,
                    WeatherApiResponse>(dmRes);

                var dates = response.List
                    .GroupBy(date => date.Dt_Txt.Date)
                    .Select(grp => grp.First().Dt_Txt.Date)
                    .ToList();

                if (request.Start.Date == defaultDate.Date
                    && request.End.Date == defaultDate.Date)
                    request.End = DateTime.Now;

                dates = dates.Where(x => x.Date >= request
                .Start && x.Date <= request.End).ToList();

                foreach (var date in dates)
                {
                    var weatherList = response.List
                        .Where(w => w.Dt_Txt.Date == date)
                        .ToList();

                    var weatherItem = new WeatherItem
                    {
                        Date = date,
                        WeatherInfo = new List<WeatherInfo>()
                    };

                    foreach (var weather in weatherList)
                    {
                        weatherItem.WeatherInfo.Add(new WeatherInfo
                        {
                            Date = weather.Dt_Txt,
                            Description = weather.Weather
                            .FirstOrDefault().Description,
                            Icon = weather.Weather.FirstOrDefault().Icon,
                            MinTemp = (int)weather.Main.Temp_Min,
                            MaxTemp = (int)weather.Main.Temp_Max
                        });
                    }

                    result.Data.Add(weatherItem);
                }
            }
            else
            {
                result.ErrorMessage = dmRes.ErrorMessage;
            }

            return result;
        }
    }
}
