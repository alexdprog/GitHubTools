using GitHubTools.CoreApplication.Interfaces;
using GitHubTools.CoreApplication.Models;

using Moq;

namespace App.UnitTests.Mocks;
internal class MockIOwnerRepository
{
    public static Mock<IOwnerRepository> GetMock()
    {
        var mock = new Mock<IOwnerRepository>();
        var owners = new List<Owner>()
        {
            new Owner()
            {
                
                Id = 1,
                Login="alexdprog",
            }
        };
        mock.Setup(m => m.GetAll()).Returns(() => owners);
        return mock;
    }
}