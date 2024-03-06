using Assignment01.Utils.Request;
using Assignment01.Utils.Response;
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Utils.Request;
using DataAccess.Utils.Response;
using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly assignment_prn_231Context _context;
        private readonly IProductRepository _productRepository;
        public CategoryRepository(assignment_prn_231Context context)
        {
            _context = context;
        }
        public CategoryRepository(assignment_prn_231Context context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }
        public bool AddNewCategory(CategoryRequest categoryRequest)
        {
            if (categoryRequest == null)
            {
                throw new ArgumentNullException("Category Request is Null!");
            }
            if (categoryRequest.Name == null || categoryRequest.Name.Trim().Length < 1)
            {
                throw new MissingFieldException(nameof(categoryRequest.Name));
            }
            try
            {
                _context.Categories.AddAsync(
                    new Category
                    {
                        Name = categoryRequest.Name
                    }
                );
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteCategory(CategoryRequest categoryRequest)
        {
            if (categoryRequest == null)
            {
                throw new ArgumentNullException("Category Request is Null!");
            }
            if (categoryRequest.Id == null)
            {
                throw new MissingFieldException(nameof(categoryRequest.Id));
            }
            int id = categoryRequest.Id;
            Category category = GetCategoryById(id);
            if (category == null)
            {
                throw new KeyNotFoundException(nameof(id));
            }
            _context.Categories.Remove(category);
            return true;
        }
        public Category GetCategoryById(int id)
        {
            if (id == null)
            {
                throw new MissingFieldException(nameof(id));
            }
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);
            return category;
        }
        public bool UpdateCategory(CategoryRequest categoryRequest)
        {
            if (categoryRequest == null)
            {
                throw new ArgumentNullException("Category Request is Null!");
            }
            if (categoryRequest.Id == null)
            {
                throw new MissingFieldException(nameof(categoryRequest.Id));
            }
            if (categoryRequest.Name == null || categoryRequest.Name.Trim().Length < 1)
            {
                throw new MissingFieldException(nameof(categoryRequest.Name));
            }

            int id = categoryRequest.Id;
            Category category = GetCategoryById(id);
            if (category == null)
            {
                throw new KeyNotFoundException(nameof(id));
            }
            category.Name = categoryRequest.Name;
            _context.Categories.Update(category);
            return true;
        }
        public CategoryResponse ConvertToResponse(Category category)
        {
            if (category == null)
            {
                return null;
            }
            return new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
                ProductList = _productRepository.GetAllProductByCategoryId(category.Id);
            };
        }
    }
}
