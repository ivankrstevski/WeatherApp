using System;
using System.Collections.Generic;
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

        public AppUser Get(string userName)
        {
            try
            {
                var result = _userRepository.Get(userName);

                return result;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public List<string> Save(AppUser customer, string password)
        {
            try
            {
                var result = _userRepository.Save(customer, password);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
