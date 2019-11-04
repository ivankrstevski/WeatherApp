using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.API.BusinessModel.Weather
{
    public class Main
    {
        public decimal Temp { get; set; }
        public decimal Temp_Min { get; set; }
        public decimal Temp_Max { get; set; }
        public decimal Pressure { get; set; }
        public decimal Sea_Level { get; set; }
        public decimal Grnd_Level { get; set; }
        public int Humidity { get; set; }
        public decimal Temp_Kf { get; set; }
    }
}
