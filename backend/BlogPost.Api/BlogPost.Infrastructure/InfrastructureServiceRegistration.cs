using BlogPost.Application.Abstractions;
using BlogPost.Domain.Abstractions;
using BlogPost.Infrastructure.ConfigOptions;
using BlogPost.Infrastructure.Data;
using BlogPost.Infrastructure.Repositories;
using BlogPost.Infrastructure.Services;
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
        services.AddScoped<IUserRepository, UserRepository>();

        services.Configure<GCSConfigOptions>(configuration);
        services.AddSingleton<ICloudStorageService, CloudStorageService>();
        services.AddSingleton<IFileFactory, FileFactory>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        services.AddSingleton<IJwtTokenService, JwtTokenService>();

        return services;
    }
}