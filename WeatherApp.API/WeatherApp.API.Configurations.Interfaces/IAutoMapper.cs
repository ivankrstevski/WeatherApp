using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.API.Configurations.Interfaces
{
    public interface IAutoMapper
    {
        T Map<T>(object objectToMap);
        T1 Map<T, T1>(T objectToMap);
    }
}
