using ControleLancamento.Application.DTOs;

namespace ControleLancamento.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetByIdAsync(int? id);
        Task<UserDTO> GetByEmailAsync(string email);
        Task<UserDTO> CreateAsync(UserCreateDTO categoryDto);
        Task<UserDTO> UpdateAsync(UserUpdateDTO categoryDto);
        Task RemoveAsync(int? id);
    }
}
