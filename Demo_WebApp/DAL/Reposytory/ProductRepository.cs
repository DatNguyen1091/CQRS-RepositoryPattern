
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApp_DAL.Data;

namespace WebApp_DAL.Reposytory
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

                _storeContext.Products!.Add(model);
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
                var product = await _storeContext.Products!.FirstOrDefaultAsync(x => x.ProductId == id);
                if (product != null)
                {
                    return product;
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

        public async Task<Product> UpdateAsync(int id, Product model)
        {
            try
            {
                var product = await _storeContext.Products!.FindAsync(id);
                if (product != null)
                {
                    product.Name = model.Name;
                    product.Description = model.Description;
                    product.Price = model.Price;
                    product.Quatity = model.Quatity;
                    product.CategoryId = model.CategoryId;
                    _storeContext.Products!.Update(product);
                }

                var changes = _storeContext.ChangeTracker.Entries()
                    .Where(x => x.State == EntityState.Modified)
                    .ToList();

                foreach (var entry in changes)
                {
                    Console.WriteLine($"Change: {entry.Entity.GetType().Name}, State: {entry.State}");

                    foreach (var property in entry.OriginalValues.Properties)
                    {
                        var original = entry.OriginalValues[property];
                        var current = entry.CurrentValues[property];

                        if (!object.Equals(original, current))
                        {
                            Console.WriteLine($"   Property: {property.Name}, Original: {original}, Current: {current}");
                        }
                    }
                }

                await _storeContext.SaveChangesAsync();

                return product!;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(int id)
        {
            using IDbConnection dbConnection = new SqlConnection("Server=DATNGUYEN\\SQLEXPRESS;Database=Demo_App;Integrated Security=True;");
            dbConnection.Open();

            var products = await dbConnection.QueryAsync<Product>( "GetProductsByCategory", new { CategoryId = id });

            return products.ToList();
        }

    }
}
