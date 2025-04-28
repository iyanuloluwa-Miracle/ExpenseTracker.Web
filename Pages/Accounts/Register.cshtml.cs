using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Client.Services;
using Client.DTOs.Auth;

namespace Client.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly AuthService _authService;

        [BindProperty]
        public SignupRequest Input { get; set; } = new();

        [TempData]
        public string? ErrorMessage { get; set; }

        public RegisterModel(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _authService.RegisterAsync(Input);
                return RedirectToPage("./RegisterConfirmation");
            }
            catch
            {
                ErrorMessage = "Error registering user. Please try again.";
                return Page();
            }
        }
    }
}