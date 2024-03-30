using Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment.DataBaseAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DatabaseContext()
        {
        }

        public DbSet<ProductCategoryModel> ProductCategories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<UserInfo>? UserInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUserInfo(modelBuilder);
            ConfigureEmployee(modelBuilder);
            // Add configurations for other entities if needed
        }

        private void ConfigureUserInfo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("UserInfo");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.DisplayName).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime"); // Example of using proper datetime type
            });
        }

        private void ConfigureEmployee(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");
                entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");
                entity.Property(e => e.NationalIDNumber).HasMaxLength(15).IsUnicode(false);
                entity.Property(e => e.EmployeeName).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.LoginID).HasMaxLength(256).IsUnicode(false);
                entity.Property(e => e.JobTitle).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.BirthDate).HasColumnType("date"); // Example of using proper date type
                entity.Property(e => e.Gender).HasMaxLength(1).IsUnicode(false);
                entity.Property(e => e.HireDate).HasColumnType("datetime"); // Example of using proper datetime type
                entity.Property(e => e.RowGuid).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime"); // Example of using proper datetime type
            });
        }
    }
}