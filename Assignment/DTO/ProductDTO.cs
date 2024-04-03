using Assignment.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment.DTO
{
    public class ProductDTO
    {

        public int? ProductId { get; set; }
        public string? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? ProductName { get; set; }
        public string? Sku { get; set; }
        public string? BarCode { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }

        public ProductDTO(int productId, string productName, string sku, string barCode, decimal productPrice, int productQuantity, string categoryName, string categoryId)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Sku = sku;
            this.BarCode = barCode;
            this.ProductPrice = productPrice;
            this.ProductQuantity = productQuantity;
            this.CategoryName = categoryName;
            this.CategoryId = categoryId;
        }

    }
}
