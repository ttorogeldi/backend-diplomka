using Assignment.DataBaseAccess;
using Assignment.Interfaces.IRepositories;
using Assignment.Models;

namespace Assignment.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly InventoryManagementDbContext _context;

        public CategoryRepository(InventoryManagementDbContext context)
        {
            _context = context;
            
        }
        public async Task<bool>AddCategory(ProductCategoryModel request)
        {
            try
            {
                _context.ProductCategories.Add(request);
                await _context.SaveChangesAsync();
                return true;

            }catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProductCategoryModel>> GetAllCategories()
        {
            try
            {
                return _context.ProductCategories.ToList();
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
                return _context.ProductCategories.Where(c => c.CategoryId == id).FirstOrDefault();
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
                _context.ProductCategories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
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
                _context.ProductCategories.Update(category);
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
