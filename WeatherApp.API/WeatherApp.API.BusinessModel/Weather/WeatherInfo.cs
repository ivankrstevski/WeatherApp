using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.API.BusinessModel.Weather
{
    public class WeatherInfo
    {
        public DateTime Date { get; set; }
        public int MinTemp { get; set; }
        public int MaxTemp { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
