using Microsoft.EntityFrameworkCore;
using WebApp_DAL.Data;

namespace WebApp_DAL.Reposytory
{
    public class CategoryRepository : IRepository<Category>
    {   
        private readonly AppStoreContext _storeContext;
        public CategoryRepository(AppStoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<Category> AddAsync(Category model)
        {
            try
            {

                _storeContext.Categories!.Add(model);
                await _storeContext.SaveChangesAsync();

                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> DeleteAsync(int id)
        {
            try
            {
                var category = await _storeContext.Categories!.FindAsync(id);
                if (category != null)
                {
                    _storeContext.Categories.Remove(category);
                    await _storeContext.SaveChangesAsync();
                    return "True";
                }
                else
                {
                    return "False";
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Category>> GetAllAsync()
        {
            try
            {
                var categories = await _storeContext.Categories!.ToListAsync();
                return categories;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Category> GetIdAsync(int id)
        {
            try
            {
                var category = await _storeContext.Categories!.FirstOrDefaultAsync(x => x.CategoryId == id);
                if (category != null)
                {
                    return category;
                }
                else
                {
                    return null!;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Category> UpdateAsync(int id, Category model)
        {
            try
            {
                var category = await _storeContext.Categories!.FindAsync(id);
                if (category != null)
                {
                    category.Name = model.Name;
                    _storeContext.Categories!.Update(category);
                    await _storeContext.SaveChangesAsync();
                }

                return category!;
            }
            catch
            {
                throw;
            }
        }



    }
}
