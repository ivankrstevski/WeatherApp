﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.API.DataModel.Weather
{
    public class WeatherRequest
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Count { get; set; }
    }
}
