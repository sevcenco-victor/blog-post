using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BlogPost.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(config
            => config.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));

        services.AddValidatorsFromAssembly(typeof(ApplicationServiceRegistration).Assembly);
        return services;
    }
}