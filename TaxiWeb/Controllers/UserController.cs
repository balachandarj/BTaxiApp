using Microsoft.AspNetCore.Mvc;
using TaxiModel.Models;

namespace TaxiWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly ApiService _apiService;

        public UserController(ApiService apiService)
        {
            _apiService = apiService;
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Call the external API to create the user
                bool success = await _apiService.CreateUserAsync(user);
                if (success)
                {
                    // Handle success, e.g., show a success message
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Handle failure, e.g., show an error message
                    ModelState.AddModelError(string.Empty, "Error creating the user.");
                }               
            }
            return View(user);
        }
    }
}
