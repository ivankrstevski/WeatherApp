using System;
using System.Collections.Generic;
using WeatherApp.API.BusinessLogic.Interfaces;
using WeatherApp.API.BusinessModel.Common;
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
            try
            {
                var dmReq = _autoMapper.Map<AppUser,
                    DataModel.Identity.AppUser>(customer);

                var response = _userService.Save(dmReq, password);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result<UserInfo> Get(string userName)
        {
            var result = new Result<UserInfo>
            {
                ErrorMessage = string.Empty
            };

            try
            {
                var user = _userService.Get(userName);

                var userInfo = _autoMapper
                    .Map<DataModel.Identity.AppUser, 
                    UserInfo>(user);

                result.Data = userInfo;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
