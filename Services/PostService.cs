using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using blazor_post_management.Models;

namespace blazor_post_management.Services
{
    public class PostService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://jsonplaceholder.typicode.com";

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Post>> FetchPostsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Post>>($"{ApiUrl}/posts");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error fetching posts", ex);
            }
        }

        public async Task<bool> DeletePostAsync(int postId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{ApiUrl}/posts/{postId}");

                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error deleting post", ex);
            }
        }

        public async Task<bool> UpdatePostAsync(int id, Post post)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}/posts/{id}", post);

                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error updating post", ex);
            }
        }

        public async Task<(bool IsSuccess, Post CreatedPost)> CreatePostAsync(Post post)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{ApiUrl}/posts", post);

                response.EnsureSuccessStatusCode();
                var createdPost = await response.Content.ReadFromJsonAsync<Post>();
                return (response.IsSuccessStatusCode, createdPost);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error creating post", ex);
            }
        }

    }
}

