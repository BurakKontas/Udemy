namespace Udemy.Common.Primitives;

public abstract class Entity
{
    private readonly List<DomainEvent> _domainEvents = [];

    public ICollection<DomainEvent> DomainEvents => _domainEvents;

    protected void Arise(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}