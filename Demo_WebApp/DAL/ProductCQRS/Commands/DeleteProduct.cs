using MediatR;

namespace WebApp_DAL.ProductCQRS.Commands
{
    public class DeleteProduct : IRequest<int>
    {
        public int ProductId { get; set; }
    }
}
