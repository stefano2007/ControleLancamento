using ControleLancamento.Domain.Entities;

namespace ControleLancamento.Domain.Interfaces
{
    public interface ILaunchRepository
    {
        Task<IEnumerable<Launch>> GetLaunchsByAccountIdAsync(int accountId);
        Task<Launch> GetByIdAsync(int? id);
        Task<Launch> CreateAsync(Launch launch);
        Task<Launch> UpdateAsync(Launch launch);
        Task<Launch> RemoveAsync(Launch launch);
    }
}
