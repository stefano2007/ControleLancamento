using ControleLancamento.Application.DTOs;

namespace ControleLancamento.Application.Interfaces
{
    public interface ICategoryTypeService
    {
        Task<IEnumerable<CategoryTypeDTO>> GetCategoryTypesAsync();
        Task<CategoryTypeDTO> GetByIdAsync(int? id);
        Task<CategoryTypeDTO> CreateAsync(CategoryTypeCreateDTO categoryDto);
        Task<CategoryTypeDTO> UpdateAsync(CategoryTypeUpdateDTO categoryDto);
        Task RemoveAsync(int? id);
    }
}
