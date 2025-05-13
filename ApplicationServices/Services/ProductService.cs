using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductManagement.DbConnection;
using ProductMangement.Application.Interface;
using ProductMangement.Domain;

namespace ProductMangement.Application.Services
{
    public class ProductService : IProductService
    {

        private readonly ProductAppContext _productAppContext;

        public ProductService(ProductAppContext productAppContext) 
        {
            _productAppContext = productAppContext;
        }


        public async Task<ProductModel?> AddProduct(ProductModel product)
        {
            try
            {
                var parameter=new List<SqlParameter>();
                parameter.Add(new SqlParameter("@ProductName",product.ProductName));
                parameter.Add(new SqlParameter ("@ProductPrice", product.ProductPrice));
                parameter.Add(new SqlParameter("@ProductNoOfStock", product.ProductNoOfStock));

                var Result = await _productAppContext.Database.ExecuteSqlRawAsync(@"EXECUTE usp_AddProductDetails @ProductName,@ProductPrice,@ProductNoOfStock",parameter.ToArray());
                //_productAppContext.productModels.Add(product);
                //_productAppContext.SaveChanges();
                return product;
            }
            catch 
            {
                return null;
            }
        }

        public async Task<List<ProductModel>?> GetAllProducts()
        {
            try
            {
                 return await _productAppContext.productModels
                    .FromSqlRaw<ProductModel>("usp_GetAllProductDetails")
                    .ToListAsync();
                //return _productAppContext.productModels.OrderBy(name => name.ProductName).ToList();
                
            }
            catch
            {
                return null;
                throw new Exception("No Data is there !");
            }
        }

        public async Task<List<ProductModel>?> GetProductById(int id)
        {
            try
            {
                var parameter=new SqlParameter("@ProductId",id);

                var ProductDetail= await _productAppContext.productModels.FromSqlRaw(@"EXECUTE usp_GetProductById @ProductId", parameter).ToListAsync();
                //return _productAppContext.productModels.FirstOrDefault(x=> x.ProductId == id);
                return ProductDetail;
            }

            catch
            {
                return null;
                throw new Exception("Invaild Id !");
            }
        }
    }
}
