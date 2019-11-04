using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.API.BusinessModel.Identity;

namespace WeatherApp.API.BusinessLogic.Interfaces
{
    public interface IUserBusinessLogic
    {
        List<string> Create(AppUser customer, string password);
    }
}
