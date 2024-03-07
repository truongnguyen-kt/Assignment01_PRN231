using Assignment01.Utils.Request;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepo;

namespace Assignment01.Controllers
{
    [ApiController]
    [Route("[category]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
    }
}
