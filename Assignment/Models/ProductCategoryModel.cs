using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    public class ProductCategoryModel
    {
        [Key]
        [Column("CategoryId",TypeName ="nvarchar(36)")]
        public string CategoryId { get; set; }

        [Column("CategoryName",TypeName ="varchar(200)")]
        public string CategoryName { get; set; }

        [Column("Discription",TypeName ="varchar(200)")]
        public string CategoryDescription { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }
    }
}
