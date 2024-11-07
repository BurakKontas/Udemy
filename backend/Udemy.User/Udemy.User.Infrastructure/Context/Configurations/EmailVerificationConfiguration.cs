using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Udemy.User.Domain.Entities.Verification;
using Udemy.User.Domain.Entities.Verification.ValueObjects;

namespace Udemy.User.Infrastructure.Context.Configurations;

public class EmailVerificationConfiguration : IEntityTypeConfiguration<EmailVerification>
{
    public void Configure(EntityTypeBuilder<EmailVerification> builder)
    {
        builder.HasKey(e => e.VerificationId);

        builder.Property(e => e.VerificationId)
            .HasConversion(id => id.Id, value => VerificationId.Create(value).Value)
            .IsRequired();

        builder.Property(e => e.EmailOneTimeCode)
            .HasConversion(otc => otc.Code, value => EmailOneTimeCode.Create(value).Value)
            .IsRequired();

        builder.Property(e => e.EmailVerificationCode)
            .HasConversion(vc => vc.Code, value => EmailVerificationCode.Create(value).Value)
            .IsRequired();

        builder.HasIndex(e => e.Email);

        builder.HasQueryFilter(verification => !verification.IsVerified);
    }
}