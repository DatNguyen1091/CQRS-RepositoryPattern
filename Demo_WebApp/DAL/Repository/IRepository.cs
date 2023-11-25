
namespace WebApp_DAL.Repository
{
    public interface IRepository<otp>
    {
        public Task<List<otp>> GetAllAsync();
        public Task<otp> GetIdAsync(int id);
        public Task<otp> AddAsync(otp model);
        public Task<otp> UpdateAsync(int id, otp model);
        public Task<int> DeleteAsync(int id);
    }
}
