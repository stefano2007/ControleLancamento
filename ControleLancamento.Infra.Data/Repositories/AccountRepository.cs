using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using ControleLancamento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleLancamento.Infra.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private ApplicationDbContext _accountContext;
        public AccountRepository(ApplicationDbContext context)
        {
            _accountContext = context;
        }

        public async Task<Account> CreateAsync(Account account)
        {
            _accountContext.Add(account);
            await _accountContext.SaveChangesAsync();
            return account;
        }

        public async Task<Account> GetByIdAsync(int? id)
        {
            return await _accountContext
                    .Accounts
                    .Include(c => c.AccountType)
                    .FirstOrDefaultAsync(c => c.Id == id && c.Active);
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await _accountContext
                .Accounts
                .Include(c => c.AccountType)
                .Where(c => c.Active)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Account> RemoveAsync(Account account)
        {
            //_accountContext.Remove(account);
            account.SetInactive();
            await _accountContext.SaveChangesAsync();
            return account;
        }

        public async Task<Account> UpdateAsync(Account account)
        {
            _accountContext.Update(account);
            await _accountContext.SaveChangesAsync();
            return account;
        }
    }

}
