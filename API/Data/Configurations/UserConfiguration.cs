using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.FirstName).IsRequired().HasMaxLength(20);

        builder.Property(user => user.LastName).IsRequired().HasMaxLength(20);

        builder.Property(user => user.Email).IsRequired().HasMaxLength(20);

        builder.Property(user => user.Password).IsRequired().HasMaxLength(20);
    }
}
