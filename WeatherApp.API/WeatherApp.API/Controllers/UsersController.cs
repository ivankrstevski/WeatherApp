using System.Web.Http;
using WeatherApp.API.BusinessLogic.Interfaces;
using WeatherApp.API.BusinessModel.Identity;

namespace WeatherApp.API.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserBusinessLogic _userBusinessLogic;

        public UsersController(IUserBusinessLogic userBusinessLogic)
        {
            _userBusinessLogic = userBusinessLogic;
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] AppUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _userBusinessLogic.Create(user, user.Password);

            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri] string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return BadRequest();
            }

            var result = _userBusinessLogic.Get(userName);

            return Ok(result);
        }
    }
}