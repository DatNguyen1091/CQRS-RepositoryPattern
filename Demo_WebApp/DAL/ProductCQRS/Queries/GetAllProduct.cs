
using MediatR;

namespace WebApp_DAL.ProductCQRS.Queries
{
    public class GetAllProduct : IRequest<List<Product>>
    {

    }
}
