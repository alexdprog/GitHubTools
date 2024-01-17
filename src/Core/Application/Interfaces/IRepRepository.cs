using GitHubTools.Domain.Entities;

namespace GitHubTools.CoreApplication.Interfaces
{
    public interface IRepRepository
    {
        RepositoryDb Add(RepositoryDb repository);

        Task<IList<RepositoryDb>> GetAll();

        void Clear();
    }
}
