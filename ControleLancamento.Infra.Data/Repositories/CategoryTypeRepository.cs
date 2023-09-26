using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using ControleLancamento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleLancamento.Infra.Data.Repositories
{
    public class CategoryTypeRepository : ICategoryTypeRepository
    {
        private ApplicationDbContext _categoryTypeContext;
        public CategoryTypeRepository(ApplicationDbContext context)
        {
            _categoryTypeContext = context;
        }

        public async Task<CategoryType> CreateAsync(CategoryType categoryType)
        {
            _categoryTypeContext.Add(categoryType);
            await _categoryTypeContext.SaveChangesAsync();
            return categoryType;
        }

        public async Task<CategoryType> GetByIdAsync(int? id)
        {
            return await _categoryTypeContext
                    .CategoryTypes
                    .FirstOrDefaultAsync(c => c.Id == id && c.Active);
        }

        public async Task<IEnumerable<CategoryType>> GetCategoryTypesAsync()
        {
            return await _categoryTypeContext
                .CategoryTypes
                .Where(c => c.Active)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CategoryType> RemoveAsync(CategoryType categoryType)
        {
            //_categoryTypeContext.Remove(categoryType);
            categoryType.SetInactive();
            await _categoryTypeContext.SaveChangesAsync();
            return categoryType;
        }

        public async Task<CategoryType> UpdateAsync(CategoryType categoryType)
        {
            _categoryTypeContext.Update(categoryType);
            await _categoryTypeContext.SaveChangesAsync();
            return categoryType;
        }
    }
}
