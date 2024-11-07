using Udemy.Common.Primitives;

namespace Udemy.User.Domain.Entities.User.DomainEvents;

public record UserPasswordChangedDomainEvent(Guid Id) : DomainEvent(Id);
