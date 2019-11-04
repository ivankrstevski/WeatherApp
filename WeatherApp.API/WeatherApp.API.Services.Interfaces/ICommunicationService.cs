using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.API.Services.Interfaces
{
    public interface ICommunicationService
    {
        Task<object> Get(object request);
    }
}
