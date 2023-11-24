using Microsoft.AspNetCore.Mvc;
using WebApp_BAL.Services;
using WebApp_DAL.Models;

namespace Demo_WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController
    {
        private readonly CategoryService _categoryService;
        public CategoryController( CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoryService.GetAllCategory();
        }

        [HttpGet("{id}")]
        public async Task<Category> GetAllCategoryId(int id)
        {
            return await _categoryService.GetAllCategoryById(id);
        }

        [HttpPost]
        public async Task<Category> PostCategory(Category category)
        {
            return await _categoryService.CreatCategory(category);
        }

        [HttpPut("{id}")]
        public async Task<Category> PutCategory(int id, Category category)
        {
            return await _categoryService.UpdateCategory(id, category);
        }

        [HttpDelete("{id}")]
        public async Task<string> RemoveCategory(int id)
        {
            return await _categoryService.DeleteCategory(id);
        }

    }
}
