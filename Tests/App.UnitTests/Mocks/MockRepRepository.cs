using GitHubTools.CoreApplication.Interfaces;
using GitHubTools.Domain.Entities;
using Moq;

namespace App.UnitTests.Mocks;

internal class MockIRepRepository
{
    public static Mock<IRepRepository> GetMock()
    {
        var mock = new Mock<IRepRepository>();
        IList<RepositoryDb> repositories = new List<RepositoryDb>()
        {
            new  RepositoryDb()
            {
                Id = 1,
                Name="Repository 1",
            },
            new  RepositoryDb()
            {
                Id = 1,
                Name="Repository 2",
            }
        };
        mock.Setup(m =>m.GetAll().Result).Returns(() => repositories);
        return mock;
    }
}