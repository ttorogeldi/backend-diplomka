using Assignment.DTO;
using Assignment.Interfaces.IServices;
using Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpPost("add-product", Name = "AddProduct")]
        public async Task<IActionResult> AddProduct(ProductRequestDTO request)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(request.categoryId);
                if (category == null)
                {
                    GeneralResponseDTO notFoundResponse = new GeneralResponseDTO(false, "Category not found");
                    return NotFound(notFoundResponse);
                }
                Guid productId = Guid.NewGuid();
                ProductModel product = new ProductModel();
                product.ProductId = productId.ToString();
                product.CategoryId = request.categoryId;
                product.ProductName = request.productName;
                product.ProductDiscription = request.productDescription;
                product.ProductQuantity = request.productQuantity;
                product.ProductPrice = request.productPrice;

                var result = await _productService.AddProduct(product);
                GeneralResponseDTO response = new GeneralResponseDTO(result, "Product created successfully");
                return Created("Product created", response);
            }
            catch (Exception ex)
            {
                GeneralResponseDTO response = new GeneralResponseDTO(false, ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpGet("get-all-product", Name = ("GettAllProducts"))]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProducts();
                GeneralResponseDTO response = new GeneralResponseDTO(true, "Products get successfull", products);
                return Ok(response);
            }
            catch (Exception ex)
            {

                GeneralResponseDTO response = new GeneralResponseDTO(false, "Product get successfull");
                return StatusCode(500, response);
            }
        }

        [HttpGet("get-product-by-id/{id}", Name = ("GettProductById"))]
        public async Task<IActionResult> GetProductById(string id)
        {
            try
            {
                var product = await _productService.GetProductById(id);
                if (product == null)
                {
                    GeneralResponseDTO notFoundResponse = new GeneralResponseDTO(false, "Product not found");
                    return NotFound(notFoundResponse);
                }
                GeneralResponseDTO response = new GeneralResponseDTO(true, "Product get successfull", product);
                return Ok(response);
            }
            catch (Exception ex)
            {

                GeneralResponseDTO response = new GeneralResponseDTO(false, ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpDelete("delete-product-by-id/{id}", Name = ("DeleteProductById"))]
        public async Task<IActionResult> DeleteProductById(string id)
        {
            try
            {
                var product = await _productService.GetProductByIdInternal(id);
                if (product == null)
                {
                    GeneralResponseDTO notFoundResponse = new GeneralResponseDTO(false, "Product not found");
                    return NotFound(notFoundResponse);
                }
                var result = await _productService.DeleteProductById(product);
                GeneralResponseDTO response = new GeneralResponseDTO(true, "Product delete successfully");
                return Ok(response);
            }
            catch (Exception ex)
            {

                GeneralResponseDTO response = new GeneralResponseDTO(false, ex.Message);
                return StatusCode(500, response);
            }
        }

        [HttpPut("update-product/{id}", Name = ("UpdateProduct"))]
        public async Task<IActionResult> UpdateProduct(ProductUpdateRequestDTO request,string id)
        {
            try
            {
                var product = await _productService.GetProductByIdInternal(id);
                if (product == null)
                {
                    GeneralResponseDTO notFoundResponse = new GeneralResponseDTO(false, "Product not found");
                    return NotFound(notFoundResponse);
                }

                product.CategoryId = request.categoryId;
                product.ProductName = request.productName;
                product.ProductDiscription = request.productDescription;
                product.ProductPrice = request.productPrice;
                product.ProductQuantity = request.productQuantity;

                var result = await _productService.UpdateProduct(product);
                GeneralResponseDTO response = new GeneralResponseDTO(true, "Product successfully updated");
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
