using WebApp_DAL.Models;
using WebApp_DAL.Repository;

namespace WebApp_BAL.Services
{
    public class CategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetAllCategoryById(int id)
        {
            return await _categoryRepository.GetIdAsync(id);
        }

        public async Task<Category> CreatCategory(Category category)
        {
            return await _categoryRepository.AddAsync(category);
        }

        public async Task<Category> UpdateCategory(int id, Category category)
        {
            return await _categoryRepository.UpdateAsync(id, category);
        }

        public async Task<int> DeleteCategory(int id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }

    }
}
