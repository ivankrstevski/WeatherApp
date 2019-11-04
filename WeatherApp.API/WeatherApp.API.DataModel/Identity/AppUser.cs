using Microsoft.AspNet.Identity.EntityFramework;

namespace WeatherApp.API.DataModel.Identity
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
