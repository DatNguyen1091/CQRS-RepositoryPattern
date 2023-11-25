
using MediatR;
using WebApp_DAL.ProductCQRS.Commands;
using WebApp_DAL.Repository;

namespace WebApp_DAL.ProductCQRS.CommandHandlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProduct, Product>
    {
        private readonly IRepository<Product> _productRepository;
        public UpdateProductHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetIdAsync(request.ProductId);
            if (product == null)
            {
                return default!;
            }
            
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Quatity = request.Quatity;
            product.CategoryId = request.CategoryId;

            return await _productRepository.UpdateAsync(request.ProductId, product);
        }
    }
}
