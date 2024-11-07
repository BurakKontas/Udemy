using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.User.Domain.Entities.Verification;
using Udemy.User.Domain.Entities.Verification.ValueObjects;

namespace Udemy.User.Infrastructure.Context.Configurations;

public class PasswordChangeVerificationConfiguration : IEntityTypeConfiguration<PasswordChangeVerification>
{
    public void Configure(EntityTypeBuilder<PasswordChangeVerification> builder)
    {
        builder.HasKey(e => e.VerificationId);

        builder.Property(e => e.VerificationId)
            .HasConversion(id => id.Id, value => VerificationId.Create(value).Value)
            .IsRequired();

        builder.Property(e => e.PasswordChangeCode)
            .HasConversion(pcc => pcc.Code, value => PasswordChangeVerificationCode.Create(value).Value)
            .IsRequired();

        builder.HasIndex(e => e.Email);

        builder.HasQueryFilter(verification => !verification.IsVerified);
    }
}