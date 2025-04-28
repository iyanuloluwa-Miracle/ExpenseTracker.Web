using System.Net.Http.Json;
using Client.DTOs.Category;

namespace Client.Services
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "api/category";

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryResponse>> GetCategoriesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<CategoryResponse>>(BaseUrl);
            return response ?? Enumerable.Empty<CategoryResponse>();
        }

        public async Task<CategoryResponse> CreateCategoryAsync(CreateCategoryRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CategoryResponse>() 
                ?? throw new InvalidOperationException("Failed to create category");
        }

        public async Task<CategoryResponse> UpdateCategoryAsync(string id, CreateCategoryRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CategoryResponse>() 
                ?? throw new InvalidOperationException("Failed to update category");
        }

        public async Task DeleteCategoryAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
} 