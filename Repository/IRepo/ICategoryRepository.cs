using Assignment01.Utils.Request;
using Assignment01.Utils.Response;
using DataAccess.Entities;
using DataAccess.Utils.Request;
using DataAccess.Utils.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepo
{
    public interface ICategoryRepository
    {
        public Task<bool> AddNewCategory(CategoryRequest categoryRequest);
        public Task<bool> UpdateCategory(CategoryRequest categoryRequest);
        public Task<bool> DeleteCategory(CategoryRequest categoryRequest);
        public Task<Category> GetCategoryById(int id);
        public Task<CategoryResponse> GetCategoryResponseById(int id);
        Task<List<CategoryResponse>> GetAllCategories();
        public Task<CategoryResponse> ConvertToResponse(Category account);
    }
}
