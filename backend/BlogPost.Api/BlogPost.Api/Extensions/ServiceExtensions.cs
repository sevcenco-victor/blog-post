namespace BlogPost.Api.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddProblemDetails();
        services.AddExceptionHandler<GlobalExceptionHandler>();

        return services;
    }
}