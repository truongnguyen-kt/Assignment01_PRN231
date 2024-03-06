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
        public bool AddNewCategory(CategoryRequest categoryRequest);
        public bool UpdateCategory(CategoryRequest categoryRequest);
        public bool DeleteCategory(CategoryRequest categoryRequest);
        public Category GetCategoryById(int id);
        public CategoryResponse ConvertToResponse(Category account);
    }
}
