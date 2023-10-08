using Microsoft.AspNetCore.Mvc;
using TaxiApi.Models;

namespace TaxiApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private List<User> _users = new List<User>();       

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {
            _users.Add(user);
            return Ok(user);
        }

        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser()
        {
            var user = new User() { FirstName="Balachandar", 
                LastName="Jeganathan", 
                Email="balachandar@gmail.com",
                Phone="9034267303"
            };
            return Ok(user);
        }

    }
}
