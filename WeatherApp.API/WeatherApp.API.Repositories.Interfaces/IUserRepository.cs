using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.API.DataModel.Identity;

namespace WeatherApp.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<string> Save(AppUser customer, string password);
    }
}
