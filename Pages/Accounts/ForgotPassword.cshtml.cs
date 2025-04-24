using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExpenseTracker.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Static data validation
                if (Input.Email == "demo@example.com")
                {
                    // Simulate successful password reset request
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                // Don't reveal that the user does not exist
                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }
    }
}