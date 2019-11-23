using System.Collections.Generic;
using WeatherApp.API.BusinessModel.Common;
using WeatherApp.API.BusinessModel.Identity;

namespace WeatherApp.API.BusinessLogic.Interfaces
{
    public interface IUserBusinessLogic
    {
        List<string> Create(AppUser customer, string password);
        Result<UserInfo> Get(string userName);
    }
}
