using Assignment01.Repository;
using Assignment01.Utils.Request;
using DataAccess.Utils.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Repository.IRepo;
using DataAccess.EnumClass;

namespace Assignment01.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [Authorize(Roles = RolesNames.ADMIN)]
        [HttpGet("get-category-by-id/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryResponseById(id);
                if (category != null)
                {
                    return StatusCode(200, category);
                }
                else return StatusCode(200, "Category is Empty");
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
        [HttpGet("get-all-category")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _categoryRepository.GetAllCategories();
                if (categories != null)
                {
                    return StatusCode(200, categories);
                }
                else return StatusCode(200, "Category is Empty");
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
        [HttpPost("create-category")]
        public async Task<IActionResult> AddNewCategory(CategoryRequest categoryRequest)
        {
            try
            {
                var category = await _categoryRepository.AddNewCategory(categoryRequest);
                if (category != null)
                {
                    return StatusCode(200, "Create Category Successfully");
                }
                else return StatusCode(200, "Create Category Fail");
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
        [HttpPut("update-category")]
        public async Task<IActionResult> UpdateCategory(CategoryRequest categoryRequest)
        {
            try
            {
                var category = await _categoryRepository.UpdateCategory(categoryRequest);
                if (category != false)
                {
                    return StatusCode(200, "Update Category Successfully");
                }
                else return StatusCode(200, "Update Category Fail");
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
        [HttpDelete("delete-category")]
        public async Task<IActionResult> DeleteCategory(CategoryRequest categoryRequest)
        {
            try
            {
                var category = await _categoryRepository.DeleteCategory(categoryRequest);
                if (category != false)
                {
                    return StatusCode(200, "Delete Category Successfully");
                }
                else return StatusCode(200, "Delete Category Fail");
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
