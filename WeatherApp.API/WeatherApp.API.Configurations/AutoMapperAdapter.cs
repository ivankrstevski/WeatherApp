using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.API.Configurations.Interfaces;

namespace WeatherApp.API.Configurations
{
    public class AutoMapperAdapter : IAutoMapper
    {
        public T Map<T>(object objectToMap)
        {
            return Mapper.Map<T>(objectToMap);
        }

        public T1 Map<T, T1>(T objectToMap)
        {
            return Mapper.Map<T, T1>(objectToMap);
        }
    }
}
