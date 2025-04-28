using System.ComponentModel.DataAnnotations;

namespace Client.DTOs.Category
{
    public class CreateCategoryRequest
    {
        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [RegularExpression("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "Please enter a valid hex color code.")]
        public string Color { get; set; } = string.Empty;
    }
} 