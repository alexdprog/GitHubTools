using CommunityToolkit.Maui.Views;
using GitHubTools.App.ViewModels;

namespace GitHubTools.App.Views
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsViewModel ViewModel => (DetailsViewModel)BindingContext;

        public DetailsPage(DetailsViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            Task.Run(async () => await ViewModel.OnNavigatedTo());
        }
    }
}
