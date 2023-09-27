using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using ControleLancamento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleLancamento.Infra.Data.Repositories
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private ApplicationDbContext _accountTypeContext;
        public AccountTypeRepository(ApplicationDbContext context)
        {
            _accountTypeContext = context;
        }

        public async Task<AccountType> CreateAsync(AccountType accountType)
        {
            _accountTypeContext.Add(accountType);
            await _accountTypeContext.SaveChangesAsync();
            return accountType;
        }

        public async Task<AccountType> GetByIdAsync(int? id)
        {
            return await _accountTypeContext
                    .AccountTypes
                    .FirstOrDefaultAsync(c => c.Id == id && c.Active);
        }

        public async Task<IEnumerable<AccountType>> GetAccountTypesAsync()
        {
            return await _accountTypeContext
                .AccountTypes
                .Where(c => c.Active)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<AccountType> RemoveAsync(AccountType accountType)
        {
            //_accountTypeContext.Remove(accountType);
            accountType.SetInactive();
            await _accountTypeContext.SaveChangesAsync();
            return accountType;
        }

        public async Task<AccountType> UpdateAsync(AccountType accountType)
        {
            _accountTypeContext.Update(accountType);
            await _accountTypeContext.SaveChangesAsync();
            return accountType;
        }
    }
}
