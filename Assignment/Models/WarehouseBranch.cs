namespace Assignment.Models
{
    public class WarehouseBranch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; } // Внешний ключ на город
        public City City { get; set; } // Навигационное свойство для EF Core
        public ICollection<WarehouseInventory> WarehouseInventories { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}