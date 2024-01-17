using GitHubTools.CoreApplication.Interfaces;
using GitHubTools.Domain.Entities;
using GitHubTools.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GitHubTools.Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ToolsBaseContext _context;

        public OwnerRepository(ToolsBaseContext context)
        {
            _context = context;
        }

        public async Task<OwnerDb> Add(OwnerDb owner)
        {
            return (await _context.Owners.AddAsync(owner)).Entity;
        }

        public async Task<IList<OwnerDb>> GetAll()
        {
            return await _context.Owners.ToListAsync();
        }
    }
}
