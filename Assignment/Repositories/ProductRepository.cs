using Assignment.DataBaseAccess;
using Assignment.Interfaces.IRepositories;
using Assignment.Models;

namespace Assignment.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly InventoryManagementDbContext _context;

        public ProductRepository(InventoryManagementDbContext context)
        {
            _context = context;

        }
        public async Task<bool> AddProduct(ProductModel request)
        {
            try
            {
                _context.Products.Add(request);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            try
            {
                return _context.Products.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<object> GetProductById(string id)
        {
            try
            {
                return _context.Products
                               .Where(p => p.ProductId == id)
                               .Select(p => new
                               {
                                   p.ProductId,
                                   p.ProductName,
                                   p.ProductPrice,
                                   p.ProductQuantity,
                                   p.ProductDiscription,
                                   CategoryName = p.Category.CategoryName
                               })
                               .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductModel> GetProductByIdInternal(string id)
        {
            try
            {
                return _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteProductById(ProductModel product)
        {
            try
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateProduct(ProductModel product)
        {
            try
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
