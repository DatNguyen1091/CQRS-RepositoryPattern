
using MediatR;

namespace WebApp_DAL.ProductCQRS.Commands
{
    public class CreateProduct : IRequest<Product>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Quatity { get; set; }
        public int CategoryId { get; set; }

        public CreateProduct(string productName, string productDescription, double productPrice, int productQuatity, int productCategoryId)
        {
            Name = productName;
            Description = productDescription;
            Price = productPrice;
            Quatity = productQuatity;
            CategoryId = productCategoryId;
        }
    }
}
