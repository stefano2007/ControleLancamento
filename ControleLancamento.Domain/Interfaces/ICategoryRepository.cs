using ControleLancamento.Domain.Entities;

namespace ControleLancamento.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategorysAsync();
        Task<Category> GetByIdAsync(int? id);
        Task<Category> CreateAsync(Category categoria);
        Task<Category> UpdateAsync(Category categoria);
        Task<Category> RemoveAsync(Category categoria);
    }
}
