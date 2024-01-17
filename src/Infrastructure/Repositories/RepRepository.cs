using GitHubTools.CoreApplication.Interfaces;
using GitHubTools.Domain.Entities;
using GitHubTools.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GitHubTools.Infrastructure.Repositories
{
    public class RepRepository : IRepRepository
    {
        private readonly ToolsBaseContext _context;

        public RepRepository(ToolsBaseContext context)
        {
            _context = context;
        }

        public RepositoryDb Add(RepositoryDb repository)
        {
            var result= _context.Repositories.Add(repository).Entity;
            _context.SaveChanges();
            return result;
        }

        public async Task<IList<RepositoryDb>> GetAll()
        {
            return await _context.Repositories.ToListAsync();
        }

        public async Task<RepositoryDb> FindAsync(int  id)
        {
            var buyer = await _context.Repositories
                .Where(b => b.Id == id)
                .SingleOrDefaultAsync();
            return buyer;
        }

        public void Clear()
        {
        }
    }
}
