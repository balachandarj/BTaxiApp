using Microsoft.AspNetCore.Mvc;
using TaxiApi.Models;

namespace TaxiApi.Controllers
{
    [ApiController]
    [Route("[UserController]")]
    public class UserController : ControllerBase
    {
        private List<User> _users = new List<User>();


        //[HttpPost]
        //[Route("AddUser")]
        //public string AddUser(User user)
        //{
        //    _users.Add(user);
        //    return "Success";
        //}

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
