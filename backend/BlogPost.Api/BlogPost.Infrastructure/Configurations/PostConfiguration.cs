using BlogPost.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogPost.Infrastructure.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(t => t.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(b => b.Text);

        builder.Property(b => b.PostDate)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_DATE");

        builder.Property(b => b.LastEdit)
            .IsRequired()
            .HasDefaultValueSql("NOW()");

        builder.Property(b => b.ImageUrl)
            .IsRequired();

        builder.Property(b => b.MarkdownFileName)
            .IsRequired();

        builder.HasMany(b => b.Tags)
            .WithMany(t => t.Blogs);
    }
}