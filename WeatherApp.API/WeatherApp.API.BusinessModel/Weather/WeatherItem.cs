using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.API.BusinessModel.Weather
{
    public class WeatherItem
    {
        public DateTime Date { get; set; }
        public List<WeatherInfo> WeatherInfo { get; set; }
    }
}
