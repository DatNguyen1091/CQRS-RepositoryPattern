
using MediatR;
using WebApp_DAL.ProductCQRS.Commands;
using WebApp_DAL.Repository;

namespace WebApp_DAL.ProductCQRS.CommandHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProduct, Product>
    {
        private readonly IRepository<Product> _productRepository;
        public CreateProductHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public string? Name { get; }
        public string? Description { get; }
        public double Price { get; }
        public int Quatity { get; }
        public int CategoryId { get; }

        public async Task<Product> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            var newProduct = new Product()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Quatity = request.Quatity,
                CategoryId = request.CategoryId,
            };

            return await _productRepository.AddAsync(newProduct);
        }
    }
}
