using Assignment.DTO;
using Assignment.Interfaces.IRepositories;
using Assignment.Interfaces.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> AddProduct(ProductModel request)
        {
            try
            {
                var result = await _productRepository.AddProduct(request);
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            try
            {
                var categoryList = await _categoryRepository.GetAllCategories();
                var result = await _productRepository.GetAllProducts();
                List<ProductDTO> productDTOList = new List<ProductDTO>();

                foreach (var product in result) 
                {
                    var categoryName = categoryList.Where(c => c.CategoryId == product.CategoryId).Select(c=>c.CategoryName).FirstOrDefault();
                    var customProduct = new ProductDTO(product.ProductId,product.ProductName,product.ProductDiscription,product.ProductPrice,product.ProductQuantity,categoryName,product.CategoryId);
                    productDTOList.Add(customProduct);
                }

                return productDTOList; 
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
                var result = await _productRepository.GetProductById(id);
                return result;
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
                var result = await _productRepository.GetProductByIdInternal(id);
                return result;
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
                var result = await _productRepository.DeleteProductById(product);
                return result;
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
                var result = await _productRepository.UpdateProduct(product);
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
