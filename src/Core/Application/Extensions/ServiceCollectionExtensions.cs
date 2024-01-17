using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;



namespace GitHubTools.CoreApplication.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureMappings(this IServiceCollection services)
        {
            return services.AddAutoMapper(cfg => {
                cfg.ShouldMapMethod = (m => false);
            },  Assembly.GetExecutingAssembly());
        }
    }
}