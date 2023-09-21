﻿using ControleLancamento.Domain.Entities;

namespace ControleLancamento.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetusersAsync();
        Task<User> GetByIdAsync(int? id);
        Task<User> GetByEmailAsync(string email);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User> RemoveAsync(User user);
    }
}
