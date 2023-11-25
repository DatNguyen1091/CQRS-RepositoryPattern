
using MediatR;

namespace WebApp_DAL.ProductCQRS.Queries
{
    public class GetProductById : IRequest<Product>
    {
        public int ProductId { get; set; }
    }
}
