using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

using blazor_post_management.Models;

namespace blazor_post_management.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://jsonplaceholder.typicode.com";

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> FetchUsersAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<User>>($"{ApiUrl}/users");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error fetching users", ex);
            }
        }
    }
}
