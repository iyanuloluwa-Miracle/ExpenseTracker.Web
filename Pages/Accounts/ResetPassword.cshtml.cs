using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Client.Services;
using Client.DTOs.Auth;

namespace Client.Pages.Account
{
    public class ResetPasswordModel : PageModel
    {
        private readonly AuthService _authService;

        [BindProperty]
        public ResetPasswordRequest Input { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? Token { get; set; }

        [TempData]
        public string? ErrorMessage { get; set; }

        public ResetPasswordModel(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult OnGet(string? token = null)
        {
            if (token == null)
            {
                return BadRequest("A token must be supplied for password reset.");
            }
            else
            {
                Input.Token = token;
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _authService.ResetPasswordAsync(Input);
                return RedirectToPage("./ResetPasswordConfirmation");
            }
            catch
            {
                ErrorMessage = "Error resetting password. Please try again.";
                return Page();
            }
        }
    }
}