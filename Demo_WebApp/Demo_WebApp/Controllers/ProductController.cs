using Microsoft.AspNetCore.Mvc;
using WebApp_BAL.Services;
using WebApp_DAL.Models;

namespace Demo_WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController
    {

        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<Product>> GetAllProducts()
        {
            return await _productService.GetAllProduct();
        }

        [HttpGet("{id}")]
        public async Task<Product> GetAllProductId(int id)
        {
            return await _productService.GetAllProductById(id);
        }

        [HttpPost]
        public async Task<Product> PostProduct(Product product)
        {
            return await _productService.CreatProduct(product);
        }

        [HttpPut("{id}")]
        public async Task<Product> PutProduct(int id, Product product)
        {
            return await _productService.UpdateProduct(id, product);
        }

        [HttpDelete("{id}")]
        public async Task<int> RemoveProduct(int id)
        {
            return await _productService.DeleteProduct(id);
        }
        /*
        [HttpGet("/provipno1/{id}")]
        public async Task<List<Product>> GetAllProductInCategoryById(int id)
        {
            return await _productService.GetAllProductInCategory(id);
        }
        */
    }
}
