using System.ComponentModel.DataAnnotations;

namespace ProductTaskCRUD.Models.ViewModels
{
    public class ProductViewModel
    {
            [Required]
            public string? Name { get; set; }

            [Required]
            public string? Description { get; set; }

            [Required]
            public string? Category { get; set; }

            [Required]
            public decimal Price { get; set; }

            [Required]
            public int Count { get; set; }

            public string? ImageLink { get; set; } = null;
    }
}
