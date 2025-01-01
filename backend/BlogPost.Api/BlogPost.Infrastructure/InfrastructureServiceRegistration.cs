using BlogPost.Domain.Abstractions;
using BlogPost.Infrastructure.Data;
using BlogPost.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogPost.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<BlogDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("BlogDbConnection")));

        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        
        return services;
    }
}