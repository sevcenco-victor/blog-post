using BlogPost.Domain.Entities;
using BlogPost.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using PostEntity = BlogPost.Domain.Entities.Post;

namespace BlogPost.Infrastructure.Data;

public class BlogDbContext(DbContextOptions<BlogDbContext> options)
    : DbContext(options)
{
    public DbSet<PostEntity> Posts => Set<PostEntity>();
    public DbSet<Tag> Tags => Set<Tag>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PostConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
    }
}