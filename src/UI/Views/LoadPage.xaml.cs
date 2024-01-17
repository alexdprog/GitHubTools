using GitHubTools.App.ViewModels;

namespace GitHubTools.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadPage
    {
        public LoadPage(LoadViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}
