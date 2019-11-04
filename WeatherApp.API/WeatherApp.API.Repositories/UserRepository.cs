using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.API.DataModel.Identity;
using WeatherApp.API.Repositories.Common;
using WeatherApp.API.Repositories.Interfaces;

namespace WeatherApp.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationUserManager _appUserManager;

        public UserRepository(ApplicationUserManager appUserManager)
        {
            _appUserManager = appUserManager;
        }

        public List<string> Save(AppUser userIdentity, string password)
        {
            List<string> result = null;

            try
            {
                result = _appUserManager.Create(userIdentity, password).Errors.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}
