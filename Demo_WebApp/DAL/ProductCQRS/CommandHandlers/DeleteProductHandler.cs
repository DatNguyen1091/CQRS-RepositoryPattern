
using MediatR;
using WebApp_DAL.ProductCQRS.Commands;
using WebApp_DAL.Repository;

namespace WebApp_DAL.ProductCQRS.CommandHandlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProduct, int>
    {
        private readonly IRepository<Product> _productRepository;
        public DeleteProductHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetIdAsync(request.ProductId);

            if (product == null)
            {
                return default!;
            }

            return await _productRepository.DeleteAsync(product.ProductId);
        }
    }
}
