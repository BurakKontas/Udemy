using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Udemy.User.Infrastructure.Context.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<Domain.Entities.User.User>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.User.User> builder)
    {
        builder.HasKey(e => e.Id);
        //builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        // Diğer konfigürasyonlar...
    }
}