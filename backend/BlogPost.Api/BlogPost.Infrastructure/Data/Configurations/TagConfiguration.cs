using BlogPost.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogPost.Infrastructure.Data.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.Property(t => t.Id)
            .UseIdentityColumn();
        
        builder.Property(t => t.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
}