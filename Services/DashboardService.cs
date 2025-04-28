using System.Net.Http.Json;
using Client.DTOs.Dashboard;

namespace Client.Services
{
    public class DashboardService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "api/dashboard";

        public DashboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DashboardSummaryResponse> GetSummaryAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<DashboardSummaryResponse>($"{BaseUrl}/summary");
            return response ?? new DashboardSummaryResponse();
        }

        public async Task<IEnumerable<CategorySummaryResponse>> GetCategorySummaryAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<CategorySummaryResponse>>($"{BaseUrl}/reports/category-summary");
            return response ?? Enumerable.Empty<CategorySummaryResponse>();
        }

        public async Task<IEnumerable<MonthlySummaryResponse>> GetMonthlySummaryAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<MonthlySummaryResponse>>($"{BaseUrl}/reports/monthly-summary");
            return response ?? Enumerable.Empty<MonthlySummaryResponse>();
        }
    }
} 