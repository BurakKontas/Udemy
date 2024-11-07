using Udemy.Common.Primitives;

namespace Udemy.User.Domain.Entities.User.DomainEvents;

public record UserEmailUpdatedDomainEvent(Guid Id, string NewEmail) : DomainEvent(Id);
