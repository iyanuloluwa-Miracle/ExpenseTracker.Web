using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Client.Services;
using Client.DTOs.Auth;

namespace Client.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly AuthService _authService;

        [BindProperty]
        public ForgotPasswordRequest Input { get; set; } = new();

        [TempData]
        public string? StatusMessage { get; set; }

        public ForgotPasswordModel(AuthService authService)
        {
            _authService = authService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _authService.ForgotPasswordAsync(Input);
                StatusMessage = "If your email is registered, you will receive a password reset link.";
                return RedirectToPage();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Error sending reset link. Please try again.");
                return Page();
            }
        }
    }
}