using ControleLancamento.Domain.Entities;

namespace ControleLancamento.Domain.Interfaces
{
    public interface IUserAccountRepository
    {
        Task<IEnumerable<UserAccount>> GetUserAccountsAsync(int userId);
        Task<UserAccount> GetByIdAndUserIdAsync(int id, int userId);
        Task<UserAccount> CreateAsync(UserAccount userAccount);
        Task<UserAccount> UpdateAsync(UserAccount userAccount);
        Task<UserAccount> RemoveAsync(UserAccount userAccount);
    }
}
