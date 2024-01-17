using GitHubTools.Domain.Entities;

namespace GitHubTools.CoreApplication.Interfaces
{
    public interface IOwnerRepository
    {
        Task<OwnerDb> Add(OwnerDb repository);

        Task<IList<OwnerDb>> GetAll();
    }
}
