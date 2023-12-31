﻿using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using ControleLancamento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleLancamento.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _categoryContext;
        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            _categoryContext.Add(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            return await _categoryContext
                    .Categories
                    .Include(c => c.CategoryType)
                    .FirstOrDefaultAsync(c => c.Id == id && c.Active);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryContext
                .Categories
                .Include(c => c.CategoryType)
                .Where(c => c.Active)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category> RemoveAsync(Category category)
        {
            //_categoryContext.Remove(category);
            category.SetInactive();
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
    }
}
