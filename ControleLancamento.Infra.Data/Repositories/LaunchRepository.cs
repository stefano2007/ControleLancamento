using ControleLancamento.Domain.Entities;
using ControleLancamento.Domain.Interfaces;
using ControleLancamento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleLancamento.Infra.Data.Repositories
{
    public class LaunchRepository : ILaunchRepository
    {
        private ApplicationDbContext _launchContext;
        public LaunchRepository(ApplicationDbContext context)
        {
            _launchContext = context;
        }

        public async Task<Launch> CreateAsync(Launch launch)
        {
            _launchContext.Add(launch);
            await _launchContext.SaveChangesAsync();
            return launch;
        }

        public async Task<Launch> GetByIdAsync(int? id)
        {
            return await _launchContext
                    .Launchs
                    .Include(c => c.Category)
                        .ThenInclude(t => t.CategoryType)
                    .Include(c => c.Account)
                    .FirstOrDefaultAsync(c => c.Id == id && c.Active);
        }

        public async Task<IEnumerable<Launch>> GetLaunchsByAccountIdAsync(int accountId)
        {
            return await _launchContext
                    .Launchs
                    .Include(c => c.Category)
                        .ThenInclude(t => t.CategoryType)
                    .Include(c => c.Account)
                    .Where(c => c.Active && c.AccountId == accountId)
                    .AsNoTracking()
                    .ToListAsync();
        }        

        public async Task<Launch> RemoveAsync(Launch launch)
        {
            //_launchContext.Remove(launch);
            launch.SetInactive();
            await _launchContext.SaveChangesAsync();
            return launch;
        }

        public async Task<Launch> UpdateAsync(Launch launch)
        {
            _launchContext.Update(launch);
            await _launchContext.SaveChangesAsync();
            return launch;
        }
    }
}
