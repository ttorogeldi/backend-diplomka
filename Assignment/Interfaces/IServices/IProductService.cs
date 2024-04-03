using Assignment.DTO;
using Assignment.Models;

namespace Assignment.Interfaces.IServices
{
    public interface IProductService
    {
        public  Task<bool> AddProduct(ProductModel request);
        public Task<List<ProductDTO>> GetAllProducts();
        public Task<object> GetProductById(int id);
        public Task<ProductModel> GetProductByIdInternal(int id);
        public Task<bool> DeleteProductById(ProductModel product);
        public Task<bool> UpdateProduct(ProductModel product);
    }
}
