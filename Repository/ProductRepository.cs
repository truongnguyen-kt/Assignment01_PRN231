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
    public class ProductRepository : IProductRepository
    {
        private readonly assignment_prn_231Context _context;

        private readonly ICategoryRepository _categoryRepository;
        public ProductRepository(assignment_prn_231Context context, ICategoryRepository categoryRepository)
        {
            _context = context;
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> AddNewProduct(ProductRequest productRequest)
        {
            if (productRequest == null)
            {
                throw new ArgumentNullException("Account Request is Null!");
            }
            if (productRequest.Name == null || productRequest.Name.Trim().Length < 1)
            {
                throw new MissingFieldException(nameof(productRequest.Name));
            }
            if (productRequest.Detail == null || productRequest.Detail.Trim().Length < 1)
            {
                throw new MissingFieldException(nameof(productRequest.Detail));
            }
            if (productRequest.Price == null || (productRequest.Detail.Trim().Length < 1) || Double.Parse(productRequest.Price) < 0)
            {
                throw new MissingFieldException(nameof(productRequest.Price));
            }
            if (productRequest.CategoryId == null || (productRequest.Detail.Trim().Length < 1) || Int32.Parse(productRequest.CategoryId) < 0)
            {
                throw new MissingFieldException(nameof(productRequest.CategoryId));
            }
            var category = await _categoryRepository.GetCategoryById(Int32.Parse(productRequest.CategoryId));
            if(category == null)
            {
                throw new Exception("Category is not existed!!!!");
            }
            try
            {
                await _context.Products.AddAsync(
                    new Product
                    {
                        Name = productRequest.Name,
                        Detail = productRequest.Detail,
                        Price = Double.Parse(productRequest.Price),
                        CategoryId = Int32.Parse(productRequest.CategoryId),
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


        public async Task<bool> DeleteProduct(ProductRequest productRequest)
        {

            if (productRequest == null)
            {
                throw new ArgumentNullException("Category Request is Null!");
            }
            if (productRequest.Id == null)
            {
                throw new MissingFieldException(nameof(productRequest.Id));
            }
            Product product = await GetProductById(productRequest.Id);  
            if (product == null)
            {
                throw new KeyNotFoundException(nameof(product.Id));
            }

             _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<Product> GetProductById(int id)
        {
            if (id == null)
            {
                throw new MissingFieldException(nameof(id));
            }
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                throw new ArgumentNullException("Product is not existed!!!!");
            }
            return product;
        }
        public async Task<bool> UpdateProduct(ProductRequest productRequest)
        {
            if (productRequest == null)
            {
                throw new ArgumentNullException("Account Request is Null!");
            }
            if (productRequest.Name == null || productRequest.Name.Trim().Length < 1)
            {
                throw new MissingFieldException(nameof(productRequest.Name));
            }
            if (productRequest.Detail == null || productRequest.Detail.Trim().Length < 1)
            {
                throw new MissingFieldException(nameof(productRequest.Detail));
            }
            if (productRequest.Price == null || (productRequest.Detail.Trim().Length < 1) || Double.Parse(productRequest.Price) < 0)
            {
                throw new MissingFieldException(nameof(productRequest.Price));
            }
            if (productRequest.CategoryId == null || (productRequest.Detail.Trim().Length < 1) || Int32.Parse(productRequest.CategoryId) < 0)
            {
                throw new MissingFieldException(nameof(productRequest.CategoryId));
            }
            var category = await _categoryRepository.GetCategoryById(Int32.Parse(productRequest.CategoryId));
            if (category == null)
            {
                throw new Exception("Category is not existed!!!!");
            }

            var product = await GetProductById(productRequest.Id);
            if (product == null)
            {
                throw new ArgumentNullException("Product is not existed!!!!");
            }

            product.Name = productRequest.Name;
            product.Detail = productRequest.Detail;
            product.Price = Double.Parse(productRequest.Price);
            product.CategoryId = Int32.Parse(productRequest.CategoryId);

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<ProductResponse>> GetAllProductByCategoryId(int categoryId)
        {
            if (categoryId == null)
            {
                throw new MissingFieldException(nameof(categoryId));
            }

            var listProduct = await _context.Products.Where(x => x.CategoryId == categoryId)
                .ToListAsync();


            var listResponse = listProduct.Select(pro => ConvertToResponse(pro));

            return (await Task.WhenAll(listResponse)).ToList();
    
        }

        public async Task<List<ProductResponse>> GetAllProduct()
        {
            var listProduct = await _context.Products.ToListAsync();

            var listResponse = listProduct.Select(pro => ConvertToResponse(pro));

            return (await Task.WhenAll(listResponse)).ToList();
        }

        public async Task<ProductResponse> ConvertToResponse(Product product)
        {
            if (product == null)
            {
                return null;
            }
            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Detail = product.Detail,
                Price = product.Price,
                CategoryId = product.CategoryId,
            };
        }
    }
}
