using BlogPost.Domain.Entities;
using BlogPost.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BlogPost.Infrastructure.Data;

public class BlogDbContext(DbContextOptions<BlogDbContext> options)
    : DbContext(options)
{
    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<Tag> Tags => Set<Tag>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new BlogConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
    }
}