using System;
using Orleans.Concurrency;

namespace Ogun.GrainInterfaces.FourEyeModels.Events
{

    [Serializable, Immutable]
    public class NewFourEyeConfigurationEvent<T> : DomainEvent<IDomainEventEntity> where T : NewFourEyeConfiguration
    {
        public NewFourEyeConfigurationEvent(Guid id, string name, DateTime whenUtc, IDomainEventEntity @event) : base(id, name, whenUtc, @event)
        {
        }
    }

    [Serializable, Immutable]
    public class NewFourEyeConfiguration : IDomainEventEntity
    {
        public NewFourEyeConfiguration(Guid id, string name)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; }
        public Guid Id { get; }
    }
}