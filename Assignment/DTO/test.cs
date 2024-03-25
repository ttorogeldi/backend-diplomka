namespace Assignment.DTO
{
    public class test
    {
        public string productId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public decimal productPrice { get; set; }
        public int productQuantity { get; set; }
        public string categoryName { get; set; }
        public string categoryId { get; set; }

        public test(string productId, string productName, string productDescription, decimal productPrice, int productQuantity, string categoryName, string categoryId)
        {
            this.productId = productId;
            this.productName = productName;
            this.productDescription = productDescription;
            this.productPrice = productPrice;
            this.productQuantity = productQuantity;
            this.categoryName = categoryName;
            this.categoryId = categoryId;
        }
    }
}
