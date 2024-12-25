using BlogPost.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogPost.Infrastructure.Data.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.Property(b => b.Id)
            .UseIdentityColumn();

        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(b => b.Text);

        builder.Property(b => b.PostDate)
            .IsRequired();
        
        builder.Property(b => b.ImageUrl)
            .IsRequired();
        
        builder.HasMany(b => b.Tags)
            .WithMany(t => t.Blogs);
    }
}