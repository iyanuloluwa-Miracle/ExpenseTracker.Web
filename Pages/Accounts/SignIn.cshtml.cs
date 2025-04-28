using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Client.Services;
using Client.DTOs.Auth;
using System.ComponentModel.DataAnnotations;

namespace Client.Pages.Account
{
    public class SignInModel : PageModel
    {
        private readonly AuthService _authService;

        [BindProperty]
        public LoginRequest Input { get; set; } = new();

        [BindProperty]
        public bool RememberMe { get; set; }

        [TempData]
        public string? ErrorMessage { get; set; }

        public SignInModel(AuthService authService)
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
                var response = await _authService.LoginAsync(Input);
                
                // Store token in secure cookie
                Response.Cookies.Append("AuthToken", response.Token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = RememberMe ? DateTime.Now.AddDays(30) : null
                });

                return RedirectToPage("/Index");
            }
            catch
            {
                ErrorMessage = "Invalid login attempt.";
                return Page();
            }
        }
    }
}