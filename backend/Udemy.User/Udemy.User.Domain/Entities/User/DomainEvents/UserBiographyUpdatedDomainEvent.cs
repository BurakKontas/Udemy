using Udemy.Common.Primitives;

namespace Udemy.User.Domain.Entities.User.DomainEvents;

public record UserBiographyUpdatedDomainEvent(Guid Id, string NewBiography) : DomainEvent(Id);
