using Udemy.Common.Primitives;

namespace Udemy.User.Domain.Entities.User.DomainEvents;

public record SocialMediaAddedDomainEvent(Guid Id, string MediaType) : DomainEvent(Id);
