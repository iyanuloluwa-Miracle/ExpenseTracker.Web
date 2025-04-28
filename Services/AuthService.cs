using System.Net.Http.Json;
using Client.DTOs.Auth;

namespace Client.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "api/auth";

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/login", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<LoginResponse>() 
                ?? throw new InvalidOperationException("Failed to deserialize login response");
        }

        public async Task RegisterAsync(SignupRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/signup", request);
            response.EnsureSuccessStatusCode();
        }

        public async Task ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/forgot-password", request);
            response.EnsureSuccessStatusCode();
        }

        public async Task ResetPasswordAsync(ResetPasswordRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/reset-password", request);
            response.EnsureSuccessStatusCode();
        }

        public async Task VerifyEmailAsync(string token)
        {
            var request = new { Token = token };
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/verify-email", request);
            response.EnsureSuccessStatusCode();
        }
    }
}