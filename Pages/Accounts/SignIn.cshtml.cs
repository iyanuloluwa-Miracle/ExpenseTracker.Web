using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExpenseTracker.Pages.Account
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }

        public IActionResult OnPost()
        {
            // Static data for demonstration
            if (Email == "demo@example.com" && Password == "Demo123!")
            {
                // Simulate successful login
                return RedirectToPage("/Index");
            }

            // Add error message for invalid credentials
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
}