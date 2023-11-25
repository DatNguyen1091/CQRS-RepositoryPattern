
using MediatR;

namespace WebApp_DAL.ProductCQRS.Commands
{
    public class UpdateProduct : IRequest<Product>
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Quatity { get; set; }
        public int CategoryId { get; set; }

        public UpdateProduct(int productId, string productName, string productDescription, double productPrice, int productQuatity, int productCategoryId)
        {
            ProductId = productId;
            Name = productName;
            Description = productDescription;
            Price = productPrice;
            Quatity = productQuatity;
            CategoryId = productCategoryId;
        }
    }
}
