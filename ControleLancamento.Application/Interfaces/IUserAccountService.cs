using ControleLancamento.Application.DTOs;

namespace ControleLancamento.Application.Interfaces
{
    public interface IUserAccountService
    {
        Task<IEnumerable<UserAccountDTO>> GetUserAccountsByUserIdQuery(int userId);
        Task<UserAccountDTO> GetByIdAndUserIdAsync(int id, int userId);
        Task<UserAccountDTO> CreateAsync(UserAccountCreateDTO userDto, int userModification);
        Task<UserAccountDTO> UpdateAsync(UserAccountUpdateDTO userDto, int userModification);
        Task RemoveAsync(int id, int userId);
    }
}
