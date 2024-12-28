using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BlogPost.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config
            => config.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly));

        services.AddValidatorsFromAssembly(typeof(ApplicationAssemblyReference).Assembly);
        return services;
    }
}

public static class ApplicationAssemblyReference
{
}