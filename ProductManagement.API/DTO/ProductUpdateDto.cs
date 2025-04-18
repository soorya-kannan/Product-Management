using System.ComponentModel.DataAnnotations;

namespace ProductManagement.API.DTO
{
    public class ProductUpdateDto
    {
        [Required]
        public int Id { get; set; }  // Need to identify which product to update

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        [Range(0, double.MaxValue)]  // Ensure price is valid
        public decimal Price { get; set; }
    }
}
