using Udemy.Common.Primitives;

namespace Udemy.User.Domain.Entities.Verification.DomainEvents;

public record EmailVerificationCreatedDomainEvent(Guid Id, string VerificationId) : DomainEvent(Id);