using Microsoft.EntityFrameworkCore;

namespace WebApp_DAL.Data
{
    public class AppStoreContext : DbContext
    {
        public AppStoreContext(DbContextOptions<AppStoreContext> otp) : base(otp)
        {

        }

        #region DbSet
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        #endregion
    }

}
