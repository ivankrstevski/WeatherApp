using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.API.DataModel.Identity;

namespace WeatherApp.API.Services.Interfaces
{
    public interface IUserService
    {
        List<string> Save(AppUser customer, string password);
    }
}
