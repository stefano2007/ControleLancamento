using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using ControleLancamento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleLancamento.Infra.Data.Repositories
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private ApplicationDbContext _userAccountContext;
        public UserAccountRepository(ApplicationDbContext context)
        {
            _userAccountContext = context;
        }

        public async Task<UserAccount> CreateAsync(UserAccount userAccount)
        {
            _userAccountContext.Add(userAccount);
            await _userAccountContext.SaveChangesAsync();
            return userAccount;
        }

        public async Task<UserAccount> GetByIdAndUserIdAsync(int id, int userId)
        {
            return await _userAccountContext
                    .UserAccounts
                    .Include(c => c.User)
                    .Include(c => c.Account)
                    .FirstOrDefaultAsync(c => c.Id == id && c.UserId == userId && c.Active);
        }

        public async Task<IEnumerable<UserAccount>> GetUserAccountsAsync(int userId)
        {
            return await _userAccountContext
                    .UserAccounts
                    .Where(c => c.UserId == userId && c.Active)
                    .Include(c => c.User)
                    .Include(c => c.Account)
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<UserAccount> RemoveAsync(UserAccount userAccount)
        {
            //_userAccountContext.Remove(account);
            userAccount.SetInactive();
            await _userAccountContext.SaveChangesAsync();
            return userAccount;
        }

        public async Task<UserAccount> UpdateAsync(UserAccount userAccount)
        {
            _userAccountContext.Update(userAccount);
            await _userAccountContext.SaveChangesAsync();
            return userAccount;
        }
    }
}
