using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Udemy.User.Domain.Entities.User.Enums;
using Udemy.User.Domain.Entities.User.ValueObjects;

namespace Udemy.User.Infrastructure.Context.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<Domain.Entities.User.User>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.User.User> builder)
    {
        builder.HasKey(e => e.Id); 

        builder.Property(e => e.Name)
               .HasConversion(name => name.Value, value => Name.Create(value).Value)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(e => e.Email)
               .HasConversion(email => email.Value, value => Email.Create(value).Value)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(e => e.PasswordHash)
               .HasConversion(password => password.Hash, value => Password.Create(value).Value)
               .IsRequired();

        builder.Property(e => e.AvatarUrl)
               .HasConversion(url => url.Value, value => Url.Create(value).Value)
               .HasMaxLength(500);

        builder.Property(e => e.Biography)
               .HasMaxLength(1000);

        builder.Property(e => e.Role)
               .HasConversion<int>()
               .HasDefaultValue(Role.Student)
               .IsRequired();

        builder.OwnsMany(e => e.SocialMedias, socialMedia =>
        {
            socialMedia.Property(sm => sm.Media).HasConversion<int>().IsRequired();
            socialMedia.Property(sm => sm.Uri).HasMaxLength(500).IsRequired();
        });

        builder.OwnsMany(e => e.IdentityProviders, identityProvider =>
        {
            identityProvider.Property(ip => ip.Provider).HasConversion<int>().IsRequired();
            identityProvider.Property(ip => ip.ProviderId).HasMaxLength(255).IsRequired();
        });

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.ToTable("Users");
    }
}