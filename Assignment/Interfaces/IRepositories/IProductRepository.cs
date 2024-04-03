using Assignment.Models;

namespace Assignment.Interfaces.IRepositories
{
    public interface IProductRepository
    {
        public Task<bool> AddProduct(ProductModel request);
        public Task<List<ProductModel>> GetAllProducts();
        public Task<object> GetProductById(int id);
        public Task<ProductModel> GetProductByIdInternal(int id);
        public Task<bool> DeleteProductById(ProductModel product);
        public Task<bool> UpdateProduct(ProductModel product);
    }
}
