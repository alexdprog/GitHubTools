using CommunityToolkit.Maui;
using GitHubTools.Infrastructure.Extensions;
using GitHubTools.App.ViewModels;
using GitHubTools.App.Views;
using GitHubTools.CoreApplication.Extensions;
using Microsoft.Extensions.Logging;

namespace GitHubTools.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiCommunityToolkit()
                .UseMauiApp<App>()

                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            
            builder.Services
                .RegisterViewsAndViewModels()
                .AddServices()
                .AddRepositories()
                .AddStorage()
                .AddInfrastructureMappings();
            return builder.Build();
        }

        static IServiceCollection RegisterViewsAndViewModels(this IServiceCollection services)
        {
            return services
                .AddSingleton<MainPageViewModel>()
                .AddSingleton<MainPage>()
                .AddSingleton<DetailsViewModel>()
                .AddSingleton<DetailsPage>()
                .AddSingleton<LoadViewModel>()
                .AddSingleton<LoadPage>();
        }

    }
}