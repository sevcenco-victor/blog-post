using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Entities;
using BlogPost.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogPost.Infrastructure.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id)
            .UseIdentityColumn();

        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.Username).IsUnique();

        builder.Property(x => x.PasswordHash);
        builder.Property(x => x.BirthDate);

        builder.Property(x => x.Role)
            .HasConversion<string>()
            .IsRequired()
            .HasDefaultValue(UserRoles.USER.ToString());
    }
}