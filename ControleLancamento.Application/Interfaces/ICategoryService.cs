using ControleLancamento.Application.DTOs;

namespace ControleLancamento.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<CategoryDTO> GetByIdAsync(int? id);
        Task<CategoryDTO> CreateAsync(CategoryCreateDTO categoryDto);
        Task<CategoryDTO> UpdateAsync(CategoryUpdateDTO categoryDto);
        Task RemoveAsync(int? id);
    }
}
