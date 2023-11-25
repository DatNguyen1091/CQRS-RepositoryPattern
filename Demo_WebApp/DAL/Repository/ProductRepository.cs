
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApp_DAL.Data;

namespace WebApp_DAL.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly AppStoreContext _storeContext;
        public ProductRepository(AppStoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<Product> AddAsync(Product model)
        {
            try
            {

                var result = _storeContext.Products!.Add(model);
                await _storeContext.SaveChangesAsync();

                return result.Entity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                var product = await _storeContext.Products!.Where(x => x.ProductId == id).FirstOrDefaultAsync();
                    _storeContext.Products!.Remove(product!);
                return await _storeContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                var products = await _storeContext.Products!.ToListAsync();
                return products;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Product> GetIdAsync(int id)
        {
            try
            {
                var product = await _storeContext.Products!.Where(x => x.ProductId == id).FirstOrDefaultAsync();
                return product!;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Product> UpdateAsync(int id, Product model)
        {
            try
            {
                var result = _storeContext.Products!.Update(model);

                await _storeContext.SaveChangesAsync();

                return result.Entity;
            }
            catch
            {
                throw;
            }
        }
/*
        public async Task<List<Product>> GetProductsByCategoryAsync(int id)
        {
            using IDbConnection dbConnection = new SqlConnection("Server=DATNGUYEN\\SQLEXPRESS;Database=Demo_App;Integrated Security=True;");
            dbConnection.Open();

            var products = await dbConnection.QueryAsync<Product>( "GetProductsByCategory", new { CategoryId = id });

            return products.ToList();
        }
*/
    }
}
