using ControleLancamento.Application.DTOs;

namespace ControleLancamento.Application.Interfaces
{
    public interface ICategoryTypeService
    {
        Task<IEnumerable<CategoryTypeDTO>> GetCategoryTypesAsync();
        Task<CategoryTypeDTO> GetByIdAsync(int? id);
        Task CreateAsync(CategoryTypeDTO categoryDto);
        Task UpdateAsync(CategoryTypeDTO categoryDto);
        Task RemoveAsync(int? id);
    }
}
