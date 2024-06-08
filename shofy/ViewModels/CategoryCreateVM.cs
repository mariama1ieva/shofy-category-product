using System.ComponentModel.DataAnnotations;

namespace shofy.ViewModels
{
    public class CategoryCreateVM
    {
        [Required]
        public string Name { get; set; }


        [Required]

        public IFormFile Image { get; set; }
    }
}
