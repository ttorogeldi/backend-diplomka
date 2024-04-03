namespace Assignment.Models
{
    public class WarehouseInventory
    {
        public int Id { get; set; }
        public int WarehouseBranchId { get; set; } // Внешний ключ на склад
        public WarehouseBranch WarehouseBranch { get; set; } // Навигационное свойство к складу
        public int ProductId { get; set; } // Внешний ключ на товар
        public ProductModel Product { get; set; } // Навигационное свойство к товару
        public int Quantity { get; set; } // Количество товара на складе
    }
}
