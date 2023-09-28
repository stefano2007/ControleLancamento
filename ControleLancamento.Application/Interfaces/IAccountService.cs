using ControleLancamento.Application.DTOs;

namespace ControleLancamento.Application.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDTO>> GetAccountsAsync();
        Task<AccountDTO> GetByIdAsync(int? id);
        Task<AccountDTO> CreateAsync(AccountCreateDTO accountDto);
        Task<AccountDTO> UpdateAsync(AccountUpdateDTO accountDto);
        Task RemoveAsync(int? id);
    }
}
