namespace Assignment.DTO
{
    public class ProductRequestDTO
    {
        public string categoryId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public decimal productPrice { get; set; }
        public int productQuantity { get; set; }
    }
}
