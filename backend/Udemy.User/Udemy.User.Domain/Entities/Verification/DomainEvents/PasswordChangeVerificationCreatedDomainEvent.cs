using Udemy.Common.Primitives;

namespace Udemy.User.Domain.Entities.Verification.DomainEvents;

public record PasswordChangeVerificationCreatedDomainEvent(Guid Id, string VerificationId) : DomainEvent(Id);
