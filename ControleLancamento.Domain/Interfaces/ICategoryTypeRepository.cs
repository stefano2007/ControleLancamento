using ControleLancamento.Domain.Entities;

namespace ControleLancamento.Domain.Interfaces
{
    public interface ICategoryTypeRepository
    {
        Task<IEnumerable<CategoryType>> GetCategoryTypesAsync();
        Task<CategoryType> GetByIdAsync(int? id);
        Task<CategoryType> CreateAsync(CategoryType tipoCategoria);
        Task<CategoryType> UpdateAsync(CategoryType tipoCategoria);
        Task<CategoryType> RemoveAsync(CategoryType tipoCategoria);
    }
}
