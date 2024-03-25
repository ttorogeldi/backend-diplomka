using Assignment.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment.DTO
{
    public class ProductUpdateRequestDTO
    {
        [Required]
        public string categoryId { get; set; }
        [Required]
        public string productName { get; set; }
        [Required]
        public string productDescription { get; set; }
        [Required]
        public decimal productPrice { get; set; }
        [Required]
        public int productQuantity { get; set; }
    }
}
