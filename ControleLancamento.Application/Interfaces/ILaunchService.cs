using ControleLancamento.Application.DTOs;

namespace ControleLancamento.Application.Interfaces
{
    public interface ILaunchService
    {
        Task<IEnumerable<LaunchDTO>> GetLaunchsByAccountIdAsync(int accountId);
        Task<LaunchDTO> GetByIdAsync(int? id);
        Task<LaunchDTO> CreateAsync(LaunchCreateDTO categoryDto);
        Task<LaunchDTO> UpdateAsync(LaunchUpdateDTO categoryDto);
        Task RemoveAsync(int? id);
    }
}
