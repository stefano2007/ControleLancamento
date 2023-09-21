using ControleLancamento.Domain.Entities;

namespace ControleLancamento.Domain.Interfaces
{
    public interface IAccountTypeRepository
    {
        Task<IEnumerable<AccountType>> GetAccountTypesAsync();
        Task<AccountType> GetByIdAsync(int? id);
        Task<AccountType> CreateAsync(AccountType accountType);
        Task<AccountType> UpdateAsync(AccountType accountType);
        Task<AccountType> RemoveAsync(AccountType accountType);
    }
}
