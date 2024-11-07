using Udemy.Common.Primitives;

namespace Udemy.User.Domain.Entities.User.DomainEvents;

public record UserCreatedDomainEvent(Guid Id) : DomainEvent(Id);
