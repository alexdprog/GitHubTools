using System.Windows.Input;
using AutoMapper;
using GitHubTools.App.Views;
using GitHubTools.CoreApplication.Models;
using GitHubTools.CoreApplication.Interfaces;

namespace GitHubTools.App.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly IMapper _mapper;
        private readonly IRepRepository _repReposotiry;
        private readonly IUnitOfWork _unitOfWork;
        private IList<Repository> _repositoryList;

        public IList<Repository> RepositoryList
        {
            get => _repositoryList; set => SetProperty(ref _repositoryList, value);
        }

        /// <summary>
        /// Показать детали
        /// </summary>
        public ICommand ShowDetailsCommand { private set; get; }

        public MainPageViewModel(
            IMapper mapper,
            IUnitOfWork unitOfWork)
            : base()
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repReposotiry = _unitOfWork.RepRepository;
            ShowDetailsCommand = new Command<Repository>(ShowDetails);
        }

        public override async Task Reload()
        {
            var dbList = await _repReposotiry.GetAll();
            RepositoryList = dbList
                .Select(repositoryDb => _mapper.Map<Repository>(repositoryDb))
                .ToList();
        }

        async void ShowDetails(Repository repository)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Repository", repository }
            };

            await Shell.Current.GoToAsync(nameof(DetailsPage), navigationParameter);
        }
    }
}
