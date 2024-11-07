using Udemy.Common.Primitives;

namespace Udemy.User.Domain.Entities.User.DomainEvents;

public record UserAvatarUpdatedDomainEvent(Guid Id, string? NewAvatarUrl) : DomainEvent(Id);
