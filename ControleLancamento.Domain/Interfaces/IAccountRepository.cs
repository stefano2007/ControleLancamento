using ControleLancamento.Domain.Entities;

namespace ControleLancamento.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account> GetByIdAsync(int? id);
        Task<Account> CreateAsync(Account account);
        Task<Account> UpdateAsync(Account account);
        Task<Account> RemoveAsync(Account account);
    }
}
