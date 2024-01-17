using GitHubTools.Infrastructure.Contexts;
using GitHubTools.CoreApplication.Interfaces;

namespace GitHubTools.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepRepository _repRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly ToolsBaseContext _dbContext;
        private bool disposed;

        public UnitOfWork(ToolsBaseContext dbContext, IRepRepository repRepository, IOwnerRepository ownerRepository)
        {
            _dbContext = dbContext;
            _repRepository = repRepository;
            _ownerRepository = ownerRepository;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Task Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            return Task.CompletedTask;
        }

        public Task Clear()
        {
            _dbContext.Repositories.RemoveRange(_dbContext.Repositories);
            _dbContext.Owners.RemoveRange(_dbContext.Owners);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepRepository RepRepository { get { return _repRepository; } }

        public IOwnerRepository OwnerRepository { get { return _ownerRepository; } }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    _dbContext.Dispose();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }


    }
}