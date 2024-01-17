using Microsoft.Extensions.DependencyInjection;
using GitHubTools.Infrastructure.Interfaces;
using GitHubTools.Infrastructure.Connectivity;
using GitHubTools.Infrastructure.Repositories;
using GitHubTools.Infrastructure.Contexts;
using GitHubTools.CoreApplication.Interfaces;

namespace GitHubTools.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IDataProvider, DataProvider>()
                .AddSingleton<IServerAccess, ServerAccess>()
                .AddSingleton<IUrlBuilder, UrlBuilder>();
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddTransient<IRepRepository, RepRepository>()
                .AddTransient<IOwnerRepository, OwnerRepository>()
                .AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddStorage(this IServiceCollection services)
        {
            return services
                .AddSingleton<ToolsBaseContext>();
        }
    }
}