using System.Collections.Generic;
using WeatherApp.API.DataModel.Identity;

namespace WeatherApp.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<string> Save(AppUser customer, string password);
        AppUser Get(string userName);
    }
}
