using Newtonsoft.Json;
using TaxiModel.Models;

namespace TaxiWeb
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // Set the base URL of the external API
            _httpClient.BaseAddress = new Uri("https://localhost:7165");
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                // Serialize the User object to JSON
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");

                // Make a POST request to the external API               
                var response = await _httpClient.PostAsync("/User/AddUser", content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Handle errors here, e.g., log the response content
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error from external API: {errorResponse}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }


        public async Task<List<User>> GetUserAsync()
        {
            try
            {
                
                // Make a Get request to the external API               
                var response = await _httpClient.GetAsync("/User/GetUser");

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonContent);
                    return users;
                }
                else
                {
                    // Handle errors here, e.g., log the response content
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error from external API: {errorResponse}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

    }
}
