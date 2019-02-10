using System;
using Orleans.Concurrency;

namespace Ogun.GrainInterfaces.FourEyeModels.Events
{
    [Serializable, Immutable]
    public class DomainEvent<T>
    {
        public DomainEvent(Guid id, string name, DateTime whenUtc, T @event)
        {
            Id = id;
            Event = @event;
            WhenUtc = whenUtc;
            EventName = name;
        }

        public string EventName { get; set; }
        public Guid Id { get; set; }
        public DateTime WhenUtc { get; set; }
        public T Event { get; set; }
    }
}