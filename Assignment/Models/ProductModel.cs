using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    public class ProductModel
    {
        [Key]
        [Column("ProductId",TypeName ="nvarchar(36)")]
        public string ProductId { get; set; }

        [Column("CategoryId",TypeName ="nvarchar(36)")]
        public string CategoryId { get; set; }
        public ProductCategoryModel Category { get; set; }


        [Column("ProductName", TypeName = "varchar(200)")]
        public string ProductName { get; set; }


        [Column("Sku", TypeName = "varchar(200)")]
        public string Sku { get; set; }
        [Column("BarCode", TypeName = "varchar(200)")]
        public string BarCode { get; set; }

        [Column("ProductPrice", TypeName = "decimal(18, 2)")]
        public decimal ProductPrice { get; set; }

        [Column("ProductQuantity")]
        public int ProductQuantity { get; set; }

    }
}
