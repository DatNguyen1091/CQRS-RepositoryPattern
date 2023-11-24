
using Microsoft.EntityFrameworkCore;
using WebApp_DAL.Data;

namespace WebApp_DAL.Reposytory
{
    public class CategoeyWithProductRepository
    {
        private readonly AppStoreContext _storeContext;
        public CategoeyWithProductRepository(AppStoreContext appStoreContext)
        {
            _storeContext = appStoreContext;
        }
        /*
                public async Task<CategoryWithProduct> GetCategoryWithProductAsync(int id)
                {
                    try
                    {
                        var category = await _storeContext.Categories!.FirstOrDefaultAsync(x => x.CategoryId == id);

                        if (category == null)
                        {
                            return null!; 
                        }

                        var categoryProducts = await _storeContext.Products!.Where(p => p.CategoryId == id).ToListAsync();

                        var categoryWithProduct = new CategoryWithProduct
                        {
                            Category = category,
                            Products = categoryProducts 
                        };

                        return categoryWithProduct;
                    }
                    catch
                    {
                        throw; 
                    }
                }    
        */

        public async Task<CategoryWithProduct> GetCategoryWithProductLazyAsync(int id)
        {
            try
            {
                var category = await _storeContext.Categories!
                    .FirstOrDefaultAsync(c => c.CategoryId == id);

                if (category == null)
                {
                    return null!;
                }

                var products = category.Products;

                return new CategoryWithProduct
                {
                    Category = category,
                    Products = products?.ToList() ?? new List<Product>() 
                };
            }
            catch
            {
                throw;
            }
        }



        public async Task<CategoryWithProduct> GetCategoryWithProductEagerAsync(int id)
        {
            try
            {
                var categoryWithProduct = await _storeContext.Categories!
                    .Where(x => x.CategoryId == id)
                    .Include(c => c.Products) 
                    .FirstOrDefaultAsync();

                if (categoryWithProduct == null)
                {
                    return null!;
                }

                return new CategoryWithProduct
                {
                    Category = categoryWithProduct,
                    Products = categoryWithProduct.Products!.ToList()
                };
            }
            catch
            {
                throw;
            }
        }



    }
}
