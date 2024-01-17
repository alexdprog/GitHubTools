namespace GitHubTools.CoreApplication.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepRepository RepRepository { get; }

        IOwnerRepository OwnerRepository { get; }

        Task Commit();

        Task Rollback();

        Task Clear();
    }
}