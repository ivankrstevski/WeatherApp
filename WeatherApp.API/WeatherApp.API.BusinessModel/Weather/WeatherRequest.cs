﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.API.BusinessModel.Weather
{
    [Serializable]
    public class WeatherRequest
    {
        [Required]
        public string CityName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
