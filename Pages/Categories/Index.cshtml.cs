using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Client.Services;
using Client.DTOs.Category;
using System.ComponentModel.DataAnnotations;

namespace Client.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly CategoryService _categoryService;

        public IndexModel(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IEnumerable<CategoryResponse> Categories { get; set; } = Enumerable.Empty<CategoryResponse>();

        public async Task OnGetAsync()
        {
            Categories = await _categoryService.GetCategoriesAsync();
        }

        public async Task<IActionResult> OnPostAsync([FromForm] CreateCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _categoryService.CreateCategoryAsync(request);
                return RedirectToPage();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Error creating category. Please try again.");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostEditAsync(string id, [FromForm] CreateCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _categoryService.UpdateCategoryAsync(id, request);
                return RedirectToPage();
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Error updating category. Please try again.");
                return Page();
            }
        }

        public async Task<IActionResult> OnDeleteAsync(string id)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(id);
                return new OkResult();
            }
            catch
            {
                return new BadRequestResult();
            }
        }
    }
} 