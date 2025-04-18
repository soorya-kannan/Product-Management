using System.ComponentModel.DataAnnotations;

namespace ProductManagement.API.DTO
{
    public class ProductCreateDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        [Range(0, double.MaxValue)]  // To make sure price is valid
        public decimal Price { get; set; }
    }
}
