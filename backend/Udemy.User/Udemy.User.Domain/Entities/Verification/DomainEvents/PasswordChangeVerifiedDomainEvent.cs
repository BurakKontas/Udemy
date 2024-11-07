using Udemy.Common.Primitives;

namespace Udemy.User.Domain.Entities.Verification.DomainEvents;

public record PasswordChangeVerifiedDomainEvent(Guid Id, string VerificationId) : DomainEvent(Id);
