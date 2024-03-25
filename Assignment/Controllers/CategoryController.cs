using Assignment.DTO;
using Assignment.Interfaces.IServices;
using Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("add-category", Name ="AddCategory")]
        public async Task<IActionResult> AddCategory(CategoryRequestDTO request)
        {
            try
            {
                Guid categoryId = Guid.NewGuid();
                ProductCategoryModel category = new ProductCategoryModel();
                category.CategoryId = categoryId.ToString();
                category.CategoryName = request.categoryName;
                category.CategoryDescription = request.categoryDescription;

                var result = await _categoryService.AddCategory(category);
                GeneralResponseDTO response = new GeneralResponseDTO(result, "Category created successfully");
                return Created("Category created",response);
            }
            catch (Exception ex)
            {
                GeneralResponseDTO response = new GeneralResponseDTO(false,ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpGet("get-all-category", Name =("GettAllCategories"))]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var result = await _categoryService.GetAllCategories();
                GeneralResponseDTO response = new GeneralResponseDTO(true, "Category get successfull", result);
                return Ok(response);
            }
            catch (Exception ex)
            {

                GeneralResponseDTO response = new GeneralResponseDTO(false, "Category get unSuccessfull");
                return StatusCode(500, response);    
            }
        }

        [HttpGet("get-category-by-id/{id}", Name = ("GettCategoryById"))]
        public async Task<IActionResult> GetCategotyById(string id)
        {
            try
            {
                var result = await _categoryService.GetCategoryById(id);
                GeneralResponseDTO response = new GeneralResponseDTO(true, "Category get successfull", result);
                return Ok(response);
            }
            catch (Exception ex)
            {

                GeneralResponseDTO response = new GeneralResponseDTO(false, ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpDelete("delete-category-by-id/{id}", Name =("DeleteCategoryById"))]
        public async Task<IActionResult> DeleteCategoryById(string id)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(id);
                if (category == null)
                {
                    GeneralResponseDTO notFoundResponse = new GeneralResponseDTO(false, "Category not found");
                    return NotFound(notFoundResponse);
                }
                var result = await _categoryService.DeleteCategoryById(category);
                GeneralResponseDTO response = new GeneralResponseDTO(true, "Product delete successfully");
                return Ok(response);
            }
            catch (Exception ex)
            {

                GeneralResponseDTO response = new GeneralResponseDTO(false, ex.Message);
                return StatusCode(500,response);
            }
        }

        [HttpPut("update-category/{id}", Name = ("UpdateCategory"))]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateRequestDTO request,string id)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(id);
                if (category == null)
                {
                    GeneralResponseDTO notFoundResponse = new GeneralResponseDTO(false, "Category not found");
                    return NotFound(notFoundResponse);
                }

                category.CategoryName = request.categoryName;
                category.CategoryDescription = request.categoryDescription;
                var result = await _categoryService.UpdateCategory(category);
                GeneralResponseDTO response = new GeneralResponseDTO(true, "Category successfully updated");
                return Ok(response);
            }
            catch (Exception ex)
            {

                GeneralResponseDTO response = new GeneralResponseDTO(false, ex.Message);
                return StatusCode(500, response);
            }
        }
    }
}
