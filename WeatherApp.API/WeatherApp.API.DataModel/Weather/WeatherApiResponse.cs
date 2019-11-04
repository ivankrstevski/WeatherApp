using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.API.DataModel.Weather
{
    public class WeatherApiResponse
    {
        public string Country { get; set; }
        public float Message { get; set; }
        public int Cnt { get; set; }
        public List<ListItem> List { get; set; }
        public string ErrorMessage { get; set; }
    }
}
