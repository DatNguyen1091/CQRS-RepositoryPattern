using Microsoft.AspNetCore.Mvc;
using WebApp_BAL.Services;
using WebApp_DAL.Models;

namespace Demo_WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryWithProductController : ControllerBase
    {
        private readonly CategoryWithProductService _categoryWithProductService;
        public CategoryWithProductController(CategoryWithProductService categoryWithProductService)
        {
            _categoryWithProductService = categoryWithProductService;
        }

        [HttpGet("/Lazy/{id}")]
        public async Task<CategoryWithProduct> GetCategoryWithProductLazyById(int id)
        {
            return await _categoryWithProductService.GetCategoryWithProductLazy(id);
        }

        [HttpGet("/Eager/{id}")]
        public async Task<CategoryWithProduct> GetCategoryWithProductEagerById(int id)
        {
            return await _categoryWithProductService.GetCategoryWithProductEager(id);
        }
    }
}
