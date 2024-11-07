using Udemy.Common.Primitives;

namespace Udemy.User.Domain.Entities.User.DomainEvents;

public record IdentityProviderAddedDomainEvent(Guid Id, string ProviderType) : DomainEvent(Id);
