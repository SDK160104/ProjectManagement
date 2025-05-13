using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMangement.Domain;

namespace ProductMangement.Application.Interface
{
    public interface IProductService
    {
        Task<List<ProductModel>?> GetAllProducts();  
        Task<List<ProductModel>?> GetProductById(int id);
        Task<ProductModel?> AddProduct(ProductModel product);

    }
}
