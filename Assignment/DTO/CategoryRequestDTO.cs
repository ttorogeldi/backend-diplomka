using System.ComponentModel.DataAnnotations;

namespace Assignment.DTO
{
    public class CategoryRequestDTO
    {
        [Required]
        public string categoryName {  get; set; }
        [Required]
        public string categoryDescription { get; set; }
    }
}
