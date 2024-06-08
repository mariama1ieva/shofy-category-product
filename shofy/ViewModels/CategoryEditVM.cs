using System.ComponentModel.DataAnnotations;

namespace shofy.ViewModels
{
    public class CategoryEditVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public IFormFile Photo { get; set; }

        public string? Image { get; set; }
    }
}
