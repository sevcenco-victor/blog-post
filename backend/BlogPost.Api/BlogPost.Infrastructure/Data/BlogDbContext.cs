using BlogPost.Domain.Entities;
using BlogPost.Domain.Tags;
using BlogPost.Domain.Users;
using BlogPost.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.Infrastructure.Data;

public sealed class BlogDbContext(DbContextOptions<BlogDbContext> options)
    : DbContext(options)
{
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PostConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
    }
}