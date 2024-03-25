using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.DTO
{
    public class CategoryUpdateRequestDTO
    {

        [Required]
        public string categoryName { get; set; }
        [Required]
        public string categoryDescription { get; set; }
    }
}
