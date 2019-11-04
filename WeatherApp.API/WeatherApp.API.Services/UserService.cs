using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.API.DataModel.Identity;
using WeatherApp.API.Repositories.Interfaces;
using WeatherApp.API.Services.Interfaces;

namespace WeatherApp.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<string> Save(AppUser customer, string password)
        {
            var result = _userRepository.Save(customer, password);

            return result;
        }
    }
}
