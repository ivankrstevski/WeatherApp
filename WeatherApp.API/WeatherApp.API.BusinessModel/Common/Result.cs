using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.API.BusinessModel.Common
{
    public class Result<T>
    {
        public string ErrorMessage { get; set; }
        public T Data;
    }
}
