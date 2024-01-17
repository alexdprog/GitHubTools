
using GitHubTools.App.ViewModels;

namespace GitHubTools.App.Views
{
    public partial class MainPage
    {
        public MainPageViewModel ViewModel => (MainPageViewModel)BindingContext;

        public MainPage(MainPageViewModel viewModel)
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
