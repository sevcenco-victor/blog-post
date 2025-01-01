using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlogPost.Domain.Entities;

namespace BlogPost.Infrastructure.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.Property(t => t.Id)
            .UseIdentityColumn();

        builder.Property(t => t.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(t => t.Name)
            .IsUnique();

        builder.Property(t => t.Color)
            .IsRequired();
    }
}