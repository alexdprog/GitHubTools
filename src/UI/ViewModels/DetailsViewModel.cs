using GitHubTools.CoreApplication.Models;

namespace GitHubTools.App.ViewModels
{
    public partial class DetailsViewModel : BaseViewModel, IQueryAttributable
    {
        private Repository _repository;

        public Repository Repository
        {
            get => _repository; set => SetProperty(ref _repository, value);
        }

        public DetailsViewModel()
        {
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("Repository", out var queryObject) && (queryObject is Repository repository))
            {
                Repository = repository;
            }
        }
    }
}
