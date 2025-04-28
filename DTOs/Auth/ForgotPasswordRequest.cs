// ForgotPasswordRequest.cs
using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.Auth
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}