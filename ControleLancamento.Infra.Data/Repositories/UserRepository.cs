using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using ControleLancamento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleLancamento.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _userContext;
        public UserRepository(ApplicationDbContext context)
        {
            _userContext = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            _userContext.Add(user);
            await _userContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userContext
                    .Users
                    .FirstOrDefaultAsync(c => c.Email == email && c.Active);
        }

        public async Task<User> GetByIdAsync(int? id)
        {
            return await _userContext
                    .Users
                    .FirstOrDefaultAsync(c => c.Id == id && c.Active);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userContext
                .Users
                .Where(c => c.Active)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User> RemoveAsync(User user)
        {
            //_userContext.Remove(user);
            user.SetInactive();
            await _userContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _userContext.Update(user);
            await _userContext.SaveChangesAsync();
            return user;
        }
    }
}
