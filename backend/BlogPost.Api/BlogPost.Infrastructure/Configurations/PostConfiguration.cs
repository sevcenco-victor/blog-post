using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogPost.Infrastructure.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Domain.Entities.Post>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Post> builder)
    {
        builder.Property(b => b.Id)
            .UseIdentityColumn();

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

        builder.HasMany(b => b.Tags)
            .WithMany(t => t.Blogs);
    }
}