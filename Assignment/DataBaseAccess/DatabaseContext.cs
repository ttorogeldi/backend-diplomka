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
        public DbSet<WarehouseBranch> WarehouseBranches { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<WarehouseInventory> WarehouseInventories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUserInfo(modelBuilder);
            ConfigureEmployee(modelBuilder);
            ConfigureWarehouseBranch(modelBuilder);
            ConfigureWarehouseInventory(modelBuilder);

            modelBuilder.Entity<City>()
       .HasKey(c => c.Id); // Настраиваем первичный ключ для сущности City

        }

        private void ConfigureWarehouseBranch(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WarehouseBranch>(entity =>
            {
                entity.ToTable("WarehouseBranch"); // Устанавливаем имя таблицы
                entity.HasKey(wb => wb.Id); // Устанавливаем первичный ключ
                entity.Property(wb => wb.Id).HasColumnName("WarehouseBranchId"); // Устанавливаем имя столбца для первичного ключа

                // Другие настройки для сущности WarehouseBranch, если необходимо
            });
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

                // Добавляем связь с филиалом
                entity.HasOne(e => e.WarehouseBranch)
                      .WithMany(wb => wb.Employees)
                      .HasForeignKey(e => e.WarehouseBranchId);
            });
        }

        private void ConfigureWarehouseInventory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WarehouseInventory>(entity =>
            {
                entity.ToTable("WarehouseInventory"); // Устанавливаем имя таблицы
                entity.HasKey(wi => wi.Id); // Устанавливаем первичный ключ

                entity.HasOne(wi => wi.WarehouseBranch)
                    .WithMany(wb => wb.WarehouseInventories)
                    .HasForeignKey(wi => wi.WarehouseBranchId);

                // Устанавливаем связь с сущностью ProductModel
                entity.HasOne(wi => wi.Product)
                    .WithMany()
                    .HasForeignKey(wi => wi.Id);

                // Другие настройки, если необходимо
            });
        }
    }
}