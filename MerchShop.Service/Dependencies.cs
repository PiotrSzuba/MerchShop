using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MerchShop.Service.Infrastructure.Mediator;
using MerchShop.Service.Services;
using Microsoft.Extensions.Configuration;

namespace MerchShop.Service;

public static class Dependencies
{
    public static void AddServicesDependency(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(WorkBehavior<,>));

        services.AddScopedServices();
    }

    private static IServiceCollection AddScopedServices(this IServiceCollection services)
    {
        services.AddScoped<IThumbnailGenerator, ThumbnailGenerator>();

        return services;
    }

    public static IServiceCollection AddSingletonServices(this IServiceCollection services, IConfiguration configuration, string root)
    {
        services.AddSingleton<IDomainProvider, DomainProvider>(x => new DomainProvider(configuration));
        services.AddSingleton<IPathProvider, PathProvider>(x => new PathProvider(root, configuration));

        return services;
    }
}