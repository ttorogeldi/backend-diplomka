namespace Assignment.DTO
{
    public class ProductRequestDTO
    {
        public string CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Sku { get; set; }
        public string BarCode { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
    }
}
