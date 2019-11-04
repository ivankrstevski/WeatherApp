using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.API.DataModel
{
    public class ListItem
    {
        public DateTime Dt { get; set; }

        public List<Weather> Weather;
    }
}
