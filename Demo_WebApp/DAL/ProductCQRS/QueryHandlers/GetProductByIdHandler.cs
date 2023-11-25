using MediatR;
using WebApp_DAL.ProductCQRS.Queries;
using WebApp_DAL.Repository;

namespace WebApp_DAL.ProductCQRS.QueryHandlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductById, Product>
    {
        private readonly IRepository<Product> _productRepository;
        public GetProductByIdHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductById request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetIdAsync(request.ProductId);
        }
    }
}
