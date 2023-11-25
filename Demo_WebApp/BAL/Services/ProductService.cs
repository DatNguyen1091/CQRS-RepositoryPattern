
using MediatR;
using WebApp_DAL.Models;
using WebApp_DAL.ProductCQRS.Commands;
using WebApp_DAL.ProductCQRS.Queries;

namespace WebApp_BAL.Services
{
    public class ProductService 
    {
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            var products = await _mediator.Send(new GetAllProduct());
            return products;
        }

        public async Task<Product> GetAllProductById(int id)
        {
            var product = await _mediator.Send(new GetProductById()
            {
                ProductId = id
            });

            return product!;
        }

        public async Task<Product> CreatProduct(Product product)
        {
            var newProduct = await _mediator.Send(new CreateProduct(
                product.Name!,
                product.Description!,
                product.Price,
                product.Quatity,
                product.CategoryId
            ));

            return newProduct!;
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            var updateProduct = await _mediator.Send(new UpdateProduct(
                product.ProductId,
                product.Name!,
                product.Description!,
                product.Price,
                product.Quatity,
                product.CategoryId
            ));
            return updateProduct!;
        }

        public async Task<int> DeleteProduct(int id)
        {
            return await _mediator.Send(new DeleteProduct() { ProductId = id });
        }


        /*
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

        public async Task<int> DeleteProduct(int id)
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
