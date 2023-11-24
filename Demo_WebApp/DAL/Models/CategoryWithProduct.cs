
namespace WebApp_DAL.Models
{
    public class CategoryWithProduct
    {
        public virtual Category? Category { get; set; }
        public virtual List<Product>? Products { get; set; }
    }
}
