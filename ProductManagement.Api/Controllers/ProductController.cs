using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMangement.Application.Interface;
using ProductMangement.Domain;

namespace ProductManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost ("AddProduct")]
        public async Task<ProductModel?> AddProduct(ProductModel product)
        {
            return await _productService.AddProduct(product);
        }

        [HttpGet ("GetAllProducts")]
        public async Task<List<ProductModel>?> GetAllProducts()
        {
            return await _productService.GetAllProducts();
        }

        [HttpGet ("GetProductById")]
        public async Task<List<ProductModel>?> GetProductById(int id)
        {
            return await _productService.GetProductById(id);
        }


    }
}
