using Microsoft.AspNetCore.Mvc;
using TaxiModel.Models;

namespace TaxiApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private List<User> _users = new List<User>();  
        private TaxiDataAccess _dataAccess = new TaxiDataAccess();


        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {
            _dataAccess.AddUser(user);            
            return Ok(user);
        }

        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser()
        {
            var users = _dataAccess.GetUsers();
            return Ok(users);
        }

    }
}
