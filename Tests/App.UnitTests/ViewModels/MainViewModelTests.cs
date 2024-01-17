using App.UnitTests.Mocks;
using AutoMapper;
using FluentAssertions;
using GitHubTools.App.ViewModels;
using GitHubTools.CoreApplication.Mappings;

namespace App.UnitTests.ViewModels;

public class MainViewModelTests
{
    private MainPageViewModel _viewModel;

    [SetUp]
    public void Setup()
    {
        var repositoryGitRepMock = MockIRepRepository.GetMock();
        var fakeUnitofWork = new FakeUnitOfWork();
        var mapper = GetMapper();

        _viewModel = new MainPageViewModel(mapper, fakeUnitofWork);
    }

    public IMapper GetMapper()
    {
        var mappingProfile = new RepositoryProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
        return new Mapper(configuration);
    }

    [Test]
    public async Task MainViewLoadRepository_Valid()
    {
        await _viewModel.OnNavigatedTo();
        Assert.AreEqual(_viewModel.RepositoryList.Count, 2);
    }

}
