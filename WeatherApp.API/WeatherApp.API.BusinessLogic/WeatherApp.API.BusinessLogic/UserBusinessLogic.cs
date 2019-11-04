using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.API.BusinessLogic.Interfaces;
using WeatherApp.API.BusinessModel.Identity;
using WeatherApp.API.Configurations.Interfaces;
using WeatherApp.API.Services.Interfaces;

namespace WeatherApp.API.BusinessLogic
{
    public class UserBusinessLogic : IUserBusinessLogic
    {
        private readonly IUserService _userService;
        private readonly IAutoMapper _autoMapper;

        public UserBusinessLogic(
            IUserService userService,
            IAutoMapper autoMapper)
        {
            _userService = userService;
            _autoMapper = autoMapper;
        }

        public List<string> Create(AppUser customer, string password)
        {
            var dmReq = _autoMapper.Map<AppUser,
                DataModel.Identity.AppUser>(customer);

            var response = _userService.Save(dmReq, password);

            return response;
        }
    }
}
