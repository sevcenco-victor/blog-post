using BlogPost.Domain.Abstractions;
using BlogPost.Infrastructure.Data;
using BlogPost.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BlogDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("BlogDbConnection")));

        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ITagRepository, TagRepository>();

        return services;
    }
}