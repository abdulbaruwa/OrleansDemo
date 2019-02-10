using System;
using Orleans.Concurrency;

namespace Ogun.GrainInterfaces.FourEyeModels.Events
{
    public class UserAddedToInstitutionEvent<T> : DomainEvent<IDomainEventEntity> where T : UserAddedToInstitution
    {
        public UserAddedToInstitutionEvent(Guid id, string name, DateTime whenUtc, IDomainEventEntity @event) : base(id, name, whenUtc, @event)
        {
        }
    }
    public class UserRemovedFromInstitutionEvent<T> : DomainEvent<IDomainEventEntity> where T : UserRemovedFromInstitution
    {
        public UserRemovedFromInstitutionEvent(Guid id, string name, DateTime whenUtc, IDomainEventEntity @event) : base(id, name, whenUtc, @event)
        {
        }
    }

    [Serializable, Immutable]
    public class UserAddedToInstitution  : IDomainEventEntity
    {
        public UserAddedToInstitution(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
    }
    [Serializable, Immutable]
    public class UserRemovedFromInstitution  : IDomainEventEntity
    {
        public UserRemovedFromInstitution(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
    }
}