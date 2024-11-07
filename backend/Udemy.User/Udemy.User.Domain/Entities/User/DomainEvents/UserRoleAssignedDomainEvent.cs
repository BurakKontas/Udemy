using Udemy.Common.Primitives;
using Udemy.User.Domain.Entities.User.Enums;

namespace Udemy.User.Domain.Entities.User.DomainEvents;

public record UserRoleAssignedDomainEvent(Guid Id, Role NewRole) : DomainEvent(Id);
