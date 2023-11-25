
using MediatR;
using WebApp_DAL.ProductCQRS.Queries;
using WebApp_DAL.Repository;

namespace WebApp_DAL.ProductCQRS.QueryHandlers
{
    public class GetAllProductHandler : IRequestHandler<GetAllProduct, List<Product>>
    {
        private readonly IRepository<Product> _productRepository;
        public GetAllProductHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<Product>> Handle(GetAllProduct request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllAsync();
        }
    }
}
