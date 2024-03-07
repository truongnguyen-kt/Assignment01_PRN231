using Assignment01.Repository;
using Assignment01.Utils.Request;
using DataAccess.Utils.Request;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepo;

namespace Assignment01.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("get-product-by-id/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _productRepository.GetProductById(id);
                if (product != null)
                {
                    return StatusCode(200, product);
                }
                else return StatusCode(200, "Product is Empty");
            }
            catch (Exception ex)
            {
                int statusCode;
                string errorMessage;
                statusCode = 500;
                errorMessage = "Server error";
                return StatusCode(statusCode, errorMessage);
            }
        }
        [HttpGet("get-all-products")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productRepository.GetAllProduct();
                if (products != null)
                {
                    return StatusCode(200, products);
                }
                else return StatusCode(200, "Product is Empty");
            }
            catch (Exception ex)
            {
                int statusCode;
                string errorMessage;
                statusCode = 500;
                errorMessage = "Server error";
                return StatusCode(statusCode, errorMessage);
            }
        }
        [HttpGet("get-all-products-by-category-id/{id}")]
        public async Task<IActionResult> GetAllProductByCategoryId(int id)
        {
            try
            {
                var products = await _productRepository.GetAllProductByCategoryId(id);
                if (products != null)
                {
                    return StatusCode(200, products);
                }
                else return StatusCode(200, "Product is Empty");
            }
            catch (Exception ex)
            {
                int statusCode;
                string errorMessage;
                statusCode = 500;
                errorMessage = "Server error";
                return StatusCode(statusCode, errorMessage);
            }
        }
        [HttpPost("create-product")]
        public async Task<IActionResult> AddNewProduct(ProductRequest productRequest)
        {
            try
            {
                var product = await _productRepository.AddNewProduct(productRequest);
                if (product != null)
                {
                    return StatusCode(200, "Create Product Successfully");
                }
                else return StatusCode(200, "Create Product Fail");
            }
            catch (Exception ex)
            {
                int statusCode;
                string errorMessage;
                statusCode = 500;
                errorMessage = "Server error";
                return StatusCode(statusCode, errorMessage);
            }
        }
        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct(ProductRequest productRequest)
        {
            try
            {
                var product = await _productRepository.UpdateProduct(productRequest);
                if (product != false)
                {
                    return StatusCode(200, "Update Product Successfully");
                }
                else return StatusCode(200, "Update Product Fail");
            }
            catch (Exception ex)
            {
                int statusCode;
                string errorMessage;
                statusCode = 500;
                errorMessage = "Server error";
                return StatusCode(statusCode, errorMessage);
            }
        }
        [HttpDelete("delete-product")]
        public async Task<IActionResult> DeleteProduct(ProductRequest productRequest)
        {
            try
            {
                var product = await _productRepository.DeleteProduct(productRequest);
                if (product != false)
                {
                    return StatusCode(200, "Delete Product Successfully");
                }
                else return StatusCode(200, "Delete Product Fail");
            }
            catch (Exception ex)
            {
                int statusCode;
                string errorMessage;
                statusCode = 500;
                errorMessage = "Server error";
                return StatusCode(statusCode, errorMessage);
            }
        }
    }
}
