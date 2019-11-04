using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.API.Configurations.Interfaces;

namespace WeatherApp.API.Configurations
{
    public class AutoMapperConfigurator
    {
        public void Configure(IEnumerable<object> autoMapperConfigurations)
        {
            var data = autoMapperConfigurations as IEnumerable;
            var mappings = data.Cast<IAutoMapperConfigurator>();
            mappings.ToList().ForEach(x => x.Configure());
        }
    }
}
