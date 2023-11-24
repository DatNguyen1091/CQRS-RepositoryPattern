using WebApp_DAL.Models;
using WebApp_DAL.Reposytory;

namespace WebApp_BAL.Services
{
    public class CategoryWithProductService
    {
        private readonly CategoeyWithProductRepository _categoeyWithProduct;
        public CategoryWithProductService(CategoeyWithProductRepository categoeyWithProduct)
        {
            _categoeyWithProduct = categoeyWithProduct;
        }
        public async Task<CategoryWithProduct> GetCategoryWithProductLazy(int id)
        {
            return await _categoeyWithProduct.GetCategoryWithProductLazyAsync(id);
        }

        public async Task<CategoryWithProduct> GetCategoryWithProductEager(int id)
        {
            return await _categoeyWithProduct.GetCategoryWithProductEagerAsync(id);
        }
    }
}
