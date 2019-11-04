using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.API.BusinessModel.Weather
{
    public class ListItem
    {
        public string Dt { get; set; }
        public Main Main { get; set; }
        public List<Weather> Weather { get; set; }
        public DateTime Dt_Txt { get; set; }
    }
}
