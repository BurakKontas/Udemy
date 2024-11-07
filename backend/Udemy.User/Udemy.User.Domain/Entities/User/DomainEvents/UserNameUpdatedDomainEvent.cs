using Udemy.Common.Primitives;

namespace Udemy.User.Domain.Entities.User.DomainEvents;

public record UserNameUpdatedDomainEvent(Guid Id, string NewName) : DomainEvent(Id);
