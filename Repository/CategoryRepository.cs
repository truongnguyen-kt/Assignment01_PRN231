using Assignment01.Utils.Request;
using Assignment01.Utils.Response;
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Utils.Request;
using DataAccess.Utils.Response;
using Microsoft.EntityFrameworkCore;
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
        public async Task<bool> AddNewCategory(CategoryRequest categoryRequest)
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
                await _context.Categories.AddAsync(
                    new Category
                    {
                        Name = categoryRequest.Name
                    }
                );
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteCategory(CategoryRequest categoryRequest)
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
            Category category = await GetCategoryById(id);
            if (category == null)
            {
                throw new KeyNotFoundException(nameof(id));
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            if (id == null)
            {
                throw new MissingFieldException(nameof(id));
            }
            Category category = await _context.Categories.FindAsync(id);
            return category;
        }
        public async Task<bool> UpdateCategory(CategoryRequest categoryRequest)
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
            Category category = await GetCategoryById(id);
            if (category == null)
            {
                throw new KeyNotFoundException(nameof(id));
            }
            category.Name = categoryRequest.Name;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<CategoryResponse> ConvertToResponse(Category category)
        {
            if (category == null)
            {
                return null;
            }
            return new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
                ProductList = await _productRepository.GetAllProductByCategoryId(category.Id)
            };
        }
    }
}
