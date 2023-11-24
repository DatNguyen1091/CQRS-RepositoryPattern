
namespace WebApp_DAL.Reposytory
{
    public interface IRepository<otp>
    {
        public Task<List<otp>> GetAllAsync();
        public Task<otp> GetIdAsync(int id);
        public Task<otp> AddAsync(otp model);
        public Task<otp> UpdateAsync(int id, otp model);
        public Task<string> DeleteAsync(int id);
    }
}
