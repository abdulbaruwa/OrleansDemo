using System;
using Ogun.GrainInterfaces.FourEyeModels.Events;
using Orleans.Concurrency;

namespace Ogun.GrainInterfaces.FourEyeModels
{
    [Serializable, Immutable]
    public class NewInstitutionEvent<T> : DomainEvent<IDomainEventEntity> where T : NewInstitution
    {

        public NewInstitutionEvent(Guid id, string name, DateTime whenUtc, IDomainEventEntity @event) : base(id, name, whenUtc, @event)
        {
        }
    }

    [Serializable, Immutable]
    public class NewInstitution : IDomainEventEntity
    {
        public NewInstitution(string name, Guid institutionId)
        {
            Name = name;
            InstitutionId = institutionId;
        }

        public string Name { get; }
        public Guid InstitutionId { get; }
    }
}