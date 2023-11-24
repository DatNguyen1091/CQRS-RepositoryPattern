
using WebApp_DAL.Models;
using WebApp_DAL.Reposytory;

namespace WebApp_BAL.Services
{
    public class ProductService 
    {
        private readonly IRepository<Product> _productRepository;
        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetAllProductById(int id)
        {
            return await _productRepository.GetIdAsync(id);
        }

        public async Task<Product> CreatProduct(Product product)
        {
            return await _productRepository.AddAsync(product);
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            return await _productRepository.UpdateAsync(id, product);
        }

        public async Task<string> DeleteProduct(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }
        /*
        public async Task<List<Product>> GetAllProductInCategory(int id)
        {
            return await _productRepository.GetProductsByCategoryAsync(id);
        }
        */
    }
}
