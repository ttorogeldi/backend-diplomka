using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Assignment.DataBaseAccess
{
    public class InventoryManagementDbContext : DbContext
    {
        public InventoryManagementDbContext(DbContextOptions<InventoryManagementDbContext>options) :base(options) { }
        public DbSet<ProductCategoryModel> ProductCategories { get; set; }
        public DbSet<ProductModel> Products { get; set; }


    }
}
