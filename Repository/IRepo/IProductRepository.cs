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
    public interface IProductRepository
    {
        Task<bool> AddNewProduct(ProductRequest productRequest);

        Task<bool> UpdateProduct(ProductRequest productRequest);
        Task<bool> DeleteProduct(ProductRequest productRequest);
        Task<ProductResponse> GetProductById(int id);
        Task<ProductResponse> ConvertToResponse(Product product);

        Task<List<ProductResponse>> GetAllProductByCategoryId(int ca);
    }
}
