using BlogPost.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogPost.Infrastructure.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.Username).IsUnique();

        builder.Property(x => x.PasswordHash);
        builder.Property(x => x.BirthDate);

        builder.Property(x => x.Role)
            .HasConversion<int>()
            .IsRequired()
            .HasDefaultValue(UserRoles.User);
    }
}