using Assignment.Interfaces.IRepositories;
using Assignment.Interfaces.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> AddCategory(ProductCategoryModel request)
        {
            try
            {
                var result = await _categoryRepository.AddCategory(request);
                return result;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProductCategoryModel>> GetAllCategories()
        {
            try
            {
                var result = await _categoryRepository.GetAllCategories();
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductCategoryModel> GetCategoryById(string id)
        {
            try
            {
                var result = await _categoryRepository.GetCategoryById(id);
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCategoryById(ProductCategoryModel category)
        {
            try
            {
                var result = await _categoryRepository.DeleteCategoryById(category);
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateCategory(ProductCategoryModel category)
        {
            try
            {
                var result = await _categoryRepository.UpdateCategory(category);
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
